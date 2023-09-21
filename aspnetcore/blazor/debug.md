---
title: Debug ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to debug Blazor WebAssembly with browser developer tools and an integrated development environment (IDE).
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/debug
---
# Debug ASP.NET Core Blazor WebAssembly

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes how to debug Blazor WebAssembly with browser developer tools and an integrated development environment (IDE).

:::moniker range=">= aspnetcore-8.0"

Blazor WebAssembly apps can be debugged using the browser developer tools in Chromium-based browsers (Edge/Chrome) and Firefox. You can also debug your app using the following IDEs:

* Visual Studio
* Visual Studio Code

Available scenarios include:

* Set and remove breakpoints.
* Run the app with debugging support in IDEs.
* Single-step through the code.
* Resume code execution with a keyboard shortcut in IDEs.
* In the *Locals* window, observe the values of local variables.
* See the call stack, including call chains between JavaScript and .NET.
* Use a [symbol server](xref:test/debug-aspnetcore-source) for debugging, configured by Visual Studio preferences.

For now, you *can't*:

* Break on unhandled exceptions.
* Hit breakpoints during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.
* Debug in non-local scenarios (for example, [Windows Subsystem for Linux (WSL)](/windows/wsl/) or [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/github-codespaces/)).

* Debug in Firefox from Visual Studio.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Blazor WebAssembly apps can be debugged using the browser developer tools in Chromium-based browsers (Edge/Chrome). You can also debug your app using the following IDEs:

* Visual Studio
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
* Debug in non-local scenarios (for example, [Windows Subsystem for Linux (WSL)](/windows/wsl/) or [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/github-codespaces/)).
* Use a [symbol server](xref:test/debug-aspnetcore-source) for debugging.

:::moniker-end

## Prerequisites

:::moniker range=">= aspnetcore-8.0"

Debugging requires the latest version of the following browsers:

* Google Chrome
* Microsoft Edge
* Firefox

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Debugging requires the latest version of the following browsers:

* Google Chrome (default)
* Microsoft Edge

:::moniker-end

Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

:::moniker range=">= aspnetcore-6.0"

Visual Studio Code users require the [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Visual Studio Code users require the following extensions:

* [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [Blazor WASM Debugging Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.blazorwasm-companion) (when using the C# for Visual Studio Code Extension version 1.23.9 or later)

After opening a project in VS Code, you may receive a notification that additional setup is required to enable debugging. If requested, install the required extensions from the Visual Studio Marketplace. To inspect the installed extensions, open **View** > **Extensions** from the menu bar or select the **Extensions** icon in the **Activity** sidebar.

:::moniker-end

> [!NOTE]
> Apple Safari on macOS isn't currently supported.

## Packages

Standalone Blazor WebAssembly: [`Microsoft.AspNetCore.Components.WebAssembly.DevServer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer): Development server for use when building Blazor apps. Calls <xref:Microsoft.AspNetCore.Builder.WebAssemblyNetDebugProxyAppBuilderExtensions.UseWebAssemblyDebugging%2A?displayProperty=nameWithType> internally to add middleware for debugging Blazor WebAssembly apps inside Chromium developer tools.

<!-- UPDATE 8.0 Although this isn't going to be true
     for hosted WASM, it might still be true for debugging
     client-side of BWAs. Will need to sort this out later. 

Hosted Blazor WebAssembly:

* **:::no-loc text="Client":::** project: [`Microsoft.AspNetCore.Components.WebAssembly.DevServer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer): Development server for use when building Blazor apps. Calls <xref:Microsoft.AspNetCore.Builder.WebAssemblyNetDebugProxyAppBuilderExtensions.UseWebAssemblyDebugging%2A?displayProperty=nameWithType> internally to add middleware for debugging Blazor WebAssembly apps inside Chromium developer tools.
* **:::no-loc text="Server":::** project: [`Microsoft.AspNetCore.Components.WebAssembly.Server`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Server): References an internal package ([`Microsoft.NETCore.BrowserDebugHost.Transport`](https://github.com/dotnet/runtime/blob/main/src/mono/nuget/Microsoft.NETCore.BrowserDebugHost.Transport/Microsoft.NETCore.BrowserDebugHost.Transport.pkgproj)) for assemblies that share the browser debug host.

[!INCLUDE[](~/includes/package-reference.md)]

-->

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

<!-- UPDATE 8.0 Need to update this for BWA. There's an issue
     to track updates for this article at 
     https://github.com/dotnet/AspNetCore.Docs/issues/30170

1. Create a new hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln).
1. With the **:::no-loc text="Server":::** project selected in **Solution Explorer**, press <kbd>F5</kbd> to run the app in the debugger.

   > [!NOTE]
   > When debugging with a Chromium-based browser, such as Google Chrome or Microsoft Edge, a new browser window might open with a separate profile for the debugging session instead of opening a tab in an existing browser window with the user's profile. If debugging with the user's profile is a requirement, adopt **one** of the following approaches:
   >
   > * Close all open browser instances before pressing <kbd>F5</kbd> to start debugging.
   > * Configure Visual Studio to launch the browser with the user's profile. For more information on this approach, see [Blazor WASM Debugging in VS launches Edge with a separate user data directory (dotnet/aspnetcore #20915)](https://github.com/dotnet/aspnetcore/issues/20915#issuecomment-614933322).

   > [!NOTE]
   > **Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

1. In the **:::no-loc text="Client":::** app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.
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

<h2 id="vscode">Debug standalone Blazor WebAssembly</h2>

-->

For information on configuring VS Code assets in the `.vscode` folder, see the **Linux** operating system guidance in <xref:blazor/tooling>.

To debug a Blazor WebAssembly app in Visual Studio:

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
     "url": "http://localhost:{PORT}"
   }
   ```

   If the app is in a subfolder of the workspace root, include the current working directory (`cwd`) property with the path to the app. In the following property value, replace the `{PATH}` placeholder with the path to the app:
   
   ```json
   "cwd": "${workspaceFolder}/{PATH}"
   ```
   
   In the following example, the app is in a subfolder named `blazorwasm`:
   
   ```json
   "cwd": "${workspaceFolder}/blazorwasm"
   ```

1. Start debugging using the <kbd>F5</kbd> keyboard shortcut or the menu command.

   > [!NOTE]
   > **Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

1. The standalone app is launched, and a debugging browser is opened.

1. In the **:::no-loc text="Client":::** app, set a breakpoint on the `currentCount++;` line in `Pages/Counter.razor`.

1. In the browser, navigate to `Counter` page and select the **Click me** button to hit the breakpoint.

> [!NOTE]
> Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in `Program.cs` and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

<!-- UPDATE 8.0 Need to update this for BWA. There's an issue
     to track updates for this article at 
     https://github.com/dotnet/AspNetCore.Docs/issues/30170

## Debug hosted Blazor WebAssembly

For guidance on configuring VS Code assets in the `.vscode` folder and where to place the `.vscode` folder in the [solution](xref:blazor/tooling#visual-studio-solution-file-sln), see the **Linux** operating system guidance in <xref:blazor/tooling?pivots=linux>.

:::moniker range=">= aspnetcore-6.0"

> [!NOTE]
> Only [browser debugging](#debug-in-the-browser) is supported at this time.
>
> You can't automatically rebuild the backend **:::no-loc text="Server":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) during debugging, for example by running the app with [`dotnet watch run`](xref:tutorials/dotnet-watch).

To debug a **published**, hosted Blazor WebAssembly app, configure debugger support (`DebuggerSupport`) and copy output symbols to the `publish` directory (`CopyOutputSymbolsToPublishDirectory`) in the **:::no-loc text="Client":::** app's project file:

```xml
<DebuggerSupport>true</DebuggerSupport>
<CopyOutputSymbolsToPublishDirectory>true</CopyOutputSymbolsToPublishDirectory>
```

By default, publishing an app disables the preceding properties by setting them to `false`.

> [!WARNING]
> Published, hosted Blazor WebAssembly apps should only enable debugging and copying output symbols when deploying published assets ***locally***. Do **not*** deploy a published app into production with the `DebuggerSupport` and `CopyOutputSymbolsToPublishDirectory` properties set to `true`.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

For guidance on configuring VS Code assets in the `.vscode` folder and where to place the `.vscode` folder in the [solution](xref:blazor/tooling#visual-studio-solution-file-sln), see the **Linux** operating system guidance in <xref:blazor/tooling?pivots=linux>.

The `.vscode/launch.json` file sets the current working directory to the **:::no-loc text="Server":::** project's folder, typically :::no-loc text="Server"::: for a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln):

```json
"cwd": "${workspaceFolder}/Server"
```

If Microsoft Edge is used for debugging instead of Google Chrome, the `.vscode/launch.json` launch configuration sets the `browser` property:

```json
"browser": "edge"
```

The `.vscode/tasks.json` file adds the **:::no-loc text="Server":::** app's project file path to the `dotnet build` arguments under `args`. The **:::no-loc text="Server":::** project's folder is typically named :::no-loc text="Server"::: in a [solution](xref:blazor/tooling#visual-studio-solution-file-sln) based on the hosted Blazor WebAssembly project template. The following example uses the project file for the **:::no-loc text="Server":::** app of the [Blazor-SignalR tutorial](xref:blazor/tutorials/signalr-blazor), which has a project file named `BlazorWebAssemblySignalRApp.Server.csproj`:

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

The **:::no-loc text="Server":::** project's `Properties/launchSettings.json` file includes the `inspectUri` property for the debugging proxy. The following example names the launch profile for the **:::no-loc text="Server":::** app of the [Blazor-SignalR tutorial](xref:blazor/tutorials/signalr-blazor), which is `BlazorWebAssemblySignalRApp.Server`:

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

To debug a **published**, hosted Blazor WebAssembly app, configure debugger support (`DebuggerSupport`) and copy output symbols to the `publish` directory (`CopyOutputSymbolsToPublishDirectory`) in the **:::no-loc text="Client":::** app's project file:

```xml
<DebuggerSupport>true</DebuggerSupport>
<CopyOutputSymbolsToPublishDirectory>true</CopyOutputSymbolsToPublishDirectory>
```

By default, publishing an app disables the preceding properties by setting them to `false`.

> [!WARNING]
> Published, hosted Blazor WebAssembly apps should only enable debugging and copying output symbols when deploying published assets ***locally***. Do **not*** deploy a published app into production with the `DebuggerSupport` and `CopyOutputSymbolsToPublishDirectory` properties set to `true`.

:::moniker-end

-->

## Attach to an existing debugging session

To attach to a running Blazor app, create a `.vscode/launch.json` file with the following configuration. Replace the `{URL}` placeholder with the URL where the app is running:

```json
{
  "name": "Attach and Debug",
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
| `browser` | The browser to launch for the debugging session. Set to `edge` or `chrome`. Defaults to `edge`. |
| `cwd`     | The working directory to launch the app under. |
| `request` | Use `launch` to launch and attach a debugging session to a Blazor WebAssembly app or `attach` to attach a debugging session to an already-running app. |
| `timeout` | The number of milliseconds to wait for the debugging session to attach. Defaults to 30,000 milliseconds (30 seconds). |
| `trace`   | Used to generate logs from the JS debugger. Set to `true` to generate logs. |
| `url`     | The URL to open in the browser when debugging. |
| `webRoot` | Specifies the absolute path of the web server. Should be set if an app is served from a sub-route. |

<!-- UPDATE 8.0 Holding for BWA/8.0 updates 

| `hosted`  | Must be set to `true` if launching and debugging a hosted Blazor WebAssembly app. |
| `program` | A reference to the executable to run the server of the hosted app. Must be set if `hosted` is `true`. |
| `env`     | The environment variables to provide to the launched process. Only applicable if `hosted` is set to `true`. |

-->

---

## Debug in the browser

*The guidance in this section applies to Google Chrome and Microsoft Edge running on Windows.*

1. Run a Debug build of the app in the Development environment.

1. Launch a browser and navigate to the app's URL.

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

:::moniker range=">= aspnetcore-8.0"

## Debug with Firefox

Debugging Blazor WebAssembly apps with Firefox requires configuring the browser for remote debugging and connecting to the browser using the browser developer tools through the .NET WebAssembly debugging proxy.

> [!NOTE]
> Debugging in Firefox from Visual Studio isn't supported at this time.

To debug a Blazor WebAssembly app in Firefox during development:

1. Open the Blazor WebAssembly app in Firefox.
1. Open the Firefox Web Developer Tools and go to the `Console` tab.
1. With Blazor WebAssembly app in focus, type the debugging command <kbd>SHIFT</kbd>+<kbd>ALT</kbd>+<kbd>D</kbd>.
1. Follow the instructions in the console output to configure Firefox for Blazor WebAssembly debugging:
   * Open `about:config` in Firefox.
   * Enable `devtools.debugger.remote-enabled`.
   * Enable `devtools.chrome.enabled`.
   * Disable `devtools.debugger.prompt-connection`.
1. Close all Firefox instances and reopen Firefox with remote debugging enabled by running the following command in a command shell: `firefox --start-debugger-server 6000 -new-tab about:debugging`.
1. In the new Firefox instance, leave the `about:debugging` tab open and open the Blazor WebAssembly app in a new browser tab.
1. Type <kbd>SHIFT</kbd>+<kbd>ALT</kbd> to open the Firefox Web Developer tools and connect to the Firefox browser instance.
1. In the `Debugger` tab, open the app source file you wish to debug under the `file://` node and set a breakpoint. For example, set a breakpoint in the `IncrementCount` method of the `Counter` component (`Counter.razor`).
1. Navigate to the `Counter` component page (`/counter`) and select the counter button to hit the breakpoint.

:::moniker-end

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
