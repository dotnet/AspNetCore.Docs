---
title: Introduction to gRPC on ASP.NET Core
author: juntaoluo
description: Learn how to build gRPC services with Kestrel server and the ASP.NET Core stack.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 02/26/2019
uid: grpc/index
---
# Introduction to gRPC on ASP.NET Core

By [John Luo](https://github.com/juntaoluo)

gRPC is a language agnostic, high-performance Remote Procedure Call (RPC) framework incubated by the Cloud Native Computing Foundation (CNCF). For more on gRPC fundamentals, see the [gRPC documentation page](https://grpc.io/docs/). While a C# implementation is currently available on the official [gRPC page](https://grpc.io/docs/quickstart/csharp.html), the current implementation relies on the native library written in C (grpc C Core).

Work is currently in progress to provide a new implementation based on the Kestrel HTTP server and the ASP.NET Core stack that is fully managed. This document provides an introduction to building gRPC services with this new implementation.

[!INCLUDE[](~/includes/net-core-prereqs-all-3.0.md)]

## Create a gRPC project

# [Visual Studio](#tab/visual-studio)

See [Get started with gRPC Services](xref:tutorials/grpc/grpc-start) for detailed instructions on how to create a gRPC project.

# [Visual Studio Code](#tab/visual-studio-code)

Run `dotnet new grpc` from the command line.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Run `dotnet new grpc` from the command line.

Open the generated *.sln* file from Visual Studio for Mac.

---

## `.proto` file

gRPC uses a design-first approach to API development. Protocol buffers (protobuf) are used as the Interface Design Language (IDL) by default. As a result, `.proto` file serve as the definition of the gRPC service and messages sent between clients and servers. For more information on the syntax of protobuf files, visit the [official documentation (protobuf)](https://developers.google.com/protocol-buffers/docs/proto3)).

For example, the `greet.proto` file defines a `Greeter` service which defines a `SayHello` call that sends a `HelloRequest` message and receives a `HelloResponse` message:

[!code-proto[](~/tutorials/grpc/grpc-start/samples/GrpcStart/Protos/greet.proto)]

### Tooling support for `.proto` files

The tooling package (Grpc.Tools)[https://www.nuget.org/packages/Grpc.Tools/] is required to generate the C# assets from `.proto` files. The assets are generated on a as-needed basis every time the project is built. This dependency is required by both the server and client projects and can be added by using the Package Manager in Visual Studio or adding a `<PackageReference>` to your project file:

[!code-xml[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/GrpcGreeter.Server.csproj?highlight=16)]

### Add a `.proto` file to your project

The `.proto` file is included in your project by adding it to the `<ProtoBuf>` item group:

[!code-xml[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/GrpcGreeter.Server.csproj?highlight=8)]

### Generated C# assets

The tooling package will generate the C# types representing the messages defined in the included `.proto` files.

For server side assets, an abstract service base type is generated. The base type contains the definitions of all the gRPC calls contained in the `.proto` file. A concrete service implementation derives from this base type and implements the logic for the gRPC calls. For the `greet.proto` example described above, an abstract `GreeterBase` type that contains a virtual `SayHello` method is generated. A concrete implementation `GreeterService` then overrides the method and implements the logic handling the gRPC call.

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Services/GreeterService.cs?highlight=10,12-18)]

For client side assets, a concrete client type is generated. The gRPC calls in the `.proto` file are translated to methods on the concrete type which can be called. For the `greet.proto` example described above, a concrete `GreeterClient` type is generated that contains a `SayHello` method that can be called to initiate a gRPC to the server.

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Client/Program.cs?highlight=19,21)]

By default, both server and client assets are generated for each `.proto` file included in the `<ProtoBuf>` item group. To ensure only the server assets are generated in a server project, the `GrpcServices` attribute is set to `Server`.

[!code-xml[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/GrpcGreeter.Server.csproj?highlight=8)]

Similarly the attribute is set to `Client` in client projects:

[!code-xml[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Client/GrpcGreeter.Client.csproj?highlight=10)]

## Add gRPC services to your ASP.NET Core app

### Prerequisite packages

To obtain the gRPC APIs for ASP.NET Core projects, the [Grpc.AspNetCore.Server](https://www.nuget.org/packages/Grpc.AspNetCore.Server) package must be added to the project. The [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/) must also be added to ensure the APIs for protobuf messages are available.

[!code-xml[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/GrpcGreeter.Server.csproj?highlight=13-14)]

### Configure `Startup`

gRPC is enabled in the `Startup.ConfigureServices` method through the `AddGrpc` method:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Startup.cs?highlight=18)]

Each gRPC service is added to the ASP.NET Core routing pipeline through the `MapGrpc` method in `Startup.Configure`:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Startup.cs?highlight=29-32)]

Since ASP.NET Core middlewares and features share the routing pipeline, an application can be configured to serve additional request handlers such as MVC controllers in parallel with the configured gRPC services.

## Integration with ASP.NET Core APIs

gRPC services have full access to the ASP.NET Core features such as Dependency Injection (DI) and Logging. For example, the service implementation can resolve a logger from the DI container via the constructor:

```csharp
public class GreeterService : Greeter.GreeterBase
{
    public GreeterService(ILogger<GreeterService> logger)
    {
    }
}
```

By default, the service implementation can resolve services with Singleton and Scoped lifetimes.

### Resolve HttpContext in gRPC methods

The gRPC API provides access to some underlying data of the HTTP/2 message such as the method, host, header and trailers through the `ServerCallContext` argument passed to each gRPC method:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Services/GreeterService.cs?highlight=12)]

While this may be sufficient for many purposes, to ensure full access to ASP.NET Core APIs, the `HttpContext` representing the underlying HTTP/2 message can be accessed through the `GetHttpContext` extension method:

```csharp
public class GreeterService : Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        HttpContext httpContext = context.GetHttpContext();

        return Task.FromResult(new HelloReply
        {
            Message = "Using https: " + httpContext.Request.IsHttps
        });
    }
}
```

## gRPC service implementation lifetime

By default, services will be created with a Scoped lifetime as defined in the [Dependency Injection](xref:fundamentals/dependency-injection) document. This allows the service implementation to resolve services with Scoped lifetimes, such as DBContext, from the DI container through constructor injection.

> [!WARNING]
> The Scoped lifetime of service implementation in ASP.NET Core is a behavioral difference from grpc C Core. Since a new instance of the service implementation is constructed for each request, it's no longer possible to share state between requests via instance members on the implementation type. Instead, the expectation is to store shared states in a Singleton service in the DI container and resolve it in the constructor of the gRPC service implementation.

### Add a singleton service

To facilitate the transition from grpc C Core implementation to ASP.NET Core, it is possible to change the service lifetime of the service implementation from Scoped to Singleton. This involves adding an instance of the service implementation to the DI container:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();
    services.AddSingleton(new GreeterService());
}
```

However, service implementation with Singleton lifetime will no longer be able to resolve Scoped services through constructor injection.

## Configure gRPC services options

`GrpcServiceOptions` provides a way to modify the behavior of the gRPC service implementation instances. For example, it can be used to configure settings such as `SendMaxMessageSize` and `ReceiveMaxMessageSize`. These settings can be applied globally to all gRPC services or to an individual service implementation type:

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
            // Individual settings
            globalOptions.SendMaxMessageSize = 2048
            globalOptions.ReceiveMaxMessageSize = 2048
        })
}
```

Options specified for individual service implementation types will override global settings when configured.

## Additional resources

* <xref:index>
* <xref:tutorials/grpc/grpc-start>
