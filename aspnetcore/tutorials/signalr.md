---
title: Get started with ASP.NET Core SignalR
author: tdykstra
description: In this tutorial, you create a chat app that uses ASP.NET Core SignalR.
ms.author: tdykstra
ms.custom: mvc
ms.date: 11/30/2018
uid: tutorials/signalr

# Customer intent: As a developer, I want to get a quick proof-of-concept app running, so I can get a practical introduction to ASP.NET Core SignalR.
---

# Tutorial: Get started with ASP.NET Core SignalR

This tutorial teaches the basics of building a real-time app using SignalR. You learn how to:

> [!div class="checklist"]
> * Create a web project.
> * Add the SignalR client library.
> * Create a SignalR hub.
> * Configure the project to use SignalR.
> * Add code that sends messages from any client to all connected clients.

At the end, you'll have a working chat app:

![SignalR sample app](signalr/_static/signalr-get-started-finished.png)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/signalr/sample) ([how to download](xref:index#how-to-download-a-sample)).

[!INCLUDE [|Prerequisites](~/includes/net-core-prereqs-all-2.2.md)]

## Create a web project

# [Visual Studio](#tab/visual-studio/)

* From the menu, select **File > New Project**.

* In the **New Project** dialog, select **Installed > Visual C# > Web > ASP.NET Core Web Application**. Name the project *SignalRChat*.

  ![New Project dialog in Visual Studio](signalr/_static/signalr-new-project-dialog.png)

* Select **Web Application** to create a project that uses Razor Pages.

* Select a target framework of **.NET Core**, select **ASP.NET Core 2.2**, and click **OK**.

  ![New Project dialog in Visual Studio](signalr/_static/signalr-new-project-choose-type.png)

# [Visual Studio Code](#tab/visual-studio-code/)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal) to the folder in which the new project folder will be created.

* Run the following commands:

   ```console
   dotnet new webapp -o SignalRChat
   code -r SignalRChat
   ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

* From the menu, select **File > New Solution**.

* Select **.NET Core > App > ASP.NET Core Web App** (Don't select **ASP.NET Core Web App (MVC)**).

* Select **Next**.

* Name the project *SignalRChat*, and then select **Create**.

---

## Add the SignalR client library

The SignalR server library is included in the `Microsoft.AspNetCore.App` metapackage. The JavaScript client library isn't automatically included in the project. For this tutorial, you use Library Manager (LibMan) to get the client library from *unpkg*. unpkg is a content delivery network (CDN)) that can deliver anything found in npm, the Node.js package manager.

# [Visual Studio](#tab/visual-studio/)

* In **Solution Explorer**, right-click the project, and select **Add** > **Client-Side Library**.

* In the **Add Client-Side Library** dialog, for **Provider** select **unpkg**. 

* For **Library**, enter `@aspnet/signalr@1`, and select the latest version that isn't preview.

  ![Add Client-Side Library dialog - select library](signalr/_static/libman1.png)

* Select **Choose specific files**, expand the *dist/browser* folder, and select *signalr.js* and *signalr.min.js*.

* Set **Target Location** to *wwwroot/lib/signalr/*, and select **Install**.

  ![Add Client-Side Library dialog - select files and destination](signalr/_static/libman2.png)

  LibMan creates a *wwwroot/lib/signalr* folder and copies the selected files to it.

# [Visual Studio Code](#tab/visual-studio-code/)

* In the integrated terminal, run the following command to install LibMan.

  ```console
  dotnet tool install -g Microsoft.Web.LibraryManager.Cli
  ```

* Run the following command to get the SignalR client library by using LibMan. You might have to wait a few seconds before seeing output.

  ```console
  libman install @aspnet/signalr -p unpkg -d wwwroot/lib/signalr --files dist/browser/signalr.js --files dist/browser/signalr.min.js
  ```

  The parameters specify the following options:
  * Use the unpkg provider.
  * Copy files to the *wwwroot/lib/signalr* destination.
  * Copy only the specified files.

  The output looks like the following example:

  ```console
  wwwroot/lib/signalr/dist/browser/signalr.js written to disk
  wwwroot/lib/signalr/dist/browser/signalr.min.js written to disk
  Installed library "@aspnet/signalr@1.0.3" to "wwwroot/lib/signalr"
  ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

* In the **Terminal**, run the following command to install LibMan.

  ```console
  dotnet tool install -g Microsoft.Web.LibraryManager.Cli
  ```

* Navigate to the project folder (the one that contains the *SignalRChat.csproj* file).

* Run the following command to get the SignalR client library by using LibMan.

  ```console
  libman install @aspnet/signalr -p unpkg -d wwwroot/lib/signalr --files dist/browser/signalr.js --files dist/browser/signalr.min.js
  ```

  The parameters specify the following options:
  * Use the unpkg provider.
  * Copy files to the *wwwroot/lib/signalr* destination.
  * Copy only the specified files.

  The output looks like the following example:

  ```console
  wwwroot/lib/signalr/dist/browser/signalr.js written to disk
  wwwroot/lib/signalr/dist/browser/signalr.min.js written to disk
  Installed library "@aspnet/signalr@1.0.3" to "wwwroot/lib/signalr"
  ```

---

## Create a SignalR hub

A *hub* is a class that serves as a high-level pipeline that handles client-server communication.

* In the SignalRChat project folder, create a *Hubs* folder.

* In the *Hubs* folder, create a *ChatHub.cs* file with the following code:

  [!code-csharp[Startup](signalr/sample/Hubs/ChatHub.cs)]

  The `ChatHub` class inherits from the SignalR `Hub` class. The `Hub` class manages connections, groups, and messaging.

  The `SendMessage` method can be called by any connected client. It sends the received message to all clients. SignalR code is asynchronous to provide maximum scalability.

## Configure SignalR

The SignalR server must be configured to pass SignalR requests to SignalR.

* Add the following highlighted code to the *Startup.cs* file.

  [!code-csharp[Startup](signalr/sample/Startup.cs?highlight=7,33,52-55)]

  These changes add SignalR to the ASP.NET Core dependency injection system and the middleware pipeline.

## Add SignalR client code

* Replace the content in *Pages\Index.cshtml* with the following code:

  [!code-cshtml[Index](signalr/sample/Pages/Index.cshtml)]

  The preceding code:

  * Creates text boxes for name and message text, and a submit button.
  * Creates a list with `id="messagesList"` for displaying messages that are received from the SignalR hub.
  * Includes script references to SignalR and the *chat.js* application code that you create in the next step.

* In the *wwwroot/js* folder, create a *chat.js* file with the following code:

  [!code-javascript[Index](signalr/sample/wwwroot/js/chat.js)]

  The preceding code:

  * Creates and starts a connection.
  * Adds to the submit button a handler that sends messages to the hub.
  * Adds to the connection object a handler that receives messages from the hub and adds them to the list.

## Run the app

# [Visual Studio](#tab/visual-studio)

* Press **CTRL+F5** to run the app without debugging.

# [Visual Studio Code](#tab/visual-studio-code)

* In the integrated terminal, run the following command:

  ```console
  dotnet run -p SignalRChat.csproj
  ```
  
# [Visual Studio for Mac](#tab/visual-studio-mac)

* From the menu, select **Run > Start Without Debugging**.

---

* Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

* Choose either browser, enter a name and message, and select the **Send Message** button.

  The name and message are displayed on both pages instantly.

  ![SignalR sample app](signalr/_static/signalr-get-started-finished.png)

> [!TIP]
> If the app doesn't work, open your browser developer tools (F12) and go to the console. You might see errors related to your HTML and JavaScript code. For example, suppose you put *signalr.js* in a different folder than directed. In that case the reference to that file won't work and you'll see a 404 error in the console.
> ![signalr.js not found error](signalr/_static/f12-console.png)

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a web app project.
> * Add the SignalR client library.
> * Create a SignalR hub.
> * Configure the project to use SignalR.
> * Add code that uses the hub to send messages from any client to all connected clients.

To learn more about SignalR, see the introduction:

> [!div class="nextstepaction"]
> [Introduction to ASP.NET Core SignalR](xref:signalr/introduction)
