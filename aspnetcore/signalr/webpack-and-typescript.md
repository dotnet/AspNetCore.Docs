---
title: Use ASP.NET Core SignalR with TypeScript and Webpack
author: ssougnez
description: Learn how to bundle an ASP.NET Core SignalR web app using TypeScript and Webpack.
monikerRange: '>= aspnetcore-2.1'
ms.author: scaddie
ms.custom: mvc
ms.date: 06/26/2018
uid: signalr/webpack-and-typescript
---
# Use ASP.NET Core SignalR with TypeScript and Webpack

By [Sébastien Sougnez](https://twitter.com/ssougnez) and [Scott Addie](https://twitter.com/Scott_Addie)

[Webpack](https://webpack.js.org/) enables developers to easily bundle the client-side resources of a web app. This tutorial uses Webpack to bundle an ASP.NET Core SignalR app whose client is written in TypeScript.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/signalr/webpack-and-typescript/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Prerequisites

Install the following software:

# [Visual Studio](#tab/visual-studio)

* [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download/all)
* [Visual Studio 2017](https://www.visualstudio.com/downloads/) version 15.7 or later with the **ASP.NET and web development** workload
* [Node.js](https://nodejs.org/) with npm

# [Visual Studio Code](#tab/visual-studio-code)

* [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download/all)
* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# extension for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* [Node.js](https://nodejs.org/) with npm

---

## Create the ASP.NET Core web app

# [Visual Studio](#tab/visual-studio)

Configure Visual Studio to look for npm in the *PATH* environment variable. By default, Visual Studio uses the version of npm in its installation directory. Follow these instructions in Visual Studio:

1. Navigate to **Tools** > **Options** > **Projects and solutions** > **Web Package Management** > **External Web Tools**.
1. Select the *$(PATH)* entry from the list. Click the up arrow to move the entry to the second position in the list. As an aside, the first entry refers to the project's local packages.

    ![Visual Studio Configuration](webpack-and-typescript/_static/signalr-configure-path-visual-studio.png)

Visual Studio configuration is completed. It's time to create the project.

1. Use the **File** > **New** > **Project** menu option and choose the **ASP.NET Core Web Application** template.
1. Name the project *SignalRWebPack*, and click the **OK** button.
1. Select *.NET Core* from the target framework drop-down, and select *ASP.NET Core 2.1* from the framework selector drop-down. Select the **Empty** template, and click the **OK** button.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following command in the **Integrated Terminal**:

```console
dotnet new web -o SignalRWebPack
```

---

## Configure Webpack and TypeScript

To bundle the client-side resources (stylesheets, images, and TypeScript), use the following steps.

1. Execute the following command in the project root to create a *package.json* file:

    ```console
    npm init -y
    ```

1. Add the highlighted property to the *package.json* file. It prevents package installation warnings in the next step.

    [!code-json[package.json](webpack-and-typescript/sample/snippets/package1.json?highlight=4)]

1. Install the required npm packages. Execute the following command from the project root:

    ```console
    npm install -D clean-webpack-plugin css-loader html-webpack-plugin mini-css-extract-plugin ts-loader typescript webpack webpack-cli
    ```

1. Replace the `scripts` property of the *package.json* file with the following:

    ```json
    "scripts": {
      "build": "webpack --mode=development --watch",
      "release": "webpack --mode=production",
      "publish": "npm run release && dotnet publish -c Release"
    },
    ```

    Some explanation of the scripts:

    * `build`: Bundles your client-side resources in development mode and watches for file changes. The file watcher causes the bundle to regenerate each time a project file changes. The `mode` option disables production optimizations, such as tree shaking and minification. Only use this script in development.
    * `release`: Bundles your client-side resources in production mode.
    * `publish`: Runs the `release` script to bundle the client-side resources in production mode. It calls the .NET Core CLI's [publish](/dotnet/core/tools/dotnet-publish) command to publish the app.

1. Create a file named *webpack.config.js*, in the project root, with the following content. Its purpose is to configure the Webpack compilation.

    [!code-javascript[webpack.config.js](webpack-and-typescript/sample/webpack.config.js)]

    Some configuration details to note:

    * The `output` property overrides the default value of *dist*. The bundle is instead emitted in the *wwwroot* directory.
    * The `resolve.extensions` array includes *.js* to import the SignalR client JavaScript.

1. Create a file named *index.html*, in the *src* directory, with the following content. It defines the homepage's HTML template.

    [!code-html[index.html](webpack-and-typescript/sample/src/index.html)]

1. Create a file named *main.css*, in the *src/assets/css* directory, with the following content. It includes CSS classes for the app.

    [!code-css[main.css](webpack-and-typescript/sample/src/assets/css/main.css)]

1. Create a file named *tsconfig.json*, in the project root, with the following content. It configures the TypeScript compiler to produce ECMAScript 5-compatible JavaScript.

    [!code-json[tsconfig.json](webpack-and-typescript/sample/tsconfig.json)]

1. Create a file named *index.ts*, in the *src* directory, with the following content.

    [!code-typescript[index.ts](webpack-and-typescript/sample/snippets/index1.ts?name=snippet_IndexTsPhase1File)]

    The preceding TypeScript retrieves references to DOM elements and attaches two event handlers:

    * `keyup`: This event fires when the user types something in the textbox identified as `tbMessage`. The `send` function is called when the user presses the **Enter** key.
    * `click`: This event fires when the user clicks the **Send** button. The `send` function is called.

## Configure the ASP.NET Core app

1. The code provided in the `Startup.Configure` method displays *Hello World!*. Replace the `app.Run` method call with calls to [UseDefaultFiles](/dotnet/api/microsoft.aspnetcore.builder.defaultfilesextensions.usedefaultfiles#Microsoft_AspNetCore_Builder_DefaultFilesExtensions_UseDefaultFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) and [UseStaticFiles](/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles#Microsoft_AspNetCore_Builder_StaticFileExtensions_UseStaticFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_).

    [!code-csharp[Startup](webpack-and-typescript/sample/Startup.cs?name=snippet_UseStaticDefaultFiles)]

    The preceding code allows the server to locate and serve the *index.html* file, whether the user enters its full URL or the root URL of the web app.

1. Call [AddSignalR](/dotnet/api/microsoft.extensions.dependencyinjection.signalrdependencyinjectionextensions.addsignalr#Microsoft_Extensions_DependencyInjection_SignalRDependencyInjectionExtensions_AddSignalR_Microsoft_Extensions_DependencyInjection_IServiceCollection_) in the `Startup.ConfigureServices` method. It adds the SignalR services to your project.

    [!code-csharp[Startup](webpack-and-typescript/sample/Startup.cs?name=snippet_AddSignalR)]

1. Map a */hub* route to the `ChatHub` hub. Add the following lines at the end of the `Startup.Configure` method:

    [!code-csharp[Startup](webpack-and-typescript/sample/Startup.cs?name=snippet_UseSignalR)]

1. Create a file named *ChatHub.cs* in a new *Hubs* directory. Use the following code to create your hub:

    [!code-csharp[ChatHub](webpack-and-typescript/sample/snippets/ChatHub.cs?name=snippet_ChatHubStubClass)]

1. Add the following code at the top of the *Startup.cs* file to resolve the `ChatHub` reference:

    [!code-csharp[Startup](webpack-and-typescript/sample/Startup.cs?name=snippet_HubsNamespace)]

## Enable client and server communication

Right now, the app displays a simple form to send messages. Nothing happens when you try to do so. The server is listening to a specific route but doesn't do anything with sent messages.

1. Execute the following command at the project root. It installs the [SignalR TypeScript client](https://www.npmjs.com/package/@aspnet/signalr), which allows the client to send messages to the server.

    ```console
    npm install -S @aspnet/signalr
    ```

1. Add the highlighted code to the *src/index.ts* file. This code supports receiving messages from the server.

    [!code-typescript[index.ts](webpack-and-typescript/sample/snippets/index2.ts?name=snippet_IndexTsPhase2File&highlight=2,9-23)]

    In the preceding code, the `HubConnectionBuilder` class creates a new builder for configuring the connection to the server. The `withUrl` function configures the hub URL.

    SignalR enables the exchange of messages between a client and a server. Each message has a specific name. For example, you can have messages with the name `messageReceived` that execute the logic responsible for displaying the new message in the messages zone. Listening to a specific message can be done via the `on` function. You can listen to any number of message names that you want. It's also possible to pass parameters to the message, such as the author's name and the content of the message received. Once the client receives a message, a new `div` element is created with the author's name and the message content in its `innerHTML` property. It's added to the main `div` element displaying the messages.

1. Now that the client can receive a message, configure it to send messages. Add the highlighted code to the *src/index.ts* file:

    [!code-typescript[index.ts](webpack-and-typescript/sample/src/index.ts?highlight=34-35)]

    Sending a message through the WebSockets connection requires calling the `send` method. The method's first parameter is the message name. The message data inhabits the other parameters. So here, you send a `newMessage` message with the username and the content of the "input" to the server. If it works, the "input" value is cleaned.

1. Add the highlighted method to the `ChatHub` class. It broadcasts received messages to all connected users once the server receives them.

    [!code-csharp[ChatHub](webpack-and-typescript/sample/Hubs/ChatHub.cs?highlight=8-11)]

    It's unnecessary to have a generic `on` method to receive all the messages. A method named after the message name suffices.

    In this example, the TypeScript client sends a message identified as `newMessage`. The C# `NewMessage` method expects the data sent by the client. A call is made to the [SendAsync](/dotnet/api/microsoft.aspnetcore.signalr.clientproxyextensions.sendasync) method on [Clients.All](/dotnet/api/microsoft.aspnetcore.signalr.ihubclients-1.all). The received messages are sent to all clients connected to the hub.