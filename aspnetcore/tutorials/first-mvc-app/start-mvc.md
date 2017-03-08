---
title: Getting started with ASP.NET Core MVC and Visual Studio | Microsoft Docs
author: rick-anderson
description: Getting started with ASP.NET Core MVC and Visual Studio
keywords: ASP.NET Core, MVC
ms.author: riande
manager: wpickett
ms.date: 03/07/2017
ms.topic: article
ms.assetid: 1d18b589-e3fd-4dc6-bde6-fb0f41998d78
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app/start-mvc
---
# Getting started with ASP.NET Core MVC and Visual Studio

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial will teach you the basics of building an ASP.NET Core MVC web app using [Visual Studio 2017](https://www.visualstudio.com/).

> [!NOTE]
> See [Your First ASP.NET Core Application on a Mac Using Visual Studio Code](../your-first-mac-aspnet.md) for a Mac tutorial.

For the Visual Studio 2015 version of this tutorial, see the [VS 2015 version of ASP.NET Core documentation in PDF format](https://github.com/aspnet/Docs/blob/master/aspnetcore/common/_static/aspnet-core-project-json.pdf).

## Install Visual Studio and .NET Core

Install Visual Studio Community 2017. Select the Community download. Skip this step if you have Visual Studio 2017 installed.

  * [Visual Studio 2017 Home page installer](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx)

Run the installer and select the following workloads:
 - **ASP.NET and web development** (under **Web & Cloud**)
 - **.NET Core cross-platform development** (under **Other Toolsets**)

![**ASP.NET and web development** (under **Web & Cloud**)](start-mvc/_static/web_workload.png)

![**.NET Core cross-cross-platfrom development** (under **Other Toolsets**)](start-mvc/_static/x_plat_wl.png)


## Create a web app

From Visual Studio, select  **File > New > Project**.

![File > New > Project](start-mvc/_static/alt_new_project.png)

Complete the **New Project** dialog:

* In the left pane, tap **.NET Core**
* In the center pane, tap **ASP.NET Core Web Application (.NET Core)**
* Verify **Authentication** is set to **No Authentication**
* Name the project "MvcMovie" (It's important to name the project "MvcMovie" so when you copy code, the namespace will match.)
* Tap **OK**

![New project dialog, .Net core in left pane, ASP.NET Core web ](start-mvc/_static/new_project2.png)

Complete the **New ASP.NET Core Web Application (.NET Core) - MvcMovie** dialog:

* In the version selector drop-down box tap **ASP.NET Core 1.1**
* Tap **Web Application**
* Keep the default **No Authentication**
* Tap **OK**.

![New ASP.NET Core web app](start-mvc/_static/p3.png)

Visual Studio used a default template for the MVC project you just created. You have a working app right now by entering a project name and selecting a few options. This is a simple starter project, and it's a good place to start,

Tap **F5** to run the app in debug mode or **Ctrl-F5** in non-debug mode.

![running app](start-mvc/_static/1.png)

* Visual Studio starts [IIS Express](http://www.iis.net/learn/extensions/introduction-to-iis-express/iis-express-overview) and runs your app. Notice that the address bar shows `localhost:port#` and not something like `example.com`. That's because `localhost` is the standard hostname for your local computer. When Visual Studio creates a web project, a random port is used for the web server. In the image above, the port number is 1234. When you run the app, you'll see a different port number.
* Launching the app with **Ctrl+F5** (non-debug mode) allows you to make code changes, save the file, refresh the browser, and see the code changes. Many developers prefer to use non-debug mode to quickly launch the app and view changes.
* You can launch the app in debug or non-debug mode from the **Debug** menu item:

![Debug menu](start-mvc/_static/debug_menu.png)

* You can debug the app by tapping the **IIS Express** button

![IIS Express](start-mvc/_static/iis_express.png)

The default template gives you working **Home, About** and **Contact** links. The browser image above doesn't show these links. Depending on the size of your browser, you might need to click the navigation icon to show them.

![navigation icon in upper right](start-mvc/_static/2.png)

If you were running in debug mode, tap **Shift-F5** to stop debugging.

In the next part of this tutorial, we'll learn about MVC and start writing some code.

>[!div class="step-by-step"]
[Next](adding-controller.md)  
