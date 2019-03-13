---
title: gRPC services with ASP.NET Core
author: juntaoluo
description: Learn the basic concepts when writing gRPC services with ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 03/08/2019
uid: grpc/aspnetcore
---
# gRPC services with ASP.NET Core

This document shows how to get started with gRPC services using ASP.NET Core. The topics covered here only apply to ASP.NET Core based apps.

[!INCLUDE[](~/includes/net-core-prereqs-all-3.0.md)]

## Get started with gRPC service in ASP.NET Core

[!INCLUDE[View or download sample code](~/includes/grpc/download.md)]

# [Visual Studio](#tab/visual-studio)

See [Get started with gRPC services](xref:tutorials/grpc/grpc-start) for detailed instructions on how to create a gRPC project.

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

Run `dotnet new grpc -o GrpcGreeter` from the command line.

---

## Add gRPC services to an ASP.NET Core app

gRPC requires the following packages:

* [Grpc.AspNetCore.Server](https://www.nuget.org/packages/Grpc.AspNetCore.Server)
* [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/) for protobuf message APIs.

<!-- recommend we don't show this. Dev's should know how to add these with the preceding instructions. The version number go stale very quickly. They're stale right now :)
[!code-xml[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/GrpcGreeter.Server.csproj?highlight=13-14)]
-->

### Configure `Startup`

gRPC is enabled in the `Startup.ConfigureServices` method through the `AddGrpc` method:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Startup.cs?highlight=18)]

Each gRPC service is added to the ASP.NET Core routing pipeline through the `MapGrpcService` method in `Startup.Configure`:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Startup.cs?highlight=29-32)]

Since ASP.NET Core middlewares and features share the routing pipeline, an application can be configured to serve additional request handlers such as MVC controllers in parallel with the configured gRPC services.

## Integration with ASP.NET Core APIs

gRPC services have full access to the ASP.NET Core features such as Dependency Injection (DI) and Logging. For example, the service implementation can resolve a logger service from the DI container via the constructor:

```csharp
public class GreeterService : Greeter.GreeterBase
{
    public GreeterService(ILogger<GreeterService> logger)
    {
    }
}
```

By default, the gRPC service implementation can resolve other DI services with any lifetime (Singleton, Scoped, or Transient).

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

### Request body data rate limit

By default, the Kestrel server imposes a [minimum request body data rate](
<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinRequestBodyDataRate>). For client streaming and duplex streaming calls, this rate may not be satisfied and the connection may be timed out. The minimum request body data rate limit must be disabled when the gRPC service include client streaming and duplex streaming calls:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel((context, options) =>
            {
                options.Limits.MinRequestBodyDataRate = null;
            });
        });
```

## Additional resources

* <xref:index>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>
