---
title: Get started with ASP.NET Core Razor Pages in Visual Studio Code
author: rick-anderson
description: Learn the basics of building an ASP.NET Core Razor Pages web app with Visual Studio Code.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/24/2018
uid: tutorials/razor-pages-vsc/razor-pages-start
---
# Get started with ASP.NET Core Razor Pages in Visual Studio Code

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial teaches the basics of building an ASP.NET Core Razor Pages web app. We recommend you complete [Introduction to Razor Pages](xref:razor-pages/index) before starting this tutorial. Razor Pages is the recommended way to build UI for web applications in ASP.NET Core.

## Prerequisites

[!INCLUDE [](~/includes/net-core-prereqs-vscode.md)]

## Create a Razor web app

From a terminal, run the following commands:

::: moniker range=">= aspnetcore-2.1"

```console
dotnet new webapp -o RazorPagesMovie
cd RazorPagesMovie
dotnet run
```

::: moniker-end

::: moniker range="= aspnetcore-2.0"

```console
dotnet new razor -o RazorPagesMovie
cd RazorPagesMovie
dotnet run
```

::: moniker-end

The preceding commands use the [.NET Core CLI](/dotnet/core/tools/dotnet) to create and run a Razor Pages project. Open a browser to http://localhost:5000 to view the application.

![Home or Index page](../razor-pages/razor-pages-start/_static/home.png)

[!INCLUDE [razor-pages-start](../../includes/RP/razor-pages-start.md)]

## Open the project

Press Ctrl+C to shut down the application.

From Visual Studio Code (VS Code), select **File > Open Folder**, and then select the *RazorPagesMovie* folder.

- Select **Yes** to the **Warn** message "Required assets to build and debug are missing from 'RazorPagesMovie'. Add them?"
- Select **Restore** to the **Info** message "There are unresolved dependencies".

### Launch the app

From the **Debug** menu, select **Start Without Debugging**. Alternatively, you can press the keyboard shortcut displayed next to the menu option. This shortcut varies depending on your operating system.

In the next tutorial, we add a model to the project. 

> [!div class="step-by-step"]
> [Next: Adding a model](xref:tutorials/razor-pages-vsc/model)  
