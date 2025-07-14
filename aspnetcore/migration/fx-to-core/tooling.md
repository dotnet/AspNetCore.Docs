---
title: Learn to upgrade from ASP.NET MVC, Web API, and Web Forms to ASP.NET Core
description: Learn how to upgrade ASP.NET Framework MVC, Web API, or Web Forms projects to ASP.NET Core using migration tooling
author: rick-anderson
ms.author: riande
ms.date: 06/20/2025
uid: migration/fx-to-core/tooling
---
# Use tooling to help migrate ASP.NET Framework to ASP.NET Core

This article shows how to upgrade ASP.NET Framework applications (MVC, Web API, and Web Forms) to ASP.NET Core using the Visual Studio [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) and the [incremental update](xref:migration/fx-to-core/index) approach.


   > [!WARNING]
   > There is a Copilot-enabled tool for staying current on modern .NET, but is not currently enabled for migrating ASP.NET Frameworkt to ASP.NET Core. Please see the documentation for [GitHub Copilot app modernization - Upgrade for .NET](/dotnet/core/porting/github-copilot-app-modernization-overview) for details.

## Prerequisites

If your .NET Framework project has supporting libraries in the solution that are required, they should be upgraded to .NET Standard 2.0, if possible. For more information, see [Upgrade supporting libraries](xref:migration/fx-to-core/start#upgrade-supporting-libraries).


1. Install the [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) Visual Studio extension.
1. Open your ASP.NET Framework solution in Visual Studio.
1. In **Solution Explorer**, right click on the project to upgrade and select **Upgrade**. Select **Side-by-side incremental project upgrade**, which is the only upgrade option.
1. For the upgrade target, select **New project**.
1. Name the project and select the best fit template (you may add the required services later if you have a solution that uses a mixture of project types):

   > [!NOTE]
   > **For MVC projects:** Select **ASP.NET Core MVC** template.
   > 
   > **For Web API projects:** Select **ASP.NET Core Web API** template.
   > 
   > **For MVC + Web API projects:** Select **ASP.NET Core MVC** template.
   > 
   > **For Web Forms projects:** Select **ASP.NET Core** template.

1. Select **Next**
1. Select the target framework version and then select **Next**. For more information, see [.NET and .NET Core Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

   > [!NOTE]
   > **For Web Forms projects:** Select **Done** instead of **Next**, then proceed to step 9.

1. Review the **Summary of changes**, then select **Finish**.
1. The **Summary** step displays **`<Framework Project>` is now connected to `<Framework ProjectCore>` via Yarp proxy.**

   > [!NOTE]
   > **For MVC and Web API projects:** The summary includes a pie chart showing the migrated endpoints. Select **Upgrade Controller** and then select a controller to upgrade. Select the component to upgrade, then select **Upgrade selection**.
