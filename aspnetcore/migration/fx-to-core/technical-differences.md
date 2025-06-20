---
title: Technical differences between ASP.NET Framework and ASP.NET Core
author: tasou
description: Important technical differences to understand when migrating from ASP.NET Framework to ASP.NET Core.
ms.author: twsouthwick
ms.date: 06/20/2025
uid: migration/fx-to-corex/technical-differences
---
# Technical differences between ASP.NET Framework and ASP.NET Core

This document outlines important technical differences between ASP.NET Framework and ASP.NET Core that you should understand before beginning your migration.

## URI decoding differences

ASP.NET Core handles URI encoding differently:

| Character | Encoded | ASP.NET Core | ASP.NET Framework |
|-----------|---------|--------------|-------------------|
| `\` | `%5C` | `\` | `/` |
| `/` | `%2F` | `%2F` | `/` |

**Solution**: Use `new Uri(this.AspNetCoreHttpRequest.GetEncodedUrl())` for proper URL handling.

## User Secrets migration

User Secrets require special handling. See [GitHub issue #27611](https://github.com/dotnet/AspNetCore.Docs/issues/27611) for current guidance.
