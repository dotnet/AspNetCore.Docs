---
title: Get started with ASP.NET Core MVC
author: rick-anderson
description: Learn how to get started with ASP.NET Core MVC.
ms.author: riande
ms.date: 12/12/2018
uid: tutorials/first-mvc-app/start-mvc
---
# Get started with ASP.NET Core MVC

By [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE [consider RP](~/includes/razor.md)]

This tutorial teaches the basics of building an ASP.NET Core MVC web app.

The app manages a database of movie titles. You learn how to:

> [!div class="checklist"]
> * Create a web app.
> * Add and scaffold a model.
> * Work with a database.
> * Add search and validation.

At the end, you have an app that can manage and display movie data.

[!INCLUDE[](~/includes/mvc-intro/download.md)]

[!INCLUDE[](~/includes/net-core-prereqs-all-2.2.md)]

## Create a web app

<!-- VS -------------------------->
# [Visual Studio](#tab/visual-studio)

From Visual Studio, select  **File > New > Project**.

![File > New > Project](start-mvc/_static/alt_new_project.png)

Complete the **New Project** dialog:

* In the left pane, select **.NET Core**
* In the center pane, select **ASP.NET Core Web Application (.NET Core)**
* Name the project "MvcMovie" (It's important to name the project "MvcMovie" so when you copy code, the namespace will match.)
* select **OK**

![New project dialog, .Net core in left pane, ASP.NET Core web ](start-mvc/_static/new_project2-21.png)

Complete the **New ASP.NET Core Web Application (.NET Core) - MvcMovie** dialog:

* In the version selector drop-down box select **ASP.NET Core 2.2**
* Select **Web Application (Model-View-Controller)**
* select **OK**.

![New project dialog, .Net core in left pane, ASP.NET Core web ](start-mvc/_static/new_project22-21.png)

Visual Studio used a default template for the MVC project you just created. You have a working app right now by entering a project name and selecting a few options. This is a basic starter project, and it's a good place to start.

Select **Ctrl-F5** to run the app in non-debug mode.

* Visual Studio starts [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview) and runs your app. Notice that the address bar shows `localhost:port#` and not something like `example.com`. That's because `localhost` is the standard hostname for your local computer. When Visual Studio creates a web project, a random port is used for the web server. In the image above, the port number is 5000. The URL in the browser shows `localhost:5000`. When you run the app, you'll see a different port number.
* Launching the app with **Ctrl+F5** (non-debug mode) allows you to make code changes, save the file, refresh the browser, and see the code changes. Many developers prefer to use non-debug mode to quickly launch the app and view changes.
* You can launch the app in debug or non-debug mode from the **Debug** menu item:

![Debug menu](start-mvc/_static/debug_menu.png)

* You can debug the app by selecting the **IIS Express** button

![IIS Express](start-mvc/_static/iis_express.png)

<!-- Code -------------------------->
# [Visual Studio Code](#tab/visual-studio-code)

The tutorial assumes familarity with VS Code. See [Getting started with VS Code](https://code.visualstudio.com/docs) and [Visual Studio Code help](#visual-studio-code-help) for more information.

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to a folder which will contain the project.
* Run the following command:

   ```console
   dotnet new mvc -o MvcMovie
   code -r MvcMovie
   ```

  * A dialog box appears with **Required assets to build and debug are missing from 'MvcMovie'. Add them?**  Select **Yes**

  * `dotnet new mvc -o MvcMovie`: creates a new ASP.NET Core MVC project in the *MvcMovie* folder.
  * `code -r MvcMovie`: Loads the *MvcMovie.csproj* project file in Visual Studio Code.

### Launch the app

* Press **Ctrl-F5** to run without the debugger.

  Visual Studio Code starts starts [Kestrel](xref:fundamentals/servers/kestrel), launches a browser, and navigates to `https://localhost:5001`. The address bar shows `localhost:port:5001` and not something like `example.com`. That's because `localhost` is the standard hostname for  local computer. Localhost only serves web requests from the local computer.

  Launching the app with **Ctrl+F5** (non-debug mode) allows you to make code changes, save the file, refresh the browser, and see the code changes. Many developers prefer to use non-debug mode to refresh the page and view changes.

<!-- Mac -------------------------->
# [Visual Studio for Mac](#tab/visual-studio-mac)

* Select **File** > **New Solution**.

  ![macOS New solution](~/tutorials/first-web-api-mac/_static/sln.png)

* Select **.NET Core App** > **ASP.NET Core** > **ASP.NET Core Web App (MVC)** > **Next**.

  ![macOS New project dialog](~/tutorials/first-mvc-app-mac/start-mvc/1.png)

* In the **Configure your new ASP.NET Core Web API** dialog, accept the default **Target Framework** of **.NET Core 2.2*.

* Name the project **MvcMovie**, and then select **Create**.

### Launch the app

Select **Run** > **Start Without Debugging** to launch the app. Visual Studio for Mac starts [Kestrel](xref:fundamentals/servers/index#kestrel) server, launches a browser, and navigates to `http://localhost:port`, where *port* is a randomly chosen port number.

* The address bar shows `localhost:port#` and not something like `example.com`. That's because `localhost` is the standard hostname for your local computer. When Visual Studio creates a web project, a random port is used for the web server. When you run the app, you'll see a different port number.
* You can launch the app in debug or non-debug mode from the **Run** menu.

---  
<!-- End of VS tabs -->

* Select **Accept** to consent to tracking. This app doesn't track personal information. The template generated code includes assets to help meet [General Data Protection Regulation (GDPR)](xref:security/gdpr).

  ![Home or Index page](start-mvc/_static/privacy.png)

  The following image shows the app after accepting tracking:

  ![Home or Index page](start-mvc/_static/home2.2.png)

[!INCLUDE[](~/includes/vs-vsc-vsmac-help.md)]

In the next part of this tutorial, you learn about MVC and start writing some code.

> [!div class="step-by-step"]
> [Next](adding-controller.md)  
