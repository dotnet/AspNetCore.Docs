---
title: Use ASP.NET Core SignalR with Blazor WebAssembly
author: guardrex
description: Create a chat app that uses ASP.NET Core SignalR with Blazor WebAssembly.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/31/2020
no-loc: [Blazor, SignalR]
uid: tutorials/signalr-blazor-webassembly
---
# Use ASP.NET Core SignalR with Blazor WebAssembly

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

This tutorial teaches the basics of building a real-time app using SignalR with Blazor WebAssembly. You learn how to:

> [!div class="checklist"]
> * Create a Blazor WebAssembly Hosted app project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

At the end of this tutorial, you'll have a working chat app.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/tutorials/signalr-blazor-webassembly/samples/) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs-3.1.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-3.1.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-core-prereqs-mac-3.1.md)]

# [.NET Core CLI](#tab/netcore-cli/)

[!INCLUDE[](~/includes/3.1-SDK.md)]

---

## Create a hosted Blazor WebAssembly app project

Install the [Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly) template. The [Microsoft.AspNetCore.Blazor.Templates](https://www.nuget.org/packages/Microsoft.AspNetCore.Blazor.Templates/) package has a preview version while Blazor WebAssembly is in preview. In a command shell, execute the following command:

```dotnetcli
dotnet new -i Microsoft.AspNetCore.Blazor.Templates::3.2.0-preview1.20073.1
```

Follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

1. Create a new project.

1. Select **Blazor App** and select **Next**.

1. Type "BlazorSignalRApp" in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Create**.

1. Choose the **Blazor WebAssembly App** template.

1. Under **Advanced**, select the **ASP.NET Core hosted** check box.

1. Select **Create**.

> [!NOTE]
> If you upgraded or installed a new version of Visual Studio and the Blazor WebAssembly template doesn't appear in the VS UI, reinstall the template using the `dotnet new` command shown previously.

# [Visual Studio Code](#tab/visual-studio-code)

1. In a command shell, execute the following command:

   ```dotnetcli
   dotnet new blazorwasm --hosted --output BlazorSignalRApp
   ```

1. In Visual Studio Code, open the app's project folder.

1. When the dialog appears to add assets to build and debug the app, select **Yes**. Visual Studio Code automatically adds the *.vscode* folder with generated *launch.json* and *tasks.json* files.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In a command shell, execute the following command:

   ```dotnetcli
   dotnet new blazorwasm --hosted --output BlazorSignalRApp
   ```

1. In Visual Studio for Mac, open the project by navigating to the project folder and opening the project's solution file (*.sln*).

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following command:

```dotnetcli
dotnet new blazorwasm --hosted --output BlazorSignalRApp
```

---

## Add the SignalR client library

# [Visual Studio](#tab/visual-studio/)

1. In **Solution Explorer**, right-click the **BlazorSignalRApp.Client** project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to *nuget.org*.

1. With **Browse** selected, type "Microsoft.AspNetCore.SignalR.Client" in the search box.

1. In the search results, select the `Microsoft.AspNetCore.SignalR.Client` package and select **Install**.

1. If the **Preview Changes** dialog appears, select **OK**.

1. If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following commands:

```dotnetcli
dotnet add Client package Microsoft.AspNetCore.SignalR.Client
```

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, right-click the **BlazorSignalRApp.Client** project and select **Manage NuGet Packages**.

1. In the **Manage NuGet Packages** dialog, confirm that the source drop-down is set to *nuget.org*.

1. With **Browse** selected, type "Microsoft.AspNetCore.SignalR.Client" in the search box.

1. In the search results, select the check box next to the `Microsoft.AspNetCore.SignalR.Client` package and select **Add Package**.

1. If the **License Acceptance** dialog appears, select **Accept** if you agree with the license terms.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following commands:

```dotnetcli
cd BlazorSignalRApp
dotnet add Client package Microsoft.AspNetCore.SignalR.Client
```

---

## Add a SignalR hub

In the **BlazorSignalRApp.Server** project, create a *Hubs* (plural) folder and add the following `ChatHub` class (*Hubs/ChatHub.cs*):

[!code-csharp[](signalr-blazor-webassembly/samples/3.x/BlazorSignalRApp/Server/Hubs/ChatHub.cs)]

## Add SignalR services and an endpoint for the SignalR hub

1. In the **BlazorSignalRApp.Server** project, open the *Startup.cs* file.

1. Add the namespace for the `ChatHub` class to the top of the file:

   ```csharp
   using BlazorSignalRApp.Server.Hubs;
   ```

1. Add the SignalR services to `Startup.ConfigureServices`:

   ```csharp
   services.AddSignalR();
   ```

1. In `Startup.Configure` between the endpoints for the default controller route and the client-side fallback, add an endpoint for the hub:

   [!code-csharp[](signalr-blazor-webassembly/samples/3.x/BlazorSignalRApp/Server/Startup.cs?name=snippet&highlight=4)]

## Add Razor component code for chat

1. In the **BlazorSignalRApp.Client** project, open the *Pages/Index.razor* file.

1. Replace the markup with the following code:

[!code-razor[](signalr-blazor-webassembly/samples/3.x/BlazorSignalRApp/Client/Pages/Index.razor)]

## Run the app

1. Follow the guidance for your tooling:

# [Visual Studio](#tab/visual-studio)

1. In **Solution Explorer**, select the **BlazorSignalRApp.Server** project. Press **Ctrl+F5** to run the app without debugging.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the **Send** button. The name and message are displayed on both pages instantly:

   ![SignalR Blazor WebAssembly sample app open in two browser windows showing exchanged messages.](signalr-blazor-webassembly/_static/3.x/signalr-blazor-webassembly-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio Code](#tab/visual-studio-code)

1. Select **Debug** > **Run Without Debugging** from the toolbar.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the **Send** button. The name and message are displayed on both pages instantly:

   ![SignalR Blazor WebAssembly sample app open in two browser windows showing exchanged messages.](signalr-blazor-webassembly/_static/3.x/signalr-blazor-webassembly-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In the **Solution** sidebar, select the **BlazorSignalRApp.Server** project. From the menu, select **Run** > **Start Without Debugging**.

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the **Send** button. The name and message are displayed on both pages instantly:

   ![SignalR Blazor WebAssembly sample app open in two browser windows showing exchanged messages.](signalr-blazor-webassembly/_static/3.x/signalr-blazor-webassembly-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

# [.NET Core CLI](#tab/netcore-cli/)

1. In a command shell, execute the following commands:

   ```dotnetcli
   cd Server
   dotnet run
   ```

1. Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

1. Choose either browser, enter a name and message, and select the **Send** button. The name and message are displayed on both pages instantly:

   ![SignalR Blazor WebAssembly sample app open in two browser windows showing exchanged messages.](signalr-blazor-webassembly/_static/3.x/signalr-blazor-webassembly-finished.png)

   Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

---

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a Blazor WebAssembly Hosted app project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

To learn more about building Blazor apps, see the Blazor documentation:

> [!div class="nextstepaction"]
> <xref:blazor/index>

## Additional resources

* <xref:signalr/introduction>
