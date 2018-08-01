---
title: Get started with SignalR on ASP.NET Core
author: tdykstra
description: In this tutorial, you create an app using SignalR for ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 05/22/2018
uid: tutorials/signalr
---
# Get started with SignalR on ASP.NET Core

This tutorial teaches the basics of building a real-time app using SignalR for ASP.NET Core.

![SignalR sample app](signalr/_static/signalr-get-started-finished.png)

This tutorial demonstrates the following SignalR development tasks:

> [!div class="checklist"]
> * Create a web app that uses SignalR on ASP.NET Core.
> * Create a SignalR hub to push content to clients.
> * Modify the `Startup` class and configure the app.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/signalr/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Prerequisites

Install the following software:

# [Visual Studio](#tab/visual-studio)

* [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download/all)
* [Visual Studio 2017](https://www.visualstudio.com/downloads/) version 15.7.3 or later with the **ASP.NET and web development** workload
* [npm](https://www.npmjs.com/get-npm) (package manager for Node.js)

# [Visual Studio Code](#tab/visual-studio-code)

* [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download/all)
* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* [npm](https://www.npmjs.com/get-npm) (package manager for Node.js)

-----

## Create the project and add SignalR client package

# [Visual Studio](#tab/visual-studio/)

1. Use the **File** > **New Project** menu option and choose **ASP.NET Core Web Application**. Name the project *SignalRChat*.

   ![New Project dialog in Visual Studio](signalr/_static/signalr-new-project-dialog.png)

2. Select **Web Application** to create a project using Razor Pages. Then select **OK**. Be sure that **ASP.NET Core 2.1** is selected from the framework selector, though SignalR runs on older versions of .NET.

   ![New Project dialog in Visual Studio](signalr/_static/signalr-new-project-choose-type.png)

   Visual Studio includes the `Microsoft.AspNetCore.SignalR` package containing its server libraries as part of its **ASP.NET Core Web Application** template. However, the JavaScript client library for SignalR must be installed using *npm*.

3. Run the following commands in the **Package Manager Console** window, from the project root:

   ```console
   npm init -y
   npm install @aspnet/signalr
   ```

4. Create a new folder named "signalr" inside the  *wwwroot/lib* folder in your project. Copy the *signalr.js* file from *node_modules\\@aspnet\signalr\dist\browser* to this folder.

# [Visual Studio Code](#tab/visual-studio-code/)

1. From the **Integrated Terminal**, run the following command:

    ```console
    dotnet new webapp -o SignalRChat
    ```

    [!INCLUDE[](~/includes/webapp-alias-notice.md)]

2. Install the JavaScript client library using *npm*.

    ```console
    npm init -y
    npm install @aspnet/signalr
    ```

3. Create a new folder named "signalr" inside the  *lib* folder in your project. Copy the *signalr.js* file from *node_modules\\@aspnet\signalr\dist\browser* to this folder.

---

## Create the SignalR hub

A [hub](xref:signalr/hubs) is a class that serves as a high-level pipeline that allows the client and server to call methods on each other.

1. In the SignalRChat project, create a folder named *Hubs*.

1. In the *Hubs* folder, create a file named *ChatHub.cs*.

1. Replace the code in the file with the following code:

   [!code-csharp[Startup](signalr/sample/Hubs/ChatHub.cs)]

   The `ChatHub` class inherits from the SignalR `Hub` class. The `Hub` class contains properties and events for managing connections and groups, as well as sending and receiving data.

   The `SendMessage` method sends a message to all connected chat clients. Notice it returns a [Task](https://msdn.microsoft.com/library/system.threading.tasks.task(v=vs.110).aspx), because SignalR is asynchronous. Asynchronous code scales better.

## Configure the project to use SignalR

The SignalR server must be configured so that it knows to pass requests to SignalR.

1. Open the *Startup.cs* file.

1. Add a `using` statement for `SignalRChat.Hubs`.

1. At the end of the `ConfigureServices` method, add a `services.AddSignalR` statement. This change makes the SignalR services available to the [dependency injection](xref:fundamentals/dependency-injection) system.

1. In the `Configure` method, before the `app.UseMvc` statement, call `app.UseSignalR`.

   [!code-csharp[](signalr/sample/Startup.cs?name=snippet_Routes)]

   This change adds SignalR to the [middleware](xref:fundamentals/middleware/index) pipeline.

1. The highlighted lines show these changes in the context of `Startup` class code. The parts that aren't highlighted may differ from your `Startup` class.

   [!code-csharp[Startup](signalr/sample/Startup.cs?name=snippet_Startup&highlight=6,37,57-60)]

## Create the SignalR client code

2. Replace the content in *Pages\Index.cshtml* with the following code:

   [!code-cshtml[Index](signalr/sample/Pages/Index.cshtml)]

   This code:

   * Creates text boxes for name and message text, and a submit button.
   * Creates an unordered list with `id="messagesList"` for the messages to be displayed.
   * Includes script references to SignalR and the *chat.js* application code that you create in the next step.

1. Add a JavaScript file named *chat.js* to the *wwwroot\js* folder. Add the following code to it:

   [!code-javascript[Index](signalr/sample/wwwroot/js/chat.js)]

   This code:

   * [Creates and starts a connection](xref:signalr/javascript-client#connect-to-a-hub).
   * Adds to the connection a handler that receives messages from the hub and adds them to the unordered list in *index.cshtml*. 
   * Adds to the submit button in *index.cshtml* a handler that sends messages to the hub.

## Run the app

# [Visual Studio](#tab/visual-studio)

1. Select **Debug** > **Start without debugging** to launch a browser and load the website locally. Copy the URL from the address bar.

1. Open another browser instance (any browser) and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the **Send** button. The name and message are displayed on both pages instantly.

# [Visual Studio Code](#tab/visual-studio-code)

1. Press **Debug** (F5) to build and run the program. Running the program opens a browser window.

1. Open another browser window and load the website locally in it.

1. Choose either browser, enter a name and message, and click the **Send** button. The name and message are displayed on both pages instantly.

---

![SignalR sample app](signalr/_static/signalr-get-started-finished.png)

## Related resources

[Introduction to ASP.NET Core SignalR](xref:signalr/introduction)
