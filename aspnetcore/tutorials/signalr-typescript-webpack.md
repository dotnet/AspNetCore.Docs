---
title: "Tutorial: Get started with ASP.NET Core SignalR using TypeScript and Webpack"
author: ssougnez
description: This tutorial provides a walkthrough of bundling and building an ASP.NET Core SignalR web app using TypeScript and Webpack.
monikerRange: ">= aspnetcore-2.1"
<!-- ms.author: bradyg -->
ms.author: wpickett
ms.custom: mvc, engagement-fy23
ms.date: 11/07/2023
uid: tutorials/signalr-typescript-webpack
---
# Tutorial: Get started with ASP.NET Core SignalR using TypeScript and Webpack

By [Sébastien Sougnez](https://twitter.com/s_sougnez)

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

This tutorial demonstrates using [Webpack](https://webpack.js.org/) in an ASP.NET Core SignalR web app to bundle and build a client written in [TypeScript](https://www.typescriptlang.org/). Webpack enables developers to bundle and build the client-side resources of a web app.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Create an ASP.NET Core SignalR app
> * Configure the SignalR server
> * Configure a build pipeline using Webpack
> * Configure the SignalR TypeScript client
> * Enable communication between the client and the server

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/tutorials/signalr-typescript-webpack/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

* [Node.js](https://nodejs.org/) with [npm](https://www.npmjs.com/)

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-8.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-8.0.md)]

---

## Create the ASP.NET Core web app

# [Visual Studio](#tab/visual-studio)

By default, Visual Studio uses the version of npm found in its installation directory. To configure Visual Studio to look for npm in the `PATH` environment variable:

Launch Visual Studio. At the start window, select **Continue without code**.

1. Navigate to **Tools** > **Options** > **Projects and Solutions** > **Web Package Management** > **External Web Tools**.
1. Select the `$(PATH)` entry from the list. Select the up arrow to move the entry to the second position in the list, and select **OK**:

   ![Visual Studio Configuration](~/tutorials/signalr-typescript-webpack/_static/8.x/signalr-configure-path-visual-studio-v17.8.0.png).

To create a new ASP.NET Core web app:

1. Use the **File** > **New** > **Project** menu option and choose the **ASP.NET Core Empty** template. Select **Next**.
1. Name the project `SignalRWebpack`, and select **Create**.
1. Select `.NET 8.0` from the **Framework** drop-down. Select **Create**.

Add the [Microsoft.TypeScript.MSBuild](https://www.nuget.org/packages/Microsoft.TypeScript.MSBuild/) NuGet package to the project:

1. In **Solution Explorer**, right-click the project node and select **Manage NuGet Packages**. In the **Browse** tab, search for `Microsoft.TypeScript.MSBuild` and then select **Install** on the right to install the package.

Visual Studio adds the NuGet package under the **Dependencies** node in **Solution Explorer**, enabling TypeScript compilation in the project.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following commands in the **Integrated Terminal**:

```dotnetcli
dotnet new web -o SignalRWebpack
code -r SignalRWebpack
```

* The `dotnet new` command creates an empty ASP.NET Core web app in a `SignalRWebpack` directory.
* The `code` command opens the `SignalRWebpack` directory in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

Run the following .NET CLI command in the **Integrated Terminal**:

```dotnetcli
dotnet add package Microsoft.TypeScript.MSBuild
```

The preceding command adds the [Microsoft.TypeScript.MSBuild](https://www.nuget.org/packages/Microsoft.TypeScript.MSBuild/) package, enabling TypeScript compilation in the project.

---

## Configure the server

In this section, you configure the ASP.NET Core web app to send and receive SignalR messages.

1. In `Program.cs`, call <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A>:

   [!code-csharp[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/Program.cs?name=snippet_AddSignalR&highlight=3)]

1. Again, in `Program.cs`, call <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles%2A> and <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>:

   [!code-csharp[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/Program.cs?name=snippet_FilesMiddleware&highlight=3-4)]

   The preceding code allows the server to locate and serve the `index.html` file. The file is served whether the user enters its full URL or the root URL of the web app.

1. Create a new directory named `Hubs` in the project root, `SignalRWebpack/`, for the SignalR hub class.

1. Create a new file, `Hubs/ChatHub.cs`, with the following code:

   [!code-csharp[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/Hubs/ChatHub.cs)]

   The preceding code broadcasts received messages to all connected users once the server receives them. It's unnecessary to have a generic `on` method to receive all the messages. A method named after the message name is enough.

   In this example:

   * The TypeScript client sends a message identified as `newMessage`.
   * The C# `NewMessage` method expects the data sent by the client.
   * A call is made to <xref:Microsoft.AspNetCore.SignalR.ClientProxyExtensions.SendAsync%2A> on [Clients.All](xref:Microsoft.AspNetCore.SignalR.IHubClients%601.All).
   * The received messages are sent to all clients connected to the hub.

1. Add the following `using` statement at the top of `Program.cs` to resolve the `ChatHub` reference:

   [!code-csharp[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/Program.cs?name=snippet_HubsNamespace)]

1. In `Program.cs`, map the `/hub` route to the `ChatHub` hub. Replace the code that displays `Hello World!` with the following code:

   [!code-csharp[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/Program.cs?name=snippet_MapHub)]

## Configure the client

In this section, you create a [Node.js](https://nodejs.org/) project to convert TypeScript to JavaScript and bundle client-side resources, including HTML and CSS, using Webpack.

1. Run the following command in the project root to create a `package.json` file:

   ```console
   npm init -y
   ```

1. Add the highlighted property to the `package.json` file and save the file changes:

   [!code-json[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples_snapshot/8.x/package.json?highlight=4)]

   Setting the `private` property to `true` prevents package installation warnings in the next step.

1. Install the required npm packages. Run the following command from the project root:

    ```console
    npm i -D -E clean-webpack-plugin css-loader html-webpack-plugin mini-css-extract-plugin ts-loader typescript webpack webpack-cli
    ```

    The `-E` option disables npm's default behavior of writing [semantic versioning](https://semver.org/) range operators to `package.json`. For example, `"webpack": "5.76.1"` is used instead of `"webpack": "^5.76.1"`. This option prevents unintended upgrades to newer package versions.

    For more information, see the [npm-install](https://docs.npmjs.com/cli/install) documentation.

1. Replace the `scripts` property of `package.json` file with the following code:

   [!code-json[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/package.json?range=7-11)]

   The following scripts are defined:

   * `build`: Bundles the client-side resources in development mode and watches for file changes. The file watcher causes the bundle to regenerate each time a project file changes. The `mode` option disables production optimizations, such as tree shaking and minification. use `build` in development only.
   * `release`: Bundles the client-side resources in production mode.
   * `publish`: Runs the `release` script to bundle the client-side resources in production mode. It calls the .NET CLI's [publish](/dotnet/core/tools/dotnet-publish) command to publish the app.

1. Create a file named `webpack.config.js` in the project root, with the following code:

   [!code-javascript[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/webpack.config.js)]

   The preceding file configures the Webpack compilation process:

   * The `output` property overrides the default value of `dist`. The bundle is instead emitted in the `wwwroot` directory.
   * The `resolve.extensions` array includes `.js` to import the SignalR client JavaScript.

1. Create a new directory named `src` in the project root, `SignalRWebpack/`, for the client code.
   
1. Copy the `src` directory and its contents from the [sample project](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/) into the project root. The `src` directory contains the following files:

   * `index.html`, which defines the homepage's boilerplate markup:

      [!code-html[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/src/index.html)]

   * `css/main.css`, which provides CSS styles for the homepage:

      [!code-css[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/src/css/main.css)]

   * `tsconfig.json`, which configures the TypeScript compiler to produce [ECMAScript](https://wikipedia.org/wiki/ECMAScript) 5-compatible JavaScript:

      [!code-json[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/src/tsconfig.json)]

   * `index.ts`:

      [!code-typescript[](~/../AspNetCore.Docs.Samples/tutorials/signalr-typescript-webpack/samples/8.x/SignalRWebpack/src/index.ts)]

      The preceding code retrieves references to DOM elements and attaches two event handlers:

      * `keyup`: Fires when the user types in the `tbMessage` textbox and calls the `send` function when the user presses the **Enter** key.
      * `click`: Fires when the user selects the **Send** button and calls `send` function is called.

      The `HubConnectionBuilder` class creates a new builder for configuring the server connection. The `withUrl` function configures the hub URL.

      SignalR enables the exchange of messages between a client and a server. Each message has a specific name. For example, messages with the name `messageReceived` can run the logic responsible for displaying the new message in the messages zone. Listening to a specific message can be done via the `on` function. Any number of message names can be listened to. It's also possible to pass parameters to the message, such as the author's name and the content of the message received. Once the client receives a message, a new `div` element is created with the author's name and the message content in its `innerHTML` attribute. It's added to the main `div` element displaying the messages.

      Sending a message through the WebSockets connection requires calling the `send` method. The method's first parameter is the message name. The message data inhabits the other parameters. In this example, a message identified as `newMessage` is sent to the server. The message consists of the username and the user input from a text box. If the send works, the text box value is cleared.

1. Run the following command at the project root:

   ```console
   npm i @microsoft/signalr @types/node
   ```

   The preceding command installs:

   * The [SignalR TypeScript client](https://www.npmjs.com/package/@microsoft/signalr), which allows the client to send messages to the server.
   * The TypeScript type definitions for Node.js, which enables compile-time checking of Node.js types.

## Test the app

Confirm that the app works with the following steps:

# [Visual Studio](#tab/visual-studio)

1. Run Webpack in `release` mode. Using the **Package Manager Console** window, run the following command in the project root.

   [!INCLUDE [npm-run-release](~/includes/signalr-typescript-webpack/npm-run-release.md)]

1. Select **Debug** > **Start without debugging** to launch the app in a browser without attaching the debugger. The `wwwroot/index.html` file is served at `https://localhost:<port>`.

   If there are compile errors, try closing and reopening the solution.

1. Open another browser instance (any browser) and paste the URL in the address bar.

1. Choose either browser, type something in the **Message** text box, and select the **Send** button. The unique user name and message are displayed on both pages instantly.

# [Visual Studio Code](#tab/visual-studio-code)

1. Run Webpack in `release` mode by executing the following command in the project root:

   [!INCLUDE [npm-run-release](~/includes/signalr-typescript-webpack/npm-run-release.md)]

1. Build and run the app by executing the following command in the project root:

   ```dotnetcli
   dotnet run
   ```

   The web server starts the app and makes it available on localhost.

1. Open a browser to `https://localhost:<port>`. The `wwwroot/index.html` file is served. Copy the URL from the address bar.

1. Open another browser instance (any browser). Paste the URL in the address bar.

1. Choose either browser, type something in the **Message** text box, and select the **Send** button. The unique user name and message are displayed on both pages instantly.

---

![Message displayed in both browser windows](~/tutorials/signalr-typescript-webpack/_static/browsers-message-broadcast.png)

## Next steps

* [Strongly typed hubs](xref:signalr/hubs#strongly-typed-hubs)
* [Authentication and authorization in ASP.NET Core SignalR](xref:signalr/authn-and-authz)
* [MessagePack Hub Protocol in SignalR for ASP.NET Core](xref:signalr/messagepackhubprotocol)

## Additional resources

* <xref:signalr/javascript-client>
* <xref:signalr/hubs>

:::moniker-end

[!INCLUDE[](~/tutorials/signalr-typescript-webpack/includes/signalr-typescript-webpack7.md)]

[!INCLUDE[](~/tutorials/signalr-typescript-webpack/includes/signalr-typescript-webpack6.md)]

[!INCLUDE[](~/tutorials/signalr-typescript-webpack/includes/signalr-typescript-webpack2.1-5.md)]
