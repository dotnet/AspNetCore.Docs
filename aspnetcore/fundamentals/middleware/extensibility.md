---
title: Factory-based middleware activation in ASP.NET Core
author: guardrex
description: Learn how to use strongly-typed middleware with a factory-based activation implementation in ASP.NET Core.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/14/2018
uid: fundamentals/middleware/extensibility
---
# Factory-based middleware activation in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

[IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory)/[IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) is an extensibility point for [middleware](xref:fundamentals/middleware/index) activation.

`UseMiddleware` extension methods check if a middleware's registered type implements `IMiddleware`. If it does, the `IMiddlewareFactory` instance registered in the container is used to resolve the `IMiddleware` implementation instead of using the convention-based middleware activation logic. The middleware is registered as a scoped or transient service in the app's service container.

Benefits:

* Activation per request (injection of scoped services)
* Strong typing of middleware

`IMiddleware` is activated per request, so scoped services can be injected into the middleware's constructor.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/middleware/extensibility/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app demonstrates middleware activated by:

* Convention. For more information on conventional middleware activation, see the [Middleware](xref:fundamentals/middleware/index) topic.
* An [IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) implementation. The default [MiddlewareFactory class](/dotnet/api/microsoft.aspnetcore.http.middlewarefactory) activates the middleware.

The middleware implementations function identically and record the value provided by a query string parameter (`key`). The middlewares use an injected database context (a scoped service) to record the query string value in an in-memory database.

## IMiddleware

[IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) defines middleware for the app's request pipeline. The [InvokeAsync(HttpContext, RequestDelegate)](/dotnet/api/microsoft.aspnetcore.http.imiddleware.invokeasync#Microsoft_AspNetCore_Http_IMiddleware_InvokeAsync_Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Http_RequestDelegate_) method handles requests and returns a `Task` that represents the execution of the middleware.

Middleware activated by convention:

[!code-csharp[](extensibility/sample/Middleware/ConventionalMiddleware.cs?name=snippet1)]

Middleware activated by `MiddlewareFactory`:

[!code-csharp[](extensibility/sample/Middleware/FactoryActivatedMiddleware.cs?name=snippet1)]

Extensions are created for the middlewares:

[!code-csharp[](extensibility/sample/Middleware/MiddlewareExtensions.cs?name=snippet1)]

It isn't possible to pass objects to the factory-activated middleware with `UseMiddleware`:

```csharp
public static IApplicationBuilder UseFactoryActivatedMiddleware(
    this IApplicationBuilder builder, bool option)
{
    // Passing 'option' as an argument throws a NotSupportedException at runtime.
    return builder.UseMiddleware<FactoryActivatedMiddleware>(option);
}
```

The factory-activated middleware is added to the built-in container in *Startup.cs*:

[!code-csharp[](extensibility/sample/Startup.cs?name=snippet1&highlight=12)]

Both middlewares are registered in the request processing pipeline in `Configure`:

[!code-csharp[](extensibility/sample/Startup.cs?name=snippet2&highlight=14-15)]

## IMiddlewareFactory

[IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory) provides methods to create middleware. The middleware factory implementation is registered in the container as a scoped service.

The default `IMiddlewareFactory` implementation, [MiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.middlewarefactory), is found in the [Microsoft.AspNetCore.Http](https://www.nuget.org/packages/Microsoft.AspNetCore.Http/) package.

## Additional resources

* <xref:fundamentals/middleware/index>
* <xref:fundamentals/middleware/extensibility-third-party-container>
