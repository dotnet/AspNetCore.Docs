---
title: Basic JSON APIs with Route-to-code in ASP.NET Core
author: jamesnk
description: Learn how to use Route-to-code and JSON extension methods to create lightweight JSON web APIs.
monikerRange: '>= aspnetcore-5.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 11/30/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, "Route-to-code"]
uid: web-api/route-to-code
---
# Basic JSON APIs with Route-to-code in ASP.NET Core

ASP.NET Core supports a number of ways of creating JSON web APIs:

* [ASP.NET Core web API](xref:web-api/index) provides a complete framework for creating APIs. A service is created by inheriting from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. Some features provided by the framework include model binding, validation, content negotiation, input and output formatting, and OpenAPI.
* Route-to-code is a non-framework alternative to ASP.NET Core web API. Route-to-code connects [ASP.NET Core routing](xref:fundamentals/routing) directly to your code. Your code reads from the request and writes the response. Route-to-code doesn't have web API's advanced features, but there's also no configuration required to use it.

Route-to-code is a good approach when building small and basic JSON web APIs.

## Create JSON web APIs

ASP.NET Core provides helper methods that ease the creation of JSON web APIs:

* <xref:Microsoft.AspNetCore.Http.HttpRequestJsonExtensions.HasJsonContentType%2A> checks the `Content-Type` header for a JSON content type.
* <xref:Microsoft.AspNetCore.Http.HttpRequestJsonExtensions.ReadFromJsonAsync%2A> reads JSON from the request and deserializes it to the specified type.
* <xref:Microsoft.AspNetCore.Http.HttpResponseJsonExtensions.WriteAsJsonAsync%2A> writes the specified value as JSON to the response body and sets the response content type to `application/json`.

Lightweight, route-based JSON APIs are specified in `Startup.cs`. The route and the API logic are configured in <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> as part of an app's request pipeline.

### Write JSON response

Consider the following code that configures a JSON API for an app:

[!code-csharp[](route-to-code/sample/Startup3.cs?name=snippet&highlight=6)]

The preceding code:

* Adds an HTTP GET API endpoint with `/hello/{name:alpha}` as the route template.
* When the route is matched, the API reads the `name` route value from the request.
* Writes an anonymous type as a JSON response with `WriteAsJsonAsync`.

### Read JSON request

`HasJsonContentType` and `ReadFromJsonAsync` can be used to deserialize a JSON response in a route-based JSON API:

[!code-csharp[](route-to-code/sample/Startup2.cs?name=snippet&highlight=5,11)]

The preceding code:

* Adds an HTTP POST API endpoint with `/weather` as the route template.
* When the route is matched, `HasJsonContentType` validates the request content type. A non-JSON content type returns a 415 status code.
* If the content type is JSON, the request content is deserialized by `ReadFromJsonAsync`.

### Configure JSON serialization

There are two ways to customize JSON serialization:

* Default serialization options can be configured with <xref:Microsoft.AspNetCore.Http.Json.JsonOptions> in the `Startup.ConfigureServices` method.
* `WriteAsJsonAsync` and `ReadFromJsonAsync` have overloads that accept a <xref:System.Text.Json.JsonSerializerOptions> object. This options object overrides the default options.

[!code-csharp[](route-to-code/sample/Startup6.cs?name=snippet)]

## Authentication and authorization

Route-to-code supports authentication and authorization. Attributes, such as `[Authorize]` and `[AllowAnonymous]`, can't be placed on endpoints that map to a request delegate. Instead, authorization metadata is added using the <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.AllowAnonymous%2A> extension methods.

[!code-csharp[](route-to-code/sample/Startup.cs?name=snippet&highlight=30)]

## Dependency injection

[Dependency injection (DI)](xref:fundamentals/dependency-injection) using a constructor isn't possible with Route-to-code. Web API creates a controller for you with services injected into the constructor. A type isn't created when an endpoint is executed, so services must be resolved manually.

Route-based APIs can use <xref:System.IServiceProvider> to resolve services:

* Transient and scoped lifetime services, such as `DbContext`, must be resolved from [HttpContext.RequestServices](xref:Microsoft.AspNetCore.Http.HttpContext.RequestServices) inside an endpoint's request delegate.
* Singleton lifetime services, such as `ILogger`, can be resolved from [IEndpointRouteBuilder.ServiceProvider](xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder.ServiceProvider). Services can be resolved outside of request delegates and shared between endpoints.

[!code-csharp[](route-to-code/sample/Startup4.cs?name=snippet&highlight=3,7)]

APIs that use DI extensively should consider using an ASP.NET Core app type that supports DI. For example, ASP.NET Core web API. Service injection using a controller's constructor is easier than manually resolving services.

## API project structure

Route-based APIs don't have to be located in `Startup.cs`. APIs can be placed in other files and mapped at startup with `UseEndpoints`. This approach reduces the startup configuration file size.

Consider the following static `UserApi` class that defines a `Map` method. The method maps route-based APIs.

[!code-csharp[](route-to-code/sample/UserApi.cs?name=snippet)]

In the `Startup.Configure` method, the `Map` method and other class's static methods are called in `UseEndpoints`:

[!code-csharp[](route-to-code/sample/Startup5.cs?name=snippet)]

## Notable missing features compared to Web API

Route-to-code is designed for basic JSON APIs. It doesn't have support for many of the advanced features provided by ASP.NET Core Web API.

Features not provided by Route-to-code include:

* Model binding
* Model validation
* OpenAPI/Swagger
* Content negotiation
* Constructor dependency injection
* `ProblemDetails` ([RFC 7807](https://tools.ietf.org/html/rfc7807))

Consider using [ASP.NET Core web API](xref:web-api/index) to create an API if it requires some of the features in the preceding list.

## Additional resources

* <xref:web-api/index>
* <xref:fundamentals/routing>
* <xref:fundamentals/dependency-injection>
