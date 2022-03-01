---
title: gRPC interceptors on .NET
author: erni27
ms.author: jamesnk
description: Learn how to use gRPC interceptors on .NET.
monikerRange: '>= aspnetcore-3.0'
ms.date: 02/26/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/interceptors
---
# gRPC interceptors on .NET

By [Ernest Nguyen](https://github.com/erni27)

Interceptors are a gRPC concept that allows apps to interact with incoming or outgoing gRPC calls. They offer a way to enrich the request processing pipeline.

Interceptors are configured for a channel or service and executed automatically for each gRPC call. Since interceptors are transparent to the user's application logic, they are an excellent solution for common cases like logging, monitoring, authentication, validation, etc.

## `Interceptor` type

Interceptors can be implemented for both gRPC servers and clients by creating a class that inherits from `Interceptor` type.

```csharp
public class ExampleInterceptor : Interceptor
{
}
```

By default, the `Interceptor` base class doesn't do anything. Add behavior to an interceptor by overriding the appropriate methods on an interceptor implementation.

## Client interceptors

gRPC client interceptors intercept outgoing RPC invocations. They provide access to the sent request, the incoming response, and the context for a client-side call.

`Interceptor` methods to override for client:

* `BlockingUnaryCall`- intercepts a blocking invocation of an unary RPC.
* `AsyncUnaryCall` - intercepts an asynchronous invocation of an unary RPC.
* `AsyncClientStreamingCall` - intercepts an asynchronous invocation of a client streaming RPC.
* `AsyncServerStreamingCall` - intercepts an asynchronous invocation of a server streaming RPC.
* `AsyncDuplexStreamingCall` - intercepts an asynchronous invocation of a bidirectional streaming RPC.

> [!WARNING]
> Although both `BlockingUnaryCall` and `AsyncUnaryCall` refer to unary RPCs, they can't be used interchangeably. A blocking invocation would not be intercepted by `AsyncUnaryCall` and an asynchronous one by `BlockingUnaryCall`.

### Create a client gRPC interceptor

The following code presents an example of intercepting an asynchronous invocation of a simple remote call.

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
        _logger.LogInformation($"Starting call. Type: {context.Method.Type}. Method: {context.Method.Name}.");
        return continuation(request, context);
    }
}
```

Overridden `AsyncUnaryCall` does the following:

* Intercepts an asynchronous unary call.
* Logs details about the call.
* Calls the `continuation` parameter passed into the method. This invokes the next interceptor in the chain or the underlying call invoker if this is the last interceptor.

Methods on `Interceptor` for each kind of service method have different signatures. However, the concept behind `continuation` and `context` parameters remains the same:

* `continuation` is a delegate which invokes the next interceptor in the chain or the underlying call invoker (if there is no interceptor left in the chain). It is not an error to call it zero or multiple times. Interceptors don't even have to return call representation (`AsyncUnaryCall` in case of unary RPC) returned from `continuation` delegate. Omitting the delegate call and returning your own instance of call representation breaks the interceptors' chain and returns the associated response immediately.
* `context` carries scoped-values associated with the client side call. You can use it to pass metadata like security principals, credentials or tracing data. Moreover, `context` carries information about deadlines and cancellation. For more, see [Reliable gRPC services with deadlines and cancellation](xref:grpc/deadlines-cancellation#deadlines>).

For more information on how to create a client interceptor, see an [example](https://github.com/grpc/grpc-dotnet/blob/master/examples/Interceptor/Client/ClientLoggerInterceptor.cs).

### Configure client interceptors

gRPC client interceptors are configured on a channel.

The following code:

* Creates a channel by using `GrpcChannel.ForAddress`.
* Uses the `Intercept(...)` extension method to configure the channel to use the interceptor. Note that this method returns a `CallInvoker`. Strongly typed gRPC clients may be created from an invoker just like a channel.
* Creates a client from the invoker. gRPC calls made by the client automatically execute the interceptor.

```csharp
using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var invoker = channel.Intercept(new ClientLoggerInterceptor());

var client = new Greeter.GreeterClient(invoker);
```

The `Intercept(...)` extension method can be chained together to configure multiple interceptors for a channel. Alternatively, there is an `Intercept` overload that accepts multiple interceptors. Any number of interceptors can be executed for a single gRPC call.

```csharp
var invoker = channel
    .Intercept(new ClientTokenInterceptor())
    .Intercept(new ClientMonitoringInterceptor())
    .Intercept(new ClientLoggerInterceptor());
```

The order of the parameters matters so in the preceding code, interceptors will be invoked as follow `ClientLoggerInterceptor`, `ClientMonitoringInterceptor` and then `ClientTokenInterceptor`.

For information on how to configure interceptors with gRPC client factory, see [Configure Interceptors](xref:grpc/clientfactory#configure-interceptors).

## Server interceptors

gRPC server interceptors intercept incoming RPC requests. They provide access to the incoming request, the outgoing response and the context for a server-side call.

`Interceptor` methods to override for server:

* `UnaryServerHandler` - intercepts a unary RPC.
* `ClientStreamingServerHandler` - intercepts a client streaming RPC.
* `ServerStreamingServerHandler` - intercepts a server streaming RPC.
* `DuplexStreamingServerHandler` - intercepts a bidirectional streaming RPC.

### Create a server gRPC interceptor

The following code presents an example of an intercepting an incoming unary RPC.

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
        _logger.LogInformation($"Starting receiving call. Type: {MethodType.Unary}. Method: {context.Method}.");
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

Overridden `UnaryServerHandler` does the following:

* Intercepts an incoming unary call.
* Logs details about the call.
* Calls the `continuation` parameter passed into the method. This invokes the next interceptor in the chain or the service handler if this is the last interceptor.
* Logs an exception if occured.

Note that the signature of both client and server interceptors methods are similar.

* `continuation` stands for a delegate for an incoming RPC calling the next interceptor in the chain or the service handler (if there is no interceptor left in the chain). Like for the client interceptors, you can call it any time and there is no need to return a response directly from the continuation delegate.
* `context` carries metadata associated with the server-side call like request metadata, deadlines and cancellation or RPC result.

For more information on how to create a server interceptor, see an [example](https://github.com/grpc/grpc-dotnet/blob/master/examples/Interceptor/Server/ServerLoggerInterceptor.cs).

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

Interceptors are run in order they were added to `InterceptorCollection`. If both global and single service interceptors are configured, then globally configured interceptors are run before those configured for a single service.

By default, gRPC server interceptors have a per-request lifetime. Overriding this behavior is possible through registering the interceptor type with [DI](xref:fundamentals/dependency-injection).

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

### gRPC Interceptors vs Middleware

ASP.NET Core [middleware](xref:fundamentals/middleware/index) offers similar functionalities compared to interceptors in C-core-based gRPC apps. ASP.NET Core middleware and interceptors are conceptually similar. Both:

* Are used to construct a pipeline that handles a gRPC request.
* Allow work to be performed before or after the next component in the pipeline.
* Provide access to `HttpContext`:
  * In middleware the `HttpContext` is a parameter.
  * In interceptors the `HttpContext` can be accessed using the `ServerCallContext` parameter with the `ServerCallContext.GetHttpContext` extension method. Note that this feature is specific to interceptors running in ASP.NET Core.

gRPC Interceptor differences from ASP.NET Core Middleware:

* Interceptors:
  * Operate on the gRPC layer of abstraction using the [ServerCallContext](https://grpc.io/grpc/csharp/api/Grpc.Core.ServerCallContext.html).
  * Provide access to:
    * The deserialized message sent to a call.
    * The message being returned from the call before it is serialized.
  * Can catch and handle exceptions thrown from gRPC services.
* Middleware:
  * Runs before gRPC interceptors.
  * Operates on the underlying HTTP/2 messages.
  * Can only access bytes from the request and response streams.

## Additional resources

* <xref:grpc/index>
* <xref:grpc/services>
* <xref:grpc/client>
* [Example how to use gRPC on the client and server](https://github.com/grpc/grpc-dotnet/tree/master/examples#interceptor)
