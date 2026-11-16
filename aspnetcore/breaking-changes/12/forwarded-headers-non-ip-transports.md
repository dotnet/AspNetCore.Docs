---
title: "Breaking change: Forwarded headers ignored when proxy has no IP address"
ai-usage: ai-assisted
description: Learn about the breaking change in ASP.NET Core 12 where forwarded headers are ignored when the proxy has no IP address and trusted proxy lists are configured.
ms.date: 11/16/2026
---
# Forwarded headers ignored when proxy has no IP address

The forwarded headers middleware no longer processes forwarded headers from a connection without a remote IP address when a trusted proxy or network list is configured. This change can affect apps that receive requests from a reverse proxy over a Unix domain socket, named pipe, or another transport that doesn't provide a remote IP address.

## Version introduced

ASP.NET Core 12 Preview 1

## Previous behavior

Previously, the middleware processed enabled forwarded headers when the connection had no remote IP address, even if known proxy or network lists were configured. The middleware couldn't verify that the peer was a trusted proxy.

## New behavior

Starting in ASP.NET Core 12, the middleware ignores enabled forwarded headers when the connection has no remote IP address and either `KnownProxies` or `KnownIPNetworks` contains an entry. The default lists contain loopback entries, so the change affects the default trust configuration. The obsolete `KnownNetworks` property shares its entries with `KnownIPNetworks`.

The default value of `ForwardedHeaders` is still `None`: an app must enable the headers it needs to process. When forwarded headers aren't applied, apps might encounter incorrect client IP addresses, HTTPS redirect loops, or authentication failures.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

Without a remote IP address, the middleware can't verify that the peer matches a configured trusted proxy or network. The change prevents connections without an IP address from bypassing the configured trust checks. For more information, see [Harden KnownProxies/KnownNetworks for non-IP transports (`dotnet/aspnetcore` #67817)](https://github.com/dotnet/aspnetcore/pull/67817).

## Recommended action

If all requests arrive over a trusted non-IP transport, you can clear both lists to process forwarded headers as before:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

var options = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
options.KnownProxies.Clear();
options.KnownIPNetworks.Clear();

app.UseForwardedHeaders(options);
```

Clearing both lists disables IP-based proxy checks for every request that reaches this middleware. Do so only when access to the transport is restricted to trusted proxies, for example through Unix socket permissions or named pipe access controls. Ensure that trusted proxies also remove or replace untrusted forwarded headers.

For deployments that accept both IP and non-IP connections, use separate middleware branches. Keep trusted IP addresses or networks configured for the IP branch, and clear the lists only for the trusted non-IP branch:

```csharp
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

var ipOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
ipOptions.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));

var nonIpOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
nonIpOptions.KnownProxies.Clear();
nonIpOptions.KnownIPNetworks.Clear();

app.UseWhen(
    context => context.Connection.RemoteIpAddress is not null,
    branch => branch.UseForwardedHeaders(ipOptions));
app.UseWhen(
    context => context.Connection.RemoteIpAddress is null,
    branch => branch.UseForwardedHeaders(nonIpOptions));
```

Replace `10.0.0.100` with a trusted proxy address and configure any other required trusted proxies or networks. Run the IP branch first: forwarded headers can change `RemoteIpAddress`, so running the non-IP branch first could cause the same request to enter both branches. A null remote IP address doesn't prove that a connection is trusted; restrict access to every non-IP transport that can reach the non-IP branch. Configure the headers and other options for your proxy setup, and avoid an additional forwarded headers middleware instance that processes the same request.

For more information, see [Configure ASP.NET Core to work with proxy servers and load balancers](../../host-and-deploy/proxy-load-balancer.md).

## Affected APIs

* <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersMiddleware?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownProxies?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownIPNetworks?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks?displayProperty=fullName>
