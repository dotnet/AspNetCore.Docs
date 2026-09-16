---
title: "Breaking change: Automatic CSRF protection requires CORS AllowCredentials for cross-origin trust"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where the automatic CSRF protection middleware only treats a CORS-allowed origin as trusted when the CORS policy also calls AllowCredentials."
ms.date: 09/16/2026
---
# Automatic CSRF protection requires CORS `AllowCredentials` for cross-origin trust

In ASP.NET Core 11, the automatic cross-site request forgery (CSRF) protection middleware only treats a CORS-allowed origin as CSRF-trusted when the resolved CORS policy also has `.AllowCredentials()` configured.

## Version introduced

.NET 11

## Previous behavior

Previously, the middleware allowed a request whenever the endpoint's resolved CORS policy trusted the request's `Origin` and the policy didn't use `AllowAnyOrigin`. Whether the policy called `.AllowCredentials()` had no effect on this check.

As a result, a CORS policy that only listed an origin with `WithOrigins` (without `.AllowCredentials()`)—intended solely to allow anonymous, non-cookie cross-origin calls—was also treated as a CSRF trust signal.

## New behavior

Starting in ASP.NET Core 11, the middleware requires the resolved CORS policy to have `.AllowCredentials()` configured, in addition to trusting the origin and not using `AllowAnyOrigin`, before it records an allowed verdict. A CORS-allowed origin whose policy doesn't call `.AllowCredentials()` no longer grants CSRF trust; the request falls through to the `Sec-Fetch-Site` and Origin-vs-Host rules instead.

`AllowAnyOrigin` remains excluded from CSRF trust regardless of `.AllowCredentials()`, consistent with prior behavior.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

CORS's `AllowCredentials()` (which sets `CorsPolicy.SupportsCredentials`) is the explicit flag a developer sets to mean "this cross-origin caller is allowed to send and receive the user's cookies." A policy that omits it is only saying "this origin can call me anonymously or publicly," which says nothing about acting on behalf of a signed-in user. Because CSRF protection is specifically about authenticated, cookie-bearing requests being triggered from another origin, only a credentialed policy actually claims the trust relationship CSRF protection cares about. Requiring `.AllowCredentials()` aligns the CSRF trust check with what the developer's CORS configuration actually authorizes.

For more information, see [dotnet/aspnetcore#69345](https://github.com/dotnet/aspnetcore/pull/69345).

## Recommended action

If a CORS policy is used to allow a cross-origin, cookie-authenticated form post through the CSRF middleware, add `.AllowCredentials()` to that policy:

```csharp
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("https://app.contoso.com")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});
```

If the endpoint doesn't rely on cookie-based authentication—for example, it's secured only by a bearer token or API key—it has no CSRF exposure. Use `.DisableAntiforgery()` (Minimal APIs) or `[IgnoreAntiforgeryToken]` (MVC) instead of relying on CORS-derived trust.

For more information, see <xref:security/anti-request-forgery#allowing-cross-origin-clients>.

## Affected APIs

None. No public API surface changed. The change affects the trust evaluation performed by the built-in `ICsrfProtection` implementation.
