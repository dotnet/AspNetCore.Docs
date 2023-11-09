---
title: Inter-process communication with gRPC
author: jamesnk
description: Learn how to use gRPC for inter-process communication.
monikerRange: '>= aspnetcore-5.0'
ms.author: jamesnk
ms.date: 11/08/2023
uid: grpc/interprocess
---
# Inter-process communication with gRPC

:::moniker range=">= aspnetcore-8.0"

Processes running on the same machine can be designed to communicate with each other. Operating systems provide technologies for enabling fast and efficient [inter-process communication (IPC)](https://wikipedia.org/wiki/Inter-process_communication). Popular examples of IPC technologies are Unix domain sockets and Named pipes.

.NET provides support for inter-process communication using gRPC.

Built-in support for Named pipes in ASP.NET Core requires .NET 8 or later.

## Get started

IPC calls are sent from a client to a server. To communicate between apps on a machine with gRPC, at least one app must host an ASP.NET Core gRPC server.

An ASP.NET Core gRPC server is usually created from the gRPC template. The project file created by the template uses `Microsoft.NET.SDK.Web` as the SDK:

[!code-xml[](~/grpc/interprocess/Server-web.csproj?highlight=1)]

The `Microsoft.NET.SDK.Web` SDK value automatically adds a reference to the ASP.NET Core framework. The reference allows the app to use ASP.NET Core types required to host a server.

It's also possible to add a server to existing non-ASP.NET Core projects, such as Windows Services, WPF apps, or WinForms apps. See [Host gRPC in non-ASP.NET Core projects](xref:grpc/aspnetcore#host-grpc-in-non-aspnet-core-projects) for more information.

## Inter-process communication (IPC) transports

gRPC calls between a client and server on different machines are usually sent over TCP sockets. TCP is a good choice for communicating across a network or the Internet. However, IPC transports offer advantages when communicating between processes on the same machine:

* Less overhead and faster transfer speeds.
* Integration with OS security features.
* Doesn't use TCP ports, which are a limited resource.

.NET supports multiple IPC transports:

* [Unix domain sockets (UDS)](https://wikipedia.org/wiki/Unix_domain_socket) is a widely supported IPC technology. UDS is the best choice for building cross-platform apps, and it's usable on Linux, macOS, and [Windows 10/Windows Server 2019 or later](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/).
* [Named pipes](https://wikipedia.org/wiki/Named_pipe) are supported by all versions of Windows. Named pipes integrate well with [Windows security](/windows/win32/ipc/named-pipe-security-and-access-rights), which can control client access to the pipe.
* Additional IPC transports by implementing <xref:Microsoft.AspNetCore.Connections.IConnectionListenerFactory> and registering the implementation at app startup.

Depending on the OS, cross-platform apps may choose different IPC transports. An app can check the OS on startup and choose the desired transport for that platform:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    if (OperatingSystem.IsWindows())
    {
        serverOptions.ListenNamedPipe("MyPipeName");
    }
    else
    {
        var socketPath = Path.Combine(Path.GetTempPath(), "socket.tmp");
        serverOptions.ListenUnixSocket(socketPath);
    }

    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});
```

## Security considerations

IPC apps send and receive RPC calls. External communication is a potential attack vector for IPC apps and must be properly secured.

### Secure IPC server app against unexpected callers

The IPC server app hosts RPC services for other apps to call. Incoming callers should be authenticated to prevent untrusted clients from making RPC calls to the server.

Transport security is one option for securing a server. IPC transports, such as Unix domain sockets and named pipes, support limiting access based on operating system permissions:

* Named pipes supports securing a pipe with the [Windows access control model](/windows/win32/ipc/named-pipe-security-and-access-rights). Access rights can be configured in .NET when a server is started using the <xref:System.IO.Pipes.PipeSecurity> class.
* Unix domain sockets support securing a socket with file permissions.

Another option for securing an IPC server is to use authentication and authorization built into ASP.NET Core. For example, the server could be configured to require [certificate authentication](xref:security/authentication/certauth). RPC calls made by client apps without the required certificate fail with an unauthorized response.

### Validate the server in the IPC client app

It's important for the client app to validate the identity of the server it is calling. Validation is necessary to protect against a malicious actor from stopping the trusted server, running their own, and accepting incoming data from clients.

Named pipes provides support for getting the account that a server is running under. A client can validate the server was launched by the expected account:

```cs
internal static bool CheckPipeConnectionOwnership(
    NamedPipeClientStream pipeStream, SecurityIdentifier expectedOwner)
{
    var remotePipeSecurity = pipeStream.GetAccessControl();
    var remoteOwner = remotePipeSecurity.GetOwner(typeof(SecurityIdentifier));
    return expectedOwner.Equals(remoteOwner);
}
```

Another option for validating the server is to [secure its endpoints with HTTPS](/aspnet/core/fundamentals/servers/kestrel/endpoints#configure-https) inside ASP.NET Core. The client can configure `SocketsHttpHandler` to validate the server is using the expected certificate when the connection is established.

```cs
var socketsHttpHandler = new SocketsHttpHandler()
{
    SslOptions = new SslOptions()
    {
        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
        {
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                return false;
            }

            // Validate server cert thumbprint matches the expected thumbprint.
        }
    }
};
```

### Protect against named pipe privilege escalation

Named pipes supports a feature called [impersonation](/windows/win32/ipc/impersonating-a-named-pipe-client). Using impersonation, the named pipes server can execute code with the privileges of the client user. This is a powerful feature but can allow a low-privilege server to impersonate a high-privilege caller and then run malicious code.

Client's can protect against this attack by not allowing impersonation when connecting to a server. Unless required by a server, a <xref:System.Security.Principal.TokenImpersonationLevel> value of `None` or `Anonymous` should be used when creating a client connection:

```cs
using var pipeClient = new NamedPipeClientStream(
    serverName: ".", pipeName: "testpipe", PipeDirection.In, PipeOptions.None, TokenImpersonationLevel.None);
await pipeClient.ConnectAsync();
```

`TokenImpersonationLevel.None` is the default value in `NamedPipeClientStream` constructors that don't have an `impersonationLevel` parameter.

## Configure client and server

The client and server must be configured to use an inter-process communication (IPC) transport. For more information about configuring Kestrel and <xref:System.Net.Http.SocketsHttpHandler> to use IPC:

* [Inter-process communication with gRPC and Unix domain sockets](xref:grpc/interprocess-uds)
* [Inter-process communication with gRPC and Named pipes](xref:grpc/interprocess-namedpipes)

> [!NOTE]
> Built-in support for Named pipes in ASP.NET Core requires .NET 8 or later. .NET 8 is currently in preview and will be released near the end of 2023.

:::moniker-end

[!INCLUDE[](~/grpc/interprocess/includes/interprocess5-7.md)]
