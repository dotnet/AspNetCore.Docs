---
title: Read and write JSON with ASP.NET Core Route to Code
author: jamesnk
description: Learn how to use route to code and JSON extension methods to create lightweight JSON web APIs.
monikerRange: '>= aspnetcore-5.0'
ms.author: jamesnk
ms.custom: mvc
ms.date: 10/22/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: web-api/route-to-code
---
# Read and write JSON with ASP.NET Core Route to Code

By [James Newton-King](https://github.com/jamesnk)

ASP.NET Core supports a number of ways of creating JSON web APIs:

* [ASP.NET Core Web API](xref:web-api/index) provides a complete framework for creating APIs. Services are created by inheriting from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. The framework provides support for model binding, validation, content negotiation, input and output formatting, OpenAPI, and much more.
* Route to code is a non-framework alternative to Web API. The route to code approach connects HTTP routing directly to your code. Your code reads directly from the request and writes the response. Route to code doesn't have Web API's advanced features, but there is also no configuration required to use it.

Route to code is a good approach when building small and basic JSON web APIs.

## Read and write JSON

ASP.NET Core provides helper methods to make it easy to create JSON APIs:

* `HasJsonContentType` checks the `Content-Type` header for a JSON content type.
* `ReadFromJsonAsync` reads JSON from the request and deserializes it to the specified type.
* `WriteAsJsonAsync` writes the specified value as JSON to the response body and sets the response content type to `application/json`.

Lightweight route-based JSON APIs are specified in *Startup.cs*. The route and the API logic is configured in `UseEndpoints` as part of an app's request pipeline.

[!code-csharp[](route-to-code/sample/Startup3.cs?name=snippet)]

The preceding code configures a JSON API for an app:

* Adds a `GET` API endpoint with `/hello/{name:alpha}` as the route template.
* When the route is matched the API reads the `name` route value from the request.
* Writes an anonymous type as JSON response with `WriteAsJsonAsync`.

`ReadFromJsonAsync` can be used to deserialize a JSON response in a route-based JSON API:

[!code-csharp[](route-to-code/sample/Startup2.cs?name=snippet)]

Attributes can't be placed on endpoints that register a request delegate. Instead, metadata is added using extension methods. For example, `RequireAuthorization` can be called when registering an endpoint to notify authorization middleware that callers of this endpoint must be authenticated.

[!code-csharp[](route-to-code/sample/Startup.cs?name=snippet)]


## Additional resources

* <xref:web-api/index>
* <xref:fundamentals/routing>
