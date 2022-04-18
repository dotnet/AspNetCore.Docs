---
title: Use ASP.NET Core SignalR with Blazor
author: guardrex
description: Create a chat app that uses ASP.NET Core SignalR with Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/tutorials/signalr-blazor
zone_pivot_groups: blazor-hosting-models
---
# Use ASP.NET Core SignalR with Blazor

This tutorial teaches the basics of building a real-time app using SignalR with Blazor.

:::moniker range=">= aspnetcore-6.0"

Learn how to:

> [!div class="checklist"]
> * Create a Blazor project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

At the end of this tutorial, you'll have a working chat app.

## Prerequisites

# [Visual Studio](#tab/visual-studio)

* [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the **ASP.NET and web development** workload
* [!INCLUDE [.NET Core 6.0 SDK](~/includes/6.0-SDK.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-6.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

* [Visual Studio for Mac 2022 or later](https://visualstudio.microsoft.com/vs/mac/): Select the *Preview* channel from within Visual Studio. For more information, see [Install a preview version of Visual Studio for Mac](/visualstudio/mac/install-preview).
* [!INCLUDE [.NET Core 6.0 SDK](~/includes/6.0-SDK.md)]

# [.NET Core CLI](#tab/netcore-cli/)

[!INCLUDE[](~/includes/6.0-SDK.md)]

---

## Sample app

Downloading the tutorial's sample chat app isn't required for this tutorial. The sample app is the final, working app produced by following the steps of this tutorial.

[View or download sample code](https://github.com/dotnet/blazor-samples)

:::zone pivot="webassembly"

## Create a hosted Blazor WebAssembly app

Follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

> [!NOTE]
> Visual Studio 2022 or later and .NET Core SDK 6.0.0 or later are required.

1. Create a new project.

1. Choose the **Blazor WebAssembly App** template. Select **Next**.

1. Type `BlazorWebAssemblySignalRApp` in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox.

1. Select **Create**.

1. Confirm that a hosted Blazor WebAssembly app was created: In **Solution Explorer**, confirm the presence of a **`Client`** project and a **`Server`** project. If the two projects aren't present, start over and confirm selection of the **ASP.NET Core hosted** checkbox before selecting **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

1. In a command shell, execute the following command:

   ```dotnetcli
   dotnet new blazorwasm -ho -o BlazorWebAssemblySignalRApp
   ```

   The `-ho|--hosted` option creates a hosted Blazor WebAssembly solution. For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

   The `-o|--output` option creates a folder for the solution. If you've created a folder for the solution and the command shell is open in that folder, omit the `-o|--output` option and value to create the solution.

1. In Visual Studio Code, open the app's project folder.

1. Confirm that a hosted Blazor WebAssembly app was created: Confirm the presence of a **`Client`** project and a **`Server`** project in the app's solution folder. If the two projects aren't present, start over and confirm passing the `-ho` or `--hosted` option to the `dotnet new` command when creating the solution.

To configure Visual Studio Code assets in the `.vscode` folder for debugging, see:

* <xref:blazor/tooling?pivots=linux> (use the guidance for the *Linux* operating system regardless of platform)
* <xref:blazor/debug>

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Install the latest version of [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) and perform the following steps.

   Select the *Preview* channel from within Visual Studio. For more information, see [Install a preview version of Visual Studio for Mac](/visualstudio/mac/install-preview).

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

1. Choose the **Blazor WebAssembly App** template. Select **Next**.

1. Confirm that **Authentication** is set to **No Authentication**. Select the **ASP.NET Core Hosted** checkbox. Select **Next**.

1. In the **Project Name** field, name the app `BlazorWebAssemblySignalRApp`. Select **Create**.

   If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate.

1. Open the project by navigating to the project folder and opening the project's solution file (`.sln`).

1. Confirm that a hosted Blazor WebAssembly app was created: In **Solution Explorer**, confirm the presence of a **`Client`** project and a **`Server`** project. If the two projects aren't present, start over and confirm selection of the **ASP.NET Core Hosted** checkbox before selecting **Create**.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following command:

```dotnetcli
dotnet new blazorwasm -ho -o BlazorWebAssemblySignalRApp
```

The `-ho|--hosted` option creates a hosted Blazor WebAssembly solution.

The `-o|--output` option creates a folder for the solution. If you've created a folder for the solution and the command shell is open in that folder, omit the `-o|--output` option and value to create the solution.

Confirm that a hosted Blazor WebAssembly app was created: Confirm the presence of a **`Client`** project and a **`Server`** project in the app's solution folder. If the two projects aren't present, start over and confirm passing the `-ho` or `--hosted` option to the `dotnet new` command when creating the solution.

---

## Add the SignalR client library

# [Visual Studio](#tab/visual-studio/)

1. In **Solution Explorer**, right-click the `BlazorWebAssemblySignalRApp.Client` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Install**.

1. If the **Preview Changes** dialog appears, select **OK**.

1. If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following command:

```dotnetcli
dotnet add Client package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, right-click the `BlazorWebAssemblySignalRApp.Client` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the source drop-down is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the checkbox next to the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Add Package**.

1. If the **License Acceptance** dialog appears, select **Accept** if you agree with the license terms.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the solution's folder, execute the following command:

```dotnetcli
dotnet add Client package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

---

## Add a SignalR hub

In the `BlazorWebAssemblySignalRApp.Server` project, create a `Hubs` (plural) folder and add the following `ChatHub` class (`Hubs/ChatHub.cs`):

[!code-csharp[](signalr-blazor/samples/6.0/BlazorWebAssemblySignalRApp/Server/Hubs/ChatHub.cs)]

## Add services and an endpoint for the SignalR hub

1. In the `BlazorWebAssemblySignalRApp.Server` project, open the `Program.cs` file.

1. Add the namespace for the `ChatHub` class to the top of the file:

   ```csharp
   using BlazorWebAssemblySignalRApp.Server.Hubs;
   ```

1. Add SignalR and Response Compression Middleware services to `Program.cs`:

   [!code-csharp[](signalr-blazor/samples/6.0/BlazorWebAssemblySignalRApp/Server/Program.cs?name=snippet_ConfigureServices)]

1. In `Program.cs`:

   * Use Response Compression Middleware at the top of the processing pipeline's configuration.
   * Between the endpoints for controllers and the client-side fallback, add an endpoint for the hub.

   [!code-csharp[](signalr-blazor/samples/6.0/BlazorWebAssemblySignalRApp/Server/Program.cs?name=snippet_Configure)]

## Add Razor component code for chat

1. In the `BlazorWebAssemblySignalRApp.Client` project, open the `Pages/Index.razor` file.

1. Replace the markup with the following code:

   [!code-razor[](signalr-blazor/samples/6.0/BlazorWebAssemblySignalRApp/Client/Pages/Index.razor)]

## Run the app

Follow the guidance for your tooling:

# [Visual Studio](#tab/visual-studio)

1. In **Solution Explorer**, select the `BlazorWebAssemblySignalRApp.Server` project. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio Code](#tab/visual-studio-code)

For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, select the `BlazorWebAssemblySignalRApp.Server` project. Press <kbd>⌘</kbd>+<kbd>↩</kbd> to run the app with debugging or <kbd>⌥</kbd>+<kbd>⌘</kbd>+<kbd>↩</kbd> to run the app without debugging.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [.NET Core CLI](#tab/netcore-cli/)

1. In a command shell from the solution's folder, execute the following commands:

   ```dotnetcli
   cd Server
   dotnet run
   ```

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

---

:::zone-end

:::zone pivot="server"

## Create a Blazor Server app

Follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

> [!NOTE]
> Visual Studio 2022 or later and .NET Core SDK 6.0.0 or later are required.

1. Create a new project.

1. Select the **Blazor Server App** template. Select **Next**.

1. Type `BlazorServerSignalRApp` in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Next**.

1. Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

1. In a command shell, execute the following command:

   ```dotnetcli
   dotnet new blazorserver -o BlazorServerSignalRApp
   ```

   The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project.

1. In Visual Studio Code, open the app's project folder.

1. When the dialog appears to add assets to build and debug the app, select **Yes**. Visual Studio Code automatically adds the `.vscode` folder with generated `launch.json` and `tasks.json` files. For information on configuring VS Code assets in the `.vscode` folder, including how to manually add the files to the solution, see the **Linux** operating system guidance in <xref:blazor/tooling?pivot=linux>.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Install the latest version of [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) and perform the following steps:

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

1. Choose the **Blazor Server App** template. Select **Next**.

1. Confirm that **Authentication** is set to **No Authentication**. Select **Next**.

1. In the **Project Name** field, name the app `BlazorServerSignalRApp`. Select **Create**.

   If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate.

1. Open the project by navigating to the project folder and opening the project's solution file (`.sln`).

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following command:

```dotnetcli
dotnet new blazorserver -o BlazorServerSignalRApp
```

The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project.

---

## Add the SignalR client library

# [Visual Studio](#tab/visual-studio/)

1. In **Solution Explorer**, right-click the `BlazorServerSignalRApp` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Install**.

1. If the **Preview Changes** dialog appears, select **OK**.

1. If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, right-click the `BlazorServerSignalRApp` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the source drop-down is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the checkbox next to the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Add Package**.

1. If the **License Acceptance** dialog appears, select **Accept** if you agree with the license terms.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the project's folder, execute the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

---

## Add a SignalR hub

Create a `Hubs` (plural) folder and add the following `ChatHub` class (`Hubs/ChatHub.cs`):

[!code-csharp[](signalr-blazor/samples/6.0/BlazorServerSignalRApp/Hubs/ChatHub.cs)]

## Add services and an endpoint for the SignalR hub

1. Open the `Program.cs` file.

1. Add the namespaces for <xref:Microsoft.AspNetCore.ResponseCompression?displayProperty=fullName> and the `ChatHub` class to the top of the file:

   ```csharp
   using Microsoft.AspNetCore.ResponseCompression;
   using BlazorServerSignalRApp.Hubs;
   ```

1. Add Response Compression Middleware services to `Program.cs`:

   [!code-csharp[](signalr-blazor/samples/6.0/BlazorServerSignalRApp/Program.cs?name=snippet_ConfigureServices)]

1. In `Program.cs`:

   * Use Response Compression Middleware at the top of the processing pipeline's configuration.
   * Between the endpoints for mapping the Blazor hub and the client-side fallback, add an endpoint for the hub:

     ```csharp
     app.MapHub<ChatHub>("/chathub");
     ```

   [!code-csharp[](signalr-blazor/samples/6.0/BlazorServerSignalRApp/Program.cs?name=snippet_Configure)]

## Add Razor component code for chat

1. Open the `Pages/Index.razor` file.

1. Replace the markup with the following code:

   [!code-razor[](signalr-blazor/samples/6.0/BlazorServerSignalRApp/Pages/Index.razor)]

## Run the app

Follow the guidance for your tooling:

# [Visual Studio](#tab/visual-studio)

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio Code](#tab/visual-studio-code)

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Press <kbd>⌘</kbd>+<kbd>↩</kbd> to run the app with debugging or <kbd>⌥</kbd>+<kbd>⌘</kbd>+<kbd>↩</kbd> to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [.NET Core CLI](#tab/netcore-cli/)

1. In a command shell from the project's folder, execute the following commands:

   ```dotnetcli
   dotnet run
   ```

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

---

:::zone-end

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a Blazor project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

To learn more about building Blazor apps, see the Blazor documentation:

> [!div class="nextstepaction"]
> <xref:blazor/index>
> [Bearer token authentication with Identity Server, WebSockets, and Server-Sent Events](xref:signalr/authn-and-authz#bearer-token-authentication)

## Additional resources

* <xref:signalr/introduction>
* [SignalR cross-origin negotiation for authentication](xref:blazor/fundamentals/signalr#signalr-cross-origin-negotiation-for-authentication-blazor-webassembly)
* [SignalR configuration](xref:blazor/host-and-deploy/server#signalr-configuration)
* <xref:blazor/debug>
* <xref:blazor/security/server/threat-mitigation>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Learn how to:

> [!div class="checklist"]
> * Create a Blazor project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

At the end of this tutorial, you'll have a working chat app.

## Prerequisites

# [Visual Studio](#tab/visual-studio)

* [Visual Studio 2019 16.10 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the **ASP.NET and web development** workload
* [!INCLUDE [.NET Core 5.0 SDK](~/includes/5.0-SDK.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-5.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

* [Visual Studio for Mac version 8.8 or later](https://visualstudio.microsoft.com/vs/mac/)
* [!INCLUDE [.NET Core 5.0 SDK](~/includes/5.0-SDK.md)]

# [.NET Core CLI](#tab/netcore-cli/)

[!INCLUDE[](~/includes/5.0-SDK.md)]

---

## Sample app

Downloading the tutorial's sample chat app isn't required for this tutorial. The sample app is the final, working app produced by following the steps of this tutorial.

[View or download sample code](https://github.com/dotnet/blazor-samples)

:::zone pivot="webassembly"

## Create a hosted Blazor WebAssembly app

Follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

> [!NOTE]
> Visual Studio 16.10 or later and .NET Core SDK 5.0.0 or later are required.

1. Create a new project.

1. Choose the **Blazor WebAssembly App** template. Select **Next**.

1. Type `BlazorWebAssemblySignalRApp` in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox.

1. Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

1. In a command shell, execute the following command:

   ```dotnetcli
   dotnet new blazorwasm -ho -o BlazorWebAssemblySignalRApp
   ```

   The `-ho|--hosted` option creates a hosted Blazor WebAssembly solution. For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

   The `-o|--output` option creates a folder for the solution. If you've created a folder for the solution and the command shell is open in that folder, omit the `-o|--output` option and value to create the solution.

1. In Visual Studio Code, open the app's project folder.

To configure Visual Studio Code assets in the `.vscode` folder for debugging, see:

* <xref:blazor/tooling?pivots=linux> (use the guidance for the *Linux* operating system regardless of platform)
* <xref:blazor/debug>

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Install the latest version of [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) and perform the following steps:

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

1. Choose the **Blazor WebAssembly App** template. Select **Next**.

1. Confirm that **Authentication** is set to **No Authentication**. Select the **ASP.NET Core Hosted** checkbox. Select **Next**.

1. In the **Project Name** field, name the app `BlazorWebAssemblySignalRApp`. Select **Create**.

   If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate.

1. Open the project by navigating to the project folder and opening the project's solution file (`.sln`).

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following command:

```dotnetcli
dotnet new blazorwasm -ho -o BlazorWebAssemblySignalRApp
```

The `-ho|--hosted` option creates a hosted Blazor WebAssembly solution.

The `-o|--output` option creates a folder for the solution. If you've created a folder for the solution and the command shell is open in that folder, omit the `-o|--output` option and value to create the solution.

---

## Add the SignalR client library

# [Visual Studio](#tab/visual-studio/)

1. In **Solution Explorer**, right-click the `BlazorWebAssemblySignalRApp.Client` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Install**.

1. If the **Preview Changes** dialog appears, select **OK**.

1. If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following command:

```dotnetcli
dotnet add Client package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, right-click the `BlazorWebAssemblySignalRApp.Client` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the source drop-down is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the checkbox next to the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Add Package**.

1. If the **License Acceptance** dialog appears, select **Accept** if you agree with the license terms.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the solution's folder, execute the following command:

```dotnetcli
dotnet add Client package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

---

## Add a SignalR hub

In the `BlazorWebAssemblySignalRApp.Server` project, create a `Hubs` (plural) folder and add the following `ChatHub` class (`Hubs/ChatHub.cs`):

[!code-csharp[](signalr-blazor/samples/5.0/BlazorWebAssemblySignalRApp/Server/Hubs/ChatHub.cs)]

## Add services and an endpoint for the SignalR hub

1. In the `BlazorWebAssemblySignalRApp.Server` project, open the `Startup.cs` file.

1. Add the namespace for the `ChatHub` class to the top of the file:

   ```csharp
   using BlazorWebAssemblySignalRApp.Server.Hubs;
   ```

1. Add SignalR and Response Compression Middleware services to `Startup.ConfigureServices`:

   [!code-csharp[](signalr-blazor/samples/5.0/BlazorWebAssemblySignalRApp/Server/Startup.cs?name=snippet_ConfigureServices&highlight=3,6-10)]

1. In `Startup.Configure`:

   * Use Response Compression Middleware at the top of the processing pipeline's configuration.
   * Between the endpoints for controllers and the client-side fallback, add an endpoint for the hub.

   [!code-csharp[](signalr-blazor/samples/5.0/BlazorWebAssemblySignalRApp/Server/Startup.cs?name=snippet_Configure&highlight=3,26)]

## Add Razor component code for chat

1. In the `BlazorWebAssemblySignalRApp.Client` project, open the `Pages/Index.razor` file.

1. Replace the markup with the following code:

   [!code-razor[](signalr-blazor/samples/5.0/BlazorWebAssemblySignalRApp/Client/Pages/Index.razor)]

## Run the app

Follow the guidance for your tooling:

# [Visual Studio](#tab/visual-studio)

1. In **Solution Explorer**, select the `BlazorWebAssemblySignalRApp.Server` project. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio Code](#tab/visual-studio-code)

For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, select the `BlazorWebAssemblySignalRApp.Server` project. Press <kbd>⌘</kbd>+<kbd>↩</kbd> to run the app with debugging or <kbd>⌥</kbd>+<kbd>⌘</kbd>+<kbd>↩</kbd> to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [.NET Core CLI](#tab/netcore-cli/)

1. In a command shell from the solution's folder, execute the following commands:

   ```dotnetcli
   cd Server
   dotnet run
   ```

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

---

:::zone-end

:::zone pivot="server"

## Create a Blazor Server app

Follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

> [!NOTE]
> Visual Studio 16.10 or later and .NET Core SDK 5.0.0 or later are required.

1. Create a new project.

1. Select the **Blazor Server App** template. Select **Next**.

1. Type `BlazorServerSignalRApp` in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Next**.

1. Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

1. In a command shell, execute the following command:

   ```dotnetcli
   dotnet new blazorserver -o BlazorServerSignalRApp
   ```

   The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project.

1. In Visual Studio Code, open the app's project folder.

1. When the dialog appears to add assets to build and debug the app, select **Yes**. Visual Studio Code automatically adds the `.vscode` folder with generated `launch.json` and `tasks.json` files. For information on configuring VS Code assets in the `.vscode` folder, including how to manually add the files to the solution, see the **Linux** operating system guidance in <xref:blazor/tooling?pivot=linux>.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Install the latest version of [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) and perform the following steps:

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

1. Choose the **Blazor Server App** template. Select **Next**.

1. Confirm that **Authentication** is set to **No Authentication**. Select **Next**.

1. In the **Project Name** field, name the app `BlazorServerSignalRApp`. Select **Create**.

   If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate.

1. Open the project by navigating to the project folder and opening the project's solution file (`.sln`).

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following command:

```dotnetcli
dotnet new blazorserver -o BlazorServerSignalRApp
```

The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project.

---

## Add the SignalR client library

# [Visual Studio](#tab/visual-studio/)

1. In **Solution Explorer**, right-click the `BlazorServerSignalRApp` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Install**.

1. If the **Preview Changes** dialog appears, select **OK**.

1. If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, right-click the `BlazorServerSignalRApp` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the source drop-down is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the checkbox next to the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Add Package**.

1. If the **License Acceptance** dialog appears, select **Accept** if you agree with the license terms.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the project's folder, execute the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

---

## Add a SignalR hub

Create a `Hubs` (plural) folder and add the following `ChatHub` class (`Hubs/ChatHub.cs`):

[!code-csharp[](signalr-blazor/samples/5.0/BlazorServerSignalRApp/Hubs/ChatHub.cs)]

## Add services and an endpoint for the SignalR hub

1. Open the `Startup.cs` file.

1. Add the namespaces for <xref:Microsoft.AspNetCore.ResponseCompression?displayProperty=fullName> and the `ChatHub` class to the top of the file:

   ```csharp
   using Microsoft.AspNetCore.ResponseCompression;
   using BlazorServerSignalRApp.Server.Hubs;
   ```

1. Add Response Compression Middleware services to `Startup.ConfigureServices`:

   [!code-csharp[](signalr-blazor/samples/5.0/BlazorServerSignalRApp/Startup.cs?name=snippet_ConfigureServices&highlight=6-10)]

1. In `Startup.Configure`:

   * Use Response Compression Middleware at the top of the processing pipeline's configuration.
   * Between the endpoints for mapping the Blazor hub and the client-side fallback, add an endpoint for the hub.

   [!code-csharp[](signalr-blazor/samples/5.0/BlazorServerSignalRApp/Startup.cs?name=snippet_Configure&highlight=3,23)]

## Add Razor component code for chat

1. Open the `Pages/Index.razor` file.

1. Replace the markup with the following code:

   [!code-razor[](signalr-blazor/samples/5.0/BlazorServerSignalRApp/Pages/Index.razor)]

## Run the app

Follow the guidance for your tooling:

# [Visual Studio](#tab/visual-studio)

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio Code](#tab/visual-studio-code)

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Press <kbd>⌘</kbd>+<kbd>↩</kbd> to run the app with debugging or <kbd>⌥</kbd>+<kbd>⌘</kbd>+<kbd>↩</kbd> to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [.NET Core CLI](#tab/netcore-cli/)

1. In a command shell from the project's folder, execute the following commands:

   ```dotnetcli
   dotnet run
   ```

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

---

:::zone-end

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a Blazor project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

To learn more about building Blazor apps, see the Blazor documentation:

> [!div class="nextstepaction"]
> <xref:blazor/index>
> [Bearer token authentication with Identity Server, WebSockets, and Server-Sent Events](xref:signalr/authn-and-authz#bearer-token-authentication)

## Additional resources

* <xref:signalr/introduction>
* [SignalR cross-origin negotiation for authentication](xref:blazor/fundamentals/signalr#signalr-cross-origin-negotiation-for-authentication-blazor-webassembly)
* [SignalR configuration](xref:blazor/host-and-deploy/server#signalr-configuration)
* <xref:blazor/debug>
* <xref:blazor/security/server/threat-mitigation>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Learn how to:

> [!div class="checklist"]
> * Create a Blazor project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

At the end of this tutorial, you'll have a working chat app.

## Prerequisites

# [Visual Studio](#tab/visual-studio)

* [Visual Studio 2019 16.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the **ASP.NET and web development** workload
* [!INCLUDE [.NET Core 3.1 SDK](~/includes/3.1-SDK.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-3.1.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

* [Visual Studio for Mac version 8.6 or later](https://visualstudio.microsoft.com/vs/mac/)
* [!INCLUDE [.NET Core 3.1 SDK](~/includes/3.1-SDK.md)]

# [.NET Core CLI](#tab/netcore-cli/)

[!INCLUDE[](~/includes/3.1-SDK.md)]

---

## Sample app

Downloading the tutorial's sample chat app isn't required for this tutorial. The sample app is the final, working app produced by following the steps of this tutorial.

[View or download sample code](https://github.com/dotnet/blazor-samples)

:::zone pivot="webassembly"

## Create a hosted Blazor WebAssembly app

Follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

> [!NOTE]
> Visual Studio 16.6 or later and .NET Core SDK 3.1.300 or later are required.

1. Create a new project.

1. Choose the **Blazor WebAssembly App** template. Select **Next**.

1. Type `BlazorWebAssemblySignalRApp` in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox.

1. Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

1. In a command shell, execute the following command:

   ```dotnetcli
   dotnet new blazorwasm -ho -o BlazorWebAssemblySignalRApp
   ```

   The `-ho|--hosted` option creates a hosted Blazor WebAssembly solution. For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

   The `-o|--output` option creates a folder for the solution. If you've created a folder for the solution and the command shell is open in that folder, omit the `-o|--output` option and value to create the solution.

1. In Visual Studio Code, open the app's project folder.

To configure Visual Studio Code assets in the `.vscode` folder for debugging, see:

* <xref:blazor/tooling?pivots=linux> (use the guidance for the *Linux* operating system regardless of platform)
* <xref:blazor/debug>

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Install the latest version of [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) and perform the following steps:

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

1. Choose the **Blazor WebAssembly App** template. Select **Next**.

1. Confirm that **Authentication** is set to **No Authentication**. Select the **ASP.NET Core Hosted** checkbox. Select **Next**.

1. In the **Project Name** field, name the app `BlazorWebAssemblySignalRApp`. Select **Create**.

   If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate.

1. Open the project by navigating to the project folder and opening the project's solution file (`.sln`).

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following command:

```dotnetcli
dotnet new blazorwasm -ho -o BlazorWebAssemblySignalRApp
```

The `-ho|--hosted` option creates a hosted Blazor WebAssembly solution.

The `-o|--output` option creates a folder for the solution. If you've created a folder for the solution and the command shell is open in that folder, omit the `-o|--output` option and value to create the solution.

---

## Add the SignalR client library

# [Visual Studio](#tab/visual-studio/)

1. In **Solution Explorer**, right-click the `BlazorWebAssemblySignalRApp.Client` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Install**.

1. If the **Preview Changes** dialog appears, select **OK**.

1. If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following command:

```dotnetcli
dotnet add Client package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, right-click the `BlazorWebAssemblySignalRApp.Client` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the source drop-down is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the checkbox next to the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Add Package**.

1. If the **License Acceptance** dialog appears, select **Accept** if you agree with the license terms.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the solution's folder, execute the following command:

```dotnetcli
dotnet add Client package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

---

## Add a SignalR hub

In the `BlazorWebAssemblySignalRApp.Server` project, create a `Hubs` (plural) folder and add the following `ChatHub` class (`Hubs/ChatHub.cs`):

[!code-csharp[](signalr-blazor/samples/3.1/BlazorWebAssemblySignalRApp/Server/Hubs/ChatHub.cs)]

## Add services and an endpoint for the SignalR hub

1. In the `BlazorWebAssemblySignalRApp.Server` project, open the `Startup.cs` file.

1. Add the namespace for the `ChatHub` class to the top of the file:

   ```csharp
   using BlazorWebAssemblySignalRApp.Server.Hubs;
   ```

1. Add SignalR and Response Compression Middleware services to `Startup.ConfigureServices`:

   [!code-csharp[](signalr-blazor/samples/3.1/BlazorWebAssemblySignalRApp/Server/Startup.cs?name=snippet_ConfigureServices&highlight=3,5-9)]

1. In `Startup.Configure`:

   * Use Response Compression Middleware at the top of the processing pipeline's configuration.
   * Between the endpoints for controllers and the client-side fallback, add an endpoint for the hub.

   [!code-csharp[](signalr-blazor/samples/3.1/BlazorWebAssemblySignalRApp/Server/Startup.cs?name=snippet_Configure&highlight=3,25)]

## Add Razor component code for chat

1. In the `BlazorWebAssemblySignalRApp.Client` project, open the `Pages/Index.razor` file.

1. Replace the markup with the following code:

   [!code-razor[](signalr-blazor/samples/3.1/BlazorWebAssemblySignalRApp/Client/Pages/Index.razor)]

## Run the app

Follow the guidance for your tooling:

# [Visual Studio](#tab/visual-studio)

1. In **Solution Explorer**, select the `BlazorWebAssemblySignalRApp.Server` project. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio Code](#tab/visual-studio-code)

For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, select the `BlazorWebAssemblySignalRApp.Server` project. Press <kbd>⌘</kbd>+<kbd>↩</kbd> to run the app with debugging or <kbd>⌥</kbd>+<kbd>⌘</kbd>+<kbd>↩</kbd> to run the app without debugging.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [.NET Core CLI](#tab/netcore-cli/)

1. In a command shell from the solution's folder, execute the following commands:

   ```dotnetcli
   cd Server
   dotnet run
   ```

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

---

:::zone-end

:::zone pivot="server"

## Create a Blazor Server app

Follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

> [!NOTE]
> Visual Studio 16.6 or later and .NET Core SDK 3.1.300 or later are required.

1. Create a new project.

1. Select the **Blazor Server App** template. Select **Next**.

1. Type `BlazorServerSignalRApp` in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Next**.

1. Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

1. In a command shell, execute the following command:

   ```dotnetcli
   dotnet new blazorserver -o BlazorServerSignalRApp
   ```

   The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project.

1. In Visual Studio Code, open the app's project folder.

1. When the dialog appears to add assets to build and debug the app, select **Yes**. Visual Studio Code automatically adds the `.vscode` folder with generated `launch.json` and `tasks.json` files. For information on configuring VS Code assets in the `.vscode` folder, including how to manually add the files to the solution, see the **Linux** operating system guidance in <xref:blazor/tooling?pivot=linux>.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Install the latest version of [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) and perform the following steps:

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

1. Choose the **Blazor Server App** template. Select **Next**.

1. Confirm that **Authentication** is set to **No Authentication**. Select **Next**.

1. In the **Project Name** field, name the app `BlazorServerSignalRApp`. Select **Create**.

   If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate.

1. Open the project by navigating to the project folder and opening the project's solution file (`.sln`).

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following command:

```dotnetcli
dotnet new blazorserver -o BlazorServerSignalRApp
```

The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project.

---

## Add the SignalR client library

# [Visual Studio](#tab/visual-studio/)

1. In **Solution Explorer**, right-click the `BlazorServerSignalRApp` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Install**.

1. If the **Preview Changes** dialog appears, select **OK**.

1. If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, right-click the `BlazorServerSignalRApp` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the source drop-down is set to `nuget.org`.

1. With **Browse** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

1. In the search results, select the checkbox next to the [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. Set the version to match the shared framework of the app. Select **Add Package**.

1. If the **License Acceptance** dialog appears, select **Accept** if you agree with the license terms.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the project's folder, execute the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

---

## Add the System.Text.Encodings.Web package

*This section only applies to apps for ASP.NET Core version 3.x.*

Due to a package resolution issue when using [`System.Text.Json`](https://www.nuget.org/packages/System.Text.Json) 5.x in an ASP.NET Core 3.x app, the project requires a package reference for [`System.Text.Encodings.Web`](https://www.nuget.org/packages/System.Text.Encodings.Web). The underlying issue will be resolved in a future patch release of .NET 5. For more information, see [System.Text.Json defines netcoreapp3.0 with no dependencies (dotnet/runtime #45560)](https://github.com/dotnet/runtime/issues/45560).

To add [`System.Text.Encodings.Web`](https://www.nuget.org/packages/System.Text.Encodings.Web) to the project, follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio/)

1. In **Solution Explorer**, right-click the `BlazorServerSignalRApp` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to `nuget.org`.

1. With **Browse** selected, type `System.Text.Encodings.Web` in the search box.

1. In the search results, select the [`System.Text.Encodings.Web`](https://www.nuget.org/packages/System.Text.Encodings.Web) package. Select the version of the package that matches the shared framework in use. Select **Install**.

1. If the **Preview Changes** dialog appears, select **OK**.

1. If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following commands:

```dotnetcli
dotnet add package System.Text.Encodings.Web
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, right-click the `BlazorServerSignalRApp` project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the source drop-down is set to `nuget.org`.

1. With **Browse** selected, type `System.Text.Encodings.Web` in the search box.

1. In the search results, select the checkbox next to the [`System.Text.Encodings.Web`](https://www.nuget.org/packages/System.Text.Encodings.Web) package, select the correct version of the package that matches the shared framework in use, and select **Add Package**.

1. If the **License Acceptance** dialog appears, select **Accept** if you agree with the license terms.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the project's folder, execute the following command:

```dotnetcli
dotnet add package System.Text.Encodings.Web
```

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

---

## Add a SignalR hub

Create a `Hubs` (plural) folder and add the following `ChatHub` class (`Hubs/ChatHub.cs`):

[!code-csharp[](signalr-blazor/samples/3.1/BlazorServerSignalRApp/Hubs/ChatHub.cs)]

## Add services and an endpoint for the SignalR hub

1. Open the `Startup.cs` file.

1. Add the namespaces for <xref:Microsoft.AspNetCore.ResponseCompression?displayProperty=fullName> and the `ChatHub` class to the top of the file:

   ```csharp
   using Microsoft.AspNetCore.ResponseCompression;
   using BlazorServerSignalRApp.Server.Hubs;
   ```

1. Add Response Compression Middleware services to `Startup.ConfigureServices`:

   [!code-csharp[](signalr-blazor/samples/3.1/BlazorServerSignalRApp/Startup.cs?name=snippet_ConfigureServices&highlight=6-10)]

1. In `Startup.Configure`:

   * Use Response Compression Middleware at the top of the processing pipeline's configuration.
   * Between the endpoints for mapping the Blazor hub and the client-side fallback, add an endpoint for the hub.

   [!code-csharp[](signalr-blazor/samples/3.1/BlazorServerSignalRApp/Startup.cs?name=snippet_Configure&highlight=3,23)]

## Add Razor component code for chat

1. Open the `Pages/Index.razor` file.

1. Replace the markup with the following code:

   [!code-razor[](signalr-blazor/samples/3.1/BlazorServerSignalRApp/Pages/Index.razor)]

## Run the app

Follow the guidance for your tooling:

# [Visual Studio](#tab/visual-studio)

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio Code](#tab/visual-studio-code)

1. Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Press <kbd>⌘</kbd>+<kbd>↩</kbd> to run the app with debugging or <kbd>⌥</kbd>+<kbd>⌘</kbd>+<kbd>↩</kbd> to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [.NET Core CLI](#tab/netcore-cli/)

1. In a command shell from the project's folder, execute the following commands:

   ```dotnetcli
   dotnet run
   ```

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

   ![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

---

:::zone-end

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a Blazor project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

To learn more about building Blazor apps, see the Blazor documentation:

> [!div class="nextstepaction"]
> <xref:blazor/index>
> [Bearer token authentication with Identity Server, WebSockets, and Server-Sent Events](xref:signalr/authn-and-authz#bearer-token-authentication)

## Additional resources

* <xref:signalr/introduction>
* [SignalR cross-origin negotiation for authentication](xref:blazor/fundamentals/signalr#signalr-cross-origin-negotiation-for-authentication-blazor-webassembly)
* [SignalR configuration](xref:blazor/host-and-deploy/server#signalr-configuration)
* <xref:blazor/debug>
* <xref:blazor/security/server/threat-mitigation>

:::moniker-end
