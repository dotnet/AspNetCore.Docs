---
uid: signalr/get-started-signalr-core
title: Get Started with SignalR on ASP.NET Core
author: rachelappel
ms.author: rachelap
description: In this tutorial, you will create a SignalR on ASP.NET Core application.
manager: wpickett
ms.date: 02/23/2018
ms.topic: tutorial
ms.technology: dotnet-signalr
ms.prod: aspnet-core
ms.custom: mvc
---
# Tutorial: Get started with SignalR for ASP.NET Core

By [Rachel Appel](https://twitter.com/rachelappel)

This tutorial teaches the basics of building a real-time app using SignalR for ASP.NET Core. 

  ![Solution](get-started-signalr-core/_static/signalr-get-started-finished.png)

This tutorial demonstrates the following SignalR development tasks:

> [!div class="checklist"]
> * Add the SignalR library to an ASP.NET web app.
> * Create a SignalR hub to push content to clients.
> * Modify the `Startup` class to configure the app.
> * Use the SignalR JavaScript library to send messages and display updates from the hub.

# Prerequisites

Install the following:

* [.NET Core 2.0.0 SDK](https://www.microsoft.com/net/core) or later.
* [Visual Studio 2017](https://www.visualstudio.com/downloads/) version 15.6 or later with the ASP.NET and web development workload.

## Create an ASP.NET Core project that uses SignalR

1. Use the **File** > **New Project** menu option and choose **ASP.NET Core Web Application**.

  ![New Project dialog in Visual Studio](get-started-signalr-core/_static/signalr-new-project-dialog.png)

1. Select **Web Application** which creates a project using Razor Pages. Then select **Ok**.

  ![New Project dialog in Visual Studio](get-started-signalr-core/_static/signalr-new-project-choose-type.png)

1. Add the `Microsoft.AspNetCore.SignalR` NuGet package to the ASP.NET Core project. Select **Tools** > **NuGet Package Manager** > **Package Manager Console**. In the console, issue the following command:

  ```powershell
  Install-Package Microsoft.AspNetCore.SignalR –IncludePrerelease
  ```

  The preceeding command installs the [Microsoft.AspNetCore.SignalR](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR) NuGet package that contains libraries SignalR server-side code.

1. Install the JavaScript client library by using npm. `npm install` creates a *\node_modules\* folder and sub-folders for the libraries in the same location as where you run the npm command.

  ```console
   npm install @aspnet/signalr-client --save
  ```

1. Copy the *signalr-client-1.0.0-alpha2-final.js* for SignalR from *\node_modules\@aspnet\signalr-client\dist\browser* to the *wwwroot\lib* folder in your project.

## Create the SignalR Hub

A hub is a class that represents a high-level pipeline that allows the client and server to call methods on each other directly.

1. Add a class to the project by choosing **File** > **New** > **File** and selecting **Visual C# Class**. 

1. Inherit from `Microsoft.AspNetCore.SignalR.Hub`. The `Hub` class contains properties and events for managing connections and groups, as well as sending and receiving data.

1. Create the `Send` method that sends a message to all connected chat clients. Notice it returns a `Task`, because SignalR is asynchronous and scales better.

  [!code-csharp[Startup](get-started-signalr-core/sample/ChatHub.cs?range=7-14)]

## Configure the project to use SignalR

The SignalR server must be configured so that it knows to pass requests to SignalR.

1. To configure a SignalR project, modify the `ConfigureServices` method of the application's `Startup` class by inserting a call to `services.AddSignalR()`.

  This adds SignalR as part of the [ASP.NET Core middleware](xref:fundamentals/middleware/index) pipeline.

1. In the `Startup` class, you must also configure SignalR routes by calling `UseSignalR`. In the call to `UseSignalR` is where you setup the SignalR hub mappings.

  [!code-csharp[Startup](get-started-signalr-core/sample/Startup.cs?highlight=22,40-43)]

## Create the SignalR client code

1. Replace the content in *\Pages\Index.cshtml* with the following code:

  [!code-html[Index](get-started-signalr-core/sample/Index.cshtml)]

  The preceding HTML displays name and message fields, and a submit button. Notice the script references at the bottom: a reference to SignalR and *chat.js*.

1. Add a JavaScript file to the *\wwwroot\js\* folder named *chat.js* and add the following code to it:

  [!code-html[Index](get-started-signalr-core/sample/chat.js)]

## Run the app

1. Select **Debug** > **Start without debugging** to launch a browser and load the website locally.

1. Enter a name and message, and click the **Send** button. The name and message are displayed in the page.

  ![Solution](get-started-signalr-core/_static/signalr-get-started-finished.png)

## Next Steps


[Publish to Azure](xref:tutorials/publish-to-azure-webapp-using-vs)
