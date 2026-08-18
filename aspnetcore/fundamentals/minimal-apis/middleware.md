---
title: Middleware in ASP.NET Core apps
ai-usage: ai-assisted
author: BrennanConroy
description: Use middleware in ASP.NET Core apps, including automatic middleware added by WebApplication, user-configured middleware, and terminal middleware.
monikerRange: '>= aspnetcore-7.0'
ms.author: wpickett
ms.date: 08/18/2026
uid: fundamentals/minimal-apis/middleware

# customer intent: As an ASP.NET Core developer, I want to use middleware, so I can handle requests and responses in my ASP.NET Core apps.
---

# Middleware in ASP.NET Core apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes the middleware that <xref:Microsoft.AspNetCore.Builder.WebApplication> configures automatically in ASP.NET Core apps and explains how to customize the request pipeline. Most ASP.NET Core apps, including Minimal API, web API, MVC, Razor Pages, and server-side Blazor apps, are built with `WebApplication`, which adds a default set of middleware based on the app's registered services and hosting environment. You can rely on the automatic middleware, add your own user-configured middleware, or define terminal middleware.

## Available middleware

[!INCLUDE [webapplication7](~/fundamentals/minimal-apis/includes/middleware7.md)]
[!INCLUDE [webapplication8](~/fundamentals/minimal-apis/includes/middleware8.md)]

## Related content

- [ASP.NET Core middleware](xref:fundamentals/middleware/index)
- [Built-in middleware (list)](xref:fundamentals/middleware/index#built-in-middleware)
- [Minimal APIs overview](xref:fundamentals/apis)