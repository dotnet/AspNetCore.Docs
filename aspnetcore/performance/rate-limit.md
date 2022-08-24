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

The [Microsoft.AspNetCore.RateLimiting](https://www.nuget.org/packages/Microsoft.AspNetCore.RateLimiting) NuGet package provides rate limiting middleware. Apps configure rate limiting policies and then attach the policies to endpoints. Apps using rate limiting should be carefully load tested before deploying. See [Testing endpoints with rate limiting](#test7) in this article for more information.

## Rate limiter algorithms

The [`RateLimiterOptionsExtensions`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions) class provide the following extension methods for rate limiting:

* [Fixed window](#fixed)
* [Sliding window](#slide)
* [Token bucket](#token)
* [Concurrency](#concur)

<a name="fixed"></a>

### Fixed window limiter

The [`AddFixedWindowLimiter`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions.addfixedwindowlimiter#microsoft-aspnetcore-ratelimiting-ratelimiteroptionsextensions-addfixedwindowlimiter(microsoft-aspnetcore-ratelimiting-ratelimiteroptions-system-string-system-threading-ratelimiting-fixedwindowratelimiteroptions)) uses a fixed time window to limit requests. When the time window expires, a new time window starts and the request limit is reset.

Consider the following code:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_fixed":::

The preceding code:
* Calls <xref:Microsoft.AspNetCore.Builder.RateLimiterApplicationBuilderExtensions.UseRateLimiter> to enable rate limiting.
* Creates a fixed window limiter with a policy name of `"fixed"` and sets:
* `permitLimit` to 4 and the time `window` to 12. A maximum of 4 requests per each 12 second window are allowed.
* `queueProcessingOrder` to `QueueProcessingOrder.OldestFirst`.
* `queueLimit` to 2.

Apps should use [Configuration](xref:fundamentals/configuration/index) to set limiter options. The preceding code using Configuration:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_fixed2":::

<a name="slide"></a>

### Sliding window limiter

In the sliding window algorithm:

* Is similar to the fixed window limiter but adds segments per window. The window slides one segment (window)/(segments per window).
* Limits the requests for a window to `permitLimit` requests.
* Each time window is divided in `n` segments per window.
* Requests taken from the expired time segment one window back (`n` segments prior to the current segment), are added to the current segment. We refer to the most expired time segment one window back as the expired segment.  Consider the following table which shows a sliding window limiter with a 30 second window, 3 segments per window and a limit of 100 requests:

* The top row and first column shows the time segment.
* The second row shows the remaining requests available. The remaining requests are available-requests+recycled.
* The third and lower rows show the requests made at that time segment and recycled requests available from the prior expired segment.
* From time 30 on, the request taken from the 3 times slots previous are added back to the request limit.

| Time | 0  | 10  | 20 | 30 | 40 | 50 | 60 |
| ---- | -- | --  | -- | -- | -- | -- | -- |
| Available | 100-20+0=80 | 80-30+0=50  | 50-40+0=10 | 10-30+20=0 |0+30-10=20 | 20-10+40=50 | 50-35+30=45 |
|  0    | -20            |                                  |  |  |  |  | |
|  10   |               | -30                             |  |  |  |  | |
|  20   |               |            | -40                    |  |  |  | |
|  30   | **[+20]**     |            |         | -30        |  |  | |
|  40   |          |**[+30]**|       |                 | -10   |  | |
|  50   |          |           | **[+40]**  |            |               | -10  | |
|  60   |          |           |            |  **[+30]**  |    |  | -35|

The following table shows the data in the previous graph in a different format. The **Remaining** column shows the requests available from the previous segment (The **Carry over** from the previous row). The first row shows 100 available because there's no previous segment:

| Time | Available | Taken | Recycled from expired | Carry over |
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

The token bucket limiter is similar to the sliding window limiter, but rather than adding back the requests taken from the expired segment, a fixed number of tokens are added each replenishment period. The tokens added each segment can't increase the available tokens to a number higher than the token bucket limit. The following table shows a token bucket limiter with a limit of 100 tokens and a 10 second replenishment period:

| Time | Available | Taken | Added | Carry over |
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

When `autoReplenishment` is set to `true`, an internal timer replenishes the tokens every `replenishmentPeriod`; when set to `false`, the app must call `TryReplenish` on the limiter.

<a name="concur"></a>

### Concurrency limiter

The concurrency limiter limits the number concurrent requests. Each request reduces the concurrency limit by one. When a request completes, the limit is increased by one. Unlike the other requests limiters that limit the total number of requests for a specified period, the concurrency limiter limits only the number of concurrent requests and doesn't cap the number of requests in a time period.

The following code uses the concurrency limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_concur":::

## Limiter algorithm comparison

The fixed, sliding, and token limiter all limit the maximum number of requests in a time period. The concurrency limiter limits only the number of concurrent requests and doesn't cap the number of requests in a time period. The cost of an endpoint should be considered when selecting a limiter. The cost of an endpoint includes the resources used, for example, data access, CPU, and I/O.

## Rate limiter samples

The following samples aren't meant for production code but examples on how to use the limiters.

### Limiter with `OnRejected`, `RetryAfter`, and `GlobalLimiter`

The following sample:

* Creates a [RateLimiterOptions.OnRejected](xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.OnRejected) callback that is called when a request exceeds the specified limit. `retryAfter` can be used with the[`TokenBucketRateLimiter`](https://source.dot.net/#System.Threading.RateLimiting/System/Threading/RateLimiting/TokenBucketRateLimiter.cs), [`FixedWindowLimiter`](https://source.dot.net/#System.Threading.RateLimiting/System/Threading/RateLimiting/FixedWindowRateLimiter.cs), and [`SlidingWindowLimiter`](https://source.dot.net/#System.Threading.RateLimiting/System/Threading/RateLimiting/SlidingWindowRateLimiter.cs) because these algorithms are able to calculate when limits will be added. The `ConcurrencyLimiter` has no way of calculating when permits will be available.
* Adds the following limiters:

  * A `SampleRateLimiterPolicy` which implements the `IRateLimiterPolicy<TPartitionKey>` interface. The `SampleRateLimiterPolicy` class is shown later in this article.
  * A `SlidingWindowLimiter`:
    * With a partition for each authenticated user.
    * One partition for all anonymous users.
  * A <xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.GlobalLimiter> that is applied to all requests. The global limiter will be executed first, followed by the endpoint-specific limiter, if one exists. The `GlobalLimiter` creates a partition for each <xref:System.Net.IPAddress>.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet":::

> [!WARNING]
>Creating partitions on client IP addresses makes the app vulnerable to Denial of Service Attacks which employ IP Source Address Spoofing. For more information, see [BCP 38 RFC 2827 Network Ingress Filtering: Defeating Denial of Service Attacks which employ IP Source Address Spoofing](https://www.rfc-editor.org/info/bcp38).

See [the samples repository for the complete `Program.cs`](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs#L145,L281) file.

The `SampleRateLimiterPolicy` class

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/SampleRateLimiterPolicy.cs" id="snippet_1":::

In the preceding code, <xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.OnRejected> uses <xref:Microsoft.AspNetCore.RateLimiting.OnRejectedContext> to set the response status to [429 Too Many Requests](https://developer.mozilla.org/docs/Web/HTTP/Status/429). The default rejected status is [503 Service Unavailable](https://developer.mozilla.org/docs/Web/HTTP/Status/503).

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/SampleRateLimiterPolicy.cs" id="snippet":::

### Limiter with authorization

The following sample uses JSON Web Tokens (JWT) and creates a partition with the JWT [access token](https://github.com/dotnet/aspnetcore/blob/fd1891536f27e959d14a140ff9307b6a21191de9/src/Security/Authentication/JwtBearer/src/JwtBearerHandler.cs#L152-L158). In a production app, the JWT would typically be provided by a server acting as a Security token service (STS). For local development, the dotnet [user-jwts](xref:security/authentication/jwt) command line tool can be used to create and manage app-specific local JWTs.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_jwt":::

### Limiter with `ConcurrencyLimiter`, `TokenBucketRateLimiter`, and authorization

The following sample:

* Adds a `ConcurrencyLimiter` with a policy name of `"get"` that is used on the Razor Pages.
* Adds a `TokenBucketRateLimiter` with a partition for each authorized user and a partition for all anonymous users.
* Sets [RateLimiterOptions.RejectionStatusCode](xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.RejectionStatusCode) to [429 Too Many Requests](https://developer.mozilla.org/docs/Web/HTTP/Status/429).

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_adm2":::

See [the samples repository for the complete `Program.cs`](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs#L145,L281) file.

<a name="test7"></a>

## Testing endpoints with rate limiting

Before deploying an app using rate limiting to production, it's a good idea to stress test the app to validate the rate limiters and options used. For example, create a [JMeter script](https://jmeter.apache.org/usermanual/jmeter_proxy_step_by_step.html) with a tool like [BlazeMeter](https://guide.blazemeter.com/hc/articles/207421695-Writing-your-first-JMeter-script) or [Apache JMeter HTTP(S) Test Script Recorder](https://jmeter.apache.org/usermanual/jmeter_proxy_step_by_step.html) and load the script to [Azure Load Testing](/azure/load-testing/overview-what-is-azure-load-testing).

Creating partitions with user input makes the app vulnerable to [Denial of Service](https://www.cisa.gov/uscert/ncas/tips/ST04-015) (DoS) Attacks. For example, creating partitions on client IP addresses makes the app vulnerable to Denial of Service Attacks which employ IP Source Address Spoofing. For more information, see [BCP 38 RFC 2827 Network Ingress Filtering: Defeating Denial of Service Attacks which employ IP Source Address Spoofing](https://www.rfc-editor.org/info/bcp38).

:::moniker-end
