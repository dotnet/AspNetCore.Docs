---
title: Factory-based middleware activation in ASP.NET Core
author: rick-anderson
description: Learn how to use strongly-typed middleware with a factory-based activation implementation in ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/25/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/middleware/extensibility
---
# Factory-based middleware activation in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

<xref:Microsoft.AspNetCore.Http.IMiddlewareFactory>/<xref:Microsoft.AspNetCore.Http.IMiddleware> is an extensibility point for [middleware](xref:fundamentals/middleware/index) activation that offers the following benefits:

* Activation per client request (injection of scoped services)
* Strong typing of middleware

<xref:Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware%2A> extension methods check if a middleware's registered type implements <xref:Microsoft.AspNetCore.Http.IMiddleware>. If it does, the <xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> instance registered in the container is used to resolve the <xref:Microsoft.AspNetCore.Http.IMiddleware> implementation instead of using the convention-based middleware activation logic. The middleware is registered as a [scoped or transient service](xref:fundamentals/dependency-injection#service-lifetimes) in the app's service container.

<xref:Microsoft.AspNetCore.Http.IMiddleware> is activated per client request (connection), so scoped services can be injected into the middleware's constructor.

## IMiddleware

<xref:Microsoft.AspNetCore.Http.IMiddleware> defines middleware for the app's request pipeline. The [InvokeAsync(HttpContext, RequestDelegate)](xref:Microsoft.AspNetCore.Http.IMiddleware.InvokeAsync%2A) method handles requests and returns a <xref:System.Threading.Tasks.Task> that represents the execution of the middleware.

Middleware activated by convention:

:::code language="csharp" source="extensibility/samples/6.x/MiddlewareExtensibilitySample/Middleware/ConventionalMiddleware.cs" id="snippet_Class":::

Middleware activated by <xref:Microsoft.AspNetCore.Http.MiddlewareFactory>:

:::code language="csharp" source="extensibility/samples/6.x/MiddlewareExtensibilitySample/Middleware/FactoryActivatedMiddleware.cs" id="snippet_Class":::

Extensions are created for the middleware:

:::code language="csharp" source="extensibility/samples/6.x/MiddlewareExtensibilitySample/Middleware/MiddlewareExtensions.cs" id="snippet_Class":::

It isn't possible to pass objects to the factory-activated middleware with <xref:Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware%2A>:

```csharp
public static IApplicationBuilder UseFactoryActivatedMiddleware(
    this IApplicationBuilder app, bool option)
{
    // Passing 'option' as an argument throws a NotSupportedException at runtime.
    return app.UseMiddleware<FactoryActivatedMiddleware>(option);
}
```

The factory-activated middleware is added to the built-in container in `Program.cs`:

:::code language="csharp" source="extensibility/samples/6.x/MiddlewareExtensibilitySample/Program.cs" id="snippet_Services" highlight="6":::

Both middleware are registered in the request processing pipeline, also in `Program.cs`:

:::code language="csharp" source="extensibility/samples/6.x/MiddlewareExtensibilitySample/Program.cs" id="snippet_Middleware" highlight="3-4":::

## IMiddlewareFactory

<xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> provides methods to create middleware. The middleware factory implementation is registered in the container as a scoped service.

The default <xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> implementation, <xref:Microsoft.AspNetCore.Http.MiddlewareFactory>, is found in the [Microsoft.AspNetCore.Http](https://www.nuget.org/packages/Microsoft.AspNetCore.Http/) package.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/middleware/extensibility/samples) ([how to download](xref:index#how-to-download-a-sample))
* <xref:fundamentals/middleware/index>
* <xref:fundamentals/middleware/extensibility-third-party-container>

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

<xref:Microsoft.AspNetCore.Http.IMiddlewareFactory>/<xref:Microsoft.AspNetCore.Http.IMiddleware> is an extensibility point for [middleware](xref:fundamentals/middleware/index) activation.

<xref:Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware%2A> extension methods check if a middleware's registered type implements <xref:Microsoft.AspNetCore.Http.IMiddleware>. If it does, the <xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> instance registered in the container is used to resolve the <xref:Microsoft.AspNetCore.Http.IMiddleware> implementation instead of using the convention-based middleware activation logic. The middleware is registered as a [scoped or transient service](xref:fundamentals/dependency-injection#service-lifetimes) in the app's service container.

Benefits:

* Activation per client request (injection of scoped services)
* Strong typing of middleware

<xref:Microsoft.AspNetCore.Http.IMiddleware> is activated per client request (connection), so scoped services can be injected into the middleware's constructor.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/middleware/extensibility/samples) ([how to download](xref:index#how-to-download-a-sample))

## IMiddleware

<xref:Microsoft.AspNetCore.Http.IMiddleware> defines middleware for the app's request pipeline. The [InvokeAsync(HttpContext, RequestDelegate)](xref:Microsoft.AspNetCore.Http.IMiddleware.InvokeAsync%2A) method handles requests and returns a <xref:System.Threading.Tasks.Task> that represents the execution of the middleware.

Middleware activated by convention:

:::code language="csharp" source="extensibility/samples/3.x/MiddlewareExtensibilitySample/Middleware/ConventionalMiddleware.cs" id="snippet1":::

Middleware activated by <xref:Microsoft.AspNetCore.Http.MiddlewareFactory>:

:::code language="csharp" source="extensibility/samples/3.x/MiddlewareExtensibilitySample/Middleware/FactoryActivatedMiddleware.cs" id="snippet1":::

Extensions are created for the middleware:

:::code language="csharp" source="extensibility/samples/3.x/MiddlewareExtensibilitySample/Middleware/MiddlewareExtensions.cs" id="snippet1":::

It isn't possible to pass objects to the factory-activated middleware with <xref:Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware%2A>:

```csharp
public static IApplicationBuilder UseFactoryActivatedMiddleware(
    this IApplicationBuilder builder, bool option)
{
    // Passing 'option' as an argument throws a NotSupportedException at runtime.
    return builder.UseMiddleware<FactoryActivatedMiddleware>(option);
}
```

The factory-activated middleware is added to the built-in container in `Startup.ConfigureServices`:

:::code language="csharp" source="extensibility/samples/3.x/MiddlewareExtensibilitySample/Startup.cs" id="snippet1" highlight="6":::

Both middleware are registered in the request processing pipeline in `Startup.Configure`:

:::code language="csharp" source="extensibility/samples/3.x/MiddlewareExtensibilitySample/Startup.cs" id="snippet2" highlight="12-13":::

## IMiddlewareFactory

<xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> provides methods to create middleware. The middleware factory implementation is registered in the container as a scoped service.

The default <xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> implementation, <xref:Microsoft.AspNetCore.Http.MiddlewareFactory>, is found in the [Microsoft.AspNetCore.Http](https://www.nuget.org/packages/Microsoft.AspNetCore.Http/) package.

## Additional resources

* <xref:fundamentals/middleware/index>
* <xref:fundamentals/middleware/extensibility-third-party-container>

:::moniker-end

:::moniker range="< aspnetcore-3.0"

<xref:Microsoft.AspNetCore.Http.IMiddlewareFactory>/<xref:Microsoft.AspNetCore.Http.IMiddleware> is an extensibility point for [middleware](xref:fundamentals/middleware/index) activation.

<xref:Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware%2A> extension methods check if a middleware's registered type implements <xref:Microsoft.AspNetCore.Http.IMiddleware>. If it does, the <xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> instance registered in the container is used to resolve the <xref:Microsoft.AspNetCore.Http.IMiddleware> implementation instead of using the convention-based middleware activation logic. The middleware is registered as a [scoped or transient service](xref:fundamentals/dependency-injection#service-lifetimes) in the app's service container.

Benefits:

* Activation per client request (injection of scoped services)
* Strong typing of middleware

<xref:Microsoft.AspNetCore.Http.IMiddleware> is activated per client request (connection), so scoped services can be injected into the middleware's constructor.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/middleware/extensibility/samples) ([how to download](xref:index#how-to-download-a-sample))

## IMiddleware

<xref:Microsoft.AspNetCore.Http.IMiddleware> defines middleware for the app's request pipeline. The [InvokeAsync(HttpContext, RequestDelegate)](xref:Microsoft.AspNetCore.Http.IMiddleware.InvokeAsync%2A) method handles requests and returns a <xref:System.Threading.Tasks.Task> that represents the execution of the middleware.

Middleware activated by convention:

:::code language="csharp" source="extensibility/samples/2.x/MiddlewareExtensibilitySample/Middleware/ConventionalMiddleware.cs" id="snippet1":::

Middleware activated by <xref:Microsoft.AspNetCore.Http.MiddlewareFactory>:

:::code language="csharp" source="extensibility/samples/2.x/MiddlewareExtensibilitySample/Middleware/FactoryActivatedMiddleware.cs" id="snippet1":::

Extensions are created for the middleware:

:::code language="csharp" source="extensibility/samples/2.x/MiddlewareExtensibilitySample/Middleware/MiddlewareExtensions.cs" id="snippet1":::

It isn't possible to pass objects to the factory-activated middleware with <xref:Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware%2A>:

```csharp
public static IApplicationBuilder UseFactoryActivatedMiddleware(
    this IApplicationBuilder builder, bool option)
{
    // Passing 'option' as an argument throws a NotSupportedException at runtime.
    return builder.UseMiddleware<FactoryActivatedMiddleware>(option);
}
```

The factory-activated middleware is added to the built-in container in `Startup.ConfigureServices`:

:::code language="csharp" source="extensibility/samples/2.x/MiddlewareExtensibilitySample/Startup.cs" id="snippet1" highlight="6":::

Both middleware are registered in the request processing pipeline in `Startup.Configure`:

:::code language="csharp" source="extensibility/samples/2.x/MiddlewareExtensibilitySample/Startup.cs" id="snippet2" highlight="13-14":::

## IMiddlewareFactory

<xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> provides methods to create middleware. The middleware factory implementation is registered in the container as a scoped service.

The default <xref:Microsoft.AspNetCore.Http.IMiddlewareFactory> implementation, <xref:Microsoft.AspNetCore.Http.MiddlewareFactory>, is found in the [Microsoft.AspNetCore.Http](https://www.nuget.org/packages/Microsoft.AspNetCore.Http/) package.

## Additional resources

* <xref:fundamentals/middleware/index>
* <xref:fundamentals/middleware/extensibility-third-party-container>

:::moniker-end
