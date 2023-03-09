---
title: Learn to upgrade from ASP.NET MVC to ASP.NET Core MVC
description: Learn how to upgrade an ASP.NET MVC Framework project to ASP.NET Core MVC
author: rick-anderson
ms.author: riande
ms.date: 03/07/2017
uid: migration/mvc
---
# Upgrade from ASP.NET MVC to ASP.NET Core MVC

 :::moniker range=">= aspnetcore-7.0"

This article show how to upgrade an ASP.NET Framework MVC app to ASP.NET Core MVC using the Visual Studio [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) and the [incremental update](xref:migration/inc/overview) approach.

## Upgrade using  the .NET Upgrade Assistant

1. Install the [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) Visual Studio extension.
1. Open the ASP.NET MVC solution in Visual Studio.
1. In **Solution Explorer**, right click on the project to upgrade and select **Upgrade**. Select **Side-by-side incremental project upgrade**, which is the only upgrade option.
1. For the upgrade target, select **New project**.
1. Name the project and select the template.
1. Select the target framework.
1. On the **Summary of changes** step, select **Finish**.
1. The **Summary** step displays **`<Framework Project>` is now connected to `<Framework ProjectCore>`  via Yarp proxy.** and a pie chart showing the migrated endpoints. Select **Upgrade Controller** and then select a controller to upgrade.
1. Select the components to upgrade, then select **Upgrade selection**.










:::moniker-end

[!INCLUDE[](~/migration/mvc/includes/mvc6.md)]
