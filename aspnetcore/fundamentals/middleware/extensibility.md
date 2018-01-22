---
title: Factory-based middleware activation in ASP.NET Core
author: guardrex
description: Learn how to activate strongly-typed middleware with a factory-based implementation in ASP.NET Core.
ms.author: riande
manager: wpickett
ms.custom: mvc
ms.date: 01/17/2018
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/middleware/extensibility
---
# Factory-based middleware activation in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

[IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory)/[IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) is an extensibility point for [middleware](xref:fundamentals/middleware/index) activation.

`UseMiddleware` extension methods check if a middleware's registered type implements `IMiddleware`. If it does, the `IMiddlewareFactory` instance registered in the container is used to resolve the `IMiddleware` implementation instead of using the convention-based middleware activation logic. The factory is registered as a scoped service with the app's service container.

Benefits:

* Activation per request (injection of scoped services)
* Strong typing of middleware

`IMiddleware` is activated per request, so scoped services can be injected into the constructor.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/middleware/extensibility/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app demonstrates:

* Conventionally-activated middleware.
* Middleware activated by an `IMiddlewareFactory` registered in an [Ninject](http://www.ninject.org/) container.

The middlewares function identically and record the value provided by a query string parameter (`key`). The middlewares use an injected database context (a scoped service) to record the query string value in an in-memory database.

## IMiddleware

[IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) defines middleware for the app's request pipeline. The [InvokeAsync(HttpContext, RequestDelegate)](/dotnet/api/microsoft.aspnetcore.http.imiddleware.invokeasync#Microsoft_AspNetCore_Http_IMiddleware_InvokeAsync_Microsoft_AspNetCore_Http_HttpContext_Microsoft_AspNetCore_Http_RequestDelegate_) method handles requests and returns a `Task` that represents the execution of the middleware.

Conventionally-activated middleware:

[!code-csharp[Main](extensibility/sample/Middleware/MiddlewareViaConventionalActivation.cs?name=snippet1)]

`IMiddlewareFactory`-activated middleware:

[!code-csharp[Main](extensibility/sample/Middleware/MiddlewareViaIMiddlewareFactoryActivation.cs?name=snippet1)]

Extensions are created for the middlewares:

[!code-csharp[Main](extensibility/sample/Middleware/MiddlewareExtensions.cs?name=snippet1)]

Note that it isn't possible to pass objects with `UseMiddleware` as it is with convention-based middleware activation:

```csharp
public static IApplicationBuilder UseMiddlewareViaIMiddlewareFactoryActivation(
    this IApplicationBuilder builder, bool option)
{
    // Passing 'option' as an argument won't work and throws a NotSupportedException 
    // at runtime.
    return builder.UseMiddleware<MiddlewareViaIMiddlewareFactoryActivation>(option);
}
```

The middlewares are added to the built-in container in *Startup.cs*:

[!code-csharp[Main](extensibility/sample/Startup.cs?name=snippet1&highlight=6-7)]

The middlewares are registered in the request processing pipeline in *Startup.cs*:

[!code-csharp[Main](extensibility/sample/Startup.cs?name=snippet2&highlight=15-16)]

## IMiddlewareFactory

[IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory) provides methods to create middleware. The middleware factory is registered in the container as a scoped service.

The default `IMiddlewareFactory` implementation is found in the [Microsoft.AspNetCore.Http](https://www.nuget.org/packages/Microsoft.AspNetCore.Http/) package:

```csharp
public class MiddlewareFactory : IMiddlewareFactory
{
    // The default middleware factory is just an IServiceProvider proxy.
    // This should be registered as a scoped service so that the middleware instances
    // don't end up being singletons.
    private readonly IServiceProvider _serviceProvider;

    public MiddlewareFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IMiddleware Create(Type middlewareType)
    {
        return _serviceProvider.GetRequiredService(middlewareType) as IMiddleware;
    }

    public void Release(IMiddleware middleware)
    {
        // The container owns the lifetime of the service
    }
}
```

The sample app activates the `MiddlewareViaIMiddlewareFactoryActivation` with its custom `BasicMiddlewareFactory`:

[!code-csharp[Main](extensibility/sample/Middleware/MiddlewareFactory.cs?name=snippet1)]

Note the injection of the database context, which is passed as an argument to `Activator.CreateInstance`. This permits the middleware to to obtain the database context via [dependency injection](xref:fundamentals/dependency-injection).

The middleware factory is registered in the service container in *Startup.cs*:

[!code-csharp[Main](extensibility/sample/Startup.cs?name=snippet3&highlight=12)]

## Additional resources

* [Middleware](xref:fundamentals/middleware/index)
