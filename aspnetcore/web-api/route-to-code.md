---
title: Basic JSON APIs with Route to code in ASP.NET Core
author: jamesnk
description: Learn how to use route to code and JSON extension methods to create lightweight JSON web APIs.
monikerRange: '>= aspnetcore-5.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 10/22/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, "route to code"]
uid: web-api/route-to-code
---
# Basic JSON APIs with Route to code in ASP.NET Core

By [James Newton-King](https://github.com/jamesnk)

ASP.NET Core supports a number of ways of creating JSON web APIs:

* [ASP.NET Core Web API](xref:web-api/index) provides a complete framework for creating APIs. Services are created by inheriting from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. The framework provides support for model binding, validation, content negotiation, input and output formatting, OpenAPI, and much more.
* Route to code is a non-framework alternative to Web API. Route to code connects [ASP.NET Core routing](xref:fundamentals/routing) directly to your code. Your code reads from the request and writes the response. Route to code doesn't have Web API's advanced features, but there is also no configuration required to use it.

Route to code is a good approach when building small and basic JSON web APIs.

## Create JSON web APIs

ASP.NET Core provides helper methods to make it easy to create JSON web APIs:

* `HasJsonContentType` checks the `Content-Type` header for a JSON content type.
* `ReadFromJsonAsync` reads JSON from the request and deserializes it to the specified type.
* `WriteAsJsonAsync` writes the specified value as JSON to the response body and sets the response content type to `application/json`.

Lightweight route-based JSON APIs are specified in *Startup.cs*. The route and the API logic is configured in `UseEndpoints` as part of an app's request pipeline.

### Write JSON response

[!code-csharp[](route-to-code/sample/Startup3.cs?name=snippet&highlight=6)]

The preceding code configures a JSON API for an app:

* Adds a `GET` API endpoint with `/hello/{name:alpha}` as the route template.
* When the route is matched the API reads the `name` route value from the request.
* Writes an anonymous type as JSON response with `WriteAsJsonAsync`.

### Read JSON request

`HasJsonContentType` and `ReadFromJsonAsync` can be used to deserialize a JSON response in a route-based JSON API:

[!code-csharp[](route-to-code/sample/Startup2.cs?name=snippet&highlight=5,11)]

The preceding code:

* Adds a `POST` API endpoint with `/weather` as the route template.
* When the route is matched `HasJsonContentType` validates the request content type. A non-JSON content type returns a 415 status code.
* If the content type is JSON then the request content is deserialized by `ReadFromJsonAsync`.

### Configure JSON serialization

There are two ways to customize JSON serialization:

* Default serialization options can be configured with `JsonOptions`. This is done in *Startup.cs* `ConfigureServices`.
* `WriteAsJsonAsync` and `ReadFromJsonAsync` have overloads that accept a `JsonSerializerOptions`. This will override the default options.

[!code-csharp[](route-to-code/sample/Startup6.cs?name=snippet)]

## Authentication and authorization

Route to code supports authentication and authorization. Attributes, such as `[Authorize]` and `[AllowAnonymous]` can't be placed on endpoints that map to a request delegate. Instead, authorization metadata is added using the `RequireAuthorization` and `AllowAnonymous` extension methods.

[!code-csharp[](route-to-code/sample/Startup.cs?name=snippet&highlight=30)]

## Dependency injection

[Dependency injection (DI)](xref:fundamentals/dependency-injection) using a constructor is not possible with Route to code. Web API creates a controller for you with services injected into the constructor. A type isn't created when an endpoint is executed so services must be resolved manually.

Route-based APIs can use `IServiceProvider` to resolve services:

* Transient and scoped lifetime services, such as `DbContext`, must be resolved from [HttpContext.RequestServices](xref:Microsoft.AspNetCore.Http.HttpContext.RequestServices) inside an endpoint's request delegate.
* Singleton lifetime services, such as `ILogger`, can be resolved from [IEndpointRouteBuilder.ServiceProvider](xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder.ServiceProvider). Services can be resolved outside of request delegates and shared between endpoints.

[!code-csharp[](route-to-code/sample/Startup4.cs?name=snippet&highlight=3,7)]

APIs that heavily use DI should consider using an ASP.NET Core framework that supports DI, such as Web API. Service injection using a controller's constructor is easier to use than manually resolving services.

## API project structure

Route-based APIs don't have to be located in *Startup.cs*. APIs can be placed in other files and mapped at startup with `UseEndpoints`. This is a good approach to reducing the startup configuration file size.

[!code-csharp[](route-to-code/sample/UserApi.cs?name=snippet)]

[!code-csharp[](route-to-code/sample/Startup5.cs?name=snippet)]

The preceding code:

* Defines a static class `UserApi` with a method that maps route-based APIs.
* Calls `UserApi` and other static classes in `UseEndpoints`.

## Additional resources

* <xref:web-api/index>
* <xref:fundamentals/routing>
* <xref:fundamentals/dependency-injection>
