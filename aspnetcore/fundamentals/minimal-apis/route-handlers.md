---
title: Route handlers in Minimal API applications
author: rick-anderson
description: Learn how to handle requests in Minimal API applications.
ms.author: riande
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/31/2022
uid: fundamentals/minimal-apis/route-handlers
---

# Route Handlers

A configured `WebApplication` supports `Map{Verb}` and <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapMethods%2A>:

[!code-csharp[](minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_r1)]

The second parameter to these methods are called the "route handlers".

[!INCLUDE [route handling](includes/route-handling.md)]
