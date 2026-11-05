---
title: Route handlers in Minimal API apps
ai-usage: ai-assisted
description: Learn how to handle route requests in Minimal API apps, define preferred methods, bind route parameters, and process the request response.
monikerRange: '>= aspnetcore-7.0'
ms.date: 04/28/2026

# customer intent: As an ASP.NET developer, I want to use route handlers in Minimal APIs, so I can define my preferred methods to execute when a route matches.
---

# Route handlers in Minimal API apps

[!INCLUDE[](~/includes/not-latest-version.md)]

A configured `WebApplication` supports `Map{Verb}` and the <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapMethods*>, where `{Verb}` is a Pascal-cased HTTP method like `Get`, `Post`, `Put`, or `Delete`:

[!code-csharp[](samples/7.0/WebMinAPIs/Program.cs?name=snippet_r1)]

The <xref:System.Delegate> arguments passed to these methods are called _route handlers_.

This article describes how to use route handlers, including examples, parameters, route groups, and route constraints.

## Work with route handlers

[!INCLUDE [route handling](includes/route-handlers.md)]

## Bind parameters in a route handler

[Parameter binding in Minimal API applications](parameter-binding.md) describes the rules in detail for how route handler parameters are populated.

## Handle the response from the route handler

[Create responses in Minimal API applications](responses.md) describes in detail how values returned from route handlers are converted into responses.

## Related content

- [Routing in ASP.NET Core](../routing.md)
- [Parameter Binding in Minimal API apps](parameter-binding.md)
- [Filters in Minimal API apps](min-api-filters.md)