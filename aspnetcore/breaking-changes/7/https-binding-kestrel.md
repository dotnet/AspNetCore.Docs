---
title: "Breaking change: Kestrel: Default HTTPS binding removed"
description: Learn about the breaking change in ASP.NET Core 7.0 where the default HTTPS binding on Kestrel was removed.
ms.date: 06/24/2022
ms.custom: https://github.com/aspnet/Announcements/issues/486
---
# Kestrel: Default HTTPS binding removed

The default HTTPS address and port have been removed from Kestrel in .NET 7. This change is part of [dotnet/aspnetcore#42016](https://github.com/dotnet/aspnetcore/issues/42016), which will improve the overall developer experience when dealing with HTTPS.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

Previously, if no values for the address and port were specified explicitly but a local development certificate was available, Kestrel defaulted to binding to both `http://localhost:5000` and `https://localhost:5001`.

## New behavior

Users must now manually bind to HTTPS and specify the address and port explicitly, through one of the following means:

- The *launchSettings.json* file
- The `ASPNETCORE_URLS` environment variable
- The `--urls` command-line argument
- The `urls` host configuration key
- The <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls(Microsoft.AspNetCore.Hosting.IWebHostBuilder,System.String[])> extension method

HTTP binding is unchanged.

## Type of breaking change

This change affects [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The previous eager-binding behavior occurs without regard to the configured environment and can lead to a poor developer experience when the certificate has not yet been trusted (that is, trusted as root certificate authority because it's self-signed). Clients often produce a poor user experience when hitting an HTTPS endpoint with an untrusted certificate. For example, they might fail silently or show an error or warning screen that alarms the user.

## Recommended action

If you weren't using the default `https://localhost:5001` binding, no changes are required. However, if you were using this binding, see [Configure endpoints for the ASP.NET Core Kestrel web server](/aspnet/core/fundamentals/servers/kestrel/endpoints) to learn how you can update your server to enable HTTPS.

## Affected APIs

N/A
