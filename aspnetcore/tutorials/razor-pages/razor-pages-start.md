---
title: Getting started with Razor Pages in ASP.NET Core
author: rick-anderson
description: Getting started with Razor Pages in ASP.NET Core
keywords: ASP.NET Core,Razor Pages,Razor,MVC
ms.author: riande
manager: wpickett
ms.date: 7/27/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: aspnet-core
uid: tutorials/razor-pages/razor-pages-start
---
# Getting started with Razor Pages in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial will teach you the basics of building an ASP.NET Core Razor Pages web app. We recommend you complete [Introduction to Razor Pages](xref:mvc/razor-pages/index) before starting this tutorial. Razor Pages is the recommended way to build UI for web applications in ASP.NET Core.

## Prerequisites

* Install the latest [.NET Core 2.0 SDK](https://github.com/dotnet/cli/tree/release/2.0.0)
* [Visual Studio 2017 Preview version 15.3](https://www.visualstudio.com/vs/preview/)

## Create a Razor web app

* From the Visual Studio **File** menu, select **New > Project**.
* Create a new ASP.NET Core Web Application. Name the project **RazorPagesMovie**. It's important to name the project *RazorPagesMovie* so the namespaces will match when you copy/paste code.
 ![new ASP.NET Core Web Application](../../mvc/razor-pages/index/_static/np.png)
* Select **ASP.NET Core 2.0** in the dropdown, and then select **Web Application**.
 ![Web Application (Razor Pages)](../../mvc/razor-pages/index/_static/np2.png)

The Visual Studio template creates a starter project:

![Solution Explorer](razor-pages-start/_static/se.png)

Press **F5** to run the app in debug mode or **Ctrl-F5** to run without attaching the debugger

![Home or Index page](razor-pages-start/_static/home.png)

* Visual Studio starts [IIS Express](https://docs.microsoft.com/iis/extensions/introduction-to-iis-express/iis-express-overview) and runs your app. The address bar shows `localhost:port#` and not something like `example.com`. That's because `localhost` is the standard hostname for your local computer. Localhost only serves web requests from the local computer. When Visual Studio creates a web project, a random port is used for the web server. In the preceding image, the port number is 5000. When you run the app, you'll see a different port number.
* Launching the app with **Ctrl+F5** (non-debug mode) allows you to make code changes, save the file, refresh the browser, and see the code changes. Many developers prefer to use non-debug mode to quickly launch the app and view changes.

The default template creates **RazorPagesMovie**, **Home**, **About** and **Contact** links. Depending on the size of your browser window, you might need to click the navigation icon to show the links.

![Home or Index page](razor-pages-start/_static/home2.png)

Test the links. The **RazorPagesMovie** and **Home** links go to the home page. The **About** and **Contact** links go to the `About` and `Contact` pages, respectively.

## Project files and folders

The following table lists the files and folders in the project. For this tutorial, the *Startup.cs* file is the most important to understand. You don't need to review each link provided below. The links are provided as a reference when you need more information on a file or folder in the project.

| File or folder              | Purpose |
| ----------------- | ------------ | 
| wwwroot | Contains static files. See [Working with static files](xref:fundamentals/static-files). |
| Pages | Folder for [Razor Pages](xref:mvc/razor-pages/index). | 
| *appsettings.json* | [Configuration](xref:fundamentals/configuration) |
| *bower.json* | Client-side package management. See [Bower](xref:client-side/bower).|
| *Program.cs* | [Hosts](xref:fundamentals/hosting) the ASP.NET Core app.|
| *Startup.cs* | Configures services and the request pipeline. See [Startup](xref:fundamentals/startup).|

### The Pages folder

The *_Layout.cshtml* file contains common HTML elements (scripts and stylesheets) and sets the layout for the application. For example, when you click on **RazorPagesMovie**, **Home**, **About** or **Contact**, you see the same elements. The common elements include the navigation menu on the top and the header on the bottom of the window. See [Layout](xref:mvc/views/layout) for more information.

The *_ViewStart.cshtml* sets the Razor Pages `Layout` property to use the *_Layout.cshtml* file. See [Layout](xref:mvc/views/layout) for more information.

The *_ViewImports.cshtml* file contains Razor directives that are imported into each Razor Page. See [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives) for more information.

The *_ValidationScriptsPartial.cshtml* file provides a reference to [jQuery](https://jquery.com/) validation scripts. When we add `Create` and `Edit` pages later in the tutorial, the *_ValidationScriptsPartial.cshtml* file will be used.

The `About`, `Contact` and `Index` pages are basic pages you can use to start an app. The `Error` page is used to display error information.

>[!div class="step-by-step"]
[Next: Adding a model](xref:tutorials/razor-pages/model)  
