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

### Configure gRPC

gRPC is enabled with the `AddGrpc` method:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Startup.cs?name=snippet&highlight=5)]

Each gRPC service is added to the routing pipeline through the `MapGrpcService` method:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Startup.cs?name=snippet&highlight=17-20)]

ASP.NET Core middlewares and features share the routing pipeline, therefore an app can be configured to serve additional request handlers. The additional request handlers, such as MVC controllers, work in parallel with the configured gRPC services.

## Integration with ASP.NET Core APIs

gRPC services have full access to the ASP.NET Core features such as [Dependency Injection](xref:fundamentals/dependency-injection) (DI) and [Logging](xref:fundamentals/logging). For example, the service implementation can resolve a logger service from the DI container via the constructor:

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

The gRPC API provides access to some underlying data of the HTTP/2 message, such as the method, host, header and trailers. Access is through the `ServerCallContext` argument passed to each gRPC method:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Services/GreeterService.cs?highlight=3-4&name=snippet)]

While this may be sufficient for many purposes, to ensure full access to ASP.NET Core APIs, the `HttpContext` representing the underlying HTTP/2 message can be accessed through the `GetHttpContext` extension method:

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Services/GreeterService.cs?highlight=5-10&name=snippet1)]

### Request body data rate limit

By default, the Kestrel server imposes a [minimum request body data rate](
<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinRequestBodyDataRate>). For client streaming and duplex streaming calls, this rate may not be satisfied and the connection may be timed out. The minimum request body data rate limit must be disabled when the gRPC service include client streaming and duplex streaming calls:

C:\GH\aspnet\docs\4\Docs\aspnetcore\tutorials\grpc\grpc-start\samples\GrpcStart\GrpcGreeter.Server\Program.cs

[!code-cs[](~/tutorials/grpc/grpc-start/samples/GrpcStart/GrpcGreeter.Server/Program.cs?highlight=8-17&name=snippet)]

## Additional resources

* <xref:index>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>
