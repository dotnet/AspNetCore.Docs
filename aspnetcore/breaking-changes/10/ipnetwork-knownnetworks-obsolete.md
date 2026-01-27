---
title: "Breaking change: IPNetwork and ForwardedHeadersOptions.KnownNetworks are obsolete"
description: Learn about the breaking change in ASP.NET Core 10.0 where IPNetwork and ForwardedHeadersOptions.KnownNetworks have been obsoleted in favor of System.Net.IPNetwork and KnownIPNetworks.
ms.date: 08/08/2025
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/523
---
# IPNetwork and ForwardedHeadersOptions.KnownNetworks are obsolete

<xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork?displayProperty=fullName> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks> have been marked as obsolete in favor of using <xref:System.Net.IPNetwork?displayProperty=fullName> and `KnownIPNetworks`.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, you could use <xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork?displayProperty=fullName> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks> to configure known networks for the forwarded headers middleware:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    KnownNetworks.Add(new(IPAddress.Loopback, 8))
});
```

## New behavior

Starting in .NET 10, if you use [the obsolete APIs](#affected-apis) in your code, you'll get warning `ASPDEPR005` at compile time:

> warning ASPDEPR005: Please use KnownIPNetworks instead. For more information, visit <https://aka.ms/aspnet/deprecate/005>.

Use the <xref:System.Net.IPNetwork?displayProperty=fullName> type and `KnownIPNetworks` property instead.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

<xref:System.Net.IPNetwork?displayProperty=fullName> has replaced the <xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork?displayProperty=fullName> type that was implemented for <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersMiddleware>.

## Recommended action

Change to using <xref:System.Net.IPNetwork?displayProperty=fullName> and `KnownIPNetworks`.

## Affected APIs

- <xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks?displayProperty=fullName>
