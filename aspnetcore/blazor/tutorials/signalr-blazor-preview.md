---
title: Use ASP.NET Core SignalR with Blazor (.NET 8 Preview)
author: guardrex
description: Create a chat app that uses ASP.NET Core SignalR with Blazor.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/30/2023
uid: blazor/tutorials/signalr-blazor-preview
---
# Use ASP.NET Core SignalR with Blazor (.NET 8 Preview)

<!-- UPDATE 8.0

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This tutorial provides a basic working experience for building a real-time app using SignalR with Blazor. For detailed Blazor guidance, see the [Blazor reference documentation](xref:blazor/index).

<!-- UPDATE 8.0 Remove preview NOTE -->

> [!IMPORTANT]
> This is the .NET 8 preview version of this article. For the current release, see the [.NET 7 version of this article](xref:blazor/tutorials/signalr-blazor?view=aspnetcore-7.0&preserve-view=true).

Learn how to:

> [!div class="checklist"]
> * Create a Blazor project
> * Add the SignalR client library
> * Add a SignalR hub
> * Add SignalR services and an endpoint for the SignalR hub
> * Add Razor component code for chat

At the end of this tutorial, you'll have a working chat app.

<!-- UPDATE 8.0 Update prereqs and tooling guidance

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the **ASP.NET and web development** workload

# [Visual Studio Code](#tab/visual-studio-code)

* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Download and install .NET](https://dotnet.microsoft.com/download/dotnet) if it isn't already installed on the system or if the system doesn't have the latest version installed.

The Visual Studio Code instructions use the .NET CLI for ASP.NET Core development functions such as project creation. You can follow these instructions on macOS, Linux, or Windows and with any code editor. Minor changes may be required if you use something other than Visual Studio Code.

# [.NET Core CLI](#tab/netcore-cli/)

[Download and install .NET](https://dotnet.microsoft.com/download/dotnet) if it isn't already installed on the system or if the system doesn't have the latest version installed.

---

-->

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/) with the **ASP.NET and web development** workload

# [Visual Studio Code](#tab/visual-studio-code)

* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [.NET 8.0 Preview](https://dotnet.microsoft.com/download/dotnet/8.0) if it isn't already installed on the system or if the system doesn't have the latest version installed.

The Visual Studio Code instructions use the .NET CLI for ASP.NET Core development functions such as project creation. You can follow these instructions on macOS, Linux, or Windows and with any code editor. Minor changes may be required if you use something other than Visual Studio Code.

# [.NET Core CLI](#tab/netcore-cli/)

[.NET 8.0 Preview](https://dotnet.microsoft.com/download/dotnet/8.0)

---

<!-- UPDATE 8.0

## Sample app

Downloading the tutorial's sample chat app isn't required for this tutorial. The sample app is the final, working app produced by following the steps of this tutorial.

[View or download sample code](https://github.com/dotnet/blazor-samples)

-->

## Create a Blazor Web App

Follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

> [!NOTE]
> Visual Studio 2022 or later and .NET Core SDK 8.0.0 or later are required.

Create a new project.

Select the **Blazor Web App** template. Select **Next**.

Type `BlazorSignalRApp` in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Next**.

Confirm the **Framework** is .NET 8.0 or later. Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

<!-- UPDATE 8.0 Confirm SSR by default without --use-server -->

In a command shell, execute the following command:

```dotnetcli
dotnet new blazor -o BlazorSignalRApp
```

The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project. <!-- The `--use-server` option enables interactivity with server rendering. -->

In Visual Studio Code, open the app's project folder.

When the dialog appears to add assets to build and debug the app, select **Yes**. Visual Studio Code automatically adds the `.vscode` folder with generated `launch.json` and `tasks.json` files. For information on configuring VS Code assets in the `.vscode` folder, including how to manually add the files to the [solution](xref:blazor/tooling#visual-studio-solution-file-sln), see the **Linux** operating system guidance in <xref:blazor/tooling?pivot=linux>.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell, execute the following command:

```dotnetcli
dotnet new blazor -o BlazorSignalRApp --use-server
```

The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project. The `--use-server` option enables interactivity with server rendering.

---

## Add the SignalR client library

# [Visual Studio](#tab/visual-studio/)

In **Solution Explorer**, right-click the `BlazorSignalRApp` project and select **Manage NuGet Packages**.

In the **Manage NuGet Packages** dialog, confirm that the **Package source** is set to `nuget.org`.

With **Browse** and **Include prerelease** selected, type `Microsoft.AspNetCore.SignalR.Client` in the search box.

In the search results, select the latest **preview** [`Microsoft.AspNetCore.SignalR.Client`](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package. <!-- Set the version to match the shared framework of the app. --> Select **Install**.

If the **Preview Changes** dialog appears, select **OK**.

If the **License Acceptance** dialog appears, select **I Accept** if you agree with the license terms.

# [Visual Studio Code](#tab/visual-studio-code/)

In the **Integrated Terminal** (**View** > **Terminal** from the toolbar), execute the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client --prerelease
```

<!-- UPDATE 8.0

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

-->

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the project's folder, execute the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.SignalR.Client --prerelease
```

<!-- UPDATE 8.0

To add an earlier version of the package, supply the `--version {VERSION}` option, where the `{VERSION}` placeholder is the version of the package to add.

-->

---

## Add a SignalR hub

Create a `Hubs` (plural) folder and add the following `ChatHub` class (`Hubs/ChatHub.cs`) to the root of the app:

```csharp
using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
```

<!-- UPDATE 8.0

## Add services and an endpoint for the SignalR hub

-->

## Add Razor component support, services, and an endpoint for the SignalR hub

Open the `Program` file.

Add the namespaces for <xref:Microsoft.AspNetCore.ResponseCompression?displayProperty=fullName> and the `ChatHub` class to the top of the file:

```csharp
using Microsoft.AspNetCore.ResponseCompression;
using BlazorSignalRApp.Hubs;
```

Add Response Compression Middleware services:

```csharp
builder.Services.AddResponseCompression(opts =>
{
   opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
         new[] { "application/octet-stream" });
});
```

Use Response Compression Middleware at the top of the processing pipeline's configuration:
   
```csharp
app.UseResponseCompression();
```

Add an endpoint for the hub immediately after the line `app.MapRazorComponents<App>();`:

```csharp
app.MapHub<ChatHub>("/chathub");
```

## Add Razor component code for chat
<!--
:::moniker range=">= aspnetcore-8.0"
-->

Open the `Components/Pages/Index.razor` file.

<!--
:::moniker-end


:::moniker range="< aspnetcore-8.0"

Open the `Pages/Index.razor` file.

:::moniker-end
-->

Replace the markup with the following code:

```razor
@page "/"
@attribute [RenderModeServer]
@using Microsoft.AspNetCore.SignalR.Client
@inject NavigationManager Navigation
@implements IAsyncDisposable

<PageTitle>Index</PageTitle>

<div class="form-group">
    <label>
        User:
        <input @bind="userInput" />
    </label>
</div>
<div class="form-group">
    <label>
        Message:
        <input @bind="messageInput" size="50" />
    </label>
</div>
<button @onclick="Send" disabled="@(!IsConnected)">Send</button>

<hr>

<ul id="messagesList">
    @foreach (var message in messages)
    {
        <li>@message</li>
    }
</ul>

@code {
    private HubConnection? hubConnection;
    private List<string> messages = new List<string>();
    private string? userInput;
    private string? messageInput;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
            .Build();

        hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            var encodedMsg = $"{user}: {message}";
            messages.Add(encodedMsg);
            InvokeAsync(StateHasChanged);
        });

        await hubConnection.StartAsync();
    }

    private async Task Send()
    {
        if (hubConnection is not null)
        {
            await hubConnection.SendAsync("SendMessage", userInput, messageInput);
        }
    }

    public bool IsConnected =>
        hubConnection?.State == HubConnectionState.Connected;

    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}
```

> [!NOTE]
> Disable Response Compression Middleware in the `Development` environment when using [Hot Reload](xref:test/hot-reload). For more information, see <xref:blazor/fundamentals/signalr#disable-response-compression-for-hot-reload>.

## Run the app

Follow the guidance for your tooling:

# [Visual Studio](#tab/visual-studio)

Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

# [Visual Studio Code](#tab/visual-studio-code)

Press <kbd>F5</kbd> to run the app with debugging or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows)/<kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

# [.NET Core CLI](#tab/netcore-cli/)

In a command shell from the project's folder, execute the following commands:

```dotnetcli
dotnet run
```

---

Copy the URL from the address bar, open another browser instance or tab, and paste the URL in the address bar.

Choose either browser, enter a name and message, and select the button to send the message. The name and message are displayed on both pages instantly:

![SignalR Blazor sample app open in two browser windows showing exchanged messages.](signalr-blazor/_static/signalr-blazor-finished.png)

Quotes: *Star Trek VI: The Undiscovered Country* &copy;1991 [Paramount](https://www.paramountmovies.com/movies/star-trek-vi-the-undiscovered-country)

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
* [SignalR cross-origin negotiation for authentication](xref:blazor/fundamentals/signalr#client-side-signalr-cross-origin-negotiation-for-authentication)
* [SignalR configuration](xref:blazor/host-and-deploy/server#signalr-configuration)
* <xref:blazor/debug>
* <xref:blazor/security/server/threat-mitigation>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
