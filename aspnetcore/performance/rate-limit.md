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

The [`RateLimiterOptionsExtensions`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions) class provide the following extension methods for rate limiting:

* [Fixed window limiter](#fixed)
* [Sliding window limiter](#slide)
* [Token bucket limiter](#token)
* [Concurrency  limiter](#concur)

<a name="fixed"></a>

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

<a name="slide"></a>

### Sliding window limiter

In the sliding window algorithm:

* Limits the requests for a window to `permitLimit` requests.
* Each time window is divided in `n` segments per window.
* Requests taken from the expired time segment one window back (`n` segments prior to the current segment), are added to the current segment. We refer to the expired time segment one window back as the expired segment.  Consider the following table which shows a sliding window limiter with a 30 second window, 3 segments per window and a limit of 100 requests:

* The top row and first column shows the time segment.
* The second row shows the remaining requests available.
* The third and lower rows rows show the requests made at that time segment and recycled requests available from the prior expired segment.
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

The follow table shows the data in the previous graph in a different format. The **Remaining** column shows the requests available from the previous segment (The **Carry over** from the previous row). The first row shows 100 available because there is no previous segment:

| Time | Remaining | Taken | Recycled from expired | Carry over |
| ---- | ----      | ------| ------                | ---- |
| 0    | 100       | 20    | 0                     | 80 |
| 10   | 80        | 30    | 0                     | 50 |
| 20   | 50        | 40    | 0                     | 10 |
| 30   | 10        | 30    | 20                    | 0  |
| 40   | 0         | 10    | 30                    | 20 |
| 50   | 20        | 10    | 40                    | 50 |
| 60   | 50        | 35    | 30                    | 45 |

The following code uses the sliding window rate limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_slide":::

<a name="token"></a>

### Token bucket limiter

The token bucket limiter is similar to the sliding window limiter, but rather than adding back the requests taken from the expired segment, a fixed number of tokens are added each replenishment period. The tokens added each segment cannot increase the available tokens to a number higher than the token bucket limit. The following table shows a token bucket limiter with a limit of 100 tokens and a 10 second replenishment period:

| Time | Remaining | Taken | Added | Carry over |
| ---- | ----      | ------| ------| ---- |
| 0    | 100       | 20    | 0     | 80 |
| 10   | 80        | 10    | 20    | 90 |
| 20   | 90        |  5    | 15    | 100 |
| 30   | 100       | 30    | 20    | 90  |
| 40   | 90        |  6    | 16    | 100 |
| 50   | 100       | 40    | 20    | 80 |
| 60   | 80        | 50    | 20    | 50 |

The following code uses the token bucket limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_token":::

<a name="concur"></a>

### Concurrency limiter

The concurrency limiter limits the number concurrent requests. Each request reduces the concurrency limit by one. When a request completes, the limit is increased by one. Unlike the other requests limiters that limit the total number of requests for a specified period, the concurrency limiter limits only the number of concurrent requests and doesn't cap the number of request in a time period.

The following code uses the concurrency limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_concur":::

## Limiter algorithm comparison

The fixed, sliding, and token limiter all limit the maximum number of requests in a time period. The concurrency limiter limits only the number of concurrent requests and doesn't cap the number of request in a time period. The cost of an endpoint should be considered when selecting a limiter. The cost of an endpoint includes the resources used, for example, time, CPU, and I/O.

:::moniker-end
