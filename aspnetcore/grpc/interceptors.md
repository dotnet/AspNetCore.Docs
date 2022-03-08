---
title: gRPC interceptors on .NET
author: erni27
ms.author: jamesnk
description: Learn how to use gRPC interceptors on .NET.
monikerRange: '>= aspnetcore-3.1'
ms.date: 02/26/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/interceptors
---
# gRPC interceptors on .NET

By [Ernest Nguyen](https://github.com/erni27)

Interceptors are a gRPC concept that allows apps to interact with incoming or outgoing gRPC calls. They offer a way to enrich the request processing pipeline.

Interceptors are configured for a channel or service and executed automatically for each gRPC call. Since interceptors are transparent to the user's application logic, they're an excellent solution for common cases, such as logging, monitoring, authentication, and validation.

## `Interceptor` type

Interceptors can be implemented for both gRPC servers and clients by creating a class that inherits from the `Interceptor` type:

```csharp
public class ExampleInterceptor : Interceptor
{
}
```

By default, the `Interceptor` base class doesn't do anything. Add behavior to an interceptor by overriding the appropriate base class methods in an interceptor implementation.

## Client interceptors

gRPC client interceptors intercept outgoing RPC invocations. They provide access to the sent request, the incoming response, and the context for a client-side call.

`Interceptor` methods to override for client:

* `BlockingUnaryCall`: Intercepts a blocking invocation of an unary RPC.
* `AsyncUnaryCall`: Intercepts an asynchronous invocation of an unary RPC.
* `AsyncClientStreamingCall`: Intercepts an asynchronous invocation of a client-streaming RPC.
* `AsyncServerStreamingCall`: Intercepts an asynchronous invocation of a server-streaming RPC.
* `AsyncDuplexStreamingCall`: Intercepts an asynchronous invocation of a bidirectional-streaming RPC.

> [!WARNING]
> Although both `BlockingUnaryCall` and `AsyncUnaryCall` refer to unary RPCs, they aren't interchangeable. A blocking invocation isn't intercepted by `AsyncUnaryCall`, and an asynchronous invocation isn't intercepted by a `BlockingUnaryCall`.

### Create a client gRPC interceptor

The following code presents a basic example of intercepting an asynchronous invocation of a unary call:

```csharp
public class ClientLoggingInterceptor : Interceptor
{
    private readonly ILogger _logger;

    public ClientLoggingInterceptor(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ClientLoggingInterceptor>();
    }

    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        _logger.LogInformation($"Starting call. Type: {context.Method.Type}. " +
            $"Method: {context.Method.Name}.");
        return continuation(request, context);
    }
}
```

Overriding `AsyncUnaryCall`:

* Intercepts an asynchronous unary call.
* Logs details about the call.
* Calls the `continuation` parameter passed into the method. This invokes the next interceptor in the chain or the underlying call invoker if this is the last interceptor.

Methods on `Interceptor` for each kind of service method have different signatures. However, the concept behind `continuation` and `context` parameters remains the same:

* `continuation` is a delegate which invokes the next interceptor in the chain or the underlying call invoker (if there is no interceptor left in the chain). It isn't an error to call it zero or multiple times. Interceptors aren't required to return a call representation (`AsyncUnaryCall` in case of unary RPC) returned from the `continuation` delegate. Omitting the delegate call and returning your own instance of call representation breaks the interceptors' chain and returns the associated response immediately.
* `context` carries scoped values associated with the client-side call. Use `context` to pass metadata, such as security principals, credentials, or tracing data. Moreover, `context` carries information about deadlines and cancellation. For more information, see <xref:grpc/deadlines-cancellation#deadlines>.

### Awaiting response in client interceptor

An interceptor can await the response in unary and client streaming calls by updating the `AsyncUnaryCall<TResponse>.ResponseAsync` or `AsyncClientStreamingCall<TRequest, TResponse>.ResponseAsync` value.

```csharp
public class ErrorHandlerInterceptor : Interceptor
{
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        var call = continuation(request, context);

        return new AsyncUnaryCall<TResponse>(
            HandleResponse(call.ResponseAsync),
            call.ResponseHeadersAsync,
            call.GetStatus,
            call.GetTrailers,
            call.Dispose);
    }

    private async Task<TResponse> HandleResponse<TResponse>(Task<TResponse> inner)
    {
        try
        {
            return await inner;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Custom error", ex);
        }
    }
}
```

The preceding code:

* Creates a new interceptor that overrides `AsyncUnaryCall`.
* Overriding `AsyncUnaryCall`:
  * Calls the `continuation` parameter to invoke the next item in the interceptor chain.
  * Creates a new `AsyncUnaryCall<TResponse>` instance based on the result of the continuation.
  * Wraps the `ResponseAsync` task using the `HandleResponse` method.
  * Awaits the response with `HandleResponse`. Awaiting the response allows logic to be added after the client received the response. By awaiting the response in a try-catch block, errors from calls can be logged.

For more information on how to create a client interceptor, see the [`ClientLoggerInterceptor.cs` example in the `grpc/grpc-dotnet` GitHub repository](https://github.com/grpc/grpc-dotnet/blob/master/examples/Interceptor/Client/ClientLoggerInterceptor.cs).

### Configure client interceptors

gRPC client interceptors are configured on a channel.

The following code:

* Creates a channel by using `GrpcChannel.ForAddress`.
* Uses the `Intercept` extension method to configure the channel to use the interceptor. Note that this method returns a `CallInvoker`. Strongly-typed gRPC clients can be created from an invoker just like a channel.
* Creates a client from the invoker. gRPC calls made by the client automatically execute the interceptor.

```csharp
using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var invoker = channel.Intercept(new ClientLoggerInterceptor());

var client = new Greeter.GreeterClient(invoker);
```

The `Intercept` extension method can be chained to configure multiple interceptors for a channel. Alternatively, there is an `Intercept` overload that accepts multiple interceptors. Any number of interceptors can be executed for a single gRPC call, as the following example demonstrates:

```csharp
var invoker = channel
    .Intercept(new ClientTokenInterceptor())
    .Intercept(new ClientMonitoringInterceptor())
    .Intercept(new ClientLoggerInterceptor());
```

Interceptors are invoked in reverse order of the chained `Intercept` extension methods. In the preceding code, interceptors are invoked in the following order:

1. `ClientLoggerInterceptor`
1. `ClientMonitoringInterceptor`
1. `ClientTokenInterceptor`

For information on how to configure interceptors with gRPC client factory, see <xref:grpc/clientfactory#configure-interceptors>.

## Server interceptors

gRPC server interceptors intercept incoming RPC requests. They provide access to the incoming request, the outgoing response, and the context for a server-side call.

`Interceptor` methods to override for server:

* `UnaryServerHandler`: Intercepts a unary RPC.
* `ClientStreamingServerHandler`: Intercepts a client-streaming RPC.
* `ServerStreamingServerHandler`: Intercepts a server-streaming RPC.
* `DuplexStreamingServerHandler`: Intercepts a bidirectional-streaming RPC.

### Create a server gRPC interceptor

The following code presents an example of an intercepting an incoming unary RPC:

```csharp
public class ServerLoggingInterceptor : Interceptor
{
    private readonly ILogger _logger;

    public ServerLoggingInterceptor(ILogger<ServerLoggingInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        _logger.LogInformation($"Starting receiving call. Type: {MethodType.Unary}. " +
            $"Method: {context.Method}.");
        try
        {
            return await continuation(request, context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error thrown by {context.Method}.");
            throw;
        }
    }
}
```

Overriding `UnaryServerHandler`:

* Intercepts an incoming unary call.
* Logs details about the call.
* Calls the `continuation` parameter passed into the method. This invokes the next interceptor in the chain or the service handler if this is the last interceptor.
* Logs any exceptions. Awaiting the continuation allows logic to be added after the service method has executed. By awaiting the continuation in a try-catch block, errors from methods can be logged.

The signature of both client and server interceptors methods are similar:

* `continuation` stands for a delegate for an incoming RPC calling the next interceptor in the chain or the service handler (if there is no interceptor left in the chain). Similar to client interceptors, you can call it any time and there's no need to return a response directly from the continuation delegate. Outbound logic can be added after a service handler has executed by awaiting the continuation.
* `context` carries metadata associated with the server-side call, such as request metadata, deadlines and cancellation, or RPC result.

For more information on how to create a server interceptor, see the [`ServerLoggerInterceptor.cs` example in the `grpc/grpc-dotnet` GitHub repository](https://github.com/grpc/grpc-dotnet/blob/master/examples/Interceptor/Server/ServerLoggerInterceptor.cs).

### Configure server interceptors

gRPC server interceptors are configured at startup. The following code:

* Adds gRPC to the app with `AddGrpc`.
* Configures `ServerLoggerInterceptor` for all services by adding it to the service option's `Interceptors` collection.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc(options =>
    {
        options.Interceptors.Add<ServerLoggerInterceptor>();
    });
}
```

An interceptor can also be configured for a specific service by using `AddServiceOptions` and specifying the service type.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddGrpc()
        .AddServiceOptions<GreeterService>(options =>
        {
            options.Interceptors.Add<ServerLoggerInterceptor>();
        });
}
```

Interceptors are run in the order that they're added to the `InterceptorCollection`. If both global and single service interceptors are configured, then globally-configured interceptors are run before those configured for a single service.

By default, gRPC server interceptors have a per-request lifetime. Overriding this behavior is possible through registering the interceptor type with [dependency injection](xref:fundamentals/dependency-injection). The following example registers the `ServerLoggerInterceptor` with a singleton lifetime:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc(options =>
    {
        options.Interceptors.Add<ServerLoggerInterceptor>();
    });

    services.AddSingleton<ServerLoggerInterceptor>();
}
```

### gRPC Interceptors versus Middleware

ASP.NET Core [middleware](xref:fundamentals/middleware/index) offers similar functionalities compared to interceptors in C-core-based gRPC apps. ASP.NET Core middleware and interceptors are conceptually similar. Both:

* Are used to construct a pipeline that handles a gRPC request.
* Allow work to be performed before or after the next component in the pipeline.
* Provide access to `HttpContext`:
  * In middleware, the `HttpContext` is a parameter.
  * In interceptors, the `HttpContext` can be accessed using the `ServerCallContext` parameter with the `ServerCallContext.GetHttpContext` extension method. This feature is specific to interceptors running in ASP.NET Core.

gRPC Interceptor differences from ASP.NET Core Middleware:

* Interceptors:
  * Operate on the gRPC layer of abstraction using the [`ServerCallContext`](https://grpc.io/grpc/csharp/api/Grpc.Core.ServerCallContext.html).
  * Provide access to:
    * The deserialized message sent to a call.
    * The message returned from the call before it's serialized.
  * Can catch and handle exceptions thrown from gRPC services.
* Middleware:
  * Runs for all HTTP requests.
  * Runs before gRPC interceptors.
  * Operates on the underlying HTTP/2 messages.
  * Can only access bytes from the request and response streams.

## Additional resources

* <xref:grpc/index>
* <xref:grpc/services>
* <xref:grpc/client>
* [Example of how to use gRPC on the client and server (`grpc/grpc-dotnet` GitHub repository)](https://github.com/grpc/grpc-dotnet/tree/master/examples#interceptor)
