---
title: Rate limiting middleware samsples
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-7.0'
description: Samples for using ASP.NET rate limitng middleware
ms.custom: mvc
ms.date: 03/05/2025
uid: performance/rate-limit-sample
---

# Rate limiter samples

The following samples aren't production quality, they're examples on how to use the limiters.

### Limiter with `OnRejected`, `RetryAfter`, and `GlobalLimiter`

The following sample:

* Creates a [RateLimiterOptions.OnRejected](xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.OnRejected) callback that is called when a request exceeds the specified limit. `retryAfter` can be used with the [TokenBucketRateLimiter](/dotnet/api/system.threading.ratelimiting.tokenbucketratelimiter), [FixedWindowLimiter](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions.addfixedwindowlimiter), and [SlidingWindowLimiter](/dotnet/api/microsoft.aspnetcore.ratelimiting.ratelimiteroptionsextensions.addslidingwindowlimiter) because these algorithms are able to estimate when more permits will be added. The `ConcurrencyLimiter` has no way of calculating when permits will be available.
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