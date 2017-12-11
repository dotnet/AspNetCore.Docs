---
title: Middleware activation with nonconforming containers in ASP.NET Core
author: guardrex
description: Learn how to activate middleware with nonconforming containers in ASP.NET Core.
ms.author: riande
manager: wpickett
ms.custom: mvc
ms.date: 12/18/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/middleware/extensibility
---
# Middleware activation with nonconforming containers in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

[IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory)/[IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) is an extensibility point for [middleware](xref:fundamentals/middleware/index) activation with nonconforming containers.

This approach creates a middleware instance that's created and released via a middleware factory. The factory is registered as a scoped service with the app's container.

`UseMiddleware` extension methods check if the middleware's registered type implements `IMiddleware`. If it does, it automatically uses the `IMiddlewareFactory` to resolve the `IMiddleware` instead of using the convention-based middleware activation logic. 

Benefits:

* Automatic middleware activation with nonconforming containers
* Strong middleware typing as `IMiddleware`
* Activation per request (injection of scoped services)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/middleware/extensibility/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## IMiddleware

[IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) defines middleware for the app's request pipeline. The [InvokeAsync(HttpContext, RequestDelegate)](/dotnet/api/microsoft.aspnetcore.http.imiddleware.invokeasync#Microsoft_AspNetCore_Http_IMiddleware_InvokeAsync_Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Http_RequestDelegate_) method handles requests and returns a `Task` that represents the execution of the middleware.

The sample app registers a middleware that sets the culture from a query string parameter. The middleware also uses an injected database context (a scoped service) to record the query string value in a database:

[!code-csharp[Main](extensibility/sample/Middleware/RequestCultureMiddleware.cs?name=snippet1)]

An extension is created for the middleware:

[!code-csharp[Main](extensibility/sample/Middleware/MiddlewareExtensions.cs?name=snippet1)]

The middleware is registered in the request processing pipeline in *Startup.cs*:

[!code-csharp[Main](extensibility/sample/Startup.cs?name=snippet2&highlight=12)]

Note that it isn't possible to pass objects with `UseMiddleware` as it is with convention-based middleware activation:

```csharp
public static IApplicationBuilder UseRequestCulture(
    this IApplicationBuilder builder, bool option)
{
    // Passing option as an argument won't work and throws a
    // NotSupportedException at runtime.
    return builder.UseMiddleware<RequestCultureMiddleware>(option);
}
```

## IMiddlewareFactory

[IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory) provides methods to create middleware. The middleware factory must be registered in the container.

The sample app activates the `RequestCultureMiddleware` with its `BasicMiddlewareFactory`:

[!code-csharp[Main](extensibility/sample/Middleware/MiddlewareFactory.cs?name=snippet1)]

Note the injection of the database context, which is passed as an argument to `Activator.CreateInstance`. This permits the middleware to to obtain the database context via [dependency injection](xref:fundamentals/dependency-injection).

The middleware factory is registered in the service container in *Startup.cs*:

[!code-csharp[Main](extensibility/sample/Startup.cs?name=snippet1&highlight=5)]

## Additional resources

* [Middleware](xref:fundamentals/middleware/index)
