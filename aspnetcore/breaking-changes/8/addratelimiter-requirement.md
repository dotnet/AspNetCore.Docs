---
title: "Breaking change: Rate-limiting middleware requires AddRateLimiter"
description: Learn about the breaking change in ASP.NET Core 8.0 where rate-limiting middleware now requires AddRateLimiter to be called on app startup.
ms.date: 05/30/2023
ms.custom: https://github.com/aspnet/Announcements/issues/506
---
# Rate-limiting middleware requires AddRateLimiter

ASP.NET Core rate-limiting middleware has been updated with extra functionality. The middleware now requires services registered with <xref:Microsoft.AspNetCore.Builder.RateLimiterServiceCollectionExtensions.AddRateLimiter%2A>.

## Version introduced

ASP.NET Core 8.0 Preview 5

## Previous behavior

Previously, rate limiting could be used without <xref:Microsoft.AspNetCore.Builder.RateLimiterServiceCollectionExtensions.AddRateLimiter%2A>. For example, the middleware could be configured by calling `Configure<RateLimiterOptions>(o => { })`:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RateLimiterOptions>(o => o
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        // configuration
    }));

var app = builder.Build();
app.UseRateLimiter();
app.MapGet("/", () => Results.Ok($"Hello world")).RequireRateLimiting("fixed");
app.Run();
```

## New behavior

If <xref:Microsoft.AspNetCore.Builder.RateLimiterServiceCollectionExtensions.AddRateLimiter%2A> is not called on app startup, ASP.NET Core throws an informative error:

> Unable to find the required services. Please add all the required services by calling 'IServiceCollection.AddRateLimiter' in the application startup code.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Rate-limiting middleware requires services that are only registered by calling <xref:Microsoft.AspNetCore.Builder.RateLimiterServiceCollectionExtensions.AddRateLimiter%2A>.

## Recommended action

Ensure that <xref:Microsoft.AspNetCore.Builder.RateLimiterServiceCollectionExtensions.AddRateLimiter%2A> is called at application startup.

For example, update `Configure<RateLimiterOptions>(o => { })` to use <xref:Microsoft.AspNetCore.Builder.RateLimiterServiceCollectionExtensions.AddRateLimiter%2A>:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRateLimiter(o => o
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        // configuration
    }));

var app = builder.Build();
app.UseRateLimiter();
app.MapGet("/", () => Results.Ok($"Hello world")).RequireRateLimiting("fixed");
app.Run();
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.RateLimiterApplicationBuilderExtensions.UseRateLimiter%2A?displayProperty=fullName>
