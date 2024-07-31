---
title: Learn to upgrade from ASP.NET MVC and Web API to ASP.NET Core MVC
description: Learn how to upgrade an ASP.NET MVC Framework or Web API project to ASP.NET Core MVC
author: rick-anderson
ms.author: riande
ms.date: 03/07/2017
uid: migration/mvc
---
# Upgrade from ASP.NET MVC and Web API to ASP.NET Core MVC

 :::moniker range=">= aspnetcore-7.0"

This article shows how to upgrade an ASP.NET Framework MVC or Web API app to ASP.NET Core MVC using the Visual Studio [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) and the [incremental update](xref:migration/inc/overview) approach.

## Upgrade using  the .NET Upgrade Assistant

If your .NET Framework project has supporting libraries in the solution that are required, they should be upgraded to .NET Standard 2.0, if possible. For more information, see [Upgrade supporting libraries](/aspnet/core/migration/inc/start#upgrade-supporting-libraries).

1. Install the [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) Visual Studio extension.
1. Open the ASP.NET MVC or Web API solution in Visual Studio.
1. In **Solution Explorer**, right click on the project to upgrade and select **Upgrade**. Select **Side-by-side incremental project upgrade**, which is the only upgrade option.
1. For the upgrade target, select **New project**.
1. Name the project and select the template. If the project you're migrating is a API project, select **ASP.NET Core Web API**. If it's an MVC project or MVC and Web API, select **ASP.NET Core MVC**.
1. Select **Next**
1. Select the target framework version and then select **Next**. For more information, see [.NET and .NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).
1. Review the **Summary of changes**, then select **Finish**.
1. The **Summary** step displays **`<Framework Project>` is now connected to `<Framework ProjectCore>`  via Yarp proxy.** and a pie chart showing the migrated endpoints. Select **Upgrade Controller** and then select a controller to upgrade.
1. Select the component to upgrade, then select **Upgrade selection**.

## Incremental update

Follow the steps in [Get started with incremental ASP.NET to ASP.NET Core migration](/aspnet/core/migration/inc/start) to continue the update process.

:::moniker-end

[!INCLUDE[](~/migration/mvc/includes/mvc6.md)]
