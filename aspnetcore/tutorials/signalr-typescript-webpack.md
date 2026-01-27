---
title: "Tutorial: Get started with ASP.NET Core SignalR using TypeScript and Webpack"
ai-usage: ai-assisted
author: ssougnez
description: This tutorial provides a walkthrough of bundling and building an ASP.NET Core SignalR web app using TypeScript and Webpack.
<!-- ms.author: bradyg -->
monikerRange: ">= aspnetcore-2.1"
ms.author: wpickett
ms.custom: mvc, engagement-fy23
ms.date: 01/27/2026
uid: tutorials/signalr-typescript-webpack
---
# Tutorial: Get started with ASP.NET Core SignalR using TypeScript and Webpack

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-10.0"

This tutorial demonstrates using [Webpack](https://webpack.js.org/) in an ASP.NET Core SignalR web app to bundle and build a client written in [TypeScript](https://www.typescriptlang.org/). Webpack enables developers to bundle and build the client-side resources of a web app.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Create an ASP.NET Core SignalR app
> * Configure the SignalR server
> * Configure a build pipeline using Webpack
> * Configure the SignalR TypeScript client
> * Enable communication between the client and the server

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/tutorials/signalr-typescript-webpack/samples) ([how to download](xref:fundamentals/index#how-to-download-a-sample))

## Prerequisites

* [Node.js](https://nodejs.org/) with [npm](https://www.npmjs.com/)

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-10.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-10.0.md)]

---

## Create the ASP.NET Core web app

# [Visual Studio](#tab/visual-studio)

By default, Visual Studio uses the version of npm found in its installation directory. To configure Visual Studio to look for npm in the `PATH` environment variable:

Launch the latest version of Visual Studio. At the start window, select **Continue without code**.

1. Navigate to **Tools** > **Options** > **Projects and Solutions** > **Web Package Management** > **External Web Tools**.
1. Select the `$(PATH)` entry from the list. Select the up arrow to move the entry to the second position in the list, and select **OK**:

   ![Visual Studio Configuration](~/tutorials/signalr-typescript-webpack/_static/8.x/signalr-configure-path-visual-studio-v17.8.0.png).

To create a new ASP.NET Core web app:

1. Use the **File** > **New** > **Project** menu option and choose the **ASP.NET Core Empty** template. Select **Next**.
1. Name the project `SignalRWebpack`, and select **Create**.
1. Select **.NET 10.0 (Standard Term Support)** from the **Framework** drop-down. Select **Create**.

Add the [Microsoft.TypeScript.MSBuild](https://www.nuget.org/packages/Microsoft.TypeScript.MSBuild/) NuGet package to the project:

1. In **Solution Explorer**, right-click the project node and select **Manage NuGet Packages**. In the **Browse** tab, search for `Microsoft.TypeScript.MSBuild` and then select **Install** on the right to install the package.

Visual Studio adds the NuGet package under the **Dependencies** node in **Solution Explorer**, enabling TypeScript compilation in the project.


:::moniker-end

[!INCLUDE[](~/tutorials/signalr-typescript-webpack/includes/signalr-typescript-webpack8-9.md)]

[!INCLUDE[](~/tutorials/signalr-typescript-webpack/includes/signalr-typescript-webpack7.md)]

[!INCLUDE[](~/tutorials/signalr-typescript-webpack/includes/signalr-typescript-webpack6.md)]

[!INCLUDE[](~/tutorials/signalr-typescript-webpack/includes/signalr-typescript-webpack2.1-5.md)]
