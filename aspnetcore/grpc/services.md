---
title: Create gRPC services and methods
author: jamesnk
description: Learn how to create gRPC services and methods.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 08/25/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/services
---
# Create gRPC services and methods

This document explains how to create gRPC services and methods in C#. Topics include:

* How to define services and methods in *.proto* files.
* Generated code using gRPC C# tooling.
* Implementing gRPC services and methods.

## Create new gRPC services

[gRPC services with C#](xref:grpc/basics) introduced gRPC's contract-first approach to API development. Services and messages are defined in *.proto* files. C# tooling then generates code from *.proto* files. For server-side assets, an abstract base type is generated for each service, along with classes for any messages.

The following *.proto* file:

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
    public override Task<HelloReply> UnaryCall(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloRequest { Message = $"Hello {request.Name}" });
    }
}
```

The final step is to register the service implementation with the app. If the service is hosted by ASP.NET Core gRPC then it should be added to the routing pipeline with the `MapGrpcService` method.

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

Streaming calls are specified with the `stream` keyword in the *.proto* file. `stream` can be placed on a call's request message, response message, or both.

```protobuf
syntax = "proto3";

service ExampleService {
  // Unary
  rpc UnaryCall (SimpleRequest) returns (SimpleResponse);

  // Server streaming
  rpc StreamingFromServer (SimpleRequest) returns (stream SimpleResponse);

  // Client streaming
  rpc StreamingFromClient (stream SimpleRequest) returns (SimpleResponse);

  // Bi-directional streaming
  rpc StreamingBothWays (stream SimpleRequest) returns (stream SimpleResponse);
}
```

Each call type has a different method signature. Overriding generated methods from the abstract base service type in a concrete implementation ensures the correct arguments and return type are used.

### Unary method

A unary method gets the request message as a parameter, and returns the response. A unary call is complete when the response is returned.

```csharp
public override Task<SimpleResponse> UnaryCall(SimpleRequest request, ServerCallContext context)
{
    var response = new SimpleResponse();
    return Task.FromResult(response);
}
```

Unary calls are the most similar to [actions on web API controllers](xref:web-api/index). One important difference gRPC methods have from actions is gRPC methods are not able to bind parts of a request to different method arguments. gRPC methods always have one message argument for the incoming request data. Multiple values can still be sent to a gRPC service by making them fields on the request message:

```protobuf
message SimpleRequest {
    int pageIndex = 1;
    int pageSize = 2;
    bool isDescending = 3;
}
```

### Server streaming method

A server streaming method gets the request message as a parameter. Because multiple messages can be streamed back to the caller, `responseStream.WriteAsync` is used to send response messages. A server streaming call is complete when the method returns.

```csharp
public override async Task StreamingFromServer(SimpleRequest request,
    IServerStreamWriter<SimpleResponse> responseStream, ServerCallContext context)
{
    for (var i = 0; i < 5; i++)
    {
        await responseStream.WriteAsync(new SimpleResponse());
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}
```

The client has no way to send additional messages or data once the server streaming method has started. Some streaming methods are designed to run forever. In this situation a client can cancel the call when they no longer need it. When cancellation happens the client sends a signal to the server and the `ServerCallContext.CancellationToken` <xref:System.Threading.CancellationToken> is raised. The token should be used on the server with async methods used so that any asynchronous work is canceled together with the streaming call, and the method exits quickly.

```csharp
public override async Task StreamingFromServer(SimpleRequest request,
    IServerStreamWriter<SimpleResponse> responseStream, ServerCallContext context)
{
    while (!context.CancellationToken.IsCancellationRequested)
    {
        await responseStream.WriteAsync(new SimpleResponse());
        await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
    }
}
```

### Client streaming method

A client streaming method starts *without* the method receiving a message. The `requestStream` parameter is used to read messages from the client. A client streaming call is complete when a response message is returned.

```csharp
public override async Task<SimpleResponse> StreamingFromClient(
    IAsyncStreamReader<SimpleRequest> requestStream, ServerCallContext context)
{
    while (await requestStream.MoveNext())
    {
        var message = requestStream.Current;
        // ...
    }
    return new SimpleResponse();
}
```

When using C# 8 or later, the `await foreach` syntax can be used to read messages. The `IAsyncStreamReader<T>.ReadAllAsync()` extension method reads all messages from the request stream:

```csharp
public override async Task<SimpleResponse> StreamingFromClient(
    IAsyncStreamReader<SimpleRequest> requestStream, ServerCallContext context)
{
    await foreach (var message in requestStream.ReadAllAsync())
    {
        // ...
    }
    return new SimpleResponse();
}
```

### Bi-directional streaming method

A bi-directional streaming method starts *without* the method receiving a message. The `requestStream` parameter is used to read messages from the client. The method can choose to send messages with `responseStream.WriteAsync`. A bi-directional streaming call is complete when the the method returns.

```csharp
public override async Task StreamingBothWays(IAsyncStreamReader<SimpleRequest> requestStream,
    IServerStreamWriter<SimpleResponse> responseStream, ServerCallContext context)
{
    await foreach (var message in requestStream.ReadAllAsync())
    {
        await responseStream.WriteAsync(new SimpleResponse());
    }
}
```

In the preceding method sends a response for each request. This is a simple usage of bi-directional streaming. It is possible to support more complex scenarios, such as reading a requests and sending responses simultaneously:

```csharp
public override async Task StreamingBothWays(IAsyncStreamReader<SimpleRequest> requestStream,
    IServerStreamWriter<SimpleResponse> responseStream, ServerCallContext context)
{
    // Read requests in a background task
    var readTask = Task.Run(async () =>
    {
        await foreach (var message in requestStream.ReadAllAsync())
        {
            // Process request
        }
    });
    
    // Send responses until the client signals that it is complete
    while (!readTask.IsCompleted)
    {
        await responseStream.WriteAsync(new SimpleResponse());
        await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
    }
}
```

In a bi-directional streaming method, the client and service can send messages to each other at any time. The best implementation of a bi-directional method varies depending upon requirements.

## Access gRPC request headers

A request message is not the only way for a client to send data to a gRPC service. Header values are available in a service using `ServerCallContext.RequestHeaders`.

```csharp
public override Task<SimpleResponse> UnaryCall(SimpleRequest request, ServerCallContext context)
{
    var userAgent = context.RequestHeaders.GetValue("user-agent");
    // ...

    return Task.FromResult(new SimpleResponse());
}
```

## Additional resources

* <xref:grpc/basics>
* <xref:grpc/client>
