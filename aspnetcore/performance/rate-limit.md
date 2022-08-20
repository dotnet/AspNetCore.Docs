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

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_fixed":::


The preceding code creates a fixed window limiter with a policy name of `"fixed"` and sets:

* `permitLimit` to 4 and the time `window` to 12. A maximum of 4 requests per each 12 second window are allowed.
* `queueProcessingOrder` to `QueueProcessingOrder.OldestFirst`.
* `queueLimit` to 2.

Apps should use [Configuration](xref:fundamentals/configuration/index) to set limiter options. The preceding code using Configuration:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_fixed2":::

### Sliding window limiter

The sliding window algorithm is similar to the fixed window algorithm, but each time window is divided in `n` segments per window. When a time segment expires, the requests taken by the most recently expired segment are added to the current segment. Consider the following table which shows a sliding window limiter with a 30 second window, 3 segments per window and a limit of 100 requests:

* The top row and first column shows the time segment.
* The second row shows the remaining requests available.
* The third and lower rows rows show the requests made at that time segment.
* From time 30 on, the request taken from the 3 times slots previous are added back to the request limit.

| Time | 0  | 10  | 20 | 30 | 40 | 50 | 60 |
| ---- | -- | --  | -- | -- | -- | -- | -- |
| Remaining | 100-20+0=80 | 80-30+0=50  | 50-40+0=10 | 10-30+20=0 |0+30-10=20 | 20-10+40=50 | 50-35+30=45 |
|  0    | -20            |                                  |  |  |  |  | |
|  10   |               | -30                             |  |  |  |  | |
|  20   |               |            | -40                    |  |  |  | |
|  30   | **[+20]**     |            |         | -30        |  |  | |
|  40   |          |**[+30]**|       |                 | -10   |  | |
|  50   |          |           | **[+40]**  |            |               | -10  | |
|  60   |          |           |            |  **[+30]**  |    |  | -35|


| Time | Requests available | requests taken | requests recycled | total remaining |
| ---- | ---- | ----| ----| ---- |
| 0 | 100 | 20 taken| 0  | 80 remaining|
| 0 | 80 | 30 taken| 0  | 50 remaining|
| 20 | 50  | 40 taken| 0  | 10 remaining|
| 30 | 10  | 30 taken| 20  | 0 remaining|
| 40 | 0  | 10 taken| 30  | 20 remaining|
| 50 | 20  | 10 taken| 40  | 50 remaining|
| 60 | 50  | 35 taken| 30  | 45 remaining|


:::moniker-end
