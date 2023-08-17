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

:::code language="protobuf" source="~/grpc/services/Protos/greeter.proto" :::

C# tooling generates the C# `GreeterBase` base type:

:::code language="csharp" source="~/grpc/services/GreeterBase.cs" id="snippet_GreeterBase" :::

By default the generated `GreeterBase` doesn't do anything. Its virtual `SayHello` method will return an `UNIMPLEMENTED` error to any clients that call it. For the service to be useful an app must create a concrete implementation of `GreeterBase`:

:::code language="csharp" source="~/grpc/services/GreeterService.cs" id="snippet_GreeterService" :::

The `ServerCallContext` gives the context for a server-side call.

The service implementation is registered with the app. If the service is hosted by ASP.NET Core gRPC, it should be added to the routing pipeline with the `MapGrpcService` method.

:::code language="csharp" source="~/grpc/services/Program.cs" id="snippet_MapGrpcService" :::

See <xref:grpc/aspnetcore> for more information.

## Implement gRPC methods

A gRPC service can have different types of methods. How messages are sent and received by a service depends on the type of method defined. The gRPC method types are:

* Unary
* Server streaming
* Client streaming
* Bi-directional streaming

Streaming calls are specified with the `stream` keyword in the `.proto` file. `stream` can be placed on a call's request message, response message, or both.

:::code language="protobuf" source="~/grpc/services/Protos/example.proto" range="1-15" :::

Each call type has a different method signature. Overriding generated methods from the abstract base service type in a concrete implementation ensures the correct arguments and return type are used.

### Unary method

A unary method has the request message as a parameter, and returns the response. A unary call is complete when the response is returned.

:::code language="csharp" source="~/grpc/services/ExampleService.cs" id="snippet_UnaryCall" :::

Unary calls are the most similar to [actions on web API controllers](xref:web-api/index). One important difference gRPC methods have from actions is gRPC methods are not able to bind parts of a request to different method arguments. gRPC methods always have one message argument for the incoming request data. Multiple values can still be sent to a gRPC service by adding fields to the request message:

:::code language="protobuf" source="~/grpc/services/Protos/example.proto" range="19-23" :::

### Server streaming method

A server streaming method has the request message as a parameter. Because multiple messages can be streamed back to the caller, `responseStream.WriteAsync` is used to send response messages. A server streaming call is complete when the method returns.

:::code language="csharp" source="~/grpc/services/ExampleService.cs" id="snippet_StreamingFromServer" :::

The client has no way to send additional messages or data once the server streaming method has started. Some streaming methods are designed to run forever. For continuous streaming methods, a client can cancel the call when it's no longer needed. When cancellation happens the client sends a signal to the server and the [ServerCallContext.CancellationToken](xref:System.Threading.CancellationToken) is raised. The `CancellationToken` token should be used on the server with async methods so that:

* Any asynchronous work is canceled together with the streaming call.
* The method exits quickly.

:::code language="csharp" source="~/grpc/services/ExampleService.cs" id="snippet_StreamingFromServerUsingCancellationToken" :::

### Client streaming method

A client streaming method starts *without* the method receiving a message. The `requestStream` parameter is used to read messages from the client. A client streaming call is complete when a response message is returned:

:::code language="csharp" source="~/grpc/services/ExampleService.cs" id="snippet_StreamingFromClient" :::

### Bi-directional streaming method

A bi-directional streaming method starts *without* the method receiving a message. The `requestStream` parameter is used to read messages from the client. The method can choose to send messages with `responseStream.WriteAsync`. A bi-directional streaming call is complete when the method returns:

:::code language="csharp" source="~/grpc/services/ExampleService.cs" id="snippet_StreamingBothWays" :::

The preceding code:

* Sends a response for each request.
* Is a basic usage of bi-directional streaming.

It is possible to support more complex scenarios, such as reading requests and sending responses simultaneously:

:::code language="csharp" source="~/grpc/services/ExampleService.cs" id="snippet_StreamingBothWaysComplex" :::

In a bi-directional streaming method, the client and service can send messages to each other at any time. The best implementation of a bi-directional method varies depending upon requirements.

## Access gRPC request headers

A request message is not the only way for a client to send data to a gRPC service. Header values are available in a service using `ServerCallContext.RequestHeaders`.

:::code language="csharp" source="~/grpc/services/ExampleService.cs" id="snippet_UnaryCallRequestHeaders" :::

## Multi-threading with gRPC streaming methods

There are important considerations to implementing gRPC streaming methods that use multiple threads.

### Reader and writer thread safety

`IAsyncStreamReader<TMessage>` and `IServerStreamWriter<TMessage>` can each be used by only one thread at a time. For a streaming gRPC method, multiple threads can't read new messages with `requestStream.MoveNext()` simultaneously. And multiple threads can't write new messages with `responseStream.WriteAsync(message)` simultaneously.

A safe way to enable multiple threads to interact with a gRPC method is to use the producer-consumer pattern with [System.Threading.Channels](/dotnet/core/extensions/channels).

:::code language="csharp" source="~/grpc/services/DownloadResults.cs" :::

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

:::code language="csharp" source="~/grpc/services/PerformLongRunningWorkAsync.cs" id="snippet_StreamingFromServer" :::

For the previous example, the solution is to await the write task before exiting the method:

:::code language="csharp" source="~/grpc/services/PerformLongRunningWorkAsync.cs" id="snippet_StreamingFromServerWriteTask" :::

## Additional resources

* <xref:grpc/basics>
* <xref:grpc/client>
