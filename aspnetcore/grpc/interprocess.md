---
title: Use gRPC with inter-process communication
author: jamesnk
description: Learn how to make inter-process gRPC calls over custom transports.
monikerRange: '>= aspnetcore-5.0'
ms.author: jamesnk
ms.date: 08/24/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/interprocess
---
# Use gRPC with inter-process communication

By [James Newton-King](https://twitter.com/jamesnk)

gRPC calls between a client and service are usually sent over TCP sockets. TCP is great for communicating across a network, but there are more efficient transports when the client and service are on the same machine. This is known as [inter-process communication (IPC)](https://wikipedia.org/wiki/Inter-process_communication). This document explains how to use gRPC with custom transports in IPC scenarios.

## Server configuration

Custom transports are supported by Kestrel. Kestrel endpoints are configured with `ConfigureKestrel` in *Program.cs* and custom endpoints, such as [Unix domain sockets](https://wikipedia.org/wiki/Unix_domain_socket), are configured here. Kestrel has built-in support for listening on unix sockets with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket*>.

```csharp
public static readonly string SocketPath = Path.Combine(Path.GetTempPath(), "socket.tmp");

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel(options =>
            {
                if (File.Exists(SocketPath))
                {
                    File.Delete(SocketPath);
                }
                options.ListenUnixSocket(SocketPath);
            });
        });
```

> [!TIP]
> Unix domain sockets are [supported](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/) by modern versions of Windows.

## Client configuration

`GrpcChannel` supports making gRPC calls over custom transports. When a channel is created can be configured with a `SocketsHttpHandler` that has a custom `ConnectionFactory`. The factory allows the client to make connections over custom transports and then sent HTTP requests over that transport.

Example of a Unix domain sockets connection factory:

```csharp
public class UnixDomainSocketConnectionFactory : SocketsConnectionFactory
{
    private readonly EndPoint _endPoint;

    public UnixDomainSocketConnectionFactory(EndPoint endPoint)
        : base(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified)
    {
        _endPoint = endPoint;
    }

    public override ValueTask<Connection> ConnectAsync(EndPoint? endPoint,
        IConnectionProperties? options = null, CancellationToken cancellationToken = default)
    {
        return base.ConnectAsync(_endPoint, options, cancellationToken);
    }
}
```

Using the custom connection factory to create a channel:

```csharp
public static readonly string SocketPath = Path.Combine(Path.GetTempPath(), "socket.tmp");

public static GrpcChannel CreateChannel()
{
    var udsEndPoint = new UnixDomainSocketEndPoint(SocketPath);
    var socketsHttpHandler = new SocketsHttpHandler
    {
        ConnectionFactory = new UnixDomainSocketConnectionFactory(udsEndPoint)
    };

    return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
    {
        HttpHandler = socketsHttpHandler
    });
}
```

Channels created using the preceding code will send gRPC calls over Unix domain sockets.
