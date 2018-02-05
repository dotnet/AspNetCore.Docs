---
title: Factory-based middleware activation with a third-party container in ASP.NET Core
author: guardrex
description: Learn how to use strongly-typed middleware with factory-based activation and a third-party container in ASP.NET Core.
ms.author: riande
manager: wpickett
ms.custom: mvc
ms.date: 02/02/2018
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/middleware/extensibility-third-party-container
---
# Factory-based middleware activation with a third-party container in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

This article demonstrates how to use [IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory) and [IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) as an extensibility point for [middleware](xref:fundamentals/middleware/index) activation with a third-party container. For introductory information on `IMiddlewareFactory` and `IMiddleware`, see the [Factory-based middleware activation](xref:fundamentals/middleware/extensibility) topic.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/middleware/extensibility-third-party-container/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app demonstrates middleware activation by an `IMiddlewareFactory` implementation, `SimpleInjectorMiddlewareFactory`. The sample uses the [Simple Injector](https://github.com/simpleinjector/SimpleInjector) dependency injection (DI) container.

The sample's middleware implementation records the value provided by a query string parameter (`key`). The middleware uses an injected database context (a scoped service) to record the query string value in an in-memory database.

## IMiddlewareFactory

[IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory) provides methods to create middleware.

In the sample app, a middleware factory is implemented to create an `SimpleInjectorActivatedMiddleware` instance. The middleware factory uses the Simple Injector container to resolve the middleware:

[!code-csharp[](extensibility-third-party-container/sample/Middleware/SimpleInjectorMiddlewareFactory.cs?name=snippet1&highlight=5-8,12)]

## IMiddleware

[IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) defines middleware for the app's request pipeline.

Middleware activated by an `IMiddlewareFactory` implementation (*Middleware/SimpleInjectorActivatedMiddleware.cs*):

[!code-csharp[](extensibility-third-party-container/sample/Middleware/SimpleInjectorActivatedMiddleware.cs?name=snippet1)]

An extension is created for the middleware (*Middleware/MiddlewareExtensions.cs*):

[!code-csharp[](extensibility-third-party-container/sample/Middleware/MiddlewareExtensions.cs?name=snippet1)]

`Startup.ConfigureServices` must perform several tasks:

* Set up the Simple Injector container.
* Register the factory and middleware.
* Make the app's database context available from the Simple Injector container for a Razor Page.

[!code-csharp[](extensibility-third-party-container/sample/Startup.cs?name=snippet1)]

The middleware is registered in the request processing pipeline in `Startup.Configure`:

[!code-csharp[](extensibility-third-party-container/sample/Startup.cs?name=snippet2&highlight=12)]

## Additional resources

* [Middleware](xref:fundamentals/middleware/index)
* [Factory-based middleware activation](xref:fundamentals/middleware/extensibility)
* [Simple Injector documentation](https://simpleinjector.readthedocs.io/en/latest/index.html)
