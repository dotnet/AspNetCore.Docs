### Rate-limiting middleware returns accurate `Retry-After` headers

The <xref:System.Threading.RateLimiting.FixedWindowRateLimiter> now reports a <xref:System.Threading.RateLimiting.MetadataName.RetryAfter> metadata value that accurately reflects the next window boundary. The rate-limiting middleware uses this metadata to set the `Retry-After` response header, so clients that exceed the rate limit automatically receive a meaningful retry interval without any extra configuration.

Previously, the `RetryAfter` metadata wasn't reliably set, which meant rejected responses either lacked the header or contained an unhelpful value. With this fix, any app that uses the rate-limiting middleware with a <xref:System.Threading.RateLimiting.FixedWindowRateLimiter> benefits from correct `Retry-After` headers automatically.

The following example shows how a rate limiter lease exposes the `RetryAfter` metadata after a failed acquisition:

```csharp
using System.Threading.RateLimiting;

var limiter = new FixedWindowRateLimiter(new()
{
    PermitLimit = 10,
    Window = TimeSpan.FromSeconds(1),
    QueueLimit = 0,
});

RateLimitLease lease = limiter.AttemptAcquire();
if (!lease.IsAcquired && lease.TryGetMetadata(MetadataName.RetryAfter, out TimeSpan retry))
{
    Console.WriteLine($"Retry after {retry}.");
}
```

Additional fixes in `System.Threading.RateLimiting` resolve an issue where <xref:System.Threading.RateLimiting.TokenBucketRateLimiter> mishandled partial token refills during zero-permit acquisition, and improve `System.Threading.RateLimiting.ChainedRateLimiter` to correctly forward idle-duration and replenishment behavior from its inner limiters.

For more information, see [Rate limiting middleware in ASP.NET Core](/aspnet/core/performance/rate-limit).

Thank you [@asbjornvad](https://github.com/asbjornvad) and [@apoorvdarshan](https://github.com/apoorvdarshan) for these contributions!
