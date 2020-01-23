---
title: gRPC in browser apps
author: jamesnk
description: Learn how to configure gRPC services on ASP.NET Core to be callable from browser apps using gRPC-Web.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 01/23/2020
uid: grpc/browser
---
# gRPC in browser apps

By [James Newton-King](https://twitter.com/jamesnk)

> [!IMPORTANT]
> **gRPC-Web support in .NET is experimental**
>
> gRPC-Web for .NET is an experimental project, not a commited product. We want to test that our approach to implementing gRPC-Web works, and get feedback on if this approach is useful to .NET developers compared to the traditional way of setting up gRPC-Web via a proxy. Please add your feedback at [https://github.com/grpc/grpc-dotnet](https://github.com/grpc/grpc-dotnet) to ensure we build something that developers love and are productive with.

It is not possible to call a HTTP/2 gRPC service from a browser-based app. [gRPC-Web](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-WEB.md) is a protocol that allows browser JavaScript and Blazor apps to call gRPC services. This article explains how to use gRPC-Web in .NET Core.

## Configure gRPC-Web in ASP.NET Core

gRPC services hosted in ASP.NET Core can be configured to support gRPC-Web alongside HTTP/2 gRPC. gRPC-Web does not require any changes to services. The only modification is startup configuration.

To enable gRPC-Web with an ASP.NET Core gRPC service:

1. Add a reference to the [Grpc.AspNetCore.Web](https://www.nuget.org/packages/Grpc.AspNetCore.Web) package.
2. Configure the app to use gRPC-Web by adding `AddGrpcWeb(...)` and `UseGrpcWeb()` to *Startup.cs*:

[!code-csharp[](~/grpc//browser/sample/Startup.cs?name=snippet_1&highlight=4,11,15)]

The preceding code:

* Adds the gRPC-Web middleware, `UseGrpcWeb`, after routing and before endpoints.
* Specifies the `endpoints.MapGrpcService<GreeterService>()` method supports gRPC-Web with `EnableGrpcWeb()`. Alternatively, configure all services to support gRPC-Web by adding `services.AddGrpcWeb(o => o.GrpcWebEnabled = true);` to ConfigureServices.

Some additional configuration may be required to call gRPC-Web from the browser, such as configuring ASP.NET Core to support CORS. For more information, see [support CORS](xref:security/cors).

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

1. Add a reference to the [Grpc.Net.Client.Web](https://www.nuget.org/packages/Grpc.Net.Client.Web) package.
2. Configure the channel to use the `GrpcWebHandler`:

[!code-csharp[](~/grpc/browser/sample/Handler.cs?name=snippet_1)]

The preceding code:

* Configures a channel to use gRPC-Web.
* Creates a client and makes a call using the channel.

The `GrpcWebHandler` has the following configuration options when created:

* **InnerHandler** - The underlying <xref:System.Net.Http.HttpMessageHandler> that will make the HTTP call, for example, `HttpClientHandler`.
* **Mode** - `GrpcWebMode` enum. `GrpcWebMode.GrpcWebText` configures content to be base64 encoded, which is required to support server streaming calls.
* **HttpVersion** - HTTP protocol `Version`. gRPC-Web doesn't require a specific protocol and won't specify one when making a request unless configured.

## Additional resources

* [gRPC for Web Clients GitHub project](https://github.com/grpc/grpc-web)
* <xref:security/cors>
