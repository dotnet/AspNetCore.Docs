### Rate-limiting middleware returns accurate `Retry-After` headers

The <xref:System.Threading.RateLimiting.FixedWindowRateLimiter> now reports a <xref:System.Threading.RateLimiting.MetadataName.RetryAfter> metadata value that accurately reflects the next window boundary. Apps that propagate this metadata to the `Retry-After` response header in their <xref:Microsoft.AspNetCore.RateLimiting.RateLimiterOptions.OnRejected> callback now produce correct retry intervals automatically, with no code changes required.

Additional fixes in `System.Threading.RateLimiting` resolve an issue where <xref:System.Threading.RateLimiting.TokenBucketRateLimiter> mishandled partial token refills during zero-permit acquisition, and improve the chained rate limiter returned by <xref:System.Threading.RateLimiting.RateLimiter.CreateChained*> to correctly forward idle-duration and replenishment behavior from its inner limiters.

For an overview of the rate limiting middleware, see [Rate limiting middleware in ASP.NET Core](/aspnet/core/performance/rate-limit).

Thank you [@asbjornvad](https://github.com/asbjornvad) and [@apoorvdarshan](https://github.com/apoorvdarshan) for these contributions!
