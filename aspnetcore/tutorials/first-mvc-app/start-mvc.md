---
title: Get started with ASP.NET Core MVC
author: wadepickett
description: Learn how to get started with ASP.NET Core MVC.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 10/16/2023
uid: tutorials/first-mvc-app/start-mvc
ms.custom: contperf-fy21q3, engagement-fy23
---
# Get started with ASP.NET Core MVC

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-8.0"

[!INCLUDE [consider RP](~/includes/razor.md)]

This is the first tutorial of a series that teaches ASP.NET Core MVC web development with controllers and views.

At the end of the series, you'll have an app that manages and displays movie data. You learn how to:

> [!div class="checklist"]
> * Create a web app.
> * Add and scaffold a model.
> * Work with a database.
> * Add search and validation.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/first-mvc-app/start-mvc/sample) ([how to download](xref:index#how-to-download-a-sample)).

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-8.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-8.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-8.0.md)]

---

<!-- 
Each new version, change the layout file to use the non-minified CSS. 
See https://github.com/dotnet/AspNetCore.Docs/issues/21193
-->

## Create a web app

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio and select **Create a new project**.
* In the **Create a new project** dialog, select **ASP.NET Core Web App (Model-View-Controller)** > **Next**.
* In the **Configure your new project** dialog, enter `MvcMovie` for **Project name**. It's important to name the project *MvcMovie*. Capitalization needs to match each `namespace` when code is copied.
* Select **Next**.
* In the **Additional information** dialog:
  * Select **.NET 8.0 (Preview)**.
  * Verify that **Do not use top-level statements** is unchecked.
* Select **Create**.

![Additional info dialog](~/tutorials/first-mvc-app/start-mvc/_static/8/additional-info-VS22-17.8.0.png)

For more information, including alternative approaches to create the project, see [Create a new project in Visual Studio](/visualstudio/ide/create-new-project).

Visual Studio uses the default project template for the created MVC project. The created project:

* Is a working app.
* Is a basic starter project.

# [Visual Studio Code](#tab/visual-studio-code)

The tutorial assumes familiarity with VS Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs) and [Visual Studio Code help](#visual-studio-code-help).

* Select **New Terminal** from the **Terminal** menu to open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change to the directory (`cd`) that will contain the project.
* Run the following commands:

   ```dotnetcli
   dotnet new mvc -o MvcMovie
   code -r MvcMovie
   ```

  The `dotnet new` command creates a new ASP.NET Core MVC project in the *MvcMovie* folder.

  The `code` command opens the *MvcMovie* project folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Select **File** > **New Project...**.
* Select **Web and Console** > **App** > **Web Application (Model-View-Controller)** > **Continue**.
* In the **Configure your new Web Application (Model-View-Controller)** dialog:
  * Select **.NET 8.0** for the **Target Framework**.
  * Verify that **Do not use top-level statements** is unchecked.
* Select **Continue**.
* Enter `MvcMovie` for **Project name**. It's important to name the project *MvcMovie*. Capitalization needs to match each `namespace` when code is copied.
* Select **Create**.

---

### Run the app

# [Visual Studio](#tab/visual-studio)

* Select Ctrl+F5 to run the app without the debugger.

  [!INCLUDE[](~/includes/trustCertVS.md)]

Visual Studio runs the app and opens the default browser.

The address bar shows `localhost:<port#>` and not something like `example.com`. The standard hostname for your local computer is `localhost`. When Visual Studio creates a web project, a random port is used for the web server.

Launching the app without debugging by selecting Ctrl+F5 allows you to:

* Make code changes.
* Save the file.
* Quickly refresh the browser and see the code changes.

You can launch the app in debug or non-debug mode from the **Debug** menu:

![Start Debug and Start Without Debugging menus](~/tutorials/first-mvc-app/start-mvc/_static/8/debug-and-without-debug-menus-VS22-17.8.0.png)

You can debug the app by selecting the **https** button in the toolbar:

![MvcMovie debug button](~/tutorials/first-mvc-app/start-mvc/_static/8/debug-button-VS22-17.8.0.png)

The following image shows the app:

![Home or Index page](~/tutorials/first-mvc-app/start-mvc/_static/home80-vs.png)

# [Visual Studio Code](#tab/visual-studio-code)

* Select F5 to run the app.

  [!INCLUDE[](~/includes/trustCertVSC.md)]

  Visual Studio Code:

  * Starts [Kestrel](xref:fundamentals/servers/kestrel)
  * Launches a browser.
  * Navigates to `https://localhost:<port#>`.

  The address bar shows `localhost:<port#>` and not something like `example.com`. The standard hostname for your local computer is `localhost`. Localhost only serves web requests from the local computer.

Launching the app without debugging by selecting Ctrl+F5 allows you to:

* Make code changes.
* Save the file.
* Quickly refresh the browser and see the code changes.

  ![Home or Index page](~/tutorials/first-mvc-app/start-mvc/_static/home80-vs.png)

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Select Option+Command+Return to run the app without the debugger.

  Visual Studio for Mac:

  * Starts [Kestrel](xref:fundamentals/servers/index#kestrel) server.
  * Launches a browser.
  * Navigates to `http://localhost:port`, where *port* is a randomly chosen port number, set when Visual Studio creates a web project.

  [!INCLUDE[](~/includes/trustCertMacVS22.md)]

  The address bar shows `localhost:<port#>` and not something like `example.com`. The standard hostname for your local computer is `localhost`. Localhost only serves web requests from the local computer.

You can launch the app in debug or non-debug mode from the **Debug** menu.

The following image shows the app:

![Home or Index page](~/tutorials/first-mvc-app/start-mvc/_static/output_macos_VS22.png)

---

[!INCLUDE[](~/includes/vs-vsc-vsmac-help.md)]

In the next tutorial in this series, you learn about MVC and start writing some code.

> [!div class="step-by-step"]
> [Next: Add a controller](~/tutorials/first-mvc-app/adding-controller.md)

:::moniker-end

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc7.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc6.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc5.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc3.md)]
