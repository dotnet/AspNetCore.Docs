---
title: Migrate from ASP.NET to ASP.NET Core
author: isaacrlevin
description: Guidance for migrating existing ASP.NET MVC or Web API apps to ASP.NET Core.web
ms.author: riande
ms.date: 10/18/2019
uid: migration/proper-to-2x/index
---
# Migrate from ASP.NET Framework to ASP.NET Core

By [Isaac Levin](https://isaaclevin.com)

 :::moniker range=">= aspnetcore-7.0"

Most non-trivial ASP.NET Framework apps should consider using the [incremental migration](xref:migration/inc/overview) approach. For more information, see [Incremental ASP.NET to ASP.NET Core migration](/aspnet/core/migration/inc/overview).

Visual Studio has tooling to help migrate ASP.NET apps to ASP.NET Core. For more information, see [Migrating from ASP.NET to ASP.NET Core in Visual Studio](/aspnet/core/migration/inc/overview).

The [.NET Upgrade Assistant](https://dotnet.microsoft.com/platform/upgrade-assistant) is a command-line tool that can help migrate ASP.NET to ASP.NET Core. For more information, see [Overview of the .NET Upgrade Assistant](/dotnet/architecture/porting-existing-aspnet-apps/) and [Upgrade an ASP.NET MVC app to .NET 6 with the .NET Upgrade Assistant](/dotnet/core/porting/upgrade-assistant-aspnetmvc).

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

## Additional resources

- [Overview of porting from .NET Framework to .NET](/dotnet/core/porting/libraries)

:::moniker-end

[!INCLUDE[](~/migration/proper-to-2x/includes/index5.md)]
