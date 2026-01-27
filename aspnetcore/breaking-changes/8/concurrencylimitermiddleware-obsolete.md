---
title: "Breaking change: ConcurrencyLimiterMiddleware is obsolete"
description: Learn about the breaking change in ASP.NET Core 8.0 where ConcurrencyLimiterMiddleware has been obsoleted.
ms.date: 05/03/2023
ms.custom: https://github.com/aspnet/Announcements/issues/502
---
# ConcurrencyLimiterMiddleware is obsolete

<xref:Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterMiddleware> and its associated methods and types have been marked as obsolete.

If you require rate-limiting capabilities, switch to the newer and more capable rate-limiting middleware that was introduced in .NET 7 (for example, <xref:Microsoft.AspNetCore.Builder.RateLimiterApplicationBuilderExtensions.UseRateLimiter%2A?displayProperty=nameWithType>). The .NET 7 rate-limiting API includes a concurrency limiter and several other rate-limiting algorithms that you can apply to your application.

## Version introduced

ASP.NET Core 8.0 Preview 4

## Previous behavior

Developers could use <xref:Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterMiddleware> to control concurrency by adding a policy to dependency injection (DI) and enabling the middleware:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddStackPolicy<options => {
    options.MaxConcurrentRequests = 2;
    options.RequestQueueLimit = 25;
    });

var app = builder.Build();
app.UseConcurrencyLimiter();
// Map endpoints.
app.Run();
```

## New behavior

If you use the [Affected APIs](#affected-apis) in your code, you'll get warning [`CS0618`](../../../../csharp/language-reference/compiler-messages/cs0618.md) at compile time.

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility).

## Reason for change

<xref:Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterMiddleware> is infrequently used and undocumented. The newer rate-limiting API has more extensive functionality.

## Recommended action

If you're using the older <xref:Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterMiddleware>, we recommend moving to the newer rate-limiting middleware. Here's an example usage of the newer API, <xref:Microsoft.AspNetCore.Builder.RateLimiterApplicationBuilderExtensions.UseRateLimiter%2A?displayProperty=nameWithType>:

```csharp
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRateLimiter(new RateLimiterOptions()
    .AddConcurrencyLimiter("only-one-at-a-time-stacked", (options) =>
    {
        options.PermitLimit = 2;
        options.QueueLimit = 25;
        options.QueueProcessingOrder = QueueProcessingOrder.NewestFirst;
    }));

app.MapGet("/", async () =>
{
    await Task.Delay(10000);
    return "Hello World";
}).RequireRateLimiting("only-one-at-a-time-stacked");

app.Run();
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.ConcurrencyLimiterExtensions.UseConcurrencyLimiter(Microsoft.AspNetCore.Builder.IApplicationBuilder)?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterMiddleware?displayProperty=fullName>
- <xref:System.Threading.RateLimiting.ConcurrencyLimiterOptions?displayProperty=fullName>

## See also

- [Rate limiting middleware in ASP.NET Core](/aspnet/core/performance/rate-limit)
