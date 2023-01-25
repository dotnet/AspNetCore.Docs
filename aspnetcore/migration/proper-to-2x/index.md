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

Most non-trivial ASP.NET Framework apps should consider using the [incremental migration](xref:migration/inc/overview) approach.

The ebook [Porting existing ASP.NET apps to .NET Core](https://aka.ms/aspnet-porting-ebook):

* Contains more information on porting ASP.NET Framework apps to ASP.NET Core.
* Contains incremental migration information that is outdated. See <xref:migration/inc/overview> for the definitive guide.

## URI decoding differences between ASP.NET to ASP.NET Core

ASP.NET Core has the following URI decoding differences with ASP.NET Framework:

| ASCII   | Encoded | ASP.NET Core | ASP.NET Framework |
| ------------- | ------------- | ------------- | ------------- |
| `\` | `%5C`  |  `/` |  `\` |
| `/` | `%2F`  |  `%2F` |  `/` |

`%2F`:

* The entire path gets unescaped except `%2F` because converting it to `/` would change the path structure. It can’t be decoded until the path is split into segments.
* Aee the [PathBase source](https://source.dot.net/#Microsoft.AspNetCore.Http.Abstractions/HttpRequest.cs,8d85f458c32cb4a5) for more information.

To generate the value for `HttpRequest.Url`, use `new Uri(this.AspNetCoreHttpRequest.GetEncodedUrl());` to avoid `Uri` misinterpreting the values.

## Additional resources

- [Porting Libraries to .NET Core](/dotnet/core/porting/libraries)

:::moniker-end

[!INCLUDE[](~/migration/proper-to-2x/includes/index5.md)]
