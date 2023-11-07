---
title: Get started with ASP.NET Core SignalR
author: bradygaster
description: In this tutorial, you create a chat app that uses ASP.NET Core SignalR.
<!-- ms.author: bradyg -->
ms.author: wpickett
monikerRange: '>= aspnetcore-3.1'
ms.custom: mvc, engagement-fy23
ms.date: 11/06/2023
uid: tutorials/signalr

# Customer intent: As a developer, I want to get a quick proof-of-concept app running, so I can get a practical introduction to ASP.NET Core SignalR.
---

# Tutorial: Get started with ASP.NET Core SignalR

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

This tutorial teaches the basics of building a real-time app using SignalR. You learn how to:

> [!div class="checklist"]
> * Create a web project.
> * Add the SignalR client library.
> * Create a SignalR hub.
> * Configure the project to use SignalR.
> * Add code that sends messages from any client to all connected clients.

At the end, you'll have a working chat app:

![SignalR sample app](~/tutorials/signalr/_static/7.x/signalr-get-started-finished.png)

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-8.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-8.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-8.0.md)]

---

## Create a web app project

# [Visual Studio](#tab/visual-studio)

Start Visual Studio 2022 and select **Create a new project**.

![Create a new project from the start window](~/tutorials/signalr/_static/8.x/start-window-create-new-project-vs17.8.0.png)

In the **Create a new project** dialog, select **ASP.NET Core Web App**, and then select **Next**.

![Create an ASP.NET Core Web App](~/tutorials/signalr/_static/8.x/new-project-select-vs17.8.0.png)

In the **Configure your new project** dialog, enter `SignalRChat` for **Project name**. It's important to name the project `SignalRChat`, including matching the capitalization, so the namespaces match the code in the tutorial.

Select **Next**.

In the **Additional information** dialog, select **.NET 8.0** and then select **Create**.

![Additional information](~/tutorials/signalr/_static/8.x/additional-info-vs17.8.0.png)

# [Visual Studio Code](#tab/visual-studio-code)

The tutorial assumes familiarity with VS Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs)

* Select **New Terminal** from the **Terminal** menu to open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change to the directory (`cd`) that will contain the project.
* Run the following commands:

```dotnetcli
dotnet new webapp -o SignalRChat
code -r SignalRChat
```

The `dotnet new` command creates a new Razor Pages project in the `SignalRChat` folder.

The `code` command opens the `SignalRChat1 folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

Select **File** > **New Project**.

![macOS New solution](~/tutorials/signalr/_static/7.x/new_project_vsmac.png)

In Visual Studio 2022 for Mac select **Web and Console** > **App** > **Web Application** > **Continue**.

![macOS web app template selection](~/tutorials/signalr/_static/7.x/web_app_template_vsmac.png)

In the **Configure your new Web Application** dialog:

* Confirm that **Authentication** is set to **No Authentication**.
* Confirm that **Target framework** is set to the latest .NET 7.x version.
* Select **Continue**.

Name the project `SignalRChat` and select **Continue**.

---

## Add the SignalR client library

The SignalR server library is included in the ASP.NET Core shared framework. The JavaScript client library isn't automatically included in the project. For this tutorial, use Library Manager (LibMan) to get the client library from [unpkg](https://unpkg.com/). `unpkg`is a fast, global content delivery network for everything on [npm](https://www.npmjs.com/).

# [Visual Studio](#tab/visual-studio/)

In **Solution Explorer**, right-click the project, and select **Add** > **Client-Side Library**.

In the **Add Client-Side Library** dialog:

* Select **unpkg** for **Provider**
* Enter `@microsoft/signalr@latest` for **Library**.
* Select **Choose specific files**, expand the *dist/browser* folder, and select `signalr.js` and `signalr.min.js`.
* Set **Target Location** to `wwwroot/js/signalr/`.
* Select **Install**.

![Add Client-Side Library dialog - select library](~/tutorials/signalr/_static/8.x/find-signalr-client-libs-select-files-vs17.8.0.png)

LibMan creates a `wwwroot/js/signalr` folder and copies the selected files to it.

# [Visual Studio Code](#tab/visual-studio-code/)

In the integrated terminal, run the following commands to install LibMan after uninstalling any previous version, if one exists.

```dotnetcli
dotnet tool uninstall -g Microsoft.Web.LibraryManager.Cli
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

Navigate to the project folder, which contains the `SignalRChat.csproj` file.

Run the following command to get the SignalR client library by using LibMan. It may take a few seconds before displaying output.

```console
libman install @microsoft/signalr@latest -p unpkg -d wwwroot/js/signalr --files dist/browser/signalr.js
```

The parameters specify the following options:

* Use the unpkg provider.
* Copy files to the `wwwroot/js/signalr` destination.
* Copy only the specified files.

The output looks similar to the following:

```console
Downloading file https://unpkg.com/@microsoft/signalr@latest/dist/browser/signalr.js...
wwwroot/js/signalr/dist/browser/signalr.js written to disk
Installed library "@microsoft/signalr@latest" to "wwwroot/js/signalr"
```

# [Visual Studio for Mac](#tab/visual-studio-mac)

In the **Terminal**, run the following commands to install LibMan after uninstalling any previous version, if one exists.

```dotnetcli
dotnet tool uninstall -g Microsoft.Web.LibraryManager.Cli
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

Navigate to the project folder, which contains the `SignalRChat.csproj` file.

Run the following command to get the SignalR client library by using LibMan:

```console
libman install @microsoft/signalr@latest -p unpkg -d wwwroot/js/signalr --files dist/browser/signalr.js --files dist/browser/signalr.js
```

The parameters specify the following options:

* Use the unpkg provider.
* Copy files to the `wwwroot/js/signalr` destination.
* Copy only the specified files.

The output looks like the following example:

```console
wwwroot/js/signalr/dist/browser/signalr.js written to disk
wwwroot/js/signalr/dist/browser/signalr.js written to disk
Installed library "@microsoft/signalr@latest" to "wwwroot/js/signalr"
```

---

## Create a SignalR hub

A *hub* is a class that serves as a high-level pipeline that handles client-server communication.

In the SignalRChat project folder, create a `Hubs` folder.

In the `Hubs` folder, create the `ChatHub` class with the following code:

[!code-csharp[ChatHub](~/tutorials/signalr/samples/8.x/SignalRChat/Hubs/ChatHub.cs)]

The `ChatHub` class inherits from the SignalR <xref:Microsoft.AspNetCore.SignalR.Hub> class. The `Hub` class manages connections, groups, and messaging.

The `SendMessage` method can be called by a connected client to send a message to all clients. JavaScript client code that calls the method is shown later in the tutorial. SignalR code is asynchronous to provide maximum scalability.

## Configure SignalR

The SignalR server must be configured to pass SignalR requests to SignalR. Add the following highlighted code to the `Program.cs` file.

[!code-csharp[Startup](~/tutorials/signalr/samples/8.x/SignalRChat/Program.cs?highlight=1,7,27)]

The preceding highlighted code adds SignalR to the ASP.NET Core dependency injection and routing systems.

## Add SignalR client code

Replace the content in `Pages/Index.cshtml` with the following code:

[!code-cshtml[Index](~/tutorials/signalr/samples/8.x/SignalRChat/Pages/Index.cshtml)]

The preceding markup:

* Creates text boxes and a submit button.
* Creates a list with `id="messagesList"` for displaying messages that are received from the SignalR hub.
* Includes script references to SignalR and the `chat.js` app code is created in the next step.

In the `wwwroot/js` folder, create a `chat.js` file with the following code:

[!code-javascript[chat](~/tutorials/signalr/samples/8.x/SignalRChat/wwwroot/js/chat.js)]

The preceding JavaScript:

* Creates and starts a connection.
* Adds to the submit button a handler that sends messages to the hub.
* Adds to the connection object a handler that receives messages from the hub and adds them to the list.

## Run the app

# [Visual Studio](#tab/visual-studio)

Select <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app without debugging.

# [Visual Studio Code](#tab/visual-studio-code)

Select <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app without debugging.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Select **Debug** > **Start Without Debugging** to run the app without debugging.

---

Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

Choose either browser, enter a name and message, and select the **Send Message** button.

The name and message are displayed on both pages instantly.

![Completed SignalR sample app](~/tutorials/signalr/_static/7.x/signalr-get-started-finished.png)

> [!TIP]
> If the app doesn't work, open the browser developer tools (F12) and go to the console. Look for possible errors related to HTML and JavaScript code. For example, if `signalr.js` was put in a different folder than directed, the reference to that file won't work resulting in a 404 error in the console.
> ![signalr.js not found error](~/tutorials/signalr/_static/7.x/f12-console.png)
> If an `ERR_SPDY_INADEQUATE_TRANSPORT_SECURITY` error has occurred in Chrome, run the following commands to update the development certificate:
>
> ```dotnetcli
> dotnet dev-certs https --clean
> dotnet dev-certs https --trust
> ```

## Publish to Azure

For information on deploying to Azure, see [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore). For more information on Azure SignalR Service, see [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview).

## Next steps

* [Use hubs](xref:signalr/hubs)
* [Strongly typed hubs](xref:signalr/hubs#strongly-typed-hubs)
* [Authentication and authorization in ASP.NET Core SignalR](xref:signalr/authn-and-authz)
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/javascript-client/samples) ([how to download](xref:index#how-to-download-a-sample))

:::moniker-end

[!INCLUDE[](~/tutorials/signalr/includes/signalr7.md)]

[!INCLUDE[](~/tutorials/signalr/includes/signalr6.md)]

[!INCLUDE[](~/tutorials/signalr/includes/signalr3-5.md)]
