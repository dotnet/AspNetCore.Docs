---
title: gRPC services with ASP.NET Core
author: jamesnk
description: Learn the basic concepts when writing gRPC services with ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 09/21/2023
uid: grpc/aspnetcore
---
# gRPC services with ASP.NET Core

:::moniker range=">= aspnetcore-8.0"
This document shows how to get started with gRPC services using ASP.NET Core.

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-8.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-8.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-8.0.md)]

---

## Get started with gRPC service in ASP.NET Core

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/grpc/grpc-start/sample) ([how to download](xref:index#how-to-download-a-sample)).

# [Visual Studio](#tab/visual-studio)

See [Get started with gRPC services](xref:tutorials/grpc/grpc-start) for detailed instructions on how to create a gRPC project.

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

Run `dotnet new grpc -o GrpcGreeter` from the command line.

---

## Add gRPC services to an ASP.NET Core app

gRPC requires the [Grpc.AspNetCore](https://www.nuget.org/packages/Grpc.AspNetCore) package.

### Configure gRPC

In `Program.cs`:

* gRPC is enabled with the `AddGrpc` method.
* Each gRPC service is added to the routing pipeline through the `MapGrpcService` method.

[!code-csharp[](~/tutorials/grpc/grpc-start/sample/sample6/GrpcGreeter/Program.cs?highlight=9,14)]
[!INCLUDE[about the series](~/includes/code-comments-loc.md)]

ASP.NET Core middleware and features share the routing pipeline, therefore an app can be configured to serve additional request handlers. The additional request handlers, such as MVC controllers, work in parallel with the configured gRPC services.

## Server options

gRPC services can be hosted by all built-in ASP.NET Core servers.

> [!div class="checklist"]
>
> * Kestrel
> * TestServer
> * IIS&dagger;
> * HTTP.sys&dagger;

&dagger;Requires .NET 5 and Windows 11 Build 22000 or Windows Server 2022 Build 20348 or later.

For more information about choosing the right server for an ASP.NET Core app, see <xref:fundamentals/servers/index>.

## Kestrel

[Kestrel](xref:fundamentals/servers/kestrel) is a cross-platform web server for ASP.NET Core. Kestrel focuses on high performance and memory utilization, but it doesn't have some of the advanced features in HTTP.sys such as port sharing.

Kestrel gRPC endpoints:

* Require HTTP/2.
* Should be secured with [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246).

### HTTP/2

gRPC requires HTTP/2. gRPC for ASP.NET Core validates [HttpRequest.Protocol](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol%2A) is `HTTP/2`.

Kestrel [supports HTTP/2](xref:fundamentals/servers/kestrel/http2) on most modern operating systems. Kestrel endpoints are configured to support HTTP/1.1 and HTTP/2 connections by default.

### TLS

Kestrel endpoints used for gRPC should be secured with TLS. In development, an endpoint secured with TLS is automatically created at `https://localhost:5001` when the ASP.NET Core development certificate is present. No configuration is required. An `https` prefix verifies the Kestrel endpoint is using TLS.

In production, TLS must be explicitly configured. In the following `appsettings.json` example, an HTTP/2 endpoint secured with TLS is provided:

[!code-json[](~/grpc/aspnetcore/sample/appsettings.json?highlight=4)]

Alternatively, Kestrel endpoints can be configured in `Program.cs`:

[!code-csharp[](~/grpc/aspnetcore/sample-6/Program.cs?highlight=5&name=snippet)]

For more information on enabling TLS with Kestrel, see [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints#listenoptionsusehttps).

### Protocol negotiation

TLS is used for more than securing communication. The TLS [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) handshake is used to negotiate the connection protocol between the client and the server when an endpoint supports multiple protocols. This negotiation determines whether the connection uses HTTP/1.1 or HTTP/2.

If an HTTP/2 endpoint is configured without TLS, the endpoint's [ListenOptions.Protocols](xref:fundamentals/servers/kestrel/endpoints#listenoptionsprotocols) must be set to `HttpProtocols.Http2`. An endpoint with multiple protocols, such as `HttpProtocols.Http1AndHttp2` for example, can't be used without TLS because there's no negotiation. All connections to the unsecured endpoint default to HTTP/1.1, and gRPC calls fail.

For more information on enabling HTTP/2 and TLS with Kestrel, see [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel/endpoints).

> [!NOTE]
> macOS doesn't support ASP.NET Core gRPC with TLS before .NET 8. Additional configuration is required to successfully run gRPC services on macOS when using .NET 7 or earlier. For more information, see [Unable to start ASP.NET Core gRPC app on macOS](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos).

## IIS

[Internet Information Services (IIS)](xref:host-and-deploy/iis/index) is a flexible, secure and manageable Web Server for hosting web apps, including ASP.NET Core. .NET 5 and Windows 11 Build 22000 or Windows Server 2022 Build 20348 or later are required to host gRPC services with IIS.

IIS must be configured to use TLS and HTTP/2. For more information, see <xref:host-and-deploy/iis/protocols>.

## HTTP.sys

[HTTP.sys](xref:fundamentals/servers/httpsys) is a web server for ASP.NET Core that only runs on Windows. .NET 5 and Windows 11 Build 22000 or Windows Server 2022 Build 20348 or later are required to host gRPC services with HTTP.sys.

HTTP.sys must be configured to use TLS and HTTP/2. For more information, see  [HTTP.sys web server HTTP/2 support](xref:fundamentals/servers/httpsys#http2-support).

## Host gRPC in non-ASP.NET Core projects

An ASP.NET Core gRPC server is typically created from the gRPC template. The project file created by the template uses `Microsoft.NET.SDK.Web` as the SDK:

[!code-xml[](~/grpc/aspnetcore/Server-web.csproj?highlight=1)]

The `Microsoft.NET.SDK.Web` SDK value automatically adds a reference to the ASP.NET Core framework. The reference allows the app to use ASP.NET Core types required to host a server.

You can add a gRPC server to non-ASP.NET Core projects with the following project file settings:

[!code-xml[](~/grpc/aspnetcore/Server.csproj?highlight=1,7)]

The preceding project file:

* Doesn't use `Microsoft.NET.SDK.Web` as the SDK.
* Adds a framework reference to `Microsoft.AspNetCore.App`.
  * The framework reference allows non-ASP.NET Core apps, such as Windows Services, WPF apps, or WinForms apps to use ASP.NET Core APIs.
  * The app can now use ASP.NET Core APIs to start an ASP.NET Core server.
* Adds gRPC requirements:
  * NuGet package reference to [`Grpc.AspNetCore`](https://www.nuget.org/packages/Grpc.AspNetCore).
  * `.proto` file.

For more information about using the `Microsoft.AspNetCore.App` framework reference, see [Use the ASP.NET Core shared framework](xref:fundamentals/target-aspnetcore#use-the-aspnet-core-shared-framework).

## Integration with ASP.NET Core APIs

gRPC services have full access to the ASP.NET Core features such as [Dependency Injection](xref:fundamentals/dependency-injection) (DI) and [Logging](xref:fundamentals/logging/index). For example, the service implementation can resolve a logger service from the DI container via the constructor:

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

The gRPC API provides access to some HTTP/2 message data, such as the method, host, header, and trailers. Access is through the `ServerCallContext` argument passed to each gRPC method:

[!code-csharp[](~/grpc/aspnetcore/sample/GrcpService/GreeterService.cs?highlight=3-4&name=snippet)]

`ServerCallContext` doesn't provide full access to `HttpContext` in all ASP.NET APIs. The `GetHttpContext` extension method provides full access to the `HttpContext` representing the underlying HTTP/2 message in ASP.NET APIs:

[!code-csharp[](~/grpc/aspnetcore/sample/GrcpService/GreeterService2.cs?highlight=6-7&name=snippet)]

## Additional resources

* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:fundamentals/servers/kestrel>

:::moniker-end

[!INCLUDE[](~/grpc/aspnetcore/includes/aspnetcore7.md)]

[!INCLUDE[](~/grpc/aspnetcore/includes/aspnetcore6.md)]

[!INCLUDE[](~/grpc/aspnetcore/includes/aspnetcore5.md)]

[!INCLUDE[](~/grpc/aspnetcore/includes/aspnetcore3_1.md)]

[!INCLUDE[](~/grpc/aspnetcore/includes/aspnetcore3.md)]
