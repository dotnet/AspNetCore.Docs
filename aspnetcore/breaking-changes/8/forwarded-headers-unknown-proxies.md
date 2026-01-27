---
title: "Breaking change: Forwarded Headers Middleware ignores X-Forwarded-* headers from unknown proxies"
description: Learn about the breaking change in ASP.NET Core where Forwarded Headers Middleware now ignores headers from proxies that aren't explicitly configured as trusted.
ms.date: 08/15/2025
ms.custom: https://github.com/aspnet/Announcements/issues/517
---
# Forwarded Headers Middleware ignores X-Forwarded-* headers from unknown proxies

Starting in ASP.NET Core 8.0.17 and 9.0.6, the Forwarded Headers Middleware ignores all `X-Forwarded-*` headers from proxies that aren't explicitly configured as trusted. This change was made for security hardening, as the proxy and IP lists weren't being applied in all cases.

## Version introduced

ASP.NET Core 8.0.17
ASP.NET Core 9.0.6

## Previous behavior

Previously, the middleware, when not configured to use `X-Forwarded-For`, processed `X-Forwarded-Prefix`, `X-Forwarded-Proto`, and `X-Forwarded-Host` headers from any source. That behavior potentially allowed malicious or misconfigured proxies/clients to spoof these headers and affect an application's understanding of client information.

## New behavior

Starting in .NET 8 and .NET 9 servicing releases, only headers sent by known, trusted proxies (as configured via <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownProxies?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks?displayProperty=nameWithType>) are processed. Headers from unknown sources are ignored.

> [!NOTE]
> If your deployment relied on forwarded headers from proxies not configured in your application's trusted proxy list, those headers are no longer honored.

This change can cause behavior like infinite redirects if you're using the HTTPS redirection middleware and using TLS termination in your proxy. It can also cause authentication to fail if you're using TLS termination and expecting an HTTPS request.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change was made for security hardening, as the proxy and IP lists weren't being applied in all cases.

## Recommended action

Review your deployment topology. Ensure that all legitimate proxy servers in front of your app are properly added to <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownProxies> or <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks> in your <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> configuration.

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    KnownProxies = { IPAddress.Parse("YOUR_PROXY_IP") }
});
```

Or, for a network:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    KnownNetworks = { new IPNetwork(IPAddress.Parse("YOUR_NETWORK_IP"), PREFIX_LENGTH) }
});
```

If you wish to enable the previous behavior, which isn't recommended due to security risks, you can do so by clearing the `KnownNetworks` and `KnownProxies` lists in <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> to allow any proxy or network to forward these headers.

You can also set the `ASPNETCORE_FORWARDEDHEADERS_ENABLED` environment variable to `true`, which clears the lists and enables `ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto`.

For applications that target .NET 9 or earlier, you can set the `Microsoft.AspNetCore.HttpOverrides.IgnoreUnknownProxiesWithoutFor` [AppContext](../../../../fundamentals/runtime-libraries/system-appcontext.md) switch to `"true"` or `1` to get back to the previous behavior. Alternatively, set the `MICROSOFT_ASPNETCORE_HTTPOVERRIDES_IGNORE_UNKNOWN_PROXIES_WITHOUT_FOR` environment variable.

> [!NOTE]
> In cloud environments, the proxy IPs can change over the lifetime of the app, and `ASPNETCORE_FORWARDEDHEADERS_ENABLED` is sometimes used to make forwarded headers work.

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*?displayProperty=fullName>

## See also

- [Configure ASP.NET Core to work with proxy servers and load balancers](/aspnet/core/host-and-deploy/proxy-load-balancer)
