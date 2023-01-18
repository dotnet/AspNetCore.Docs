---
title: Inter-process communication with gRPC and Named pipes
author: jamesnk
description: Learn how to use gRPC for inter-process communication with Named pipes
monikerRange: '>= aspnetcore-8.0'
ms.author: jamesnk
ms.date: 08/08/2022
uid: grpc/interprocess-namedpipes
---
# Inter-process communication with gRPC and Named pipes

By [James Newton-King](https://twitter.com/jamesnk)

[Named pipes](https://wikipedia.org/wiki/Named_pipe) supports all versions of Windows. Named pipes integrate well with [Windows security](/windows/win32/ipc/named-pipe-security-and-access-rights) to control client access to the pipe.

Requirements:

* .NET 8 or later
* Windows

## Server configuration

Named pipes are supported by [Kestrel](xref:fundamentals/servers/kestrel), which is configured in `Program.cs`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel(options =>
            {
                options.ListenNamedPipe("MyPipeName", listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2;
                });
            });
        });
```

The preceding example:

* Configures Kestrel's endpoints in `ConfigureKestrel`.
* Calls `ListenNamedPipe()` to listen to a named pipe with the specified name.
* Creates a UDS endpoint that isn't configured to use HTTPS. For information about enabling HTTPS, see [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints#listenoptionsusehttps).

### Client configuration

`GrpcChannel` supports making gRPC calls over custom transports. When a channel is created, it can be configured with a `SocketsHttpHandler` that has a custom `ConnectCallback`. The callback allows the client to make connections over custom transports and then send HTTP requests over that transport.

Named pipes connection factory example:

```csharp
public class UnixDomainSocketConnectionFactory
{
    private readonly EndPoint _endPoint;

    public UnixDomainSocketConnectionFactory(EndPoint endPoint)
    {
        _endPoint = endPoint;
    }

    public async ValueTask<Stream> ConnectAsync(SocketsHttpConnectionContext _,
        CancellationToken cancellationToken = default)
    {
        var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);

        try
        {
            await socket.ConnectAsync(_endPoint, cancellationToken).ConfigureAwait(false);
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
public static GrpcChannel CreateChannel()
{
    var udsEndPoint = new UnixDomainSocketEndPoint(SocketPath);
    var connectionFactory = new UnixDomainSocketConnectionFactory(udsEndPoint);
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

Channels created using the preceding code send gRPC calls over Named pipes.
