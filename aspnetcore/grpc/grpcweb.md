---
title: gRPC-Web in ASP.NET Core gRPC apps
author: jamesnk
description: Learn how to configure gRPC services on ASP.NET Core to be callable from browser apps using gRPC-Web.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 06/30/2020
uid: grpc/grpcweb
---
# gRPC-Web in ASP.NET Core gRPC apps

By [James Newton-King](https://twitter.com/jamesnk)

Learn how to configure an existing ASP.NET Core gRPC service to be callable from browser apps, using the [gRPC-Web](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-WEB.md) protocol. gRPC-Web allows browser JavaScript and Blazor apps to call gRPC services. It's not possible to call an HTTP/2 gRPC service from a browser-based app. gRPC services hosted in ASP.NET Core can be configured to support gRPC-Web alongside HTTP/2 gRPC.

For instructions on adding a gRPC service to an existing ASP.NET Core app, see [Add gRPC services to an ASP.NET Core app](xref:grpc/aspnetcore#add-grpc-services-to-an-aspnet-core-app).

For instructions on creating a gRPC project, see <xref:tutorials/grpc/grpc-start>.

## ASP.NET Core gRPC-Web versus Envoy

There are two choices for how to add gRPC-Web to an ASP.NET Core app:

* Support gRPC-Web alongside gRPC HTTP/2 in ASP.NET Core. This option uses middleware provided by the [`Grpc.AspNetCore.Web`](https://www.nuget.org/packages/Grpc.AspNetCore.Web) package.
* Use the [Envoy proxy's](https://www.envoyproxy.io/) gRPC-Web support to translate gRPC-Web to gRPC HTTP/2. The translated call is then forwarded onto the ASP.NET Core app.

There are pros and cons to each approach. If an app's environment is already using Envoy as a proxy, it might make sense to also use Envoy to provide gRPC-Web support. For a basic solution for gRPC-Web that only requires ASP.NET Core, `Grpc.AspNetCore.Web` is a good choice.

## Configure gRPC-Web in ASP.NET Core

gRPC services hosted in ASP.NET Core can be configured to support gRPC-Web alongside HTTP/2 gRPC. gRPC-Web doesn't require any changes to services. The only modification is startup configuration.

To enable gRPC-Web with an ASP.NET Core gRPC service:

* Add a reference to the [`Grpc.AspNetCore.Web`](https://www.nuget.org/packages/Grpc.AspNetCore.Web) package.
* Configure the app to use gRPC-Web by adding `UseGrpcWeb` and `EnableGrpcWeb` to `Startup.cs`:

[!code-csharp[](~/grpc/grpcweb/sample/Startup.cs?name=snippet_1&highlight=10,14)]

The preceding code:

* Adds the gRPC-Web middleware, `UseGrpcWeb`, after routing and before endpoints.
* Specifies that the `endpoints.MapGrpcService<GreeterService>()` method supports gRPC-Web with `EnableGrpcWeb`. 

Alternatively, the gRPC-Web middleware can be configured so that all services support gRPC-Web by default and `EnableGrpcWeb` isn't required. Specify `new GrpcWebOptions { DefaultEnabled = true }` when the middleware is added.

[!code-csharp[](~/grpc/grpcweb/sample/AllServicesSupportExample_Startup.cs?name=snippet_1&highlight=12)]

> [!NOTE]
> There is a known issue that causes gRPC-Web to fail when [hosted by HTTP.sys](xref:fundamentals/servers/httpsys) in .NET Core 3.x.
>
> A workaround to get gRPC-Web working on HTTP.sys is available in [Grpc-web experimental and UseHttpSys()? (grpc/grpc-dotnet #853)](https://github.com/grpc/grpc-dotnet/issues/853#issuecomment-610078202).

### gRPC-Web and CORS

Browser security prevents a web page from making requests to a different domain than the one that served the web page. This restriction applies to making gRPC-Web calls with browser apps. For example, a browser app served by `https://www.contoso.com` is blocked from calling gRPC-Web services hosted on `https://services.contoso.com`. Cross-Origin Resource Sharing (CORS) can be used to relax this restriction.

To allow a browser app to make cross-origin gRPC-Web calls, set up [CORS in ASP.NET Core](xref:security/cors). Use the built-in CORS support, and expose gRPC-specific headers with <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithExposedHeaders%2A>.

[!code-csharp[](~/grpc/grpcweb/sample/CORS_Startup.cs?name=snippet_1&highlight=5-11,19,24)]

The preceding code:

* Calls `AddCors` to add CORS services and configure a CORS policy that exposes gRPC-specific headers.
* Calls `UseCors` to add the CORS middleware after routing configuration and before endpoints configuration.
* Specifies that the `endpoints.MapGrpcService<GreeterService>()` method supports CORS with `RequireCors`.

### gRPC-Web and streaming

Traditional gRPC over HTTP/2 supports client, server and bidirectional streaming. gRPC-Web offers limited support for streaming:

* gRPC-Web browser clients don't support calling client streaming and bidirectional streaming methods.
* gRPC-Web .NET clients don't support calling client streaming and bidirectional streaming methods over HTTP/1.1.
* ASP.NET Core gRPC services hosted on Azure App Service and IIS don't support bidirectional streaming.

When using gRPC-Web, we only recommend the use of unary methods and server streaming methods.

### HTTP protocol

The ASP.NET Core gRPC service template, included in the .NET SDK, creates an app that's only configured for HTTP/2. This is a good default when an app only supports traditional gRPC over HTTP/2. gRPC-Web, however, works with both HTTP/1.1 and HTTP/2. Some platforms, such as UWP or Unity, can't use HTTP/2. To support all client apps, configure the server to enable HTTP/1.1 and HTTP/2.

Update the default protocol in `appsettings.json`:

```json
{
  "Kestrel": {
    "EndpointDefaults": {
      "Protocols": "Http1AndHttp2"
    }
  }
}
```

Alternatively, [configure Kestrel endpoints in startup code](xref:fundamentals/servers/kestrel/endpoints).

Enabling HTTP/1.1 and HTTP/2 on the same port requires TLS for protocol negotiation. For more information, see [ASP.NET Core gRPC protocol negotiation](xref:grpc/aspnetcore#protocol-negotiation).

## Call gRPC-Web from the browser

Browser apps can use gRPC-Web to call gRPC services. There are some requirements and limitations when calling gRPC services with gRPC-Web from the browser:

* The server must contain configuration to support gRPC-Web.
* Client streaming and bidirectional streaming calls aren't supported. Server streaming is supported.
* Calling gRPC services on a different domain requires [CORS](xref:security/cors) configuration on the server.

### JavaScript gRPC-Web client

A JavaScript gRPC-Web client exists. For instructions on how to use gRPC-Web from JavaScript, see [write JavaScript client code with gRPC-Web](https://github.com/grpc/grpc-web/tree/master/net/grpc/gateway/examples/helloworld#write-client-code).

### Configure gRPC-Web with the .NET gRPC client

The .NET gRPC client can be configured to make gRPC-Web calls. This is useful for [Blazor WebAssembly](xref:blazor/index#blazor-webassembly) apps, which are hosted in the browser and have the same HTTP limitations of JavaScript code. Calling gRPC-Web with a .NET client is the same as [HTTP/2 gRPC](xref:grpc/client). The only modification is how the channel is created.

To use gRPC-Web:

* Add a reference to the [`Grpc.Net.Client.Web`](https://www.nuget.org/packages/Grpc.Net.Client.Web) package.
* Ensure the reference to [`Grpc.Net.Client`](https://www.nuget.org/packages/Grpc.Net.Client) package is version 2.29.0 or later.
* Configure the channel to use the `GrpcWebHandler`:

[!code-csharp[](~/grpc/grpcweb/sample/Handler.cs?name=snippet_1)]

The preceding code:

* Configures a channel to use gRPC-Web.
* Creates a client and makes a call using the channel.

`GrpcWebHandler` has the following configuration options:

* `InnerHandler`: The underlying <xref:System.Net.Http.HttpMessageHandler> that makes the gRPC HTTP request, for example, `HttpClientHandler`.
* `GrpcWebMode`: An enumeration type that specifies whether the gRPC HTTP request `Content-Type` is `application/grpc-web` or `application/grpc-web-text`.
    * `GrpcWebMode.GrpcWeb` configures sending content without encoding. Default value.
    * `GrpcWebMode.GrpcWebText` configures base64-encoded content. Required for server streaming calls in browsers.
* `HttpVersion`: HTTP protocol `Version` used to set <xref:System.Net.Http.HttpRequestMessage.Version?displayProperty=nameWithType> on the underlying gRPC HTTP request. gRPC-Web doesn't require a specific version and doesn't override the default unless specified.

> [!IMPORTANT]
> Generated gRPC clients have synchronous and asynchronous methods for calling unary methods. For example, `SayHello` is synchronous, and `SayHelloAsync` is asynchronous. Asynchronous methods are always required in Blazor WebAssembly. Calling a synchronous method in a Blazor WebAssembly app causes the app to become unresponsive.

### Use gRPC client factory with gRPC-Web

Create a .NET client compatible with gRPC-Web using the [gRPC client factory](xref:grpc/clientfactory):

* Add package references to the project file for the following packages:
  * [`Grpc.Net.Client.Web`](https://www.nuget.org/packages/Grpc.Net.Client.Web)
  * [`Grpc.Net.ClientFactory`](https://www.nuget.org/packages/Grpc.Net.ClientFactory)
* Register a gRPC client with dependency injection (DI) using the generic `AddGrpcClient` extension method. In a Blazor WebAssembly app, services are registered with DI in `Program.cs`.
* Configure `GrpcWebHandler` using the <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A> extension method.

```csharp
builder.Services
    .AddGrpcClient<Greet.GreeterClient>(options =>
    {
        options.Address = new Uri("https://localhost:5001");
    })
    .ConfigurePrimaryHttpMessageHandler(
        () => new GrpcWebHandler(new HttpClientHandler()));
```

For more information, see <xref:grpc/clientfactory>.

## Additional resources

* [gRPC for Web Clients GitHub project](https://github.com/grpc/grpc-web)
* <xref:security/cors>
* <xref:grpc/json-transcoding>
