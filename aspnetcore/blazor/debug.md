---
title: Debug ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to debug Blazor WebAssembly with browser developer tools and an integrated development environment (IDE).
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/debug
---
# Debug ASP.NET Core Blazor WebAssembly

This article describes how to debug Blazor WebAssembly with browser developer tools and an integrated development environment (IDE).

:::moniker range=">= aspnetcore-6.0"

Blazor WebAssembly apps can be debugged using the browser developer tools in Chromium-based browsers (Edge/Chrome). You can also debug your app using the following IDEs:

* Visual Studio
* Visual Studio for Mac
* Visual Studio Code

Available scenarios include:

* Set and remove breakpoints.
* Run the app with debugging support in IDEs.
* Single-step through the code.
* Resume code execution with a keyboard shortcut in IDEs.
* In the *Locals* window, observe the values of local variables.
* See the call stack, including call chains between JavaScript and .NET.

For now, you *can't*:

* Break on unhandled exceptions.
* Hit breakpoints during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.
* Debug in non-local scenarios (for example, [Windows Subsystem for Linux (WSL)](/windows/wsl/) or [Visual Studio Codespaces](/visualstudio/devinit/devinit-and-codespaces)).
* Automatically rebuild the backend **`Server`** app of a hosted Blazor WebAssembly solution during debugging, for example by running the app with [`dotnet watch run`](xref:tutorials/dotnet-watch).

## Prerequisites

Debugging requires either of the following browsers:

* Google Chrome (version 70 or later) (default)
* Microsoft Edge (version 80 or later)

Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

Visual Studio Code users require the following extensions:

* [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Blazor WASM Debugging Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.blazorwasm-companion) (when using the C# for Visual Studio Code Extension version 1.23.9 or later)

After opening a project in VS Code, you may receive a notification that additional setup is required to enable debugging. If requested, install the required extensions from the Visual Studio Marketplace. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.

Visual Studio for Mac requires version 8.8 (build 1532) or later:

1. Install the latest release of Visual Studio for Mac by selecting the **Download Visual Studio for Mac** button at [Microsoft: Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
1. Select the *Preview* channel from within Visual Studio. For more information, see [Install a preview version of Visual Studio for Mac](/visualstudio/mac/install-preview).

> [!NOTE]
> Apple Safari on macOS isn't currently supported.

## Debug a standalone Blazor WebAssembly app

To enable debugging for an existing Blazor WebAssembly app, update the `launchSettings.json` file in the startup project to include the following `inspectUri` property in each launch profile:

```json
"inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}"
```

Once updated, the `launchSettings.json` file should look similar to the following example:

[!code-json[](~/blazor/debug/launchSettings.json?highlight=14,22)]

The `inspectUri` property:

* Enables the IDE to detect that the app is a Blazor WebAssembly app.
* Instructs the script debugging infrastructure to connect to the browser through Blazor's debugging proxy.

The placeholder values for the WebSocket protocol (`wsProtocol`), host (`url.hostname`), port (`url.port`), and inspector URI on the launched browser (`browserInspectUri`) are provided by the framework.

# [Visual Studio](#tab/visual-studio)

To debug a Blazor WebAssembly app in Visual Studio:

1. Create a new hosted Blazor WebAssembly solution.
1. With the **`Server`** project selected in **Solution Explorer**, press <kbd>F5</kbd> to run the app in the debugger.

   > [!NOTE]
   > When debugging with a Chromium-based browser, such as Google Chrome or Microsoft Edge, a new browser window might open with a separate profile for the debugging session instead of opening a tab in an existing browser window with the user's profile. If debugging with the user's profile is a requirement, adopt **one** of the following approaches:
   >
   > * Close all open browser instances before pressing <kbd>F5</kbd> to start debugging.
   > * Configure Visual Studio to launch the browser with the user's profile. For more information on this approach, see [Blazor WASM Debugging in VS launches Edge with a separate user data directory (dotnet/aspnetcore #20915)](https://github.com/dotnet/aspnetcore/issues/20915#issuecomment-614933322).

   > [!NOTE]
   > **Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.
1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint.
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>F5</kbd> to continue execution.

While debugging a Blazor WebAssembly app, you can also debug server code:

1. Set a breakpoint in the `Pages/FetchData.razor` page in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
1. Set a breakpoint in the `WeatherForecastController` in the `Get` action method.
1. Browse to the `Fetch Data` page to hit the first breakpoint in the `FetchData` component just before it issues an HTTP request to the server.
1. Press <kbd>F5</kbd> to continue execution and then hit the breakpoint on the server in the `WeatherForecastController`.
1. Press <kbd>F5</kbd> again to let execution continue and see the weather forecast table rendered in the browser.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

If the app is hosted at a different [app base path](xref:blazor/host-and-deploy/index#app-base-path) than `/`, update the following properties in `Properties/launchSettings.json` to reflect the app's base path:

* `applicationUrl`:

  ```json
  "iisSettings": {
    ...
    "iisExpress": {
      "applicationUrl": "http://localhost:{INSECURE PORT}/{APP BASE PATH}/",
      "sslPort": {SECURE PORT}
    }
  },
  ```

* `inspectUri` of each profile:

  ```json
  "profiles": {
    ...
    "{PROFILE 1, 2, ... N}": {
      ...
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/{APP BASE PATH}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      ...
    }
  }
  ```

The placeholders in the preceding settings:

* `{INSECURE PORT}`: The insecure port. A random value is provided by default, but a custom port is permitted.
* `{APP BASE PATH}`: The app's base path.
* `{SECURE PORT}`: The secure port. A random value is provided by default, but a custom port is permitted.
* `{PROFILE 1, 2, ... N}`: Launch settings profiles. Usually, an app specifies more than one profile by default (for example, a profile for IIS Express and a project profile, which is used by Kestrel server).

In the following examples, the app is hosted at `/OAT` with an app base path configured in `wwwroot/index.html` as `<base href="/OAT/">`:

```json
"applicationUrl": "http://localhost:{INSECURE PORT}/OAT/",
```

```json
"inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/OAT/_framework/debug/ws-proxy?browser={browserInspectUri}",
```

For information on using a custom app base path for Blazor WebAssembly apps, see <xref:blazor/host-and-deploy/index#app-base-path>.

# [Visual Studio Code](#tab/visual-studio-code)

<h2 id="vscode">Debug standalone Blazor WebAssembly</h2>

For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

1. Open the standalone Blazor WebAssembly app in VS Code.

   You may receive a notification that additional setup is required to enable debugging:

   > Additional setup is required to debug Blazor WebAssembly applications.

   If you receive the notification:

   * Confirm that the latest [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) is installed. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.
   * When using the [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) **version 1.23.9 or later**, confirm that the latest [Blazor WASM Debugging Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.blazorwasm-companion) is installed. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.
   * Reload the window.

1. Create a `.vscode/launch.json` file with the following configuration. Replace the `{PORT}` placeholder with the port configured in `Properties/launchSettings.json`:

   ```json
   {
     "name": "Launch and Debug",
     "type": "blazorwasm",
     "request": "launch",
     "url": "https://localhost:{PORT}"
   }
   ```

1. Start debugging using the <kbd>F5</kbd> keyboard shortcut or the menu item.

   > [!NOTE]
   > **Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

1. The standalone app is launched, and a debugging browser is opened.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.

1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

## Debug hosted Blazor WebAssembly

For guidance on configuring VS Code assets in the `.vscode` folder and where to place the `.vscode` folder in the solution, see the **Linux** operating system guidance in <xref:blazor/tooling?pivots=linux>.

> [!NOTE]
> Only [browser debugging](#debug-in-the-browser) is supported at this time.
>
> You can't automatically rebuild the backend **`Server`** app of a hosted Blazor WebAssembly solution during debugging, for example by running the app with [`dotnet watch run`](xref:tutorials/dotnet-watch).

To debug a **published**, hosted Blazor WebAssembly app, configure debugger support (`DebuggerSupport`) and copy output symbols to the `publish` directory (`CopyOutputSymbolsToPublishDirectory`) in the **`Client`** app's project file:

```xml
<DebuggerSupport>true</DebuggerSupport>
<CopyOutputSymbolsToPublishDirectory>true</CopyOutputSymbolsToPublishDirectory>
```

By default, publishing an app disables the preceding properties by setting them to `false`.

> [!WARNING]
> Published, hosted Blazor WebAssembly apps should only enable debugging and copying output symbols when deploying published assets ***locally***. Do **not*** deploy a published app into production with the `DebuggerSupport` and `CopyOutputSymbolsToPublishDirectory` properties set to `true`.

## Attach to an existing debugging session

To attach to a running Blazor app, create a `.vscode/launch.json` file with the following configuration. Replace the `{URL}` placeholder with the URL where the app is running:

```json
{
  "name": "Attach and Debug"
  "type": "blazorwasm",
  "request": "attach",
  "url": "{URL}"
}
```

> [!NOTE]
> Attaching to a debugging session is only supported for standalone apps. To use full-stack debugging, you must launch the app from VS Code.

## Launch configuration options

The following launch configuration options are supported for the `blazorwasm` debug type (`.vscode/launch.json`).

| Option    | Description |
| --------- | ----------- |
| `request` | Use `launch` to launch and attach a debugging session to a Blazor WebAssembly app or `attach` to attach a debugging session to an already-running app. |
| `url`     | The URL to open in the browser when debugging. Defaults to `https://localhost:5001`. If the app is running at a different URL, an `about:blank` tab launches in the browser. |
| `browser` | The browser to launch for the debugging session. Set to `edge` or `chrome`. Defaults to `chrome`. |
| `trace`   | Used to generate logs from the JS debugger. Set to `true` to generate logs. |
| `hosted`  | Must be set to `true` if launching and debugging a hosted Blazor WebAssembly app. |
| `webRoot` | Specifies the absolute path of the web server. Should be set if an app is served from a sub-route. |
| `timeout` | The number of milliseconds to wait for the debugging session to attach. Defaults to 30,000 milliseconds (30 seconds). |
| `program` | A reference to the executable to run the server of the hosted app. Must be set if `hosted` is `true`. |
| `cwd`     | The working directory to launch the app under. Must be set if `hosted` is `true`. |
| `env`     | The environment variables to provide to the launched process. Only applicable if `hosted` is set to `true`. |

# [Visual Studio for Mac](#tab/visual-studio-mac)

To debug a Blazor WebAssembly app in Visual Studio for Mac:

1. Create a new hosted Blazor WebAssembly app.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to run the app in the debugger.

   > [!NOTE]
   > **Start Without Debugging** (<kbd>&#8997;</kbd>+<kbd>&#8984;</kbd>+<kbd>&#8617;</kbd>) isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

   > [!IMPORTANT]
   > Google Chrome or Microsoft Edge must be the selected browser for the debugging session.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.
1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint:
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to continue execution.

While debugging a Blazor WebAssembly app, you can also debug server code:

1. Set a breakpoint in the `Pages/FetchData.razor` page in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
1. Set a breakpoint in the `WeatherForecastController` in the `Get` action method.
1. Browse to the `Fetch Data` page to hit the first breakpoint in the `FetchData` component just before it issues an HTTP request to the server.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to continue execution and then hit the breakpoint on the server in the `WeatherForecastController`.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> again to let execution continue and see the weather forecast table rendered in the browser.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

For more information, see [Debugging with Visual Studio for Mac](/visualstudio/mac/debugging).

---

## Debug in the browser

*The guidance in this section applies to Google Chrome and Microsoft Edge running on Windows.*

1. Run a Debug build of the app in the Development environment.

1. Launch a browser and navigate to the app's URL (for example, `https://localhost:7268`).

1. In the browser, attempt to commence remote debugging by pressing <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd>.

   The browser must be running with remote debugging enabled, which isn't the default. If remote debugging is disabled, an **Unable to find debuggable browser tab** error page is rendered with instructions for launching the browser with the debugging port open. Follow the instructions for your browser, which opens a new browser window. Close the previous browser window.

<!-- HOLD 
1. In the browser, attempt to commence remote debugging by pressing:

   * <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd> on Windows.
   * <kbd>Shift</kbd>+<kbd>&#8984;</kbd>+<kbd>d</kbd> on macOS.

   The browser must be running with remote debugging enabled, which isn't the default. If remote debugging is disabled, an **Unable to find debuggable browser tab** error page is rendered with instructions for launching the browser with the debugging port open. Follow the instructions for your browser, which opens a new browser window. Close the previous browser window.
-->

1. Once the browser is running with remote debugging enabled, the debugging keyboard shortcut in the previous step opens a new debugger tab.

1. After a moment, the **Sources** tab shows a list of the app's .NET assemblies within the `file://` node.

1. In component code (`.razor` files) and C# code files (`.cs`), breakpoints that you set are hit when code executes. After a breakpoint is hit, single-step (<kbd>F10</kbd>) through the code or resume (<kbd>F8</kbd>) code execution normally.

Blazor provides a debugging proxy that implements the [Chrome DevTools Protocol](https://chromedevtools.github.io/devtools-protocol/) and augments the protocol with .NET-specific information. When debugging keyboard shortcut is pressed, Blazor points the Chrome DevTools at the proxy. The proxy connects to the browser window you're seeking to debug (hence the need to enable remote debugging).

## Browser source maps

Browser source maps allow the browser to map compiled files back to their original source files and are commonly used for client-side debugging. However, Blazor doesn't currently map C# directly to JavaScript/WASM. Instead, Blazor does IL interpretation within the browser, so source maps aren't relevant.

## Firewall configuration

If a firewall blocks communication with the debug proxy, create a firewall exception rule that permits communication between the browser and the `NodeJS` process.

> [!WARNING]
> Modification of a firewall configuration must be made with care to avoid creating security vulnerabilities. Carefully apply security guidance, follow best security practices, and respect warnings issued by the firewall's manufacturer.
>
> Permitting open communication with the `NodeJS` process:
>
> * Opens up the Node server to any connection, depending on the firewall's capabilities and configuration.
> * Might be risky depending on your network.
> * **Is only recommended on developer machines.**
>
> If possible, only allow open communication with the `NodeJS` process **on trusted or private networks**.

For [Windows Firewall](/windows/security/threat-protection/windows-firewall/windows-firewall-with-advanced-security) configuration guidance, see [Create an Inbound Program or Service Rule](/windows/security/threat-protection/windows-firewall/create-an-inbound-program-or-service-rule). For more information, see [Windows Defender Firewall with Advanced Security](/windows/security/threat-protection/windows-firewall/windows-firewall-with-advanced-security) and related articles in the Windows Firewall documentation set.

## Troubleshoot

If you're running into errors, the following tips may help:

* In the **Debugger** tab, open the developer tools in your browser. In the console, execute `localStorage.clear()` to remove any breakpoints.
* Confirm that you've installed and trusted the ASP.NET Core HTTPS development certificate. For more information, see <xref:security/enforcing-ssl#troubleshoot-certificate-problems-such-as-certificate-not-trusted>.
* Visual Studio requires the **Enable JavaScript debugging for ASP.NET (Chrome, Edge and IE)** option in **Tools** > **Options** > **Debugging** > **General**. This is the default setting for Visual Studio. If debugging isn't working, confirm that the option is selected.
* If your environment uses an HTTP proxy, make sure that `localhost` is included in the proxy bypass settings. This can be done by setting the `NO_PROXY` environment variable in either:
  * The `launchSettings.json` file for the project.
  * At the user or system environment variables level for it to apply to all apps. When using an environment variable, restart Visual Studio for the change to take effect.
* Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

### Breakpoints in `OnInitialized{Async}` not hit

The Blazor framework's debugging proxy takes a short time to launch, so breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) might not be hit. We recommend adding a delay at the start of the method body to give the debug proxy some time to launch before the breakpoint is hit. You can include the delay based on an [`if` compiler directive](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) to ensure that the delay isn't present for a release build of the app.

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A>:

```csharp
protected override void OnInitialized()
{
#if DEBUG
    Thread.Sleep(10000);
#endif

    ...
}
```

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>:

```csharp
protected override async Task OnInitializedAsync()
{
#if DEBUG
    await Task.Delay(10000);
#endif

    ...
}
```

### Visual Studio (Windows) timeout

If Visual Studio throws an exception that the debug adapter failed to launch mentioning that the timeout was reached, you can adjust the timeout with a Registry setting:

```console
VsRegEdit.exe set "<VSInstallFolder>" HKCU JSDebugger\Options\Debugging "BlazorTimeoutInMilliseconds" dword {TIMEOUT}
```

The `{TIMEOUT}` placeholder in the preceding command is in milliseconds. For example, one minute is assigned as `60000`.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Blazor WebAssembly apps can be debugged using the browser developer tools in Chromium-based browsers (Edge/Chrome). You can also debug your app using the following IDEs:

* Visual Studio
* Visual Studio for Mac
* Visual Studio Code

Available scenarios include:

* Set and remove breakpoints.
* Run the app with debugging support in IDEs.
* Single-step through the code.
* Resume code execution with a keyboard shortcut in IDEs.
* In the *Locals* window, observe the values of local variables.
* See the call stack, including call chains between JavaScript and .NET.

For now, you *can't*:

* Break on unhandled exceptions.
* Hit breakpoints during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.
* Debug in non-local scenarios (for example, [Windows Subsystem for Linux (WSL)](/windows/wsl/) or [Visual Studio Codespaces](/visualstudio/devinit/devinit-and-codespaces)).
* Automatically rebuild the backend `*Server*` app of a hosted Blazor WebAssembly solution during debugging, for example by running the app with [`dotnet watch run`](xref:tutorials/dotnet-watch).

## Prerequisites

Debugging requires either of the following browsers:

* Google Chrome (version 70 or later) (default)
* Microsoft Edge (version 80 or later)

Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

Visual Studio Code users require the following extensions:

* [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Blazor WASM Debugging Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.blazorwasm-companion) (when using the C# for Visual Studio Code Extension version 1.23.9 or later)

After opening a project in VS Code, you may receive a notification that additional setup is required to enable debugging. If requested, install the required extensions from the Visual Studio Marketplace. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.

Visual Studio for Mac requires version 8.8 (build 1532) or later:

1. Install the latest release of Visual Studio for Mac by selecting the **Download Visual Studio for Mac** button at [Microsoft: Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
1. Select the *Preview* channel from within Visual Studio. For more information, see [Install a preview version of Visual Studio for Mac](/visualstudio/mac/install-preview).

> [!NOTE]
> Apple Safari on macOS isn't currently supported.

## Debug a standalone Blazor WebAssembly app

To enable debugging for an existing Blazor WebAssembly app, update the `launchSettings.json` file in the startup project to include the following `inspectUri` property in each launch profile:

```json
"inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}"
```

Once updated, the `launchSettings.json` file should look similar to the following example:

[!code-json[](~/blazor/debug/launchSettings.json?highlight=14,22)]

The `inspectUri` property:

* Enables the IDE to detect that the app is a Blazor WebAssembly app.
* Instructs the script debugging infrastructure to connect to the browser through Blazor's debugging proxy.

The placeholder values for the WebSocket protocol (`wsProtocol`), host (`url.hostname`), port (`url.port`), and inspector URI on the launched browser (`browserInspectUri`) are provided by the framework.

# [Visual Studio](#tab/visual-studio)

To debug a Blazor WebAssembly app in Visual Studio:

1. Create a new hosted Blazor WebAssembly solution.
1. With the **`Server`** project selected in **Solution Explorer**, press <kbd>F5</kbd> to run the app in the debugger.

   > [!NOTE]
   > When debugging with a Chromium-based browser, such as Google Chrome or Microsoft Edge, a new browser window might open with a separate profile for the debugging session instead of opening a tab in an existing browser window with the user's profile. If debugging with the user's profile is a requirement, adopt **one** of the following approaches:
   >
   > * Close all open browser instances before pressing <kbd>F5</kbd> to start debugging.
   > * Configure Visual Studio to launch the browser with the user's profile. For more information on this approach, see [Blazor WASM Debugging in VS launches Edge with a separate user data directory (dotnet/aspnetcore #20915)](https://github.com/dotnet/aspnetcore/issues/20915#issuecomment-614933322).

   > [!NOTE]
   > **Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.
1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint.
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>F5</kbd> to continue execution.

While debugging a Blazor WebAssembly app, you can also debug server code:

1. Set a breakpoint in the `Pages/FetchData.razor` page in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
1. Set a breakpoint in the `WeatherForecastController` in the `Get` action method.
1. Browse to the `Fetch Data` page to hit the first breakpoint in the `FetchData` component just before it issues an HTTP request to the server.
1. Press <kbd>F5</kbd> to continue execution and then hit the breakpoint on the server in the `WeatherForecastController`.
1. Press <kbd>F5</kbd> again to let execution continue and see the weather forecast table rendered in the browser.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

If the app is hosted at a different [app base path](xref:blazor/host-and-deploy/index#app-base-path) than `/`, update the following properties in `Properties/launchSettings.json` to reflect the app's base path:

* `applicationUrl`:

  ```json
  "iisSettings": {
    ...
    "iisExpress": {
      "applicationUrl": "http://localhost:{INSECURE PORT}/{APP BASE PATH}/",
      "sslPort": {SECURE PORT}
    }
  },
  ```

* `inspectUri` of each profile:

  ```json
  "profiles": {
    ...
    "{PROFILE 1, 2, ... N}": {
      ...
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/{APP BASE PATH}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      ...
    }
  }
  ```

The placeholders in the preceding settings:

* `{INSECURE PORT}`: The insecure port. A random value is provided by default, but a custom port is permitted.
* `{APP BASE PATH}`: The app's base path.
* `{SECURE PORT}`: The secure port. A random value is provided by default, but a custom port is permitted.
* `{PROFILE 1, 2, ... N}`: Launch settings profiles. Usually, an app specifies more than one profile by default (for example, a profile for IIS Express and a project profile, which is used by Kestrel server).

In the following examples, the app is hosted at `/OAT` with an app base path configured in `wwwroot/index.html` as `<base href="/OAT/">`:

```json
"applicationUrl": "http://localhost:{INSECURE PORT}/OAT/",
```

```json
"inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/OAT/_framework/debug/ws-proxy?browser={browserInspectUri}",
```

For information on using a custom app base path for Blazor WebAssembly apps, see <xref:blazor/host-and-deploy/index#app-base-path>.

# [Visual Studio Code](#tab/visual-studio-code)

<h2 id="vscode">Debug standalone Blazor WebAssembly</h2>

For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

1. Open the standalone Blazor WebAssembly app in VS Code.

   You may receive a notification that additional setup is required to enable debugging:

   > Additional setup is required to debug Blazor WebAssembly applications.

   If you receive the notification:

   * Confirm that the latest [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) is installed. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.
   * When using the [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) **version 1.23.9 or later**, confirm that the latest [Blazor WASM Debugging Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.blazorwasm-companion) is installed. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.
   * Reload the window.

1. Create a `.vscode/launch.json` file with the following configuration. Replace the `{PORT}` placeholder with the port configured in `Properties/launchSettings.json`:

   ```json
   {
     "name": "Launch and Debug",
     "type": "blazorwasm",
     "request": "launch",
     "url": "https://localhost:{PORT}"
   }
   ```

1. Start debugging using the <kbd>F5</kbd> keyboard shortcut or the menu item.

   > [!NOTE]
   > **Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

1. The standalone app is launched, and a debugging browser is opened.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.

1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

## Debug hosted Blazor WebAssembly

For guidance on configuring VS Code assets in the `.vscode` folder and where to place the `.vscode` folder in the solution, see the **Linux** operating system guidance in <xref:blazor/tooling?pivots=linux>.

The `.vscode/launch.json` file sets the current working directory to the **`Server`** project's folder, typically `Server` for a hosted Blazor WebAssembly solution:

```json
"cwd": "${workspaceFolder}/Server"
```

If Microsoft Edge is used for debugging instead of Google Chrome, the `.vscode/launch.json` launch configuration sets the `browser` property:

```json
"browser": "edge"
```

The `.vscode/tasks.json` file adds the **`Server`** app's project file path to the `dotnet build` arguments under `args`. The **`Server`** project's folder is typically named `Server` in a solution based on the hosted Blazor WebAssembly project template. The following example uses the project file for the **`Server`** app of the [Blazor-SignalR tutorial](xref:blazor/tutorials/signalr-blazor), which has a project file named `BlazorWebAssemblySignalRApp.Server.csproj`:

```json
{
    ...
    "tasks": [
        {
            "label": "build",
            "command": "dotnet",
            "type": "shell",
            "args": [
                ...
                "${workspaceFolder}/Server/BlazorWebAssemblySignalRApp.Server.csproj",
                ...
            ],
            ...
        }
    ]
}
```

The **`Server`** project's `Properties/launchSettings.json` file includes the `inspectUri` property for the debugging proxy. The following example names the launch profile for the **`Server`** app of the [Blazor-SignalR tutorial](xref:blazor/tutorials/signalr-blazor), which is `BlazorWebAssemblySignalRApp.Server`:

```json
{
  "iisSettings": {
    ...
  },
  "profiles": {
    "IIS Express": {
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      ...
    },
    "BlazorWebAssemblySignalRApp.Server": {
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      ...
    }
  }
}
```

To debug a **published**, hosted Blazor WebAssembly app, configure debugger support (`DebuggerSupport`) and copy output symbols to the `publish` directory (`CopyOutputSymbolsToPublishDirectory`) in the **`Client`** app's project file:

```xml
<DebuggerSupport>true</DebuggerSupport>
<CopyOutputSymbolsToPublishDirectory>true</CopyOutputSymbolsToPublishDirectory>
```

By default, publishing an app disables the preceding properties by setting them to `false`.

> [!WARNING]
> Published, hosted Blazor WebAssembly apps should only enable debugging and copying output symbols when deploying published assets ***locally***. Do **not*** deploy a published app into production with the `DebuggerSupport` and `CopyOutputSymbolsToPublishDirectory` properties set to `true`.

## Attach to an existing debugging session

To attach to a running Blazor app, create a `.vscode/launch.json` file with the following configuration. Replace the `{URL}` placeholder with the URL where the app is running:

```json
{
  "name": "Attach and Debug"
  "type": "blazorwasm",
  "request": "attach",
  "url": "{URL}"
}
```

> [!NOTE]
> Attaching to a debugging session is only supported for standalone apps. To use full-stack debugging, you must launch the app from VS Code.

## Launch configuration options

The following launch configuration options are supported for the `blazorwasm` debug type (`.vscode/launch.json`).

| Option    | Description |
| --------- | ----------- |
| `request` | Use `launch` to launch and attach a debugging session to a Blazor WebAssembly app or `attach` to attach a debugging session to an already-running app. |
| `url`     | The URL to open in the browser when debugging. Defaults to `https://localhost:5001`. If the app is running at a different URL, an `about:blank` tab launches in the browser. |
| `browser` | The browser to launch for the debugging session. Set to `edge` or `chrome`. Defaults to `chrome`. |
| `trace`   | Used to generate logs from the JS debugger. Set to `true` to generate logs. |
| `hosted`  | Must be set to `true` if launching and debugging a hosted Blazor WebAssembly app. |
| `webRoot` | Specifies the absolute path of the web server. Should be set if an app is served from a sub-route. |
| `timeout` | The number of milliseconds to wait for the debugging session to attach. Defaults to 30,000 milliseconds (30 seconds). |
| `program` | A reference to the executable to run the server of the hosted app. Must be set if `hosted` is `true`. |
| `cwd`     | The working directory to launch the app under. Must be set if `hosted` is `true`. |
| `env`     | The environment variables to provide to the launched process. Only applicable if `hosted` is set to `true`. |

# [Visual Studio for Mac](#tab/visual-studio-mac)

To debug a Blazor WebAssembly app in Visual Studio for Mac:

1. Create a new hosted Blazor WebAssembly app.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to run the app in the debugger.

   > [!NOTE]
   > **Start Without Debugging** (<kbd>&#8997;</kbd>+<kbd>&#8984;</kbd>+<kbd>&#8617;</kbd>) isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

   > [!IMPORTANT]
   > Google Chrome or Microsoft Edge must be the selected browser for the debugging session.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.
1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint:
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to continue execution.

While debugging a Blazor WebAssembly app, you can also debug server code:

1. Set a breakpoint in the `Pages/FetchData.razor` page in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
1. Set a breakpoint in the `WeatherForecastController` in the `Get` action method.
1. Browse to the `Fetch Data` page to hit the first breakpoint in the `FetchData` component just before it issues an HTTP request to the server.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to continue execution and then hit the breakpoint on the server in the `WeatherForecastController`.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> again to let execution continue and see the weather forecast table rendered in the browser.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

For more information, see [Debugging with Visual Studio for Mac](/visualstudio/mac/debugging).

---

## Debug in the browser

*The guidance in this section applies to Google Chrome and Microsoft Edge running on Windows.*

1. Run a Debug build of the app in the Development environment.

1. Launch a browser and navigate to the app's URL (for example, `https://localhost:5001`).

1. In the browser, attempt to commence remote debugging by pressing <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd>.

   The browser must be running with remote debugging enabled, which isn't the default. If remote debugging is disabled, an **Unable to find debuggable browser tab** error page is rendered with instructions for launching the browser with the debugging port open. Follow the instructions for your browser, which opens a new browser window. Close the previous browser window.

<!-- HOLD 
1. In the browser, attempt to commence remote debugging by pressing:

   * <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd> on Windows.
   * <kbd>Shift</kbd>+<kbd>&#8984;</kbd>+<kbd>d</kbd> on macOS.

   The browser must be running with remote debugging enabled, which isn't the default. If remote debugging is disabled, an **Unable to find debuggable browser tab** error page is rendered with instructions for launching the browser with the debugging port open. Follow the instructions for your browser, which opens a new browser window. Close the previous browser window.
-->

1. Once the browser is running with remote debugging enabled, the debugging keyboard shortcut in the previous step opens a new debugger tab.

1. After a moment, the **Sources** tab shows a list of the app's .NET assemblies within the `file://` node.

1. In component code (`.razor` files) and C# code files (`.cs`), breakpoints that you set are hit when code executes. After a breakpoint is hit, single-step (<kbd>F10</kbd>) through the code or resume (<kbd>F8</kbd>) code execution normally.

Blazor provides a debugging proxy that implements the [Chrome DevTools Protocol](https://chromedevtools.github.io/devtools-protocol/) and augments the protocol with .NET-specific information. When debugging keyboard shortcut is pressed, Blazor points the Chrome DevTools at the proxy. The proxy connects to the browser window you're seeking to debug (hence the need to enable remote debugging).

## Browser source maps

Browser source maps allow the browser to map compiled files back to their original source files and are commonly used for client-side debugging. However, Blazor doesn't currently map C# directly to JavaScript/WASM. Instead, Blazor does IL interpretation within the browser, so source maps aren't relevant.

## Firewall configuration

If a firewall blocks communication with the debug proxy, create a firewall exception rule that permits communication between the browser and the `NodeJS` process.

> [!WARNING]
> Modification of a firewall configuration must be made with care to avoid creating security vulnerabilities. Carefully apply security guidance, follow best security practices, and respect warnings issued by the firewall's manufacturer.
>
> Permitting open communication with the `NodeJS` process:
>
> * Opens up the Node server to any connection, depending on the firewall's capabilities and configuration.
> * Might be risky depending on your network.
> * **Is only recommended on developer machines.**
>
> If possible, only allow open communication with the `NodeJS` process **on trusted or private networks**.

For [Windows Firewall](/windows/security/threat-protection/windows-firewall/windows-firewall-with-advanced-security) configuration guidance, see [Create an Inbound Program or Service Rule](/windows/security/threat-protection/windows-firewall/create-an-inbound-program-or-service-rule). For more information, see [Windows Defender Firewall with Advanced Security](/windows/security/threat-protection/windows-firewall/windows-firewall-with-advanced-security) and related articles in the Windows Firewall documentation set.

## Troubleshoot

If you're running into errors, the following tips may help:

* In the **Debugger** tab, open the developer tools in your browser. In the console, execute `localStorage.clear()` to remove any breakpoints.
* Confirm that you've installed and trusted the ASP.NET Core HTTPS development certificate. For more information, see <xref:security/enforcing-ssl#troubleshoot-certificate-problems-such-as-certificate-not-trusted>.
* Visual Studio requires the **Enable JavaScript debugging for ASP.NET (Chrome, Edge and IE)** option in **Tools** > **Options** > **Debugging** > **General**. This is the default setting for Visual Studio. If debugging isn't working, confirm that the option is selected.
* If your environment uses an HTTP proxy, make sure that `localhost` is included in the proxy bypass settings. This can be done by setting the `NO_PROXY` environment variable in either:
  * The `launchSettings.json` file for the project.
  * At the user or system environment variables level for it to apply to all apps. When using an environment variable, restart Visual Studio for the change to take effect.
* Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

### Breakpoints in `OnInitialized{Async}` not hit

The Blazor framework's debugging proxy takes a short time to launch, so breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) might not be hit. We recommend adding a delay at the start of the method body to give the debug proxy some time to launch before the breakpoint is hit. You can include the delay based on an [`if` compiler directive](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) to ensure that the delay isn't present for a release build of the app.

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A>:

```csharp
protected override void OnInitialized()
{
#if DEBUG
    Thread.Sleep(10000);
#endif

    ...
}
```

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>:

```csharp
protected override async Task OnInitializedAsync()
{
#if DEBUG
    await Task.Delay(10000);
#endif

    ...
}
```

### Visual Studio (Windows) timeout

If Visual Studio throws an exception that the debug adapter failed to launch mentioning that the timeout was reached, you can adjust the timeout with a Registry setting:

```console
VsRegEdit.exe set "<VSInstallFolder>" HKCU JSDebugger\Options\Debugging "BlazorTimeoutInMilliseconds" dword {TIMEOUT}
```

The `{TIMEOUT}` placeholder in the preceding command is in milliseconds. For example, one minute is assigned as `60000`.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Blazor WebAssembly apps can be debugged using the browser developer tools in Chromium-based browsers (Edge/Chrome). You can also debug your app using the following IDEs:

* Visual Studio
* Visual Studio for Mac
* Visual Studio Code

Available scenarios include:

* Set and remove breakpoints.
* Run the app with debugging support in IDEs.
* Single-step through the code.
* Resume code execution with a keyboard shortcut in IDEs.
* In the *Locals* window, observe the values of local variables.
* See the call stack, including call chains between JavaScript and .NET.

For now, you *can't*:

* Break on unhandled exceptions.
* Hit breakpoints during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.
* Debug in non-local scenarios (for example, [Windows Subsystem for Linux (WSL)](/windows/wsl/) or [Visual Studio Codespaces](/visualstudio/devinit/devinit-and-codespaces)).
* Automatically rebuild the backend `*Server*` app of a hosted Blazor WebAssembly solution during debugging, for example by running the app with [`dotnet watch run`](xref:tutorials/dotnet-watch).

## Prerequisites

Debugging requires either of the following browsers:

* Google Chrome (version 70 or later) (default)
* Microsoft Edge (version 80 or later)

Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

Visual Studio Code users require the following extensions:

* [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Blazor WASM Debugging Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.blazorwasm-companion) (when using the C# for Visual Studio Code Extension version 1.23.9 or later)

After opening a project in VS Code, you may receive a notification that additional setup is required to enable debugging. If requested, install the required extensions from the Visual Studio Marketplace. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.

Visual Studio for Mac requires version 8.8 (build 1532) or later:

1. Install the latest release of Visual Studio for Mac by selecting the **Download Visual Studio for Mac** button at [Microsoft: Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
1. Select the *Preview* channel from within Visual Studio. For more information, see [Install a preview version of Visual Studio for Mac](/visualstudio/mac/install-preview).

> [!NOTE]
> Apple Safari on macOS isn't currently supported.

## Debug a standalone Blazor WebAssembly app

To enable debugging for an existing Blazor WebAssembly app, update the `launchSettings.json` file in the startup project to include the following `inspectUri` property in each launch profile:

```json
"inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}"
```

Once updated, the `launchSettings.json` file should look similar to the following example:

[!code-json[](~/blazor/debug/launchSettings.json?highlight=14,22)]

The `inspectUri` property:

* Enables the IDE to detect that the app is a Blazor WebAssembly app.
* Instructs the script debugging infrastructure to connect to the browser through Blazor's debugging proxy.

The placeholder values for the WebSocket protocol (`wsProtocol`), host (`url.hostname`), port (`url.port`), and inspector URI on the launched browser (`browserInspectUri`) are provided by the framework.

# [Visual Studio](#tab/visual-studio)

To debug a Blazor WebAssembly app in Visual Studio:

1. Create a new hosted Blazor WebAssembly solution.
1. With the **`Server`** project selected in **Solution Explorer**, press <kbd>F5</kbd> to run the app in the debugger.

   > [!NOTE]
   > When debugging with a Chromium-based browser, such as Google Chrome or Microsoft Edge, a new browser window might open with a separate profile for the debugging session instead of opening a tab in an existing browser window with the user's profile. If debugging with the user's profile is a requirement, adopt **one** of the following approaches:
   >
   > * Close all open browser instances before pressing <kbd>F5</kbd> to start debugging.
   > * Configure Visual Studio to launch the browser with the user's profile. For more information on this approach, see [Blazor WASM Debugging in VS launches Edge with a separate user data directory (dotnet/aspnetcore #20915)](https://github.com/dotnet/aspnetcore/issues/20915#issuecomment-614933322).

   > [!NOTE]
   > **Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.
1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint.
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>F5</kbd> to continue execution.

While debugging a Blazor WebAssembly app, you can also debug server code:

1. Set a breakpoint in the `Pages/FetchData.razor` page in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
1. Set a breakpoint in the `WeatherForecastController` in the `Get` action method.
1. Browse to the `Fetch Data` page to hit the first breakpoint in the `FetchData` component just before it issues an HTTP request to the server.
1. Press <kbd>F5</kbd> to continue execution and then hit the breakpoint on the server in the `WeatherForecastController`.
1. Press <kbd>F5</kbd> again to let execution continue and see the weather forecast table rendered in the browser.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

If the app is hosted at a different [app base path](xref:blazor/host-and-deploy/index#app-base-path) than `/`, update the following properties in `Properties/launchSettings.json` to reflect the app's base path:

* `applicationUrl`:

  ```json
  "iisSettings": {
    ...
    "iisExpress": {
      "applicationUrl": "http://localhost:{INSECURE PORT}/{APP BASE PATH}/",
      "sslPort": {SECURE PORT}
    }
  },
  ```

* `inspectUri` of each profile:

  ```json
  "profiles": {
    ...
    "{PROFILE 1, 2, ... N}": {
      ...
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/{APP BASE PATH}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      ...
    }
  }
  ```

The placeholders in the preceding settings:

* `{INSECURE PORT}`: The insecure port. A random value is provided by default, but a custom port is permitted.
* `{APP BASE PATH}`: The app's base path.
* `{SECURE PORT}`: The secure port. A random value is provided by default, but a custom port is permitted.
* `{PROFILE 1, 2, ... N}`: Launch settings profiles. Usually, an app specifies more than one profile by default (for example, a profile for IIS Express and a project profile, which is used by Kestrel server).

In the following examples, the app is hosted at `/OAT` with an app base path configured in `wwwroot/index.html` as `<base href="/OAT/">`:

```json
"applicationUrl": "http://localhost:{INSECURE PORT}/OAT/",
```

```json
"inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/OAT/_framework/debug/ws-proxy?browser={browserInspectUri}",
```

For information on using a custom app base path for Blazor WebAssembly apps, see <xref:blazor/host-and-deploy/index#app-base-path>.

# [Visual Studio Code](#tab/visual-studio-code)

<h2 id="vscode">Debug standalone Blazor WebAssembly</h2>

For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

1. Open the standalone Blazor WebAssembly app in VS Code.

   You may receive a notification that additional setup is required to enable debugging:

   > Additional setup is required to debug Blazor WebAssembly applications.

   If you receive the notification:

   * Confirm that the latest [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) is installed. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.
   * When using the [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) **version 1.23.9 or later**, confirm that the latest [Blazor WASM Debugging Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.blazorwasm-companion) is installed. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.
   * Reload the window.

1. Create a `.vscode/launch.json` file with the following configuration. Replace the `{PORT}` placeholder with the port configured in `Properties/launchSettings.json`:

   ```json
   {
     "name": "Launch and Debug",
     "type": "blazorwasm",
     "request": "launch",
     "url": "https://localhost:{PORT}"
   }
   ```

1. Start debugging using the <kbd>F5</kbd> keyboard shortcut or the menu item.

   > [!NOTE]
   > **Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

1. The standalone app is launched, and a debugging browser is opened.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.

1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

## Debug hosted Blazor WebAssembly

For guidance on configuring VS Code assets in the `.vscode` folder and where to place the `.vscode` folder in the solution, see the **Linux** operating system guidance in <xref:blazor/tooling?pivots=linux>.

The `.vscode/launch.json` file sets the current working directory to the **`Server`** project's folder, typically `Server` for a hosted Blazor WebAssembly solution:

```json
"cwd": "${workspaceFolder}/Server"
```

If Microsoft Edge is used for debugging instead of Google Chrome, the `.vscode/launch.json` launch configuration sets the `browser` property:

```json
"browser": "edge"
```

The `.vscode/tasks.json` file adds the **`Server`** app's project file path to the `dotnet build` arguments under `args`. The **`Server`** project's folder is typically named `Server` in a solution based on the hosted Blazor WebAssembly project template. The following example uses the project file for the **`Server`** app of the [Blazor-SignalR tutorial](xref:blazor/tutorials/signalr-blazor), which has a project file named `BlazorWebAssemblySignalRApp.Server.csproj`:

```json
{
    ...
    "tasks": [
        {
            "label": "build",
            "command": "dotnet",
            "type": "shell",
            "args": [
                ...
                "${workspaceFolder}/Server/BlazorWebAssemblySignalRApp.Server.csproj",
                ...
            ],
            ...
        }
    ]
}
```

The **`Server`** project's `Properties/launchSettings.json` file includes the `inspectUri` property for the debugging proxy. The following example names the launch profile for the **`Server`** app of the [Blazor-SignalR tutorial](xref:blazor/tutorials/signalr-blazor), which is `BlazorWebAssemblySignalRApp.Server`:

```json
{
  "iisSettings": {
    ...
  },
  "profiles": {
    "IIS Express": {
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      ...
    },
    "BlazorWebAssemblySignalRApp.Server": {
      "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
      ...
    }
  }
}
```

## Attach to an existing debugging session

To attach to a running Blazor app, create a `.vscode/launch.json` file with the following configuration. Replace the `{URL}` placeholder with the URL where the app is running:

```json
{
  "name": "Attach and Debug"
  "type": "blazorwasm",
  "request": "attach",
  "url": "{URL}"
}
```

> [!NOTE]
> Attaching to a debugging session is only supported for standalone apps. To use full-stack debugging, you must launch the app from VS Code.

## Launch configuration options

The following launch configuration options are supported for the `blazorwasm` debug type (`.vscode/launch.json`).

| Option    | Description |
| --------- | ----------- |
| `request` | Use `launch` to launch and attach a debugging session to a Blazor WebAssembly app or `attach` to attach a debugging session to an already-running app. |
| `url`     | The URL to open in the browser when debugging. Defaults to `https://localhost:5001`. If the app is running at a different URL, an `about:blank` tab launches in the browser. |
| `browser` | The browser to launch for the debugging session. Set to `edge` or `chrome`. Defaults to `chrome`. |
| `trace`   | Used to generate logs from the JS debugger. Set to `true` to generate logs. |
| `hosted`  | Must be set to `true` if launching and debugging a hosted Blazor WebAssembly app. |
| `webRoot` | Specifies the absolute path of the web server. Should be set if an app is served from a sub-route. |
| `timeout` | The number of milliseconds to wait for the debugging session to attach. Defaults to 30,000 milliseconds (30 seconds). |
| `program` | A reference to the executable to run the server of the hosted app. Must be set if `hosted` is `true`. |
| `cwd`     | The working directory to launch the app under. Must be set if `hosted` is `true`. |
| `env`     | The environment variables to provide to the launched process. Only applicable if `hosted` is set to `true`. |

# [Visual Studio for Mac](#tab/visual-studio-mac)

To debug a Blazor WebAssembly app in Visual Studio for Mac:

1. Create a new hosted Blazor WebAssembly app.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to run the app in the debugger.

   > [!NOTE]
   > **Start Without Debugging** (<kbd>&#8997;</kbd>+<kbd>&#8984;</kbd>+<kbd>&#8617;</kbd>) isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

   > [!IMPORTANT]
   > Google Chrome or Microsoft Edge must be the selected browser for the debugging session.

1. In the `*Client*` app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.
1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint:
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to continue execution.

While debugging a Blazor WebAssembly app, you can also debug server code:

1. Set a breakpoint in the `Pages/FetchData.razor` page in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
1. Set a breakpoint in the `WeatherForecastController` in the `Get` action method.
1. Browse to the `Fetch Data` page to hit the first breakpoint in the `FetchData` component just before it issues an HTTP request to the server.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> to continue execution and then hit the breakpoint on the server in the `WeatherForecastController`.
1. Press <kbd>&#8984;</kbd>+<kbd>&#8617;</kbd> again to let execution continue and see the weather forecast table rendered in the browser.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

For more information, see [Debugging with Visual Studio for Mac](/visualstudio/mac/debugging).

---

## Debug in the browser

*The guidance in this section applies to Google Chrome and Microsoft Edge running on Windows.*

1. Run a Debug build of the app in the Development environment.

1. Launch a browser and navigate to the app's URL (for example, `https://localhost:5001`).

1. In the browser, attempt to commence remote debugging by pressing <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd>.

   The browser must be running with remote debugging enabled, which isn't the default. If remote debugging is disabled, an **Unable to find debuggable browser tab** error page is rendered with instructions for launching the browser with the debugging port open. Follow the instructions for your browser, which opens a new browser window. Close the previous browser window.

<!-- HOLD 
1. In the browser, attempt to commence remote debugging by pressing:

   * <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd> on Windows.
   * <kbd>Shift</kbd>+<kbd>&#8984;</kbd>+<kbd>d</kbd> on macOS.

   The browser must be running with remote debugging enabled, which isn't the default. If remote debugging is disabled, an **Unable to find debuggable browser tab** error page is rendered with instructions for launching the browser with the debugging port open. Follow the instructions for your browser, which opens a new browser window. Close the previous browser window.
-->

1. Once the browser is running with remote debugging enabled, the debugging keyboard shortcut in the previous step opens a new debugger tab.

1. After a moment, the **Sources** tab shows a list of the app's .NET assemblies within the `file://` node.

1. In component code (`.razor` files) and C# code files (`.cs`), breakpoints that you set are hit when code executes. After a breakpoint is hit, single-step (<kbd>F10</kbd>) through the code or resume (<kbd>F8</kbd>) code execution normally.

Blazor provides a debugging proxy that implements the [Chrome DevTools Protocol](https://chromedevtools.github.io/devtools-protocol/) and augments the protocol with .NET-specific information. When debugging keyboard shortcut is pressed, Blazor points the Chrome DevTools at the proxy. The proxy connects to the browser window you're seeking to debug (hence the need to enable remote debugging).

## Browser source maps

Browser source maps allow the browser to map compiled files back to their original source files and are commonly used for client-side debugging. However, Blazor doesn't currently map C# directly to JavaScript/WASM. Instead, Blazor does IL interpretation within the browser, so source maps aren't relevant.

## Firewall configuration

If a firewall blocks communication with the debug proxy, create a firewall exception rule that permits communication between the browser and the `NodeJS` process.

> [!WARNING]
> Modification of a firewall configuration must be made with care to avoid creating security vulnerabilities. Carefully apply security guidance, follow best security practices, and respect warnings issued by the firewall's manufacturer.
>
> Permitting open communication with the `NodeJS` process:
>
> * Opens up the Node server to any connection, depending on the firewall's capabilities and configuration.
> * Might be risky depending on your network.
> * **Is only recommended on developer machines.**
>
> If possible, only allow open communication with the `NodeJS` process **on trusted or private networks**.

For [Windows Firewall](/windows/security/threat-protection/windows-firewall/windows-firewall-with-advanced-security) configuration guidance, see [Create an Inbound Program or Service Rule](/windows/security/threat-protection/windows-firewall/create-an-inbound-program-or-service-rule). For more information, see [Windows Defender Firewall with Advanced Security](/windows/security/threat-protection/windows-firewall/windows-firewall-with-advanced-security) and related articles in the Windows Firewall documentation set.

## Troubleshoot

If you're running into errors, the following tips may help:

* In the **Debugger** tab, open the developer tools in your browser. In the console, execute `localStorage.clear()` to remove any breakpoints.
* Confirm that you've installed and trusted the ASP.NET Core HTTPS development certificate. For more information, see <xref:security/enforcing-ssl#troubleshoot-certificate-problems-such-as-certificate-not-trusted>.
* Visual Studio requires the **Enable JavaScript debugging for ASP.NET (Chrome, Edge and IE)** option in **Tools** > **Options** > **Debugging** > **General**. This is the default setting for Visual Studio. If debugging isn't working, confirm that the option is selected.
* If your environment uses an HTTP proxy, make sure that `localhost` is included in the proxy bypass settings. This can be done by setting the `NO_PROXY` environment variable in either:
  * The `launchSettings.json` file for the project.
  * At the user or system environment variables level for it to apply to all apps. When using an environment variable, restart Visual Studio for the change to take effect.
* Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

### Breakpoints in `OnInitialized{Async}` not hit

The Blazor framework's debugging proxy takes a short time to launch, so breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) might not be hit. We recommend adding a delay at the start of the method body to give the debug proxy some time to launch before the breakpoint is hit. You can include the delay based on an [`if` compiler directive](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) to ensure that the delay isn't present for a release build of the app.

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A>:

```csharp
protected override void OnInitialized()
{
#if DEBUG
    Thread.Sleep(10000);
#endif

    ...
}
```

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>:

```csharp
protected override async Task OnInitializedAsync()
{
#if DEBUG
    await Task.Delay(10000);
#endif

    ...
}
```

### Visual Studio (Windows) timeout

If Visual Studio throws an exception that the debug adapter failed to launch mentioning that the timeout was reached, you can adjust the timeout with a Registry setting:

```console
VsRegEdit.exe set "<VSInstallFolder>" HKCU JSDebugger\Options\Debugging "BlazorTimeoutInMilliseconds" dword {TIMEOUT}
```

The `{TIMEOUT}` placeholder in the preceding command is in milliseconds. For example, one minute is assigned as `60000`.

:::moniker-end
