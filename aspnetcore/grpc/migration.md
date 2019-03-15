---
title: Migrating gRPC services from C-core to ASP.NET Core
author: juntaoluo
description: Learn how to move an existing C-core based gRPC app to run on top of ASP.NET Core stack.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 03/08/2019
uid: grpc/migration
---
# Migrating gRPC services from C-core to ASP.NET Core

By [John Luo](https://github.com/juntaoluo)

Due to implementation of the underlying stack, not all features work in the same way between [C-core based gRPC](https://grpc.io/blog/grpc-stacks) apps and ASP.NET Core based apps. This document highlights the key differences to note when migrating between the two stacks.

## gRPC service implementation lifetime

In the ASP.NET Core stack, gRPC services, by default, will be created with a Scoped lifetime as defined in the [Dependency Injection (DI)](xref:fundamentals/dependency-injection) document. In contrast, gRPC C-core by default binds to a service with a Singleton lifetime.

A Scoped lifetime allows the service implementation to resolve other services with Scoped lifetimes, such as `DBContext`, from the DI container through constructor injection. Since a new instance of the service implementation is constructed for each request, it's not possible to share state between requests via instance members on the implementation type. Instead, the expectation is to store shared states in a Singleton service in the DI container and resolve it in the constructor of the gRPC service implementation.

### Add a singleton service

To facilitate the transition from gRPC C-core implementation to ASP.NET Core, it is possible to change the service lifetime of the service implementation from Scoped to Singleton. This involves adding an instance of the service implementation to the DI container:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();
    services.AddSingleton(new GreeterService());
}
```

However, service implementation with Singleton lifetime will no longer be able to resolve Scoped services through constructor injection.

## Configure gRPC services options

In C-core based apps, settings such as `grpc.max_receive_message_length` and `grpc.max_send_message_length` are configured with `ChannelOption` when [constructing the `Server` instance](https://grpc.io/grpc/csharp/api/Grpc.Core.Server.html#Grpc_Core_Server__ctor_System_Collections_Generic_IEnumerable_Grpc_Core_ChannelOption__).

In ASP.NET Core, `GrpcServiceOptions` provides a way to configure these settings. The settings can be applied globally to all gRPC services or to an individual service implementation type. Options specified for individual service implementation types will override global settings when configured.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddGrpc(globalOptions =>
        {
            // Global settings
            globalOptions.SendMaxMessageSize = 4096
            globalOptions.ReceiveMaxMessageSize = 4096
        })
        .AddServiceOptions<GreeterService>(greeterOptions =>
        {
            // GreeterService settings. These will override global settings
            globalOptions.SendMaxMessageSize = 2048
            globalOptions.ReceiveMaxMessageSize = 2048
        })
}
```

## Logging

C-core based apps rely on the `GrpcEnvironment` to [configure the logger](https://grpc.io/grpc/csharp/api/Grpc.Core.GrpcEnvironment.html?q=size#Grpc_Core_GrpcEnvironment_SetLogger_Grpc_Core_Logging_ILogger_) for debugging purposes. The ASP.NET Core stack provides this functionality through the [logging API](xref:fundamentals/logging/index). For example a logger can be added to the gRPC service via constructor injection:

```csharp
public class GreeterService : Greeter.GreeterBase
{
    public GreeterService(ILogger<GreeterService> logger)
    {
    }
}
```

## HTTPS

C-core based apps configure HTTPS through the [`Server.Ports` property](https://grpc.io/grpc/csharp/api/Grpc.Core.Server.html#Grpc_Core_Server_Ports). A similar concept is used to configure servers in ASP.NET Core. For example, Kestrel uses [endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) for this functionality.

## Interceptors and Middlewares

ASP.NET Core [middlewares](xref:fundamentals/middleware/index) offers similar functionalities compared to interceptors in C-core based gRPC apps. Middlewares and interceptors are conceptually the same as both are used to construct a pipleline that handles a gRPC request. They both allow work to be performed before or after the next component in the pipeline. However, ASP.NET Core middlewares operate on the underlying HTTP/2 messages whereas interceptors operate on the gRPC layer of abstraction using the [`ServerCallContext`](https://grpc.io/grpc/csharp/api/Grpc.Core.ServerCallContext.html).

## Additional resources

* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/aspnetcore>
