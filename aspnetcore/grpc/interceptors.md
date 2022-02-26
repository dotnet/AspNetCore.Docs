---
title: gRPC interceptors on .NET
author: erni27
description: Learn how to use gRPC interceptors on .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author:
ms.date: 02/26/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/interceptors
---
# gRPC interceptors on .NET

By [Ernest Nguyen](https://github.com/erni27)

Interceptors allow you to intercept incoming or outgoing gRPC requests. They offer a way to enrich the request processing pipeline. Since they are transparent for the user's application logic and once applied are triggered automatically, interceptors became a perfect solution for common cases like logging, monitoring, authentication, validation, etc.

Interceptors can be implemented for both gRPC servers and clients by creating a class that inherits from `Interceptor` type.

```csharp
public class ExemplaryInterceptor : Interceptor
{
}
```

By default `Interceptor` base class doesn't do anything. Its virtual methods just passes the calls through. Thus, implementing your own interceptor comes down to overriding appropriate methods.

## Client interceptors

gRPC client interceptors intercept outgoing RPC invocations. They provide access to the sent request, the incoming response and the context for a client-side call.

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
public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
    TRequest request,
    ClientInterceptorContext<TRequest, TResponse> context,
    AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
{
    LogCall(context.Method);
    AddCallerMetadata(ref context);

    var call = continuation(request, context);

    return new AsyncUnaryCall<TResponse>(HandleResponse(call.ResponseAsync), call.ResponseHeadersAsync, call.GetStatus, call.GetTrailers, call.Dispose);
}
```

Overridden `AsyncUnaryCall` does the following:
* Logs call to the console.
* Adds caller metadata to call headers.
* Handles response in a custom way (logs if an exception occurred).

Although the interceptors for each kind of service method are slightly different, the concept behind `continuation` and `context` parameters remains the same.

* `continuation` is a delegate which invokes the next interceptor in the chain or the underlying call invoker (if there is no interceptor left in the chain). It is not an error to call it zero or multiple times. Interceptors don't even have to return call representation (`AsyncUnaryCall` in case of unary RPC) returned from `continuation` delegate. Notice that in the preceding example a new instance of call representation is constructed. Omitting the delegate call and returning your own instance of call representation breaks the interceptors' chain and returns the associated response immediately.
* `context` carries scoped-values associated with the client side call. You can use it to pass metadata like security principals, credentials or tracing data. Moreover, `context` carries information about deadlines and cancellation. For more information, see [Reliable gRPC services with deadlines and cancellation](xref:grpc/deadlines-cancellation#deadlines>).

The following code shows how to add caller metadata through the context.

```csharp
private void AddCallerMetadata<TRequest, TResponse>(ref ClientInterceptorContext<TRequest, TResponse> context)
    where TRequest : class
    where TResponse : class
{
    var headers = context.Options.Headers;

    // Call doesn't have a headers collection to add to.
    // Need to create a new context with headers for the call.
    if (headers == null)
    {
        headers = new Metadata();
        var options = context.Options.WithHeaders(headers);
        context = new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host, options);
    }

    // Add caller metadata to call headers
    headers.Add("caller-user", Environment.UserName);
    headers.Add("caller-machine", Environment.MachineName);
    headers.Add("caller-os", Environment.OSVersion.ToString());
}
```

`LogCall`, `AddCallerMetadata` and `HandleResponse` methods are private methods embedded in the exemplary `ClientLoggerInterceptor` class. For complete implementation, see an [example of client interceptor](https://github.com/grpc/grpc-dotnet/blob/master/examples/Interceptor/Client/ClientLoggerInterceptor.cs).

### Configure client interceptors

gRPC client interceptors are configured by creating a call invoker from a channel and then 
creating a client from that invoker.

The following code:
* Creates a channel by using `GrpcChannel.ForAddress`.
* Creates an invoker by using `Intercept` method on the created channel.
* Creates a client from the invoker.

```csharp
using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var invoker = channel.Intercept(new ClientLoggerInterceptor());

var client = new Greeter.GreeterClient(invoker);
```

A call invoker intercepts the channel with the given interceptor. If you want to intercept the channel with multiple interceptors use overloaded `Intercept` method. Any number of interceptors may be used for a single RPC.

```csharp
var invoker = channel.Intercept(
    new ClientLoggerInterceptor(),
    new ClientMonitoringInterceptor(),
    new ClientTokenInterceptor());
```

The order of the parameters matters so in the preceding code, interceptors will be invoked as follow `ClientLoggerInterceptor`, `ClientMonitoringInterceptor` and then `ClientTokenInterceptor`.

The same result can be achieved by building a chain of interceptors.

```csharp
var invoker = channel
    .Intercept(new ClientTokenInterceptor())
    .Intercept(new ClientMonitoringInterceptor())
    .Intercept(new ClientLoggerInterceptor());
```

For information on how to configure interceptors with gRPC client factory, see [Configure Channel and Interceptors](xref:grpc/clientfactory#configure-channel-and-interceptors).

## Server interceptors

gRPC server interceptors intercept incoming RPC requests. They provide access to the incoming request, the outgoing response and the context for a server-side call.

`Interceptor` methods to override for server:
* `UnaryServerHandler` - intercepts an incoming unary RPC.
* `ClientStreamingServerHandler` - intercepts a client streaming RPC.
* `ServerStreamingServerHandler` - intercepts a server streaming RPC.
* `DuplexStreamingServerHandler` - intercepts a bidirectional streaming RPC.

### Create a server gRPC interceptor

The following code presents an example of an intercepting an incoming unary RPC.

```csharp
public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
    TRequest request,
    ServerCallContext context,
    UnaryServerMethod<TRequest, TResponse> continuation)
{
    LogCall<TRequest, TResponse>(MethodType.Unary, context);

    try
    {
        return await continuation(request, context);
    }
    catch (Exception ex)
    {
        // Note: The gRPC framework also logs exceptions thrown by handlers to .NET Core logging.
        _logger.LogError(ex, $"Error thrown by {context.Method}.");

        throw;
    }
}
```

Note that the signature of both client and server interceptors methods are similar.

* `continuation` stands for a delegate for an incoming RPC calling the next interceptor in the chain or the service handler (if there is no interceptor left in the chain). Like for the client interceptors, you can call it any time and there is no need to return a response directly from the continuation delegate.
* `context` carries metadata associated with the server-side call like request metadata, deadlines and cancellation or RPC result.

The following code shows how to retrieve request metadata from the context.

```csharp
private void LogCall<TRequest, TResponse>(MethodType methodType, ServerCallContext context)
    where TRequest : class
    where TResponse : class
{
    _logger.LogWarning($"Starting call. Type: {methodType}. Request: {typeof(TRequest)}. Response: {typeof(TResponse)}");
    WriteMetadata(context.RequestHeaders, "caller-user");
    WriteMetadata(context.RequestHeaders, "caller-machine");
    WriteMetadata(context.RequestHeaders, "caller-os");

    void WriteMetadata(Metadata headers, string key)
    {
        var headerValue = headers.SingleOrDefault(h => h.Key == key)?.Value;
        _logger.LogWarning($"{key}: {headerValue ?? "(unknown)"}");
    }
}
```

For complete implementation of introduced `ServerLoggerInterceptor`, see an [example of server interceptor](https://github.com/grpc/grpc-dotnet/blob/master/examples/Interceptor/Server/ServerLoggerInterceptor.cs).

### Configure server interceptors

gRPC server interceptors can be configured for all services by providing an appropriate options delegate to the `AddGrpc` call in `Startup.ConfigureServices`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc(options =>
    {
        options.Interceptors.Add<ServerLoggerInterceptor>();
    });
}
```

If a particular interceptor is dedicated for one specific service, then configure options for a single service.

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
