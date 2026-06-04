---
title: "Breaking change: ConcurrencyLimiter middleware removed"
description: "Learn about the breaking change in ASP.NET Core 11 where the Microsoft.AspNetCore.ConcurrencyLimiter package and middleware are removed. Use the rate-limiting middleware instead."
ms.date: 06/04/2026
ai-usage: ai-assisted
---

# ConcurrencyLimiter middleware removed

The `Microsoft.AspNetCore.ConcurrencyLimiter` package and its middleware have been removed from ASP.NET Core 11. The middleware was marked obsolete in ASP.NET Core 8 in favor of the rate-limiting middleware (`Microsoft.AspNetCore.RateLimiting`), which exposes the equivalent concurrency-limiting functionality through `System.Threading.RateLimiting`.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, you could install the [`Microsoft.AspNetCore.ConcurrencyLimiter`](https://www.nuget.org/packages/Microsoft.AspNetCore.ConcurrencyLimiter) NuGet package and use the `UseConcurrencyLimiter` extension method together with one of the queue policies (`AddQueuePolicy` or `AddStackPolicy`) to bound how many requests could run concurrently:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ConcurrencyLimiter;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQueuePolicy(options =>
{
    options.MaxConcurrentRequests = 2;
    options.RequestQueueLimit = 25;
});

var app = builder.Build();

app.UseConcurrencyLimiter();
app.Run(async context => await context.Response.WriteAsync("Hello World!"));
app.Run();
```

The middleware emitted a build warning that directed you to the rate-limiting middleware, but it still worked at runtime.

## New behavior

Starting in ASP.NET Core 11, the `Microsoft.AspNetCore.ConcurrencyLimiter` middleware source is removed from the ASP.NET Core repository, and no `Microsoft.AspNetCore.ConcurrencyLimiter` 11.x or later package is published. The following types and methods are no longer available to apps that target `net11.0`:

- `Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterMiddleware`
- `Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterOptions`
- `Microsoft.AspNetCore.ConcurrencyLimiter.IQueuePolicy`
- `Microsoft.AspNetCore.ConcurrencyLimiter.QueuePolicyOptions`
- `Microsoft.AspNetCore.Builder.ConcurrencyLimiterExtensions` (including the `UseConcurrencyLimiter` extension method)
- `Microsoft.Extensions.DependencyInjection.QueuePolicyServiceCollectionExtensions` (including `AddQueuePolicy` and `AddStackPolicy`)

Existing 9.x and 10.x package versions remain on NuGet and continue to work for projects that still target `net9.0` or `net10.0`. Projects that take an explicit `PackageReference` and retarget to `net11.0` get a NuGet restore error because there's no 11.x package version. Code that references these types fails to compile against ASP.NET Core 11.

## Type of breaking change

This change can affect [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility) and [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

The `ConcurrencyLimiter` middleware was marked obsolete in ASP.NET Core 8 (diagnostic `ASP0025`) because its functionality is covered by the rate-limiting middleware, which is built on the more general-purpose `System.Threading.RateLimiting` APIs. Maintaining two parallel implementations adds friction without benefit. For more information, see [dotnet/aspnetcore#64020](https://github.com/dotnet/aspnetcore/pull/64020).

## Recommended action

Migrate to the [rate-limiting middleware](/aspnet/core/performance/rate-limit), which provides an equivalent concurrency limiter built on <xref:System.Threading.RateLimiting.ConcurrencyLimiter?displayProperty=nameWithType>:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRateLimiter(options =>
{
    options.AddConcurrencyLimiter("ConcurrencyPolicy", limiterOptions =>
    {
        limiterOptions.PermitLimit = 2;
        limiterOptions.QueueLimit = 25;
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

var app = builder.Build();

app.UseRateLimiter();
app.MapGet("/", () => "Hello World!").RequireRateLimiting("ConcurrencyPolicy");
app.Run();
```

If you can't migrate immediately, you can stay on a `Microsoft.AspNetCore.ConcurrencyLimiter` 9.x or 10.x [NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.ConcurrencyLimiter) while you target `net11.0`. No new versions of the package will ship for .NET 11 or later.

## Affected APIs

- `Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterMiddleware`
- `Microsoft.AspNetCore.ConcurrencyLimiter.ConcurrencyLimiterOptions`
- `Microsoft.AspNetCore.ConcurrencyLimiter.IQueuePolicy`
- `Microsoft.AspNetCore.ConcurrencyLimiter.QueuePolicyOptions`
- `Microsoft.AspNetCore.Builder.ConcurrencyLimiterExtensions.UseConcurrencyLimiter`
- `Microsoft.Extensions.DependencyInjection.QueuePolicyServiceCollectionExtensions.AddQueuePolicy`
- `Microsoft.Extensions.DependencyInjection.QueuePolicyServiceCollectionExtensions.AddStackPolicy`
