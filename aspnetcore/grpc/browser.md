---
title: Use gRPC in browser apps
author: jamesnk
description: Learn how to configure gRPC services on ASP.NET Core to be callable from browser apps using gRPC-Web.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 02/16/2020
uid: grpc/browser
---
# Use gRPC in browser apps

By [James Newton-King](https://twitter.com/jamesnk)

> [!IMPORTANT]
> **gRPC-Web support in .NET is experimental**
>
> gRPC-Web for .NET is an experimental project, not a committed product. We want to:
>
> * Test that our approach to implementing gRPC-Web works.
> * Get feedback on if this approach is useful to .NET developers compared to the traditional way of setting up gRPC-Web via a proxy.
>
> Please leave feedback at [https://github.com/grpc/grpc-dotnet](https://github.com/grpc/grpc-dotnet) to ensure we build something that developers like and are productive with.

It is not possible to call a HTTP/2 gRPC service from a browser-based app. [gRPC-Web](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-WEB.md) is a protocol that allows browser JavaScript and Blazor apps to call gRPC services. This article explains how to use gRPC-Web in .NET Core.

## Configure gRPC-Web in ASP.NET Core

gRPC services hosted in ASP.NET Core can be configured to support gRPC-Web alongside HTTP/2 gRPC. gRPC-Web does not require any changes to services. The only modification is startup configuration.

To enable gRPC-Web with an ASP.NET Core gRPC service:

* Add a reference to the [Grpc.AspNetCore.Web](https://www.nuget.org/packages/Grpc.AspNetCore.Web) package.
* Configure the app to use gRPC-Web by adding `AddGrpcWeb` and `UseGrpcWeb` to *Startup.cs*:

[!code-csharp[](~/grpc/browser/sample/Startup.cs?name=snippet_1&highlight=10,14)]

The preceding code:

* Adds the gRPC-Web middleware, `UseGrpcWeb`, after routing and before endpoints.
* Specifies the `endpoints.MapGrpcService<GreeterService>()` method supports gRPC-Web with `EnableGrpcWeb`. 

Alternatively, configure all services to support gRPC-Web by adding `services.AddGrpcWeb(o => o.GrpcWebEnabled = true);` to ConfigureServices.

[!code-csharp[](~/grpc/browser/sample/AllServicesSupportExample_Startup.cs?name=snippet_1&highlight=6,13)]

### gRPC-Web and CORS

Browser security prevents a web page from making requests to a different domain than the one that served the web page. This restriction applies to making gRPC-Web calls with browser apps. For example, a browser app served by `https://www.contoso.com` is blocked from calling gRPC-Web services hosted on `https://services.contoso.com`. Cross Origin Resource Sharing (CORS) can be used to relax this restriction.

To allow your browser app to make cross-origin gRPC-Web calls, set up [CORS in ASP.NET Core](xref:security/cors). Use the built-in CORS support, and expose gRPC-specific headers with <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithExposedHeaders*>.

[!code-csharp[](~/grpc/browser/sample/CORS_Startup.cs?name=snippet_1&highlight=5-11,19,24)]

The preceding code:

* Calls `AddCors` to add CORS services and configures a CORS policy that exposes gRPC-specific headers.
* Calls `UseCors` to add the CORS middleware after routing and before endpoints.
* Specifies the `endpoints.MapGrpcService<GreeterService>()` method supports CORS with `RequiresCors`.

## Call gRPC-Web from the browser

Browser apps can use gRPC-Web to call gRPC services. There are some requirements and limitations when calling gRPC services with gRPC-Web from the browser:

* The server must have been configured to support gRPC-Web.
* Client streaming and bidirectional streaming calls aren't supported. Server streaming is supported.
* Calling gRPC services on a different domain requires [CORS](xref:security/cors) to be configured on the server.

### JavaScript gRPC-Web client

There is a JavaScript gRPC-Web client. For instructions on how to use gRPC-Web from JavaScript, see [write JavaScript client code with gRPC-Web](https://github.com/grpc/grpc-web/tree/master/net/grpc/gateway/examples/helloworld#write-client-code).

### Configure gRPC-Web with the .NET gRPC client

The .NET gRPC client can be configured to make gRPC-Web calls. This is useful for [Blazor WebAssembly](xref:blazor/index#blazor-webassembly) apps, which are hosted in the browser and have the same HTTP limitations of JavaScript code. Calling gRPC-Web with a .NET client is [the same as HTTP/2 gRPC](xref:grpc/client). The only modification is how the channel is created.

To use gRPC-Web:

* Add a reference to the [Grpc.Net.Client.Web](https://www.nuget.org/packages/Grpc.Net.Client.Web) package.
* Ensure the reference to [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) package is 2.27.0 or greater.
* Configure the channel to use the `GrpcWebHandler`:

[!code-csharp[](~/grpc/browser/sample/Handler.cs?name=snippet_1)]

The preceding code:

* Configures a channel to use gRPC-Web.
* Creates a client and makes a call using the channel.

The `GrpcWebHandler` has the following configuration options when created:

* **InnerHandler**: The underlying <xref:System.Net.Http.HttpMessageHandler> that makes the gRPC HTTP request, for example, `HttpClientHandler`.
* **Mode**: An enumeration type that specifies whether the gRPC HTTP request request `Content-Type` is `application/grpc-web` or `application/grpc-web-text`.
    * `GrpcWebMode.GrpcWeb` configures content to be sent without encoding. Default value.
    * `GrpcWebMode.GrpcWebText` configures content to be base64 encoded. Required for server streaming calls in browsers.
* **HttpVersion**: HTTP protocol `Version` used to set [HttpRequestMessage.Version](xref:System.Net.Http.HttpRequestMessage.Version) on the underlying gRPC HTTP request. gRPC-Web doesn't require a specific version and doesn't override the default unless specified.

> [!IMPORTANT]
> Generated gRPC clients have sync and async methods for calling unary methods. For example, `SayHello` is sync and `SayHelloAsync` is async. Calling a sync method in a Blazor WebAssembly app will cause the app to become unresponsive. Async methods must always be used in Blazor WebAssembly.

## Additional resources

* [gRPC for Web Clients GitHub project](https://github.com/grpc/grpc-web)
* <xref:security/cors>
