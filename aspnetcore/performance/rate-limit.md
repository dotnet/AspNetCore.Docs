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

:::code language="csharp" source="~/performance/rate-limit/samples/Program.cs" id="snippet_fixed" highlight="10-15,18":::

The preceding code creates a fixed window limiter with a policy name of `"fixed"` and sets:

* `permitLimit` to 4 and the time `window` to 12. A maximum of 4 requests per each 12 second window are allowed.
* `queueProcessingOrder` to `QueueProcessingOrder.OldestFirst`.
* `queueLimit` to 2.

Apps should use [Configuration](xref:fundamentals/configuration/index) to set limiter options. The preceding code using Configuration:

:::code language="csharp" source="~/performance/rate-limit/samples/Program.cs" id="snippet_fixed2" highlight="19,20,22":::

### Sliding window limiter

| Time | 0  | 10  | 20 | 30 | 40 | 50 |
| ---- | -- | --  | -- | -- | -- | -- |
|      | 20 (80) |   | |  |  |  |
|      |         | 30 (50)  |  |  |  |  |
|      |         |          | 40 (10) |  |  |  |
|      | **[+20]**|         |         | 30 (10+20-30=0) |  |  |
|      |          | **[+30]** |       |                 | 10 (0+30=30)  |  |
|      |          |           | **[+40]**  |            |               | 10 (30+40=70) |


:::moniker-end
