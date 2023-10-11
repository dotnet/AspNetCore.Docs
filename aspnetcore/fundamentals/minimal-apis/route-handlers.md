---
title: Route handlers in Minimal API apps
author: rick-anderson
description: Learn how to handle requests in Minimal API apps.
ms.author: riande
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/31/2022
uid: fundamentals/minimal-apis/route-handlers
---

# Route Handlers in Minimal API apps

A configured `WebApplication` supports `Map{Verb}` and <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapMethods%2A> where `{Verb}` is a Pascal-cased HTTP method like `Get`, `Post`, `Put` or `Delete`:

[!code-csharp[](7.0-samples/WebMinAPIs/Program.cs?name=snippet_r1)]

The <xref:System.Delegate> arguments passed to these methods are called "route handlers".

## Route handlers

[!INCLUDE [route handling](includes/route-handlers.md)]

## Parameter binding

<xref:fundamentals/minimal-apis/parameter-binding> describes the rules in detail for how route handler parameters are populated.

## Responses

<xref:fundamentals/minimal-apis/responses> describes in detail how values returned from route handlers are converted into responses.
