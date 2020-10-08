---
title: What's new in ASP.NET Core 5.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 5.0.
ms.author: riande
ms.custom: mvc
ms.date: 12/05/2019
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: aspnetcore-5.0
---
# What's new in ASP.NET Core 5.0

This article highlights the most significant changes in ASP.NET Core 5.0 with links to relevant documentation.

## Blazor

For more information, see <xref:blazor/index>.

### Blazor Server

### Blazor WebAssembly

Blazor can run client-side C# code directly in the browser, using [WebAssembly](xref:blazor/hosting-models#blazor-webassembly).

The Blazor WebAssembly template and the Blazor Server template are included in the .NET 5 SDK. along with the Blazor Server template.

To create a Blazor WebAssembly project, run the following command in a console window:

```dotnetcli
dotnet new blazorwasm
``` 

## gRPC

[gRPC](https://grpc.io/):

For more information, see <xref:grpc/index>.

## SignalR

SignalR Hub filters, called Hub pipelines in ASP.NET SignalR, is a feature that allows code code to run before and after Hub methods are called. Running code before and after Hub methods are called is similar to how middleware has the ability to run code before and after an HTTP request. Common uses include logging, error handling, and argument validation.

For more information, see [Use hub filters in ASP.NET Core SignalR](xref:signalr/hub-filters).

You can read more about this Hub filters on the docs page.
<!--
See [Update SignalR code](xref:migration/31-to-50#signalr) for migration instructions.
-->

## Kestrel

* Reloadable endpoints via configuration: Kestrel can detect changes to configuration passed to [KestrelServerOptions.Configure](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure%2A) and unbind from existing endpoints and bind to new endpoints without requiring an application restart.
* HTTP/2 response headers improvements. For more information, see [Performance improvements](#performance-improvements) in the next section.

## Performance improvements

* HTTP/2:
  * Significant reductions in allocations in the HTTP/2 code path.
  * Support for [HPack dynamic compression](https://tools.ietf.org/html/rfc7541) of HTTP/2 response headers in [Kestrel](xref:fundamentals/servers/kestrel). For more information, see [Header table size](xref:fundamentals/servers/kestrel#header-table-size) and [HPACK: the silent killer (feature) of HTTP/2](https://blog.cloudflare.com/hpack-the-silent-killer-feature-of-http-2/).

## Containers

Prior to .NET 5, building and publishing a Dockerfile ASP.NET app required pulling the .NET Core SDK and the ASP.NET image. With this release, the SDK images size is reduced and the ASP.NET image is eliminated, only the small manifest needs to be pulled. For more information, see [this GitHub issue comment](https://github.com/dotnet/dotnet-docker/issues/1814#issuecomment-625294750).

## API improvements

### JSON extension methods for HttpRequest and HttpResponse

JSON data can be read and written to from an `HttpRequest` and `HttpResponse` using the new <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> and `WriteAsJsonAsync` extension methods. These extension methods use the [System.Text.Json](xref:System.Text.Json) serializer to handle the JSON data. You can also check if a request has a JSON content type using the new `HasJsonContentType` extension method.

The JSON extension methods can be combined with [endpoint routing](xref:fundamentals/routing) to create JSON APIs in a style of programming we call ***route to code***. It is a new option for developers who want to create basic JSON APIs in a lightweight way. For example, a web app that has only a handful of endpoints might choose to use route to code rather than the full functionality of ASP.NET Core MVC:

```csharp
endpoints.MapGet("/weather/{city:alpha}", async context =>
{
    var city = (string)context.Request.RouteValues["city"];
    var weather = GetFromDatabase(city);

    await context.Response.WriteAsJsonAsync(weather);
});
```

For more information on the new JSON extension methods and route to code, see [this .NET show](WriteAsJsonAsync).

### allow anonymous access to an endpoint

The `AllowAnonymous` extension method allows anonymous access to an endpoint:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Hello World!");
        })
        .AllowAnonymous();
    });
}
```

### Custom handling of authorization failures

Custom handling of authorization failures is now easier with the new [IAuthorizationMiddlewareResultHandler](https://github.com/dotnet/aspnetcore/blob/v5.0.0-rc.1.20451.17/src/Security/Authorization/Policy/src/IAuthorizationMiddlewareResultHandler.cs) interface that is invoked by the [authorization](xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A) [Middleware](fundamentals/middleware). The default implementation remains the same, but a custom handler can be be registered in [Dependency injection](xref:fundamentals/dependency-injection) which allows custom HTTP responses based on why authorization failed. See [this sample](https://github.com/dotnet/aspnetcore/blob/master/src/Security/samples/CustomAuthorizationFailureResponse/Authorization/SampleAuthorizationMiddlewareResultHandler.cs) that demonstrates usage of the `IAuthorizationMiddlewareResultHandler`.