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

Most non-trivial ASP.NET Framework apps should consider using the [incremental upgrade](/aspnet/core/migration/inc/overview) approach used in this article.

## Why upgrade to the latest .NET

ASP.NET Core is the modern web framework for .NET. While ASP.NET Core has many similarities to ASP.NET in the .NET Framework, it's a new framework that's completely rewritten. ASP.NET apps updated to ASP.NET Core can benefit from improved performance and access to the latest web development features and capabilities.

## Upgrade from ASP.NET MVC or Web API to ASP.NET Core

See [ Upgrade from ASP.NET MVC and Web API to ASP.NET Core MVC](xref:migration/mvc).

## Upgrade an ASP.NET Framework Web Forms app to ASP.NET Core

If your .NET Framework project has supporting libraries in it's solution that are required, they should be upgraded to .NET Standard 2.0, if possible. For more information, see [Upgrade supporting libraries](/aspnet/core/migration/inc/start#upgrade-supporting-libraries).

1. Install the [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) Visual Studio extension.
1. Open the ASP.NET MVC solution in Visual Studio.
1. In **Solution Explorer**, right click on the project to upgrade and select **Upgrade**. Select **Side-by-side incremental project upgrade**, which is the only upgrade option.
1. For the upgrade target, select **New project**.
1. Name the project and select the **ASP.NET Core** template and then select **Next**
1. Select the target framework version and then select **Next**. For more information, see [.NET and .NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).
1. Select **Done**, then select **Finish**.
1. The **Summary** step displays **`<Framework Project>` is now connected to `<Framework ProjectCore>`  via Yarp proxy.**.
1. Select the component to upgrade, then select **Upgrade selection**.

## Incremental update

Follow the steps in [Get started with incremental ASP.NET to ASP.NET Core migration](/aspnet/core/migration/inc/start) to continue the update process.

<!-- TODO: replace link to blog to article when the blog is migrated -->

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
