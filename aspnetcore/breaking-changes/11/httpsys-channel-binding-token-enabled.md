---
title: "Breaking change: HttpSys enables TLS channel binding token exposure by default"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where HttpSys configures HttpServerChannelBindProperty on every startup, enabling per-request TLS channel binding tokens and the new ITlsConnectionFeature.TryGetChannelBindingBytes API."
ms.date: 07/09/2026
---
# HttpSys enables TLS channel binding token exposure by default

In ASP.NET Core 11, `Microsoft.AspNetCore.Server.HttpSys` unconditionally configures the URL group with `HttpServerChannelBindProperty` at startup. This exposes the RFC 5929 endpoint TLS channel binding token (CBT) to the app through the new `ITlsConnectionFeature.TryGetChannelBindingBytes` API, enabling Extended Protection for Authentication (EPA) scenarios.

## Version introduced

.NET 11

## Previous behavior

HttpSys-backed servers didn't configure `HttpServerChannelBindProperty` on the URL group at startup, and the RFC 5929 TLS channel binding token wasn't exposed to the app.

Applications could opt in by enabling the `Microsoft.AspNetCore.Server.HttpSys.EnableCBTHardening` `AppContext` switch. That switch set the hardening level to `Medium`, but it didn't set the `HTTP_CHANNEL_BIND_SECURE_CHANNEL_TOKEN` flag, so http.sys didn't deliver a per-request CBT.

`ITlsConnectionFeature` had no way to retrieve the token. The only related API was the now-obsolete `ITlsTokenBindingFeature`, which is a different, unrelated feature.

## New behavior

`HttpSysOptions` has a new property `HttpAuthenticationHardeningLevel` of type `HttpAuthenticationHardeningLevel` (`Legacy`, `Medium`, `Strict`) that defaults to `Medium`.

At startup, HttpSys unconditionally calls `HttpSetUrlGroupProperty` with `HttpServerChannelBindProperty`, applying the configured hardening level. For `Medium` and `Strict`, it also sets the `HTTP_CHANNEL_BIND_SECURE_CHANNEL_TOKEN` flag so that http.sys delivers a per-request `HTTP_REQUEST_CHANNEL_BIND_STATUS`.

The new `ITlsConnectionFeature.TryGetChannelBindingBytes(ChannelBindingKind kind, out ReadOnlyMemory<byte> channelBindingToken)` returns the endpoint CBT (RFC 5929 `tls-server-end-point`) on authenticated HTTPS requests.

If the `HttpSetUrlGroupProperty` call fails (for example, on an old or blocked kernel), the failure is logged and startup continues. The app runs as if `Legacy` was configured.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

This change exposes the RFC 5929 endpoint channel binding to authentication middleware so it can implement Extended Protection for Authentication (EPA). EPA cryptographically binds Kerberos, NTLM, or Negotiate authentication to the underlying TLS channel, mitigating authentication-relay attacks. Previously, no ASP.NET Core server exposed the CBT to managed code.

For more information, see [dotnet/aspnetcore#67436](https://github.com/dotnet/aspnetcore/pull/67436).

## Recommended action

No action is required for most users. The new API is opt-in. Apps that don't call `TryGetChannelBindingBytes` see only one extra `HttpSetUrlGroupProperty` call at startup, which has no runtime cost.

To restore the pre-.NET 11 behavior, set the hardening level to `Legacy`:

```csharp
builder.WebHost.UseHttpSys(options =>
{
    options.HttpAuthenticationHardeningLevel = HttpAuthenticationHardeningLevel.Legacy;
});
```

When `Legacy` is configured, HttpSys doesn't set the CBT flag, http.sys doesn't populate `HTTP_REQUEST_CHANNEL_BIND_STATUS`, and `TryGetChannelBindingBytes` returns `false`.

`HttpServerChannelBindProperty` has been supported in http.sys since Windows 7 and Windows Server 2008 R2 (released October 22, 2009), which is below the OS floor for any supported ASP.NET Core version. No ASP.NET Core-supported OS is affected.

## Affected APIs

- `Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions.HttpAuthenticationHardeningLevel` (new)
- `Microsoft.AspNetCore.Server.HttpSys.HttpAuthenticationHardeningLevel` (new enum)
- `Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature.TryGetChannelBindingBytes` (new default interface method)
