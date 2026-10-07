---
title: Inter-process communication with gRPC and Named pipes
ai-usage: ai-assisted
author: jamesnk
description: Learn how to use gRPC for inter-process communication with Named pipes.
monikerRange: '>= aspnetcore-8.0'
ms.author: wpickett
ms.date: 09/24/2026
uid: grpc/interprocess-namedpipes
---
# Inter-process communication with gRPC and Named pipes

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

By [James Newton-King](https://twitter.com/jamesnk)

.NET supports inter-process communication (IPC) using gRPC. For more information about getting started with using gRPC to communicate between processes, see [Inter-process communication with gRPC](xref:grpc/interprocess).

[Named pipes](https://wikipedia.org/wiki/Named_pipe) is an IPC transport that is supported on all versions of Windows. Named pipes integrate well with [Windows security](/windows/win32/ipc/named-pipe-security-and-access-rights) to control client access to the pipe. This article discusses how to configure gRPC communication over named pipes.

## Prerequisites

* .NET 8 or later
* Windows

## Server configuration

Named pipes are supported by [Kestrel](xref:fundamentals/servers/kestrel), which is configured in `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenNamedPipe("MyPipeName", listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});
```

The preceding example:

* Configures Kestrel's endpoints in <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.ConfigureKestrel%2A>.
* Calls `ListenNamedPipe` to listen to a named pipe with the specified name.
* Creates a named pipe endpoint that isn't configured to use HTTPS. For information about enabling HTTPS, see [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints#listenoptionsusehttps).

### Configuring `PipeSecurity` for named pipes

To control which users or groups can connect, use the <xref:Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes.NamedPipeTransportOptions> class. This allows a custom [`PipeSecurity`](xref:System.IO.Pipes.PipeSecurity) object to be specified.

Example:

```csharp
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Configure PipeSecurity
builder.WebHost.UseNamedPipes(options =>
{
    using var serverIdentity = WindowsIdentity.GetCurrent();
    var pipeSecurity = new PipeSecurity();

    // Grant the account the server runs as the rights to create each instance
    // of the pipe that Kestrel listens on.
    pipeSecurity.AddAccessRule(new PipeAccessRule(
        serverIdentity.User!,
        PipeAccessRights.ReadWrite | PipeAccessRights.CreateNewInstance,
        AccessControlType.Allow));

    // Grant client accounts read/write access only. Replace {CLIENT GROUP}
    // with a security group containing only the accounts allowed to call
    // the service.
    pipeSecurity.AddAccessRule(new PipeAccessRule(
        "{CLIENT GROUP}",
        PipeAccessRights.ReadWrite,
        AccessControlType.Allow));
    // Add additional rules as needed

    options.PipeSecurity = pipeSecurity;
    options.CurrentUserOnly = false;
});
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenNamedPipe("MyPipeName", listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});
```

The preceding example:

* Calls `UseNamedPipes` on the <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> to access and configure <xref:Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes.NamedPipeTransportOptions>.
* Sets <xref:Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes.NamedPipeTransportOptions.CurrentUserOnly> to `false`, which is required when providing a custom <xref:System.IO.Pipes.PipeSecurity> object.
* Sets the <xref:System.IO.Pipes.PipeSecurity> property to control which users or groups can connect to the named pipe.
* Grants the account the server runs as read/write and `CreateNewInstance` access. Kestrel creates several instances of the pipe to accept connections in parallel, and Windows requires `CreateNewInstance` to create each instance after the first.
* Grants the client security group read/write access only, where the `{CLIENT GROUP}` placeholder is a group containing the accounts allowed to call the service. Additional security rules can be added as needed for the scenario.

> [!IMPORTANT]
> Unless the app also configures authentication and authorization, the pipe's security descriptor is the only thing that prevents other accounts from calling the server. Grant access to the narrowest principal the scenario requires. Avoid broad groups such as `Users`, which resolves to `BUILTIN\Users` and includes every authenticated and interactive account on the machine, plus `Domain Users` on a domain-joined machine. For information about authenticating callers, see <xref:grpc/authn-and-authz>.

> [!WARNING]
> Don't grant `PipeAccessRights.CreateNewInstance` to client accounts or to groups that contain untrusted users. `CreateNewInstance` corresponds to the Windows `FILE_CREATE_PIPE_INSTANCE` right, which authorizes a grantee to create *additional server instances* under the same pipe name. Windows distributes incoming client connections across all instances of a pipe, so a process holding that right can accept genuine client connections and impersonate the service. Grant `CreateNewInstance` only to the account the server runs as.

Inspecting the connected pipe's owner SID from the client doesn't detect an impostor created this way. Every instance of a named pipe shares the security descriptor supplied when the first instance was created, so an instance added by another process reports the same owner as the genuine server. To let clients verify which server they're talking to, authenticate the channel itself. For example, enable HTTPS on the endpoint and validate the server certificate, or require a secret that only the genuine server can present. For more information, see [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints#listenoptionsusehttps).

> [!IMPORTANT]
> `CurrentUserOnly` defaults to `true`, which restricts the pipe to the account the server runs as. Setting a custom `PipeSecurity` requires `CurrentUserOnly` to be `false`, otherwise an `ArgumentException` is thrown. Setting it to `false` replaces that built-in restriction, so the supplied `PipeSecurity` becomes the only access control on the pipe.

> [!NOTE]
> Account names are resolved to security identifiers (SIDs) when the access rule is added. Resolution is locale-dependent and can fail on a localized installation of Windows or on a domain-joined machine that can't reach a domain controller. Constructing a <xref:System.Security.Principal.SecurityIdentifier> directly from the group's SID avoids both problems.

### Customize Kestrel named pipe endpoints

Kestrel's named pipe support enables advanced customization, allowing you to configure different security settings for each endpoint using the `CreateNamedPipeServerStream` option. This approach is ideal for scenarios where multiple named pipe endpoints require unique access controls. The ability to customize pipes per endpoint is available starting with .NET 9.

An example of where this is useful is a Kestrel app that requires two pipe endpoints with different access security. The `CreateNamedPipeServerStream` option can be used to create pipes with custom security settings, depending on the pipe name.

```csharp
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenNamedPipe("pipe1");
    options.ListenNamedPipe("pipe2");
});

builder.WebHost.UseNamedPipes(options =>
{
    options.CurrentUserOnly = false;
    options.CreateNamedPipeServerStream = (context) =>
    {
        var pipeSecurity = CreatePipeSecurity(context.NamedPipeEndPoint.PipeName);

        return NamedPipeServerStreamAcl.Create(context.NamedPipeEndPoint.PipeName, PipeDirection.InOut,
            NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte,
            context.PipeOptions, inBufferSize: 0, outBufferSize: 0, pipeSecurity);
    };
});

static PipeSecurity CreatePipeSecurity(string pipeName)
{
    using var serverIdentity = WindowsIdentity.GetCurrent();
    var pipeSecurity = new PipeSecurity();

    // The server account creates every instance of both pipes.
    pipeSecurity.AddAccessRule(new PipeAccessRule(
        serverIdentity.User!,
        PipeAccessRights.ReadWrite | PipeAccessRights.CreateNewInstance,
        AccessControlType.Allow));

    // pipe1 and pipe2 allow different client groups to connect. Replace the
    // placeholders with groups containing the accounts allowed to connect.
    var clientGroup = pipeName == "pipe1"
        ? "{PIPE1 CLIENT GROUP}"
        : "{PIPE2 CLIENT GROUP}";

    pipeSecurity.AddAccessRule(new PipeAccessRule(
        clientGroup,
        PipeAccessRights.ReadWrite,
        AccessControlType.Allow));

    return pipeSecurity;
}
```

The preceding example applies the same principle per endpoint: only the server's own account is granted `CreateNewInstance`, and each pipe grants read/write access to a different set of callers. `CurrentUserOnly` is set to `false` because `context.PipeOptions` is passed to <xref:System.IO.Pipes.NamedPipeServerStreamAcl.Create%2A> along with a `PipeSecurity` object.

> [!WARNING]
> A pipe's security descriptor controls which accounts can *connect* to that pipe. It doesn't control which services a connected caller can invoke. Every endpoint mapped in the app is served on every named pipe endpoint, so a caller that connects to any pipe can call every mapped service. Don't rely on per-pipe access control to restrict access to individual services. Use authentication and authorization instead, or host the restricted services in a separate process with its own pipe. For more information, see <xref:grpc/authn-and-authz>.

## Client configuration

`GrpcChannel` supports making gRPC calls over custom transports. When a channel is created, it can be configured with a <xref:System.Net.Http.SocketsHttpHandler> that has a custom <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. The callback allows the client to make connections over custom transports and then send HTTP requests over that transport.

> [!NOTE]
> Some connectivity features of `GrpcChannel`, such as client side load balancing and channel status, can't be used together with named pipes.

Named pipes connection factory example:

```csharp
public class NamedPipesConnectionFactory
{
    private readonly string pipeName;

    public NamedPipesConnectionFactory(string pipeName)
    {
        this.pipeName = pipeName;
    }

    public async ValueTask<Stream> ConnectAsync(SocketsHttpConnectionContext _,
        CancellationToken cancellationToken = default)
    {
        var clientStream = new NamedPipeClientStream(
            serverName: ".",
            pipeName: this.pipeName,
            direction: PipeDirection.InOut,
            options: PipeOptions.WriteThrough | PipeOptions.Asynchronous,
            impersonationLevel: TokenImpersonationLevel.Anonymous);

        try
        {
            await clientStream.ConnectAsync(cancellationToken).ConfigureAwait(false);
            return clientStream;
        }
        catch
        {
            clientStream.Dispose();
            throw;
        }
    }
}
```

Using the custom connection factory to create a channel:

```csharp
public static GrpcChannel CreateChannel()
{
    var connectionFactory = new NamedPipesConnectionFactory("MyPipeName");
    var socketsHttpHandler = new SocketsHttpHandler
    {
        ConnectCallback = connectionFactory.ConnectAsync
    };

    return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
    {
        HttpHandler = socketsHttpHandler
    });
}
```

Channels created using the preceding code send gRPC calls over named pipes.
