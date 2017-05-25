---
title: Getting started with ASP.NET Core MVC and Visual Studio | Microsoft Docs
author: rick-anderson
description: Getting started with ASP.NET Core MVC and Visual Studio
keywords: ASP.NET Core, MVC
ms.author: riande
manager: wpickett
ms.date: 03/07/2017
ms.topic: article
ms.assetid: 1d18b509-e3fd-4dc6-bde6-fb0f41998d77
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app-mac/start-mvc
---
# Getting started with ASP.NET Core MVC and Visual Studio

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial will teach you the basics of building an ASP.NET Core MVC web app using [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/).

## Install Visual Studio for Mac and .NET Core



## Create a web app

From Visual Studio, select **File > New Solution**.

![macOS New solution](../first-web-api-mac/_static/sln.png)

Select **.NET Core App >  ASP.NET Core Web App > Next**.

![macOS New project dialog](start-mvc/1.png)

Name the project **MvcMovie** and then select **Create**.

![macOS New project dialog](start-mvc/2.png)

### Launch the app

In Visual Studio, select **Run > Start With Debugging** to launch the app. Visual Studio launches a browser and navigates to `http://localhost:port`, where *port* is a randomly chosen port number. utorials/first-mvc-app-xplat/start-mvc -->


* Visual Studio starts [IIS Express](http://www.iis.net/learn/extensions/introduction-to-iis-express/iis-express-overview) and runs your app. Notice that the address bar shows `localhost:port#` and not something like `example.com`. That's because `localhost` is the standard hostname for your local computer. When Visual Studio creates a web project, a random port is used for the web server. In the image above, the port number is 5000. When you run the app, you'll see a different port number.
* Launching the app with **Ctrl+F5** (non-debug mode) allows you to make code changes, save the file, refresh the browser, and see the code changes. Many developers prefer to use non-debug mode to quickly launch the app and view changes.
* You can launch the app in debug or non-debug mode from the **Debug** menu item:



* You can debug the app by tapping the **IIS Express** button

![IIS Express](../first-mvc-app/start-mvc/_static/iis_express.png)

The default template gives you working **Home, About** and **Contact** links. The browser image above doesn't show these links. Depending on the size of your browser, you might need to click the navigation icon to show them.



If you were running in debug mode, tap **Shift-F5** to stop debugging.

In the next part of this tutorial, we'll learn about MVC and start writing some code.

>[!div class="step-by-step"]

<!--
[Next](adding-controller.md)  

-->
