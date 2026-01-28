---
title: Breaking changes in ASP.NET Core 9
titleSuffix: ""
description: Navigate to the breaking changes in ASP.NET Core 9.
ms.date: 03/26/2025
no-loc: [Blazor, Razor, Kestrel]
---
# Breaking changes in ASP.NET Core 9

If you're migrating an app to ASP.NET Core 9, the breaking changes listed here might affect you.

[!INCLUDE [binary-source-behavioral](../includes/binary-source-behavioral.md)]

| Title                                                                          | Type of change    |
|--------------------------------------------------------------------------------|-------------------|
| [DefaultKeyResolution.ShouldGenerateNewKey altered meaning](key-resolution.md) | Behavioral change |
| [Dev cert export no longer creates folder](certificate-export.md)              | Behavioral change |
| [Forwarded Headers Middleware ignores X-Forwarded-* headers from unknown proxies](../8/forwarded-headers-unknown-proxies.md) | Behavioral change |
| [HostBuilder enables ValidateOnBuild/ValidateScopes in development environment](hostbuilder-validation.md) | Behavioral change |
| [Legacy Mono and Emscripten APIs not exported to global namespace](legacy-apis.md) | Source incompatible |
| [Middleware types with multiple constructors](middleware-constructors.md)      | Behavioral change |
