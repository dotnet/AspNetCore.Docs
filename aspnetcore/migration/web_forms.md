---
title: Learn to upgrade from ASP.NET Web Forms to ASP.NET Core
description: Learn how to upgrade an ASP.NET Web Forms project to ASP.NET Core
author: rick-anderson
ms.author: riande
ms.date: 03/07/2017
uid: migration/web_forms
---
# Upgrade an ASP.NET Framework Web Forms app to ASP.NET Core MVC

 :::moniker range=">= aspnetcore-7.0"

This article shows how to upgrade an ASP.NET Framework Web Forms to ASP.NET Core MVC using the Visual Studio [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) and the [incremental update](xref:migration/inc/overview) approach.

If your .NET Framework project has supporting libraries in it's solution that are required, they should be upgraded to .NET Standard 2.0, if possible. For more information, see [Upgrade supporting libraries](/aspnet/core/migration/inc/start#upgrade-supporting-libraries).

1. Install the [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) Visual Studio extension.
1. Open the ASP.NET Web Forms solution in Visual Studio.
1. In **Solution Explorer**, right click on the project to upgrade and select **Upgrade**. Select **Side-by-side incremental project upgrade**, which is the only upgrade option.
1. For the upgrade target, select **New project**.
1. Name the project and select the **ASP.NET Core** template and then select **Next**
1. Select the target framework version and then select **Next**. For more information, see [.NET and .NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).
1. Select **Done**, then select **Finish**.
1. The **Summary** step displays **`<Framework Project>` is now connected to `<Framework ProjectCore>`  via Yarp proxy.**.
1. Select the component to upgrade, then select **Upgrade selection**.

## Incremental update

Follow the steps in [Get started with incremental ASP.NET to ASP.NET Core migration](/aspnet/core/migration/inc/start) to continue the update process.

:::moniker-end

[!INCLUDE[](~/migration/mvc/includes/mvc6.md)]
