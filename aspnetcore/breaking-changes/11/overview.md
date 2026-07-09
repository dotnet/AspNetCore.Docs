---
title: Breaking changes in ASP.NET Core 11
ai-usage: ai-assisted
titleSuffix: ""
description: Navigate to the breaking changes in ASP.NET Core 11.
ms.date: 06/04/2026
no-loc: [Blazor, Kestrel, SignalR]
---
# Breaking changes in ASP.NET Core 11

If you're migrating an app to ASP.NET Core 11, the breaking changes listed here might affect you.

[!INCLUDE [binary-source-behavioral](../includes/binary-source-behavioral.md)]

| Title | Type of change    |
|-------|-------------------|
| [Blazor custom event registration throws when name matches a browser event](blazor-custom-event-name-collision.md) | Behavioral change |
| [Blazor enhanced navigation no longer preloads resources](blazor-enhanced-nav-preloading-disabled.md) | Behavioral change |
| [ConcurrencyLimiter middleware removed](concurrencylimiter-removed.md) | Binary/source incompatible |
| [Hosting emits OpenTelemetry HTTP semantic-convention tags by default](http-activity-otel-semconv.md) | Behavioral change |
| [HttpSys enables TLS channel binding token exposure by default](httpsys-channel-binding-token-enabled.md) | Behavioral change |
| [Kestrel tightens HTTP protocol compliance](kestrel-strict-protocol-compliance.md) | Behavioral change |
| [Microsoft.OpenApi upgraded to 3.x](microsoft-openapi-3x.md) | Source incompatible |
| [Obsolete Blazor APIs removed](blazor-obsolete-apis-removed.md) | Source incompatible |
| [OpenAPI document includes all ProducesResponseType entries per status code](openapi-multiple-produces-per-status.md) | Behavioral change |
| [OpenAPI server URL no longer has a trailing slash when PathBase is empty](openapi-server-url-trailing-slash.md) | Behavioral change |
| [Passkey sign-in enforces email/phone confirmation and lockout](passkey-signin-enforces-confirmation-lockout.md) | Behavioral change |
| [Response compression always emits Vary: Accept-Encoding](response-compression-always-vary.md) | Behavioral change |
| [SqlClient Active Directory authentication moved to a separate package](sqlclient-azure-extensions-required.md) | Behavioral change |
| [WebAssemblyHostBuilder loads environment variables into IConfiguration](wasm-env-vars-in-configuration.md) | Behavioral change |
