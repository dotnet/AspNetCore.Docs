---
title: Write custom ASP.NET Core middleware
author: rick-anderson
description: Learn how to write custom ASP.NET Core middleware.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 5/18/2020
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/middleware/write
---
# Write custom ASP.NET Core middleware

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Steve Smith](https://ardalis.com/)

Middleware is software that's assembled into an app pipeline to handle requests and responses. ASP.NET Core provides a rich set of built-in middleware components, but in some scenarios you might want to write a custom middleware.

> [!NOTE]
> This topic describes how to write *convention-based* middleware. For an approach that uses strong typing and per-request activation, see <xref:fundamentals/middleware/extensibility>.

## Middleware class

Middleware is generally encapsulated in a class and exposed with an extension method. Consider the following middleware, which sets the culture for the current request from a query string:

:::code language="csharp" source="write/snapshot/StartupCulture.cs":::

The preceding sample code is used to demonstrate creating a middleware component. For ASP.NET Core's built-in localization support, see <xref:fundamentals/localization>.

Test the middleware by passing in the culture. For example, request `https://localhost:5001/?culture=no`.

The following code moves the middleware delegate to a class:

:::code language="csharp" source="write/snapshot/RequestCultureMiddleware.cs":::

The middleware class must include:

* A public constructor with a parameter of type <xref:Microsoft.AspNetCore.Http.RequestDelegate>.
* A public method named `Invoke` or `InvokeAsync`. This method must:
  * Return a `Task`.
  * Accept a first parameter of type <xref:Microsoft.AspNetCore.Http.HttpContext>.
  
Additional parameters for the constructor and `Invoke`/`InvokeAsync` are populated by [dependency injection (DI)](xref:fundamentals/dependency-injection).

## Middleware dependencies

Middleware should follow the [Explicit Dependencies Principle](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#explicit-dependencies) by exposing its dependencies in its constructor. Middleware is constructed once per *application lifetime*. See the [Per-request middleware dependencies](#per-request-middleware-dependencies) section if you need to share services with middleware within a request.

Middleware components can resolve their dependencies from [dependency injection (DI)](xref:fundamentals/dependency-injection) through constructor parameters. <xref:Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware%2A> can also accept additional parameters directly.

## Per-request middleware dependencies

Because middleware is constructed at app startup, not per-request, *scoped* lifetime services used by middleware constructors aren't shared with other dependency-injected types during each request. If you must share a *scoped* service between your middleware and other types, add these services to the `InvokeAsync` method's signature. The `InvokeAsync` method can accept additional parameters that are populated by DI:

```csharp
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // IMyScopedService is injected into InvokeAsync
    public async Task InvokeAsync(HttpContext httpContext, IMyScopedService svc)
    {
        svc.MyProperty = 1000;
        await _next(httpContext);
    }
}
```

[Lifetime and registration options](xref:fundamentals/dependency-injection#lifetime-and-registration-options) contains a complete sample of middleware with *scoped* lifetime services.

## Middleware extension method

The following extension method exposes the middleware through <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder>:

:::code language="csharp" source="write/snapshot/RequestCultureMiddlewareExtensions.cs":::

The following code calls the middleware from `Startup.Configure`:

:::code language="csharp" source="write/snapshot/Startup.cs" highlight="5":::

## Additional resources

* [Lifetime and registration options](xref:fundamentals/dependency-injection#lifetime-and-registration-options) contains a complete sample of middleware with *scoped*, *transient*, and *singleton* lifetime services.
* <xref:fundamentals/middleware/index>
* <xref:test/middleware>
* <xref:migration/http-modules>
* <xref:fundamentals/startup>
* <xref:fundamentals/request-features>
* <xref:fundamentals/middleware/extensibility>
* <xref:fundamentals/middleware/extensibility-third-party-container>
