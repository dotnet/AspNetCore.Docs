---
title: Migrating gRPC services from C-core to ASP.NET Core
author: juntaoluo
description: Learn how to move an existing C-core based gRPC app to run on top of ASP.NET Core stack.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 09/25/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/migration
---
# Migrating gRPC services from C-core to ASP.NET Core

By [John Luo](https://github.com/juntaoluo)

Due to the implementation of the underlying stack, not all features work in the same way between [C-core-based gRPC](https://grpc.io/blog/grpc-stacks) apps and ASP.NET Core-based apps. This document highlights the key differences for migrating between the two stacks.

## gRPC service implementation lifetime

In the ASP.NET Core stack, gRPC services, by default, are created with a [scoped lifetime](xref:fundamentals/dependency-injection#service-lifetimes). In contrast, gRPC C-core by default binds to a service with a [singleton lifetime](xref:fundamentals/dependency-injection#service-lifetimes).

A scoped lifetime allows the service implementation to resolve other services with scoped lifetimes. For example, a scoped lifetime can also resolve `DbContext` from the DI container through constructor injection. Using scoped lifetime:

* A new instance of the service implementation is constructed for each request.
* It isn't possible to share state between requests via instance members on the implementation type.
* The expectation is to store shared states in a singleton service in the DI container. The stored shared states are resolved in the constructor of the gRPC service implementation.

For more information on service lifetimes, see <xref:fundamentals/dependency-injection#service-lifetimes>.

### Add a singleton service

To facilitate the transition from a gRPC C-core implementation to ASP.NET Core, it's possible to change the service lifetime of the service implementation from scoped to singleton. This involves adding an instance of the service implementation to the DI container:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();
    services.AddSingleton(new GreeterService());
}
```

However, a service implementation with a singleton lifetime is no longer able to resolve scoped services through constructor injection.

## Configure gRPC services options

In C-core-based apps, settings such as `grpc.max_receive_message_length` and `grpc.max_send_message_length` are configured with `ChannelOption` when [constructing the Server instance](https://grpc.io/grpc/csharp/api/Grpc.Core.Server.html#Grpc_Core_Server__ctor_System_Collections_Generic_IEnumerable_Grpc_Core_ChannelOption__).

In ASP.NET Core, gRPC provides configuration through the `GrpcServiceOptions` type. For example, a gRPC service's the maximum incoming message size can be configured via `AddGrpc`. The following example changes the default `MaxReceiveMessageSize` of 4 MB to 16 MB:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc(options =>
    {
        options.MaxReceiveMessageSize = 16 * 1024 * 1024; // 16 MB
    });
}
```

For more information on configuration, see <xref:grpc/configuration>.

## Logging

C-core-based apps rely on the `GrpcEnvironment` to [configure the logger](https://grpc.io/grpc/csharp/api/Grpc.Core.GrpcEnvironment.html?q=size#Grpc_Core_GrpcEnvironment_SetLogger_Grpc_Core_Logging_ILogger_) for debugging purposes. The ASP.NET Core stack provides this functionality through the [Logging API](xref:fundamentals/logging/index). For example, a logger can be added to the gRPC service via constructor injection:

```csharp
public class GreeterService : Greeter.GreeterBase
{
    public GreeterService(ILogger<GreeterService> logger)
    {
    }
}
```

## HTTPS

C-core-based apps configure HTTPS through the [Server.Ports property](https://grpc.io/grpc/csharp/api/Grpc.Core.Server.html#Grpc_Core_Server_Ports). A similar concept is used to configure servers in ASP.NET Core. For example, Kestrel uses [endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) for this functionality.

## gRPC Interceptors vs Middleware

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
* <xref:grpc/basics>
* <xref:grpc/aspnetcore>
* <xref:tutorials/grpc/grpc-start>
