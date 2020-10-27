---
title: Performance best practices with gRPC
author: jamesnk
description: Learn the best practices for building high-performance gRPC services.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 08/23/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/performance
---
# Performance best practices with gRPC

By [James Newton-King](https://twitter.com/jamesnk)

gRPC is designed for high-performance services. This document explains how to get the best performance possible from gRPC.

## Reuse gRPC channels

A gRPC channel should be reused when making gRPC calls. Reusing a channel allows calls to be multiplexed through an existing HTTP/2 connection.

If a new channel is created for each gRPC call then the amount of time it takes to complete can increase significantly. Each call will require multiple network round-trips between the client and the server to create a new HTTP/2 connection:

1. Opening a socket
2. Establishing TCP connection
3. Negotiating TLS
4. Starting HTTP/2 connection
5. Making the gRPC call

Channels are safe to share and reuse between gRPC calls:

* gRPC clients are created with channels. gRPC clients are lightweight objects and don't need to be cached or reused.
* Multiple gRPC clients can be created from a channel, including different types of clients.
* A channel and clients created from the channel can safely be used by multiple threads.
* Clients created from the channel can make multiple simultaneous calls.

gRPC client factory offers a centralized way to configure channels. It automatically reuses underlying channels. For more information, see <xref:grpc/clientfactory>.

## Connection concurrency

HTTP/2 connections typically have a limit on the number of [maximum concurrent streams (active HTTP requests)](https://httpwg.github.io/specs/rfc7540.html#rfc.section.5.1.2) on a connection at one time. By default, most servers set this limit to 100 concurrent streams.

A gRPC channel uses a single HTTP/2 connection, and concurrent calls are multiplexed on that connection. When the number of active calls reaches the connection stream limit, additional calls are queued in the client. Queued calls wait for active calls to complete before they are sent. Applications with high load, or long running streaming gRPC calls, could see performance issues caused by calls queuing because of this limit.

::: moniker range=">= aspnetcore-5.0"

.NET 5 introduces the `SocketsHttpHandler.EnableMultipleHttp2Connections` property. When set to `true`, additional HTTP/2 connections are created by a channel when the concurrent stream limit is reached. When a `GrpcChannel` is created its internal `SocketsHttpHandler` is automatically configured to create additional HTTP/2 connections. If an app configures its own handler, consider setting `EnableMultipleHttp2Connections` to `true`:

```csharp
var channel = GrpcChannel.ForAddress("https://localhost", new GrpcChannelOptions
{
    HttpHandler = new SocketsHttpHandler
    {
        EnableMultipleHttp2Connections = true,

        // ...configure other handler settings
    }
});
```

::: moniker-end

There are a couple of workarounds for .NET Core 3.1 apps:

* Create separate gRPC channels for areas of the app with high load. For example, the `Logger` gRPC service might have a high load. Use a separate channel to create the `LoggerClient` in the app.
* Use a pool of gRPC channels, for example,  create a list of gRPC channels. `Random` is used to pick a channel from the list each time a gRPC channel is needed. Using `Random` randomly distributes calls over multiple connections.

> [!IMPORTANT]
> Increasing the maximum concurrent stream limit on the server is another way to solve this problem. In Kestrel this is configured with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.MaxStreamsPerConnection>.
>
> Increasing the maximum concurrent stream limit is not recommended. Too many streams on a single HTTP/2 connection introduces new performance issues:
>
> * Thread contention between streams trying to write to the connection.
> * Connection packet loss causes all calls to be blocked at the TCP layer.

## Load balancing

Some load balancers don't work effectively with gRPC. L4 (transport) load balancers operate at a connection level, by distributing TCP connections across endpoints. This approach works well for loading balancing API calls made with HTTP/1.1. Concurrent calls made with HTTP/1.1 are sent on different connections, allowing calls to be load balanced across endpoints.

Because L4 load balancers operate at a connection level, they don't work well with gRPC. gRPC uses HTTP/2, which multiplexes multiple calls on a single TCP connection. All gRPC calls over that connection go to one endpoint.

There are two options to effectively load balance gRPC:

* Client-side load balancing
* L7 (application) proxy load balancing

> [!NOTE]
> Only gRPC calls can be load balanced between endpoints. Once a streaming gRPC call is established, all messages sent over the stream go to one endpoint.

### Client-side load balancing

With client-side load balancing, the client knows about endpoints. For each gRPC call it selects a different endpoint to send the call to. Client-side load balancing is a good choice when latency is important. There is no proxy between the client and the service so the call is sent to the service directly. The downside to client-side load balancing is that each client must keep track of available endpoints it should use.

Lookaside client load balancing is a technique where load balancing state is stored in a central location. Clients periodically query the central location for information to use when making load balancing decisions.

`Grpc.Net.Client` currently doesn't support client-side load balancing. [Grpc.Core](https://www.nuget.org/packages/Grpc.Core) is a good choice if client-side load balancing is required in .NET.

### Proxy load balancing

An L7 (application) proxy works at a higher level than an L4 (transport) proxy. L7 proxies understand HTTP/2, and are able to distribute gRPC calls multiplexed to the proxy on one HTTP/2 connection across multiple endpoints. Using a proxy is simpler than client-side load balancing, but can add extra latency to gRPC calls.

There are many L7 proxies available. Some options are:

* [Envoy](https://www.envoyproxy.io/) - A popular open source proxy.
* [Linkerd](https://linkerd.io/) - Service mesh for Kubernetes.
* [YARP: A Reverse Proxy](https://microsoft.github.io/reverse-proxy/) - A preview open source proxy written in .NET.

::: moniker range=">= aspnetcore-5.0"

## Inter-process communication

gRPC calls between a client and service are usually sent over TCP sockets. TCP is great for communicating across a network, but [inter-process communication (IPC)](https://wikipedia.org/wiki/Inter-process_communication) is more efficient when the client and service are on the same machine.

Consider using a transport like Unix domain sockets or named pipes for gRPC calls between processes on the same machine. For more information, see <xref:grpc/interprocess>.

## Keep alive pings

Keep alive pings can be used to keep HTTP/2 connections alive during periods of inactivity. Having an existing HTTP/2 connection ready when an app resumes activity allows for the initial gRPC calls to be made quickly, without a delay caused by the connection being reestablished.

Keep alive pings are configured on <xref:System.Net.Http.SocketsHttpHandler>:

```csharp
var handler = new SocketsHttpHandler
{
    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
    KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
    EnableMultipleHttp2Connections = true
};

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
{
    HttpHandler = handler
});
```

The preceding code configures a channel that sends a keep alive ping to the server every 60 seconds during periods of inactivity. The ping ensures the server and any proxies in use won't close the connection because of inactivity.

::: moniker-end

## Streaming

gRPC bidirectional streaming can be used to replace unary gRPC calls in high-performance scenarios. Once a bidirectional stream has started, streaming messages back and forth is faster than sending messages with multiple unary gRPC calls. Streamed messages are sent as data on an existing HTTP/2 request and eliminates the overhead of creating a new HTTP/2 request for each unary call.

Example service:

```csharp
public override async Task SayHello(IAsyncStreamReader<HelloRequest> requestStream,
    IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
{
    await foreach (var request in requestStream.ReadAllAsync())
    {
        var helloReply = new HelloReply { Message = "Hello " + request.Name };

        await responseStream.WriteAsync(helloReply);
    }
}
```

Example client:

```csharp
var client = new Greet.GreeterClient(channel);
using var call = client.SayHello();

Console.WriteLine("Type a name then press enter.");
while (true)
{
    var text = Console.ReadLine();

    // Send and receive messages over the stream
    await call.RequestStream.WriteAsync(new HelloRequest { Name = text });
    await call.ResponseStream.MoveNext();

    Console.WriteLine($"Greeting: {call.ResponseStream.Current.Message}");
}
```

Replacing unary calls with bidirectional streaming for performance reasons is an advanced technique and is not appropriate in many situations.

Using streaming calls is a good choice when:

1. High throughput or low latency is required.
2. gRPC and HTTP/2 are identified as a performance bottleneck.
3. A worker in the client is sending or receiving regular messages with a gRPC service.

Be aware of the additional complexity and limitations of using streaming calls instead of unary:

1. A stream can be interrupted by a service or connection error. Logic is required to restart stream if there is an error.
2. `RequestStream.WriteAsync` is not safe for multi-threading. Only one message can be written to a stream at a time. Sending messages from multiple threads over a single stream requires a producer/consumer queue like <xref:System.Threading.Channels.Channel%601> to marshall messages.
3. A gRPC streaming method is limited to receiving one type of message and sending one type of message. For example, `rpc StreamingCall(stream RequestMessage) returns (stream ResponseMessage)` receives `RequestMessage` and sends `ResponseMessage`. Protobuf's support for unknown or conditional messages using `Any` and `oneof` can work around this limitation.
