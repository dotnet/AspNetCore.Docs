---
title: Rate limiting middleware in ASP.NET Core
author: rick-anderson
description: Learn how limit requests in ASP.NET Core apps
ms.author: riande
ms.custom: mvc
ms.date: 4/05/2019
uid: performance/rate-limit
---

# Rate limiting middleware in ASP.NET Core

By [Arvin Kahbazi](https://github.com/Kahbazi) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-7.0"

The [Microsoft.AspNetCore.RateLimiting](https://www.nuget.org/packages/Microsoft.AspNetCore.RateLimiting) NuGet package provides rate limiting middleware. Apps configure rate limiting  policies and then attach the policies to endpoints.

## Rate limiter algorithms

The [`RateLimiterOptionsExtensions`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions) class provide several extension methods for rate limiting, which are explained in the following sections.

### Fixed window limiter

The [`AddFixedWindowLimiter`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions.addfixedwindowlimiter#microsoft-aspnetcore-ratelimiting-ratelimiteroptionsextensions-addfixedwindowlimiter(microsoft-aspnetcore-ratelimiting-ratelimiteroptions-system-string-system-threading-ratelimiting-fixedwindowratelimiteroptions)) uses a fixed time window to limit requests. When the time window expires, a new time window starts and the request limit is reset.

Consider the following code:

:::code language="csharp" source="~/performance/rate-limit/samples/Program.cs" id="snippet_fixed":::



:::moniker-end
