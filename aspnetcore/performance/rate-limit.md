---
title: Rate limiting middleware in ASP.NET Core
author: rick-anderson
monikerRange: '>= aspnetcore-7.0'
description: Learn how limit requests in ASP.NET Core apps
ms.author: riande
ms.custom: mvc
ms.date: 10/29/2022
uid: performance/rate-limit
---

# Rate limiting middleware in ASP.NET Core

By [Arvin Kahbazi](https://github.com/Kahbazi), [Maarten Balliauw](https://github.com/maartenba), and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-7.0"

The `Microsoft.AspNetCore.RateLimiting` middleware provides rate limiting middleware. Apps configure rate limiting policies and then attach the policies to endpoints. Apps using rate limiting should be carefully load tested and reviewed before deploying. See [Testing endpoints with rate limiting](#test7) in this article for more information.

For an introduction to rate limiting, see [Rate limiting middleware](https://blog.maartenballiauw.be/post/2022/09/26/aspnet-core-rate-limiting-middleware.html).

## Rate limiter algorithms

The [`RateLimiterOptionsExtensions`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions) class provides the following extension methods for rate limiting:

* [Fixed window](#fixed)
* [Sliding window](#slide)
* [Token bucket](#token)
* [Concurrency](#concur)

<a name="fixed"></a>

### Fixed window limiter

The [`AddFixedWindowLimiter`](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions.addfixedwindowlimiter#microsoft-aspnetcore-ratelimiting-ratelimiteroptionsextensions-addfixedwindowlimiter(microsoft-aspnetcore-ratelimiting-ratelimiteroptions-system-string-system-threading-ratelimiting-fixedwindowratelimiteroptions)) method uses a fixed time window to limit requests. When the time window expires, a new time window starts and the request limit is reset.

Consider the following code:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_fixed":::

The preceding code:

* Calls <xref:Microsoft.AspNetCore.Builder.RateLimiterServiceCollectionExtensions.AddRateLimiter%2A> to add a rate limiting service to the service collection.
* Calls `AddFixedWindowLimiter` to create a fixed window limiter with a policy name of `"fixed"` and sets:
* <xref:System.Threading.RateLimiting.FixedWindowRateLimiterOptions.PermitLimit> to 4 and the time <xref:System.Threading.RateLimiting.FixedWindowRateLimiterOptions.Window> to 12. A maximum of 4 requests per each 12-second window are allowed.
* <xref:System.Threading.RateLimiting.FixedWindowRateLimiterOptions.QueueProcessingOrder> to <xref:System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst>.
* <xref:System.Threading.RateLimiting.FixedWindowRateLimiterOptions.QueueLimit> to 2.
* Calls [UseRateLimiter](/dotnet/api/microsoft.aspnetcore.builder.ratelimiterapplicationbuilderextensions.useratelimiter) to enable rate limiting.

Apps should use [Configuration](xref:fundamentals/configuration/index) to set limiter options. The following code updates the preceding code using [`MyRateLimitOptions`](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/fundamentals/middleware/rate-limit/WebRateLimitAuth/Models/MyRateLimitOptions.cs) for configuration:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_fixed2":::

<xref:Microsoft.AspNetCore.Builder.RateLimiterApplicationBuilderExtensions.UseRateLimiter%2A> must be called after `UseRouting` when rate limiting endpoint specific APIs are used. For example, if the [`[EnableRateLimiting]`](xref:Microsoft.AspNetCore.RateLimiting.EnableRateLimitingAttribute) attribute is used, `UseRateLimiter` must be called after `UseRouting`. When calling only global limiters, `UseRateLimiter` can be called before `UseRouting`.

<a name="slide"></a>

### Sliding window limiter

A sliding window algorithm:

* Is similar to the fixed window limiter but adds segments per window. The window slides one segment each segment interval. The segment interval is (window time)/(segments per window).
* Limits the requests for a window to `permitLimit` requests.
* Each time window is divided in `n` segments per window.
* Requests taken from the expired time segment one window back (`n` segments prior to the current segment) are added to the current segment. We refer to the most expired time segment one window back as the expired segment.

Consider the following table that shows a sliding window limiter with a 30-second window, three segments per window, and a limit of 100 requests:

* The top row and first column shows the time segment.
* The second row shows the remaining requests available. The remaining requests are calculated as the available requests minus the processed requests plus the recycled requests.
* Requests at each time moves along the diagonal blue line.
* From time 30 on, the request taken from the expired time segment are added back to the request limit, as shown in the red lines.

![Table showing requests, limits, and recycled slots](~/performance/rate-limit/_static/rate.png)

<!-- 
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
-->

The following table shows the data in the previous graph in a different format. The **Available** column shows the requests available from the previous segment (The **Carry over** from the previous row). The first row shows 100 available requests because there's no previous segment.

| Time | Available | Taken | Recycled from expired | Carry over |
| :--: | :-------: | :---: | :-------------------: | :--------: |
| 0    | 100       | 20    | 0                     | 80         |
| 10   | 80        | 30    | 0                     | 50         |
| 20   | 50        | 40    | 0                     | 10         |
| 30   | 10        | 30    | 20                    | 0          |
| 40   | 0         | 10    | 30                    | 20         |
| 50   | 20        | 10    | 40                    | 50         |
| 60   | 50        | 35    | 30                    | 45         |

The following code uses the sliding window rate limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_slide":::

<a name="token"></a>

### Token bucket limiter

The token bucket limiter is similar to the sliding window limiter, but rather than adding back the requests taken from the expired segment, a fixed number of tokens are added each replenishment period. The tokens added each segment can't increase the available tokens to a number higher than the token bucket limit. The following table shows a token bucket limiter with a limit of 100 tokens and a 10-second replenishment period.

| Time | Available | Taken | Added | Carry over |
| :--: | :-------: | :---: | :---: | :--------: |
| 0    | 100       | 20    | 0     | 80         |
| 10   | 80        | 10    | 20    | 90         |
| 20   | 90        | 5     | 15    | 100        |
| 30   | 100       | 30    | 20    | 90         |
| 40   | 90        | 6     | 16    | 100        |
| 50   | 100       | 40    | 20    | 80         |
| 60   | 80        | 50    | 20    | 50         |

The following code uses the token bucket limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_token":::

When <xref:System.Threading.RateLimiting.TokenBucketRateLimiterOptions.AutoReplenishment%2A> is set to `true`, an internal timer replenishes the tokens every <xref:System.Threading.RateLimiting.TokenBucketRateLimiter.ReplenishmentPeriod%2A>; when set to `false`, the app must call <xref:System.Threading.RateLimiting.TokenBucketRateLimiter.TryReplenish%2A> on the limiter.

<a name="concur"></a>

### Concurrency limiter

The concurrency limiter limits the number of concurrent requests. Each request reduces the concurrency limit by one. When a request completes, the limit is increased by one. Unlike the other requests limiters that limit the total number of requests for a specified period, the concurrency limiter limits only the number of concurrent requests and doesn't cap the number of requests in a time period.

The following code uses the concurrency limiter:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_concur":::

### Create chained limiters

The <xref:System.Threading.RateLimiting.PartitionedRateLimiter.CreateChained%2A> API allows passing in multiple <xref:System.Threading.RateLimiting.PartitionedRateLimiter> which are combined into one `PartitionedRateLimiter`. The combined limiter runs all the input limiters in sequence.

The following code uses `CreateChained`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Program.cs" id="snippet_3" highlight="21,51":::

For more information, see the [CreateChained source code](https://github.com/dotnet/runtime/blob/79874806d246670ee5fe76e73ce566578fe675c0/src/libraries/System.Threading.RateLimiting/src/System/Threading/RateLimiting/PartitionedRateLimiter.cs#L52-L64)

## `EnableRateLimiting` and `DisableRateLimiting` attributes

The [`[EnableRateLimiting]`](xref:Microsoft.AspNetCore.RateLimiting.EnableRateLimitingAttribute) and [`[DisableRateLimiting]`](xref:Microsoft.AspNetCore.RateLimiting.DisableRateLimitingAttribute) attributes can be applied to a Controller, action method, or Razor Page. For Razor Pages, the attribute must be applied to the Razor Page and not the page handlers. For example, `[EnableRateLimiting]` can't be applied to `OnGet`, `OnPost`, or any other page handler.

The `[DisableRateLimiting]` attribute ***disables*** rate limiting to the Controller, action method, or Razor Page regardless of named rate limiters or global limiters applied. For example, consider the following code which calls <xref:Microsoft.AspNetCore.Builder.RateLimiterEndpointConventionBuilderExtensions.RequireRateLimiting%2A> to apply the `fixedPolicy` rate limiting to all controller endpoints:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Program.cs" id="snippet_1" highlight="51":::

In the following code, `[DisableRateLimiting]` disables rate limiting and overrides `[EnableRateLimiting("fixed")]` applied to the `Home2Controller` and `app.MapDefaultControllerRoute().RequireRateLimiting(fixedPolicy)` called in `Program.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Controllers/Home2Controller.cs" id="snippet_1" highlight="1,16,22":::

In the preceding code, the `[EnableRateLimiting("sliding")]` is ***not*** applied to the `Privacy` action method because `Program.cs` called `app.MapDefaultControllerRoute().RequireRateLimiting(fixedPolicy)`. <!-- https://github.com/dotnet/AspNetCore.Docs/pull/27294#discussion_r998484867 -->

Consider the following code which doesn't call `RequireRateLimiting` on `MapRazorPages` or `MapDefaultControllerRoute`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Program.cs" id="snippet_2" highlight="51-52":::

Consider the following controller:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRate2/Controllers/Home2Controller.cs" id="snippet_1" highlight="1,16,22":::

In the preceding controller:

* The `"fixed"` policy rate limiter is applied to all action methods that don't have `EnableRateLimiting` and `DisableRateLimiting` attributes.
* The `"sliding"` policy rate limiter is applied to the `Privacy` action.
* Rate limiting is disabled on the `NoLimit` action method.

### Applying attributes to Razor Pages

For Razor Pages, the attribute must be applied to the Razor Page and not the page handlers. For example, `[EnableRateLimiting]` can't be applied to `OnGet`, `OnPost`, or any other page handler.

The `DisableRateLimiting` attribute disables rate limiting on a Razor Page. `EnableRateLimiting` is only applied to a Razor Page if `MapRazorPages().RequireRateLimiting(Policy)` has ***not*** been called.

## Limiter algorithm comparison

The fixed, sliding, and token limiters all limit the maximum number of requests in a time period. The concurrency limiter limits only the number of concurrent requests and doesn't cap the number of requests in a time period. The cost of an endpoint should be considered when selecting a limiter. The cost of an endpoint includes the resources used, for example, time, data access, CPU, and I/O.

## Rate limiter samples

The following samples aren't meant for production code but are examples on how to use the limiters.

### Limiter with `OnRejected`, `RetryAfter`, and `GlobalLimiter`

The following sample:

* Creates a [RateLimiterOptions.OnRejected](xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.OnRejected) callback that is called when a request exceeds the specified limit. `retryAfter` can be used with the [`TokenBucketRateLimiter`](https://source.dot.net/#System.Threading.RateLimiting/System/Threading/RateLimiting/TokenBucketRateLimiter.cs), [`FixedWindowLimiter`](https://source.dot.net/#System.Threading.RateLimiting/System/Threading/RateLimiting/FixedWindowRateLimiter.cs), and [`SlidingWindowLimiter`](https://source.dot.net/#System.Threading.RateLimiting/System/Threading/RateLimiting/SlidingWindowRateLimiter.cs) because these algorithms are able to estimate when more permits will be added. The `ConcurrencyLimiter` has no way of calculating when permits will be available.
* Adds the following limiters:

  * A `SampleRateLimiterPolicy` which implements the `IRateLimiterPolicy<TPartitionKey>` interface. The `SampleRateLimiterPolicy` class is shown later in this article.
  * A `SlidingWindowLimiter`:
    * With a partition for each authenticated user.
    * One shared partition for all anonymous users.
  * A <xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.GlobalLimiter> that is applied to all requests. The global limiter will be executed first, followed by the endpoint-specific limiter, if one exists. The `GlobalLimiter` creates a partition for each <xref:System.Net.IPAddress>.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs" id="snippet_1":::

> [!WARNING]
>Creating partitions on client IP addresses makes the app vulnerable to Denial of Service Attacks which employ IP Source Address Spoofing. For more information, see [BCP 38 RFC 2827 Network Ingress Filtering: Defeating Denial of Service Attacks which employ IP Source Address Spoofing](https://www.rfc-editor.org/info/bcp38).

See [the samples repository for the complete `Program.cs`](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/fundamentals/middleware/rate-limit/WebRateLimitAuth/Program.cs#L145,L281) file.

The `SampleRateLimiterPolicy` class

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/middleware/rate-limit/WebRateLimitAuth/SampleRateLimiterPolicy.cs" id="snippet_1":::

In the preceding code, <xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.OnRejected> uses <xref:Microsoft.AspNetCore.RateLimiting.OnRejectedContext> to set the response status to [429 Too Many Requests](https://developer.mozilla.org/docs/Web/HTTP/Status/429). The default rejected status is [503 Service Unavailable](https://developer.mozilla.org/docs/Web/HTTP/Status/503).

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

Before deploying an app using rate limiting to production, stress test the app to validate the rate limiters and options used. For example, create a [JMeter script](https://jmeter.apache.org/usermanual/jmeter_proxy_step_by_step.html) with a tool like [BlazeMeter](https://guide.blazemeter.com/hc/articles/207421695-Writing-your-first-JMeter-script) or [Apache JMeter HTTP(S) Test Script Recorder](https://jmeter.apache.org/usermanual/jmeter_proxy_step_by_step.html) and load the script to [Azure Load Testing](/azure/load-testing/overview-what-is-azure-load-testing).

Creating partitions with user input makes the app vulnerable to [Denial of Service](https://www.cisa.gov/uscert/ncas/tips/ST04-015) (DoS) Attacks. For example, creating partitions on client IP addresses makes the app vulnerable to Denial of Service Attacks that employ IP Source Address Spoofing. For more information, see [BCP 38 RFC 2827 Network Ingress Filtering: Defeating Denial of Service Attacks that employ IP Source Address Spoofing](https://www.rfc-editor.org/info/bcp38).

## Additional resources

* [Rate limiting middleware](https://blog.maartenballiauw.be/post/2022/09/26/aspnet-core-rate-limiting-middleware.html) by Maarten Balliauw provides an excellent introduction and overview to rate limiting.
* [Rate limit an HTTP handler in .NET](/dotnet/core/extensions/http-ratelimiter)

:::moniker-end
