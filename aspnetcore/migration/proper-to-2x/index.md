---
title: Update from ASP.NET to ASP.NET Core
author: isaacrlevin
description: Guidance for migrating existing ASP.NET MVC or Web API apps to ASP.NET Core.web
ms.author: riande
ms.date: 10/18/2019
uid: migration/proper-to-2x/index
---
# Upgrade from ASP.NET Framework to ASP.NET Core

 :::moniker range=">= aspnetcore-7.0"

## Why upgrade to the latest .NET

ASP.NET Core is the modern web framework for .NET. While ASP.NET Core has many similarities to ASP.NET in the .NET Framework, it's a new framework that's completely rewritten. ASP.NET apps updated to ASP.NET Core can benefit from improved performance and access to the latest web development features and capabilities.

## ASP.NET Framework update approaches

Most non-trivial ASP.NET Framework apps should consider using the [incremental upgrade](/aspnet/core/migration/inc/overview) approach. For more information, see [Incremental ASP.NET to ASP.NET Core upgrade](/aspnet/core/migration/inc/overview).

For ASP.NET MVC and Web API apps, see <xref:migration/mvc>. For ASP.NET Framework Web Forms apps, see <xref:migration/web_forms>.

[!INCLUDE[](~/includes/reliableWAP_H2.md)]

## URI decoding differences between ASP.NET to ASP.NET Core

ASP.NET Core has the following URI decoding differences with ASP.NET Framework:

| ASCII   | Encoded | ASP.NET Core | ASP.NET Framework |
| ------------- | ------------- | ------------- | ------------- |
| `\` | `%5C`  |  `\` |  `/` |
| `/` | `%2F`  |  `%2F` |  `/` |

When decoding `%2F` on ASP.NET Core:

* The entire path gets unescaped except `%2F` because converting it to `/` would change the path structure. It can’t be decoded until the path is split into segments.

To generate the value for `HttpRequest.Url`, use `new Uri(this.AspNetCoreHttpRequest.GetEncodedUrl());` to avoid `Uri` misinterpreting the values.

## Migrating User Secrets from ASP.NET Framework to ASP.NET Core

See [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/27611).

<!-- remove these comments when the following overview topic is updated
## Additional resources

- [Overview of porting from .NET Framework to .NET](/dotnet/core/porting/libraries)
-->
:::moniker-end

[!INCLUDE[](~/migration/proper-to-2x/includes/index5.md)]