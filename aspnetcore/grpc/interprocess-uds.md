---
title: Inter-process communication with gRPC and Unix domain sockets
author: jamesnk
description: Learn how to use gRPC for inter-process communication with Unix domain sockets.
monikerRange: '>= aspnetcore-5.0'
ms.author: jamesnk
ms.date: 01/18/2023
uid: grpc/interprocess-uds
---
# Inter-process communication with gRPC and Unix domain sockets

By [James Newton-King](https://twitter.com/jamesnk)

.NET supports inter-process communication (IPC) using gRPC. For more information about getting started with using gRPC to communicate between processes, see [Inter-process communication with gRPC](xref:grpc/interprocess).

[Unix domain sockets (UDS)](https://wikipedia.org/wiki/Unix_domain_socket) is a widely supported IPC transport that's more efficient than TCP when the client and server are on the same machine. This article discusses how to configure gRPC communication over UDS.

## Prerequisites

* .NET 5 or later
* Linux, macOS, or [Windows 10/Windows Server 2019 or later](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/)

## Server configuration

Unix domain sockets are supported by [Kestrel](xref:fundamentals/servers/kestrel), which is configured in `Program.cs`:

```csharp
var socketPath = Path.Combine(Path.GetTempPath(), "socket.tmp");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenUnixSocket(socketPath, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});
```

The preceding example:

* Configures Kestrel's endpoints in <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.ConfigureKestrel%2A>.
* Calls <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> to listen to a UDS with the specified path.
* Creates a UDS endpoint that isn't configured to use HTTPS. For information about enabling HTTPS, see [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints#listenoptionsusehttps).

## Client configuration

`GrpcChannel` supports making gRPC calls over custom transports. When a channel is created, it can be configured with a <xref:System.Net.Http.SocketsHttpHandler> that has a custom <xref:System.Net.Http.SocketsHttpHandler.ConnectCallback>. The callback allows the client to make connections over custom transports and then send HTTP requests over that transport.

> [!NOTE]
> Some connectivity features of `GrpcChannel`, such as client side load balancing and channel status, can't be used together with Unix domain sockets.

Unix domain sockets connection factory example:

```csharp
public class UnixDomainSocketsConnectionFactory
{
    private readonly EndPoint endPoint;

    public UnixDomainSocketsConnectionFactory(EndPoint endPoint)
    {
        this.endPoint = endPoint;
    }

    public async ValueTask<Stream> ConnectAsync(SocketsHttpConnectionContext _,
        CancellationToken cancellationToken = default)
    {
        var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);

        try
        {
            await socket.ConnectAsync(this.endPoint, cancellationToken).ConfigureAwait(false);
            return new NetworkStream(socket, true);
        }
        catch
        {
            socket.Dispose();
            throw;
        }
    }
}
```

Using the custom connection factory to create a channel:

```csharp
public static readonly string SocketPath = Path.Combine(Path.GetTempPath(), "socket.tmp");

public static GrpcChannel CreateChannel()
{
    var udsEndPoint = new UnixDomainSocketEndPoint(SocketPath);
    var connectionFactory = new UnixDomainSocketsConnectionFactory(udsEndPoint);
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

Channels created using the preceding code send gRPC calls over Unix domain sockets.
