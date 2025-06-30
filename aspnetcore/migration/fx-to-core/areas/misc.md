---
title: Technical differences between ASP.NET Framework and ASP.NET Core
author: twsouthwick
description: Important technical differences to understand when migrating from ASP.NET Framework to ASP.NET Core.
ms.author: tasou
ms.date: 06/20/2025
uid: migration/fx-to-core/areas/misc
---
# Technical differences between ASP.NET Framework and ASP.NET Core

This document outlines important technical differences between ASP.NET Framework and ASP.NET Core that you should understand before beginning your migration.

## URI decoding differences

ASP.NET Core handles URI encoding differently:

| Character | Encoded | ASP.NET Core | ASP.NET Framework |
|-----------|---------|--------------|-------------------|
| `\` | `%5C` | `\` | `/` |
| `/` | `%2F` | `%2F` | `/` |

**Recommendation**: Use `new Uri(this.AspNetCoreHttpRequest.GetEncodedUrl())` for proper URL handling.

## User Secrets migration

User Secrets require special handling. See [GitHub issue #27611](https://github.com/dotnet/AspNetCore.Docs/issues/27611) for current guidance.

## CultureInfo.CurrentCulture differences

> [!NOTE]
> ASP.NET Core does not automatically set `CultureInfo.CurrentCulture` for requests like ASP.NET Framework does. You must explicitly configure localization middleware.

In ASP.NET Framework, <xref:System.Globalization.CultureInfo.CurrentCulture> was set for a request, but this is not done automatically in ASP.NET Core. Instead, you must add the appropriate middleware to your pipeline.

**Recommendation**: See [ASP.NET Core Localization](/aspnet/core/fundamentals/localization#localization-middleware) for details on how to enable this.

Simplest way to enable this with similar behavior as ASP.NET Framework would be to add the following to your pipeline:

```csharp
app.UseRequestLocalization();
```
