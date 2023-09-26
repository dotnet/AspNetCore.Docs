:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

This tutorial demonstrates using [Webpack](https://webpack.js.org/) in an ASP.NET Core SignalR web app to bundle and build a client written in [TypeScript](https://www.typescriptlang.org/). Webpack enables developers to bundle and build the client-side resources of a web app.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Scaffold a starter ASP.NET Core SignalR app
> * Configure the SignalR TypeScript client
> * Configure a build pipeline using Webpack
> * Configure the SignalR server
> * Enable communication between client and server

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/signalr-typescript-webpack/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

# [Visual Studio](#tab/visual-studio)

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the **ASP.NET and web development** workload
* [.NET Core SDK 3.0 or later](https://dotnet.microsoft.com/download/dotnet-core)
* [Node.js](https://nodejs.org/) with [npm](https://www.npmjs.com/)

# [Visual Studio Code](#tab/visual-studio-code)

* [Visual Studio Code](https://code.visualstudio.com/download)
* [.NET Core SDK 3.0 or later](https://dotnet.microsoft.com/download/dotnet-core)
* [C# for Visual Studio Code version 1.17.1 or later](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Node.js](https://nodejs.org/) with [npm](https://www.npmjs.com/)

---

## Create the ASP.NET Core web app

# [Visual Studio](#tab/visual-studio)

Configure Visual Studio to look for npm in the *PATH* environment variable. By default, Visual Studio uses the version of npm found in its installation directory. Follow these instructions in Visual Studio:

1. Launch Visual Studio. At the start window, select **Continue without code**.
1. Navigate to **Tools** > **Options** > **Projects and Solutions** > **Web Package Management** > **External Web Tools**.
1. Select the *$(PATH)* entry from the list. Select the up arrow to move the entry to the second position in the list, and select **OK**.

   ![Visual Studio Configuration](~/tutorials/signalr-typescript-webpack/_static/signalr-configure-path-visual-studio.png).

Visual Studio configuration is complete.

1. Use the **File** > **New** > **Project** menu option and choose the **ASP.NET Core Web Application** template. Select **Next**.
1. Name the project *SignalRWebPac``, and select **Create**.
1. Select *.NET Core* from the target framework drop-down, and select *ASP.NET Core 3.1* from the framework selector drop-down. Select the **Empty** template, and select **Create**.

Add the `Microsoft.TypeScript.MSBuild` package to the project:

1. In **Solution Explorer** (right pane), right-click the project node and select **Manage NuGet Packages**. In the **Browse** tab, search for `Microsoft.TypeScript.MSBuild`, and then click **Install** on the right to install the package.

Visual Studio adds the NuGet package under the **Dependencies** node in **Solution Explorer**, enabling TypeScript compilation in the project.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following command in the **Integrated Terminal**:

```dotnetcli
dotnet new web -o SignalRWebPack
code -r SignalRWebPack
```

* The `dotnet new` command creates an empty ASP.NET Core web app in a `SignalRWebPack` directory.
* The `code` command opens the `SignalRWebPack` folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

Run the following .NET Core CLI command in the **Integrated Terminal**:

```dotnetcli
dotnet add package Microsoft.TypeScript.MSBuild
```

The preceding command adds the [Microsoft.TypeScript.MSBuild](https://www.nuget.org/packages/Microsoft.TypeScript.MSBuild/) package, enabling TypeScript compilation in the project.

---

## Configure Webpack and TypeScript

The following steps configure the conversion of TypeScript to JavaScript and the bundling of client-side resources.

1. Run the following command in the project root to create a `package.json` file:

    ```console
    npm init -y
    ```

1. Add the highlighted property to the `package.json` file and save the file changes:

    [!code-json[](~/tutorials/signalr-typescript-webpack/samples_snapshot/3.x/package1.json?highlight=4)]

    Setting the `private` property to `true` prevents package installation warnings in the next step.

1. Install the required npm packages. Run the following command from the project root:

    ```console
    npm i -D -E clean-webpack-plugin@3.0.0 css-loader@3.4.2 html-webpack-plugin@3.2.0 mini-css-extract-plugin@0.9.0 ts-loader@6.2.1 typescript@3.7.5 webpack@4.41.5 webpack-cli@3.3.10
    ```

    Some command details to note:

    * A version number follows the `@` sign for each package name. npm installs those specific package versions.
    * The `-E` option disables npm's default behavior of writing [semantic versioning](https://semver.org/) range operators to *package`json`. For example, `"webpack": "4.41.5"` is used instead of `"webpack": "^4.41.5"`. This option prevents unintended upgrades to newer package versions.

    See the [npm-install](https://docs.npmjs.com/cli/install) docs for more detail.

1. Replace the `scripts` property of the `package.json` file with the following code:

    ```json
    "scripts": {
      "build": "webpack --mode=development --watch",
      "release": "webpack --mode=production",
      "publish": "npm run release && dotnet publish -c Release"
    },
    ```

    Some explanation of the scripts:

    * `build`: Bundles the client-side resources in development mode and watches for file changes. The file watcher causes the bundle to regenerate each time a project file changes. The `mode` option disables production optimizations, such as tree shaking and minification. Only use `build` in development.
    * `release`: Bundles the client-side resources in production mode.
    * `publish`: Runs the `release` script to bundle the client-side resources in production mode. It calls the .NET Core CLI's [publish](/dotnet/core/tools/dotnet-publish) command to publish the app.

1. Create a file named `webpack.config.js`, in the project root, with the following code:

    [!code-javascript[](~/tutorials/signalr-typescript-webpack/samples/3.x/webpack.config.js)]

    The preceding file configures the Webpack compilation. Some configuration details to note:

    * The `output` property overrides the default value of `dist`. The bundle is instead emitted in the `wwwroot` directory.
    * The `resolve.extensions` array includes `.js` to import the SignalR client JavaScript.

1. Create a new *src* directory in the project root to store the project's client-side assets.

1. Create `src/index.html` with the following markup.

    [!code-html[](~/tutorials/signalr-typescript-webpack/samples/3.x/src/index.html)]

    The preceding HTML defines the homepage's boilerplate markup.

1. Create a new *src/css* directory. Its purpose is to store the project's `.css` files.

1. Create `src/css/main.css` with the following CSS:

    [!code-css[](~/tutorials/signalr-typescript-webpack/samples/3.x/src/css/main.css)]

    The preceding `main.css` file styles the app.

1. Create `src/tsconfig.json` with the following JSON:

    [!code-json[](~/tutorials/signalr-typescript-webpack/samples/3.x/src/tsconfig.json)]

    The preceding code configures the TypeScript compiler to produce [ECMAScript](https://wikipedia.org/wiki/ECMAScript) 5-compatible JavaScript.

1. Create `src/index.ts` with the following code:

    [!code-typescript[](~/tutorials/signalr-typescript-webpack/samples_snapshot/3.x/index1.ts)]

    The preceding TypeScript retrieves references to DOM elements and attaches two event handlers:

    * `keyup`: This event fires when the user types in the `tbMessage`textbox. The `send` function is called when the user presses the **Enter** key.
    * `click`: This event fires when the user selects the **Send** button. The `send` function is called.

## Configure the app

1. In `Startup.Configure`, add calls to <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder)> and <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder)>.

   [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/3.x/Startup.cs?name=snippet_UseStaticDefaultFiles&highlight=9-10)]

   The preceding code allows the server to locate and serve the `index.html` file.  The file is served whether the user enters its full URL or the root URL of the web app.

1. At the end of `Startup.Configure`, map a */hub* route to the `ChatHub` hub. Replace the code that displays *Hello World!* with the following line: 

   [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/3.x/Startup.cs?name=snippet_UseSignalR&highlight=3)]

1. In `Startup.ConfigureServices`, call <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A>.

   [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/3.x/Startup.cs?name=snippet_AddSignalR)]

1. Create a new directory named *Hubs* in the project root *SignalRWebPack/* to store the SignalR hub.

1. Create hub `Hubs/ChatHub.cs` with the following code:

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples_snapshot/3.x/ChatHub.cs)]

1. Add the following `using` statement at the top of the `Startup.cs` file to resolve the `ChatHub` reference:

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/3.x/Startup.cs?name=snippet_HubsNamespace)]

## Enable client and server communication

The app currently displays a basic form to send messages, but isn't yet functional. The server is listening to a specific route but does nothing with sent messages.

1. Run the following command at the project root:

    ```console
    npm i @microsoft/signalr @types/node
    ```

    The preceding command installs:

     * The [SignalR TypeScript client](https://www.npmjs.com/package/@microsoft/signalr), which allows the client to send messages to the server.
     * The TypeScript type definitions for Node.js, which enables compile-time checking of Node.js types.

1. Add the highlighted code to the `src/index.ts` file:

    [!code-typescript[](~/tutorials/signalr-typescript-webpack/samples_snapshot/3.x/index2.ts?highlight=2,9-23)]

    The preceding code supports receiving messages from the server. The `HubConnectionBuilder` class creates a new builder for configuring the server connection. The `withUrl` function configures the hub URL.

    SignalR enables the exchange of messages between a client and a server. Each message has a specific name. For example, messages with the name `messageReceived` can run the logic responsible for displaying the new message in the messages zone. Listening to a specific message can be done via the `on` function. Any number of message names can be listened to. It's also possible to pass parameters to the message, such as the author's name and the content of the message received. Once the client receives a message, a new `div` element is created with the author's name and the message content in its `innerHTML` attribute. It's added to the main `div` element displaying the messages.

1. Now that the client can receive a message, configure it to send messages. Add the highlighted code to the `src/index.ts` file:

    [!code-typescript[](~/tutorials/signalr-typescript-webpack/samples/3.x/src/index.ts?highlight=34-35)]

    Sending a message through the WebSockets connection requires calling the `send` method. The method's first parameter is the message name. The message data inhabits the other parameters. In this example, a message identified as `newMessage` is sent to the server. The message consists of the username and the user input from a text box. If the send works, the text box value is cleared.

1. Add the `NewMessage` method to the `ChatHub` class:

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/3.x/Hubs/ChatHub.cs?highlight=8-11)]

    The preceding code broadcasts received messages to all connected users once the server receives them. It's unnecessary to have a generic `on` method to receive all the messages. A method named after the message name suffices.

    In this example, the TypeScript client sends a message identified as `newMessage`. The C# `NewMessage` method expects the data sent by the client. A call is made to <xref:Microsoft.AspNetCore.SignalR.ClientProxyExtensions.SendAsync%2A> on [Clients.All](xref:Microsoft.AspNetCore.SignalR.IHubClients%601.All). The received messages are sent to all clients connected to the hub.

## Test the app

Confirm that the app works with the following steps.

# [Visual Studio](#tab/visual-studio)

1. Run Webpack in *release* mode. Using the **Package Manager Console** window, run the following command in the project root. If you aren't in the project root, enter `cd SignalRWebPack` before entering the command.

    [!INCLUDE [npm-run-release](~/includes/signalr-typescript-webpack/npm-run-release.md)]

1. Select **Debug** > **Start without debugging** to launch the app in a browser without attaching the debugger. The `wwwroot/index.html` file is served at `http://localhost:<port_number>`.

   If you get compile errors, try closing and reopening the solution. 

1. Open another browser instance (any browser). Paste the URL in the address bar.

1. Choose either browser, type something in the **Message** text box, and select the **Send** button. The unique user name and message are displayed on both pages instantly.

# [Visual Studio Code](#tab/visual-studio-code)

1. Run Webpack in *release* mode by executing the following command in the project root:

    [!INCLUDE [npm-run-release](~/includes/signalr-typescript-webpack/npm-run-release.md)]

1. Build and run the app by executing the following command in the project root:

    ```dotnetcli
    dotnet run
    ```

    The web server starts the app and makes it available on localhost.

1. Open a browser to `http://localhost:<port_number>`. The `wwwroot/index.html` file is served. Copy the URL from the address bar.

1. Open another browser instance (any browser). Paste the URL in the address bar.

1. Choose either browser, type something in the **Message** text box, and select the **Send** button. The unique user name and message are displayed on both pages instantly.

---

![Message displayed in both browser windows](~/tutorials/signalr-typescript-webpack/_static/browsers-message-broadcast.png)

## Additional resources

* <xref:signalr/javascript-client>
* <xref:signalr/hubs>

:::moniker-end

:::moniker range="< aspnetcore-3.0"

This tutorial demonstrates using [Webpack](https://webpack.js.org/) in an ASP.NET Core SignalR web app to bundle and build a client written in [TypeScript](https://www.typescriptlang.org/). Webpack enables developers to bundle and build the client-side resources of a web app.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Scaffold a starter ASP.NET Core SignalR app
> * Configure the SignalR TypeScript client
> * Configure a build pipeline using Webpack
> * Configure the SignalR server
> * Enable communication between client and server

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/signalr-typescript-webpack/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

# [Visual Studio](#tab/visual-studio)

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the **ASP.NET and web development** workload
* [.NET Core SDK 2.2 or later](https://dotnet.microsoft.com/download/dotnet-core)
* [Node.js](https://nodejs.org/) with [npm](https://www.npmjs.com/)

# [Visual Studio Code](#tab/visual-studio-code)

* [Visual Studio Code](https://code.visualstudio.com/download)
* [.NET Core SDK 2.2 or later](https://dotnet.microsoft.com/download/dotnet-core)
* [C# for Visual Studio Code version 1.17.1 or later](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Node.js](https://nodejs.org/) with [npm](https://www.npmjs.com/)

---

## Create the ASP.NET Core web app

# [Visual Studio](#tab/visual-studio)

Configure Visual Studio to look for npm in the *PATH* environment variable. By default, Visual Studio uses the version of npm found in its installation directory. Follow these instructions in Visual Studio:

1. Navigate to **Tools** > **Options** > **Projects and Solutions** > **Web Package Management** > **External Web Tools**.
1. Select the *$(PATH)* entry from the list. Select the up arrow to move the entry to the second position in the list.

   ![Visual Studio Configuration](~/tutorials/signalr-typescript-webpack/_static/signalr-configure-path-visual-studio.png)

Visual Studio configuration is completed. It's time to create the project.

1. Use the **File** > **New** > **Project** menu option and choose the **ASP.NET Core Web Application** template.
1. Name the project *SignalRWebPack`, and select **Create**.
1. Select *.NET Core* from the target framework drop-down, and select *ASP.NET Core 2.2* from the framework selector drop-down. Select the **Empty** template, and select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following command in the **Integrated Terminal**:

```dotnetcli
dotnet new web -o SignalRWebPack
```

An empty ASP.NET Core web app, targeting .NET Core, is created in a `SignalRWebPack` directory.

---

## Configure Webpack and TypeScript

The following steps configure the conversion of TypeScript to JavaScript and the bundling of client-side resources.

1. Run the following command in the project root to create a `package.json` file:

    ```console
    npm init -y
    ```

1. Add the highlighted property to the `package.json` file:

    [!code-json[](~/tutorials/signalr-typescript-webpack/samples_snapshot/2.x/package1.json?highlight=4)]

    Setting the `private` property to `true` prevents package installation warnings in the next step.

1. Install the required npm packages. Run the following command from the project root:

    ```console
    npm install -D -E clean-webpack-plugin@1.0.1 css-loader@2.1.0 html-webpack-plugin@4.0.0-beta.5 mini-css-extract-plugin@0.5.0 ts-loader@5.3.3 typescript@3.3.3 webpack@4.29.3 webpack-cli@3.2.3
    ```

    Some command details to note:

    * A version number follows the `@` sign for each package name. npm installs those specific package versions.
    * The `-E` option disables npm's default behavior of writing [semantic versioning](https://semver.org/) range operators to *package`json`. For example, `"webpack": "4.29.3"` is used instead of `"webpack": "^4.29.3"`. This option prevents unintended upgrades to newer package versions.

    See the [npm-install](https://docs.npmjs.com/cli/install) docs for more detail.

1. Replace the `scripts` property of the `package.json` file with the following code:

    ```json
    "scripts": {
      "build": "webpack --mode=development --watch",
      "release": "webpack --mode=production",
      "publish": "npm run release && dotnet publish -c Release"
    },
    ```

    Some explanation of the scripts:

    * `build`: Bundles the client-side resources in development mode and watches for file changes. The file watcher causes the bundle to regenerate each time a project file changes. The `mode` option disables production optimizations, such as tree shaking and minification. Only use `build` in development.
    * `release`: Bundles the client-side resources in production mode.
    * `publish`: Runs the `release` script to bundle the client-side resources in production mode. It calls the .NET Core CLI's [publish](/dotnet/core/tools/dotnet-publish) command to publish the app.

1. Create a file named`*webpack.config.js` in the project root, with the following code:

    [!code-javascript[](~/tutorials/signalr-typescript-webpack/samples/2.x/webpack.config.js)]

    The preceding file configures the Webpack compilation. Some configuration details to note:

    * The `output` property overrides the default value of `dist`. The bundle is instead emitted in the `wwwroot` directory.
    * The `resolve.extensions` array includes `.js` to import the SignalR client JavaScript.

1. Create a new *src* directory in the project root to store the project's client-side assets.

1. Create `src/index.html` with the following markup.

    [!code-html[](~/tutorials/signalr-typescript-webpack/samples/2.x/src/index.html)]

    The preceding HTML defines the homepage's boilerplate markup.

1. Create a new *src/css* directory. Its purpose is to store the project's `.css` files.

1. Create `src/css/main.css` with the following markup:

    [!code-css[](~/tutorials/signalr-typescript-webpack/samples/2.x/src/css/main.css)]

    The preceding `main.css` file styles the app.

1. Create `src/tsconfig.json` with the following JSON:

    [!code-json[](~/tutorials/signalr-typescript-webpack/samples/2.x/src/tsconfig.json)]

    The preceding code configures the TypeScript compiler to produce [ECMAScript](https://wikipedia.org/wiki/ECMAScript) 5-compatible JavaScript.

1. Create `src/index.ts` with the following code:

    [!code-typescript[](~/tutorials/signalr-typescript-webpack/samples_snapshot/2.x/index1.ts)]

    The preceding TypeScript retrieves references to DOM elements and attaches two event handlers:

    * `keyup`: This event fires when the user types in the `tbMessage` textbox. The `send` function is called when the user presses the **Enter** key.
    * `click`: This event fires when the user selects the **Send** button. The `send` function is called.

## Configure the ASP.NET Core app

1. The code provided in the `Startup.Configure` method displays *Hello World!*. Replace the `app.Run` method call with calls to <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder)> and <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder)>.

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/2.x/Startup.cs?name=snippet_UseStaticDefaultFiles)]

    The preceding code allows the server to locate and serve the `index.html` file, whether the user enters its full URL or the root URL of the web app.

1. Call <xref:Microsoft.Extensions.DependencyInjection.SignalRDependencyInjectionExtensions.AddSignalR%2A> in `Startup.ConfigureServices`. It adds the SignalR services to the project.

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/2.x/Startup.cs?name=snippet_AddSignalR)]

1. Map a */hub* route to the `ChatHub` hub. Add the following lines at the end of `Startup.Configure`:

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/2.x/Startup.cs?name=snippet_UseSignalR)]

1. Create a new directory, called *Hubs*, in the project root. Its purpose is to store the SignalR hub, which is created in the next step.

1. Create hub `Hubs/ChatHub.cs` with the following code:

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples_snapshot/2.x/ChatHub.cs)]

1. Add the following code at the top of the `Startup.cs` file to resolve the `ChatHub` reference:

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/2.x/Startup.cs?name=snippet_HubsNamespace)]

## Enable client and server communication

The app currently displays a simple form to send messages. Nothing happens when you try to do so. The server is listening to a specific route but does nothing with sent messages.

1. Run the following command at the project root:

    ```console
    npm install @aspnet/signalr
    ```

    The preceding command installs the [SignalR TypeScript client](https://www.npmjs.com/package/@microsoft/signalr), which allows the client to send messages to the server.

1. Add the highlighted code to the `src/index.ts` file:

    [!code-typescript[](~/tutorials/signalr-typescript-webpack/samples_snapshot/2.x/index2.ts?highlight=2,9-23)]

    The preceding code supports receiving messages from the server. The `HubConnectionBuilder` class creates a new builder for configuring the server connection. The `withUrl` function configures the hub URL.

    SignalR enables the exchange of messages between a client and a server. Each message has a specific name. For example, messages with the name `messageReceived` can run the logic responsible for displaying the new message in the messages zone. Listening to a specific message can be done via the `on` function. You can listen to any number of message names. It's also possible to pass parameters to the message, such as the author's name and the content of the message received. Once the client receives a message, a new `div` element is created with the author's name and the message content in its `innerHTML` attribute. The new message is added to the main `div` element displaying the messages.

1. Now that the client can receive a message, configure it to send messages. Add the highlighted code to the `src/index.ts` file:

    [!code-typescript[](~/tutorials/signalr-typescript-webpack/samples/2.x/src/index.ts?highlight=34-35)]

    Sending a message through the WebSockets connection requires calling the `send` method. The method's first parameter is the message name. The message data inhabits the other parameters. In this example, a message identified as `newMessage` is sent to the server. The message consists of the username and the user input from a text box. If the send works, the text box value is cleared.

1. Add the `NewMessage` method to the `ChatHub` class:

    [!code-csharp[](~/tutorials/signalr-typescript-webpack/samples/2.x/Hubs/ChatHub.cs?highlight=8-11)]

    The preceding code broadcasts received messages to all connected users once the server receives them. It's unnecessary to have a generic `on` method to receive all the messages. A method named after the message name suffices.

    In this example, the TypeScript client sends a message identified as `newMessage`. The C# `NewMessage` method expects the data sent by the client. A call is made to <xref:Microsoft.AspNetCore.SignalR.ClientProxyExtensions.SendAsync%2A> on [Clients.All](xref:Microsoft.AspNetCore.SignalR.IHubClients%601.All). The received messages are sent to all clients connected to the hub.

## Test the app

Confirm that the app works with the following steps.

# [Visual Studio](#tab/visual-studio)

1. Run Webpack in *release* mode. Using the **Package Manager Console** window, run the following command in the project root. If you aren't in the project root, enter `cd SignalRWebPack` before entering the command.

    [!INCLUDE [npm-run-release](~/includes/signalr-typescript-webpack/npm-run-release.md)]

1. Select **Debug** > **Start without debugging** to launch the app in a browser without attaching the debugger. The `wwwroot/index.html` file is served at `http://localhost:<port_number>`.

1. Open another browser instance (any browser). Paste the URL in the address bar.

1. Choose either browser, type something in the **Message** text box, and select the **Send** button. The unique user name and message are displayed on both pages instantly.

# [Visual Studio Code](#tab/visual-studio-code)

1. Run Webpack in *release* mode by executing the following command in the project root:

    [!INCLUDE [npm-run-release](~/includes/signalr-typescript-webpack/npm-run-release.md)]

1. Build and run the app by executing the following command in the project root:

    ```dotnetcli
    dotnet run
    ```

    The web server starts the app and makes it available on localhost.

1. Open a browser to `http://localhost:<port_number>`. The `wwwroot/index.html` file is served. Copy the URL from the address bar.

1. Open another browser instance (any browser). Paste the URL in the address bar.

1. Choose either browser, type something in the **Message** text box, and select the **Send** button. The unique user name and message are displayed on both pages instantly.

---

![Message displayed in both browser windows](~/tutorials/signalr-typescript-webpack/_static/browsers-message-broadcast.png)

## Additional resources

* <xref:signalr/javascript-client>
* <xref:signalr/hubs>

:::moniker-end
