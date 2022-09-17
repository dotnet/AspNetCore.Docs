---
title: Create gRPC services and methods
author: jamesnk
description: Learn how to create gRPC services and methods.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 08/18/2022
uid: grpc/services
---
# Create gRPC services and methods

By [James Newton-King](https://twitter.com/jamesnk)

This document explains how to create gRPC services and methods in C#. Topics include:

* How to define services and methods in `.proto` files.
* Generated code using gRPC C# tooling.
* Implementing gRPC services and methods.

## Create new gRPC services

[gRPC services with C#](xref:grpc/basics) introduced gRPC's contract-first approach to API development. Services and messages are defined in `.proto` files. C# tooling then generates code from `.proto` files. For server-side assets, an abstract base type is generated for each service, along with classes for any messages.

The following `.proto` file:

* Defines a `Greeter` service.
* The `Greeter` service defines a `SayHello` call.
* `SayHello` sends a `HelloRequest` message and receives a `HelloReply` message

```protobuf
syntax = "proto3";

service Greeter {
  rpc SayHello (HelloRequest) returns (HelloReply);
}

message HelloRequest {
  string name = 1;
}

message HelloReply {
  string message = 1;
}
```

C# tooling generates the C# `GreeterBase` base type:

```csharp
public abstract partial class GreeterBase
{
    public virtual Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
    }
}

public class HelloRequest
{
    public string Name { get; set; }
}

public class HelloReply
{
    public string Message { get; set; }
}
```

By default the generated `GreeterBase` doesn't do anything. Its virtual `SayHello` method will return an `UNIMPLEMENTED` error to any clients that call it. For the service to be useful an app must create a concrete implementation of `GreeterBase`:

```csharp
public class GreeterService : GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply { Message = $"Hello {request.Name}" });
    }
}
```

The `ServerCallContext` gives the context for a server-side call.

The service implementation is registered with the app. If the service is hosted by ASP.NET Core gRPC, it should be added to the routing pipeline with the `MapGrpcService` method.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GreeterService>();
});
```

See <xref:grpc/aspnetcore> for more information.

## Implement gRPC methods

A gRPC service can have different types of methods. How messages are sent and received by a service depends on the type of method defined. The gRPC method types are:

* Unary
* Server streaming
* Client streaming
* Bi-directional streaming

Streaming calls are specified with the `stream` keyword in the `.proto` file. `stream` can be placed on a call's request message, response message, or both.

```protobuf
syntax = "proto3";

service ExampleService {
  // Unary
  rpc UnaryCall (ExampleRequest) returns (ExampleResponse);

  // Server streaming
  rpc StreamingFromServer (ExampleRequest) returns (stream ExampleResponse);

  // Client streaming
  rpc StreamingFromClient (stream ExampleRequest) returns (ExampleResponse);

  // Bi-directional streaming
  rpc StreamingBothWays (stream ExampleRequest) returns (stream ExampleResponse);
}
```

Each call type has a different method signature. Overriding generated methods from the abstract base service type in a concrete implementation ensures the correct arguments and return type are used.

### Unary method

A unary method has the request message as a parameter, and returns the response. A unary call is complete when the response is returned.

```csharp
public override Task<ExampleResponse> UnaryCall(ExampleRequest request,
    ServerCallContext context)
{
    var response = new ExampleResponse();
    return Task.FromResult(response);
}
```

Unary calls are the most similar to [actions on web API controllers](xref:web-api/index). One important difference gRPC methods have from actions is gRPC methods are not able to bind parts of a request to different method arguments. gRPC methods always have one message argument for the incoming request data. Multiple values can still be sent to a gRPC service by making them fields on the request message:

```protobuf
message ExampleRequest {
    int32 pageIndex = 1;
    int32 pageSize = 2;
    bool isDescending = 3;
}
```

### Server streaming method

A server streaming method has the request message as a parameter. Because multiple messages can be streamed back to the caller, `responseStream.WriteAsync` is used to send response messages. A server streaming call is complete when the method returns.

```csharp
public override async Task StreamingFromServer(ExampleRequest request,
    IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
{
    for (var i = 0; i < 5; i++)
    {
        await responseStream.WriteAsync(new ExampleResponse());
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}
```

The client has no way to send additional messages or data once the server streaming method has started. Some streaming methods are designed to run forever. For continuous streaming methods, a client can cancel the call when it's no longer needed. When cancellation happens the client sends a signal to the server and the [ServerCallContext.CancellationToken](xref:System.Threading.CancellationToken) is raised. The `CancellationToken` token should be used on the server with async methods so that:

* Any asynchronous work is canceled together with the streaming call.
* The method exits quickly.

```csharp
public override async Task StreamingFromServer(ExampleRequest request,
    IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
{
    while (!context.CancellationToken.IsCancellationRequested)
    {
        await responseStream.WriteAsync(new ExampleResponse());
        await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
    }
}
```

### Client streaming method

A client streaming method starts *without* the method receiving a message. The `requestStream` parameter is used to read messages from the client. A client streaming call is complete when a response message is returned:

```csharp
public override async Task<ExampleResponse> StreamingFromClient(
    IAsyncStreamReader<ExampleRequest> requestStream, ServerCallContext context)
{
    while (await requestStream.MoveNext())
    {
        var message = requestStream.Current;
        // ...
    }
    return new ExampleResponse();
}
```

When using C# 8 or later, the `await foreach` syntax can be used to read messages. The `IAsyncStreamReader<T>.ReadAllAsync()` extension method reads all messages from the request stream:

```csharp
public override async Task<ExampleResponse> StreamingFromClient(
    IAsyncStreamReader<ExampleRequest> requestStream, ServerCallContext context)
{
    await foreach (var message in requestStream.ReadAllAsync())
    {
        // ...
    }
    return new ExampleResponse();
}
```

### Bi-directional streaming method

A bi-directional streaming method starts *without* the method receiving a message. The `requestStream` parameter is used to read messages from the client. The method can choose to send messages with `responseStream.WriteAsync`. A bi-directional streaming call is complete when the method returns:

```csharp
public override async Task StreamingBothWays(IAsyncStreamReader<ExampleRequest> requestStream,
    IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
{
    await foreach (var message in requestStream.ReadAllAsync())
    {
        await responseStream.WriteAsync(new ExampleResponse());
    }
}
```

The preceding code:

* Sends a response for each request.
* Is a basic usage of bi-directional streaming.

It is possible to support more complex scenarios, such as reading requests and sending responses simultaneously:

```csharp
public override async Task StreamingBothWays(IAsyncStreamReader<ExampleRequest> requestStream,
    IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
{
    // Read requests in a background task.
    var readTask = Task.Run(async () =>
    {
        await foreach (var message in requestStream.ReadAllAsync())
        {
            // Process request.
        }
    });
    
    // Send responses until the client signals that it is complete.
    while (!readTask.IsCompleted)
    {
        await responseStream.WriteAsync(new ExampleResponse());
        await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
    }
}
```

In a bi-directional streaming method, the client and service can send messages to each other at any time. The best implementation of a bi-directional method varies depending upon requirements.

## Access gRPC request headers

A request message is not the only way for a client to send data to a gRPC service. Header values are available in a service using `ServerCallContext.RequestHeaders`.

```csharp
public override Task<ExampleResponse> UnaryCall(ExampleRequest request, ServerCallContext context)
{
    var userAgent = context.RequestHeaders.GetValue("user-agent");
    // ...

    return Task.FromResult(new ExampleResponse());
}
```

## Multi-threading with gRPC streaming methods

There are important considerations to implementing gRPC streaming methods that use multiple threads.

### Reader and writer thread safety

`IAsyncStreamReader<TMessage>` and `IServerStreamWriter<TMessage>` can each be used by only one thread at a time. For a streaming gRPC method, multiple threads can't read new messages with `requestStream.MoveNext()` simultaneously. And multiple threads can't write new messages with `responseStream.WriteAsync(message)` simultaneously.

A safe way to enable multiple threads to interact with a gRPC method is to use the producer-consumer pattern with [System.Threading.Channels](/dotnet/core/extensions/channels).

```csharp
public override async Task DownloadResults(DataRequest request,
    IServerStreamWriter<DataResult> responseStream, ServerCallContext context)
{
    var channel = Channel.CreateBounded<DataResult>(new BoundedChannelOptions(capacity: 5));

    var consumerTask = Task.Run(async () =>
    {
        // Consume messages from channel and write to response stream.
        await foreach (var message in channel.Reader.ReadAllAsync())
        {
            await responseStream.WriteAsync(message);
        }
    });

    var dataChunks = request.Value.Chunk(size: 10);

    // Write messages to channel from multiple threads.
    await Task.WhenAll(dataChunks.Select(
        async c =>
        {
            var message = new DataResult { BytesProcessed = c.Length };
            await channel.Writer.WriteAsync(message);
        }));

    // Complete writing and wait for consumer to complete.
    channel.Writer.Complete();
    await consumerTask;
}
```

The preceding gRPC server streaming method:

* Creates a bounded channel for producing and consuming `DataResult` messages.
* Starts a task to read messages from the channel and write them to the response stream.
* Writes messages to the channel from multiple threads.

> [!NOTE]
> Bidirectional streaming methods take `IAsyncStreamReader<TMessage>` and `IServerStreamWriter<TMessage>` as arguments. It's safe to use these types on separate threads from each other.

### Interacting with a gRPC method after a call ends

A gRPC call ends on the server once the gRPC method exits. The following arguments passed to gRPC methods aren't safe to use after the call has ended:

* `ServerCallContext`
* `IAsyncStreamReader<TMessage>`
* `IServerStreamWriter<TMessage>`

If a gRPC method starts background tasks that use these types, it must complete the tasks before the gRPC method exits. Continuing to use the context, stream reader, or stream writer after the gRPC method exists causes errors and unpredictable behavior.

In the following example, the server streaming method could write to the response stream after the call has finished:

```csharp
public override async Task StreamingFromServer(ExampleRequest request,
    IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
{
    _ = Task.Run(async () =>
    {
        for (var i = 0; i < 5; i++)
        {
            await responseStream.WriteAsync(new ExampleResponse());
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    });

    await PerformLongRunningWorkAsync();
}
```

For the previous example, the solution is to await the write task before exiting the method:

```csharp
public override async Task StreamingFromServer(ExampleRequest request,
    IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
{
    var writeTask = Task.Run(async () =>
    {
        for (var i = 0; i < 5; i++)
        {
            await responseStream.WriteAsync(new ExampleResponse());
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    });

    await PerformLongRunningWorkAsync();

    await writeTask;
}
```

## Additional resources

* <xref:grpc/basics>
* <xref:grpc/client>
