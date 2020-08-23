---
title: Performance best practices
author: jamesnk
description: Learn the best practices for building high-performance gRPC services.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 08/23/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/performance
---
# Performance best practices

By [James Newton-King](https://twitter.com/jamesnk)

gRPC is designed for high-performance services. This document explains how to get the best performance possible from gRPC.

## Reuse channel

A gRPC channel should be reused when making gRPC calls. Reusing a channel allows calls to be multiplexed through an existing HTTP/2 connection.

If a new channel is created for each gRPC call then the amount of time it takes to complete can increase significantly. Each call will require multiple network round-trips between the client and the server to create an HTTP/2 connection:

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

::: moniker range=">= aspnetcore-5.0"

## Keep alive pings

Keep alive pings can be used to keep HTTP/2 connections alive during periods of inactivity. Having an existing HTTP/2 connection ready when an app resumes activity allows for the initial gRPC calls to be made quickly, without a delay caused by the connection being reestablished.

Keep alive pings are configured on <xref:System.Net.Http.SocketsHttpHandler>:

```csharp
var handler = new SocketsHttpHandler
{
    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
    KeepAlivePingTimeout = TimeSpan.FromSeconds(30)
};

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
{
    HttpHandler = handler
});
```

The preceding code configures a channel that sends a keep alive ping to the server every 60 seconds during periods of inactivity. The ping will ensure the server and any proxies in use won't close the connection because of inactivity.

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
