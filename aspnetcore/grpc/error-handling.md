---
title: Error handling with gRPC on .NET
author: jamesnk
ms.author: jamesnk
description: Learn how to do error handling with gRPC on .NET.
monikerRange: '>= aspnetcore-3.1'
ms.date: 01/09/2024
uid: grpc/error-handling
---
# Error handling with gRPC

By [James Newton-King](https://twitter.com/jamesnk)

This article discusses error handling and gRPC:

* Built-in error handling capabilities using gRPC status codes and error messages.
* Sending complex, structured error information using [rich error handling](#rich-error-handling).

## Built-in error handling

gRPC calls communicate success or failure with a status code. When a gRPC call completes successfully the server returns an `OK` status to the client. If an error occurs, gRPC returns:

* An error status code, such as `CANCELLED` or `UNAVAILABLE`.
* An optional string error message.

The types commonly used with error handling are:

* `StatusCode`: An enumeration of [gRPC status codes](https://grpc.github.io/grpc/core/md_doc_statuscodes.html). `OK` signals success; other values are failure.
* `Status`: A `struct` that combines a `StatusCode` and an optional string error message. The error message provides further details about what happened.
* `RpcException`: An exception type that has `Status` value. This exception is thrown in gRPC server methods and caught by gRPC clients.

Built-in error handling only supports a status code and string description. To send complex error information from the server to the client, [use rich error handling](#rich-error-handling).

## Throw server errors

A gRPC server call always returns a status. The server automatically returns `OK` when a method completes successfully.

```cs
public class GreeterService : GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply { Message = $"Hello {request.Name}" });
    }

    public override async Task SayHelloStreaming(HelloRequest request,
        IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
    {
        for (var i = 0; i < 5; i++)
        {
            await responseStream.WriteAsync(new HelloReply { Message = $"Hello {request.Name} {i}" });
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}
```

The preceding code:

* Implements the unary `SayHello` method that completes successfully when it returns a response message.
* Implements the server streaming `SayHelloStreaming` method that completes successfully when the method finished.

### Server error status

gRPC methods return an error status code by throwing an exception. When an `RpcException` is thrown on the server, its status code and description is returned to the client:

```cs
public class GreeterService : GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Name is required."));
        }
        return Task.FromResult(new HelloReply { Message = $"Hello {request.Name}" });
    }
}
```

Thrown exception types that aren't `RpcException` also cause the call to fail, but with an `UNKNOWN` status code and a generic message `Exception was thrown by handler`.

`Exception was thrown by handler` is sent to the client rather than the exception message to prevent exposing potentially sensitive information. To see a more descriptive error message in a development environment, configure [`EnableDetailedErrors`](xref:grpc/configuration#configure-services-options).

## Handle client errors

When a gRPC client makes a call, the status code is automatically validated when accessing the response. For example, awaiting a unary gRPC call returns the message sent by the server if the call is successful, and throws an `RpcException` if there's a failure. Catch `RpcException` to handle errors in a client:

```cs
var client = new Greet.GreeterClient(channel);

try
{
    var response = await client.SayHelloAsync(new HelloRequest { Name = "World" });
    Console.WriteLine("Greeting: " + response.Message);
}
catch (RpcException ex)
{
    Console.WriteLine("Status code: " + ex.Status.StatusCode);
    Console.WriteLine("Message: " + ex.Status.Detail);
}
```

The preceding code:

* Makes a unary gRPC call to the `SayHello` method.
* Writes the response message to the console if it's successful.
* Catches `RpcException` and writes out the error details on failure.

### Error scenarios

Errors are represented by `RpcException` with an error status code and optional detail message. `RpcException` is thrown in many scenarios:

* The call failed on the server and the server sent an error status code. For example, the gRPC client started a call that was missing required data from the request message and the server returns an `INVALID_ARGUMENT` status code.
* An error occurred inside the client when making the gRPC call. For example, a client makes a gRPC call, can't connect to the server, and throws an error with a status of `UNAVAILABLE`.
* The <xref:System.Threading.CancellationToken> passed to the gRPC call is canceled. The gRPC call is stopped and the client throws an error with a status of `CANCELLED`.
* A gRPC call exceeds its configured deadline. The gRPC call is stopped and the client throws an error with a status of `DEADLINE_EXCEEDED`.

## Rich error handling

Rich error handling allows complex, structured information to be sent with error messages. For example, validation of incoming message fields that returns a list of invalid field names and descriptions. The [`google.rpc.Status` error model](https://cloud.google.com/apis/design/errors#error_model) is often used to send complex error information between gRPC apps.

gRPC on .NET supports a rich error model using the `Grpc.StatusProto` package. This package has methods for creating rich error models on the server and reading them by a client. The rich error model builds on top of gRPC's built-in handling capabilities and they can be used side-by-side.

> [!IMPORTANT]
> Errors are included in headers, and total headers in responses are often limited to 8 KB (8,192 bytes). Ensure that the headers containing errors do not exceed 8 KB.

### Creating rich errors on the server

Rich errors are created from `Google.Rpc.Status`. This type is ***different*** from `Grpc.Core.Status`.

`Google.Rpc.Status` has status, message, and details fields. The most important field is details, which is a repeating field of [`Any`](xref:grpc/protobuf#any) values. Details are where complex payloads are added.

Although any message type can be used as a payload, it's recommended to use one of the [standard error payloads](https://cloud.google.com/apis/design/errors#error_model):

* `BadRequest`
* `PreconditionFailure`
* `ErrorInfo`
* `ResourceInfo`
* `QuotaFailure`

`Grpc.StatusProto` includes the `ToRpcException` a helper method to convert `Google.Rpc.Status` to an error. Throw the error from the gRPC server method:

```cs
public class GreeterService : Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        ArgumentNotNullOrEmpty(request.Name);

        return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
    }
    
    public static void ArgumentNotNullOrEmpty(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (string.IsNullOrEmpty(value))
        {
            var status = new Google.Rpc.Status
            {
                Code = (int)Code.InvalidArgument,
                Message = "Bad request",
                Details =
                {
                    Any.Pack(new BadRequest
                    {
                        FieldViolations =
                        {
                            new BadRequest.Types.FieldViolation { Field = paramName, Description = "Value is null or empty" }
                        }
                    })
                }
            };
            throw status.ToRpcException();
        }
    }
}
```

### Reading rich errors by a client

Rich errors are read from the `RpcException` caught in the client. Catch the exception and use helper methods provided by `Grpc.StatusCode` to get its `Google.Rpc.Status` instance:

```cs
var client = new Greet.GreeterClient(channel);

try
{
    var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
    Console.WriteLine("Greeting: " + reply.Message);
}
catch (RpcException ex)
{
    Console.WriteLine($"Server error: {ex.Status.Detail}");
    var badRequest = ex.GetRpcStatus()?.GetDetail<BadRequest>();
    if (badRequest != null)
    {
        foreach (var fieldViolation in badRequest.FieldViolations)
        {
            Console.WriteLine($"Field: {fieldViolation.Field}");
            Console.WriteLine($"Description: {fieldViolation.Description}");
        }
    }
}
```

The preceding code:

* Makes a gRPC call inside a try/catch that catches `RpcException`.
* Calls `GetRpcStatus()` to attempt to get the rich error model from the exception.
* Calls `GetDetail<BadRequest>()` to attempt to get a `BadRequest` payload from the rich error.

## Additional resources

* <xref:grpc/services>
* <xref:grpc/client>
* [gRPC status codes](https://grpc.github.io/grpc/core/md_doc_statuscodes.html)
