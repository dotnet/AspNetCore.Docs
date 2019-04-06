# ASP.NET Core Middleware Extensibility Sample

This sample demonstrates the scenarios described in [Factory-based middleware activation in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/middleware-extensibility).

The sample app demonstrates middleware activated by:

* Convention. For more information on conventional middleware activation, see the [Middleware](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/) topic.
* An [IMiddleware](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.imiddleware) implementation. The default [IMiddlewareFactory](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.imiddlewarefactory) class activates the middleware.

The middleware implementations function identically and record the value provided by a query string parameter (`key`). The middlewares use an injected database context (a scoped service) to record the query string value in an in-memory database.
