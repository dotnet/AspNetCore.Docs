---
title: Breaking changes in ASP.NET Core 8
titleSuffix: ""
description: Navigate to the breaking changes in ASP.NET Core 8.
ms.date: 04/10/2025
no-loc: [Blazor, Razor, Kestrel]
---
# Breaking changes in ASP.NET Core 8

If you're migrating an app to ASP.NET Core 8, the breaking changes listed here might affect you.

[!INCLUDE [binary-source-behavioral](../includes/binary-source-behavioral.md)]

| Title                                                                                                | Type of change      |
| ---------------------------------------------------------------------------------------------------- | ------------------- |
| [ConcurrencyLimiterMiddleware is obsolete](concurrencylimitermiddleware-obsolete.md) | Source incompatible |
| [Custom converters for serialization removed](problemdetails-custom-converters.md)   | Behavioral change   |
| [Forwarded Headers Middleware ignores X-Forwarded-* headers from unknown proxies](forwarded-headers-unknown-proxies.md) | Behavioral change   |
| [HTTP logging middleware requires AddHttpLogging()](httplogging-addhttplogging-requirement.md) | Behavioral change |
| [ISystemClock is obsolete](isystemclock-obsolete.md)                                 | Source incompatible |
| [Minimal APIs: IFormFile parameters require anti-forgery checks](antiforgery-checks.md) | Behavioral change   |
| [Rate-limiting middleware requires AddRateLimiter](addratelimiter-requirement.md)    | Behavioral change   |
| [Security token events return a JsonWebToken](securitytoken-events.md)               | Behavioral change   |
| [TrimMode defaults to full for Web SDK projects](trimmode-full.md)                   | Source incompatible |
