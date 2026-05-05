---
title: Route handlers in Minimal API apps
author: wadepickett
description: Learn how to handle route requests in Minimal API apps, define preferred methods, bind route parameters, and process the request response.
ms.author: wpickett
monikerRange: '>= aspnetcore-7.0'
ms.date: 04/28/2026
uid: fundamentals/minimal-apis/route-handlers

# customer intent: As an ASP.NET developer, I want to use route handlers in Minimal APIs, so I can define my preferred methods to execute when a route matches.
---

# Route handlers in Minimal API apps

[!INCLUDE[](~/includes/not-latest-version.md)]

A configured `WebApplication` supports `Map{Verb}` and the <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapMethods%2A>, where `{Verb}` is a Pascal-cased HTTP method like `Get`, `Post`, `Put`, or `Delete`:

[!code-csharp[](7.0-samples/WebMinAPIs/Program.cs?name=snippet_r1)]

The <xref:System.Delegate> arguments passed to these methods are called _route handlers_.

This article describes how to use route handlers, including examples, parameters, route groups, and route constraints.

## Work with route handlers

[!INCLUDE [route handling](includes/route-handlers.md)]

## Bind parameters in a route handler

<xref:fundamentals/minimal-apis/parameter-binding> describes the rules in detail for how route handler parameters are populated.

## Handle the response from the route handler

<xref:fundamentals/minimal-apis/responses> describes in detail how values returned from route handlers are converted into responses.

## Related content

- [Routing in ASP.NET Core](xref:fundamentals/routing)
- [Parameter Binding in Minimal API apps](xref:fundamentals/minimal-apis/parameter-binding)
- [Filters in Minimal API apps](xref:fundamentals/minimal-apis/min-api-filters)