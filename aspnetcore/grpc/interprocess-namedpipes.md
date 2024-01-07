---
title: Inter-process communication with gRPC and Named pipes
author: jamesnk
description: Learn how to use gRPC for inter-process communication with Named pipes.
monikerRange: '>= aspnetcore-8.0'
ms.author: jamesnk
ms.date: 01/18/2023
uid: grpc/interprocess-namedpipes
---
# Inter-process communication with gRPC and Named pipes

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
