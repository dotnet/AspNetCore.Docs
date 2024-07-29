---
title: Get started with ASP.NET Core MVC
author: wadepickett
description: Learn how to get started with ASP.NET Core MVC.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 07/24/2024
uid: tutorials/first-mvc-app/start-mvc
---
# Get started with ASP.NET Core MVC

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-9.0"

[!INCLUDE [consider RP](~/includes/razor.md)]

This is the first tutorial of a series that teaches ASP.NET Core MVC web development with controllers and views.

At the end of the series, you'll have an app that manages, validates, and displays movie data. You learn how to:

> [!div class="checklist"]
> * Create a web app.
> * Add and scaffold a model.
> * Work with a database.
> * Add search and validation.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/first-mvc-app/start-mvc/sample) ([how to download](xref:index#how-to-download-a-sample)).

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-9.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-9.0.md)]

---

<!-- 
Each new version, change the layout file to use the non-minified CSS. 
See https://github.com/dotnet/AspNetCore.Docs/issues/21193
-->

## Create a web app

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio and select **Create a new project**.
* In the **Create a new project** dialog, select **ASP.NET Core Web App (Model-View-Controller)** > **Next**.
* In the **Configure your new project** dialog:
  * Enter `MvcMovie` for **Project name**. It's important to name the project *MvcMovie*. Capitalization needs to match each `namespace` when code is copied.
  * The **Location** for the project can be set to anywhere.
* Select **Next**.
* In the **Additional information** dialog:
  * Select **.NET 9.0 (Preview)**.
  * Verify that **Do not use top-level statements** is unchecked.
* Select **Create**.

![Additional info dialog](~/tutorials/first-mvc-app/start-mvc/_static/9/additional-info-VS22-17.11.0.png)

For more information, including alternative approaches to create the project, see [Create a new project in Visual Studio](/visualstudio/ide/create-new-project).

Visual Studio uses the default project template for the created MVC project. The created project:

* Is a working app.
* Is a basic starter project.

# [Visual Studio Code](#tab/visual-studio-code)

The tutorial assumes familiarity with VS Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs) and [Visual Studio Code help](#visual-studio-code-help).

* Select **New Terminal** from the **Terminal** menu to open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change to the directory (`cd`) that will contain the project. The project can be located anywhere.
* Run the following commands:

   ```dotnetcli
   dotnet new mvc -o MvcMovie
   code -r MvcMovie
   ```

  The `dotnet new` command creates a new ASP.NET Core MVC project in the *MvcMovie* folder.

  The `code` command opens the *MvcMovie* project folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

---

### Run the app

# [Visual Studio](#tab/visual-studio)

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app without the debugger.

  [!INCLUDE[](~/includes/trustCertVS.md)]

Visual Studio runs the app and opens the default browser.

The address bar shows `localhost:<port#>` and not something like `example.com`. The standard hostname for your local computer is `localhost`. When Visual Studio creates a web project, a random port is used for the web server.

Launching the app without debugging by pressing <kbd>Ctrl</kbd>+<kbd>F5</kbd> allows you to:

* Make code changes.
* Save the file.
* Quickly refresh the browser and see the code changes.

You can launch the app in debug or non-debug mode from the **Debug** menu:

![Start Debug and Start Without Debugging menus](~/tutorials/first-mvc-app/start-mvc/_static/9/debug-and-without-debug-menus-VS22-17.11.0.png)

You can debug the app by selecting the **https** button in the toolbar:

![MvcMovie debug button](~/tutorials/first-mvc-app/start-mvc/_static/9/debug-button-VS22-17.11.0.png)

The following image shows the app:

![Home or Index page](~/tutorials/first-mvc-app/start-mvc/_static/9/home90-vs.png)

* Close the browser window.  Visual Studio will stop the application.

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

* In Visual Studio Code, press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>^</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

  Visual Studio Code:

  * Starts [Kestrel](xref:fundamentals/servers/kestrel)
  * Launches a browser.
  * Navigates to `https://localhost:<port#>`.

  The address bar shows `localhost:<port#>` and not something like `example.com`. The standard hostname for your local computer is `localhost`. Localhost only serves web requests from the local computer.

Launching the app without debugging by selecting Ctrl+F5 allows you to:

* Make code changes.
* Save the file.
* Quickly refresh the browser and see the code changes.

  ![Home or Index page](~/tutorials/first-mvc-app/start-mvc/_static/9/home90-vs.png)

* Close the browser window.

* In Visual Studio Code, from the *Run* menu, select *Stop Debugging* or press <kbd>Shift</kbd>+<kbd>F5</kbd> to stop the app.

---

[!INCLUDE[](~/includes/vs-vsc-help.md)]

In the next tutorial in this series, you learn about MVC and start writing some code.

> [!div class="step-by-step"]
> [Next: Add a controller](~/tutorials/first-mvc-app/adding-controller.md)

:::moniker-end

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc8.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc7.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc6.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc5.md)]

[!INCLUDE[](~/tutorials/first-mvc-app/start-mvc/includes/start-mvc3.md)]
