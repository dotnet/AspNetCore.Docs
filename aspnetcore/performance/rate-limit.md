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

The sliding window algorithm is similar to the fixed window algorithm, but each time window is divided in `n` segments per window. When a time window segment expires, the requests taken by the expired segment are added to the current segment. Consider the following table which shows a sliding window limiter with 3 segments per window and a limit of 100 requests. The top rows shows the time, the second row shows the remaining requests available, and each of the following rows shows the requests made at that time segment. Three rows below each requests at time entry shows those requests available for the current time segment.

| Time | 0  | 10  | 20 | 30 | 40 | 50 | 60 |
| ---- | -- | --  | -- | -- | -- | -- | -- |
| Remaining | 100-20=80 | 80-30=50  | 50-40=10 | 10+20-30=0 |0+30-10=20 | 20-10+40=50 | 50-10+50=90 |
|  0    | 20            |                                  |  |  |  |  | |
|  10   |               | 30                             |  |  |  |  | |
|  20   |               |            | 40                    |  |  |  | |
|  30   | **[+20]**     |            |         | 30        |  |  | |
|  40   |          |**[+30]**|       |                 | 10   |  | |
|  50   |          |           | **[+40]**  |            |               | 10  | |
|  60   |          |           |            |  **[+30]**  |    |  | 50|




:::moniker-end
