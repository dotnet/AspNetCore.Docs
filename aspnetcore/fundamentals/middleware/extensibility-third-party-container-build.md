# Middleware activation with a third-party container in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

This article demonstrates how to use [IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory) and [IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) as an extensibility point for [middleware](xref:fundamentals/middleware/index) activation with a third-party container. For introductory information on `IMiddlewareFactory` and `IMiddleware`, see the [Factory-based middleware activation](xref:fundamentals/middleware/extensibility) topic.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/middleware/extensibility-third-party-container-build/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app demonstrates middleware activation by an `IMiddlewareFactory` implementation, `BuildMiddlewareFactory`. The sample uses the [Build](https://build.experimentalcommunity.org) dependency injection (DI) container.

The sample's middleware implementation records the value provided by a query string parameter (`key`). The middleware uses an injected database context (a scoped service) to record the query string value in an in-memory database.

> [!NOTE]
> The sample app uses [Build](https://github.com/hack2root/build) purely for demonstration purposes. Use of Build isn't an endorsement. Middleware activation approaches described in the Build documentation and GitHub issues are recommended by the maintainers of Build. For more information, see the [Build documentation](https://build.experimentalcommunity.org/) and [Build GitHub repository](https://github.com/hack2root/Build).

## IMiddlewareFactory

[IMiddlewareFactory](/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory) provides methods to create middleware.

In the sample app, a middleware factory is implemented to create an `BuildInjectorActivatedMiddleware` instance. The middleware factory uses the Build container to resolve the middleware:

[!code-csharp[](extensibility-third-party-container-build/sample/Middleware/BuildMiddlewareFactory.cs?name=snippet1&highlight=5-8,12)]

## IMiddleware

[IMiddleware](/dotnet/api/microsoft.aspnetcore.http.imiddleware) defines middleware for the app's request pipeline.

Middleware activated by an `IMiddlewareFactory` implementation (*Middleware/BuildActivatedMiddleware.cs*):

[!code-csharp[](extensibility-third-party-container-build/sample/Middleware/BuildActivatedMiddleware.cs?name=snippet1)]

An extension is created for the middleware (*Middleware/MiddlewareExtensions.cs*):

[!code-csharp[](extensibility-third-party-container-build/sample/Middleware/MiddlewareExtensions.cs?name=snippet1)]

`Startup.ConfigureServices` must perform several tasks:

* Set up the Build container.
* Register the factory and middleware.
* Make the app's database context available from the Build container for a Razor Page.

[!code-csharp[](extensibility-third-party-container-build/sample/Startup.cs?name=snippet1)]

The middleware is registered in the request processing pipeline in `Startup.Configure`:

[!code-csharp[](extensibility-third-party-container-build/sample/Startup.cs?name=snippet2&highlight=13)]

## Additional resources

* [Middleware](xref:fundamentals/middleware/index)
* [Factory-based middleware activation](xref:fundamentals/middleware/extensibility)
* [Build GitHub repository](https://github.com/hack2root/build)
* [Build documentation](https://build.experimentalcommunity.org)
