---
title: Debug ASP.NET Core Blazor apps
author: guardrex
description: Learn how to debug Blazor apps, including debugging Blazor WebAssembly with browser developer tools or an integrated development environment (IDE).
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/debug
---
# Debug ASP.NET Core apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes how to debug Blazor apps, including debugging Blazor WebAssembly apps with browser developer tools or an integrated development environment (IDE).

:::moniker range=">= aspnetcore-8.0"

Blazor Web Apps can be debugged in an IDE, Visual Studio or Visual Studio Code.

Blazor WebAssembly apps can be debugged:

* In an IDE, Visual Studio or Visual Studio Code.
* Using browser developer tools in Chromium-based browsers, including Microsoft Edge and Google Chrome, and Firefox.

Available scenarios for Blazor WebAssembly debugging include:

* Set and remove breakpoints.
* Run the app with debugging support in IDEs.
* Single-step through the code.
* Resume code execution with a keyboard shortcut in IDEs.
* In the *Locals* window, observe the values of local variables.
* See the call stack, including call chains between JavaScript and .NET.
* Use a [symbol server](xref:test/debug-aspnetcore-source) for debugging, configured by Visual Studio preferences.

Unsupported scenarios include:

* Debug in non-local scenarios (for example, [Windows Subsystem for Linux (WSL)](/windows/wsl/) or [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/github-codespaces/)).
* Debug in Firefox from Visual Studio or Visual Studio Code.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Blazor Server apps can be debugged in an IDE, Visual Studio or Visual Studio Code.

Blazor WebAssembly apps can be debugged:

* In an IDE, Visual Studio or Visual Studio Code.
* Using browser developer tools in Chromium-based browsers, including Microsoft Edge and Google Chrome.

Unsupported scenarios for Blazor WebAssembly apps include:

* Set and remove breakpoints.
* Run the app with debugging support in IDEs.
* Single-step through the code.
* Resume code execution with a keyboard shortcut in IDEs.
* In the *Locals* window, observe the values of local variables.
* See the call stack, including call chains between JavaScript and .NET.
* Debug in non-local scenarios (for example, [Windows Subsystem for Linux (WSL)](/windows/wsl/) or [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/github-codespaces/)).
* Use a [symbol server](xref:test/debug-aspnetcore-source) for debugging.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Blazor Server apps can be debugged in an IDE, Visual Studio or Visual Studio Code.

Blazor WebAssembly apps can be debugged:

* In an IDE, Visual Studio or Visual Studio Code.
* Using browser developer tools in Chromium-based browsers, including Microsoft Edge and Google Chrome.

Unsupported scenarios for Blazor WebAssembly apps include:

* Set and remove breakpoints.
* Run the app with debugging support in IDEs.
* Single-step through the code.
* Resume code execution with a keyboard shortcut in IDEs.
* In the *Locals* window, observe the values of local variables.
* See the call stack, including call chains between JavaScript and .NET.
* Hit breakpoints during app startup before the debug proxy is running. This includes breakpoints in the `Program` file and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.
* Debug in non-local scenarios (for example, [Windows Subsystem for Linux (WSL)](/windows/wsl/) or [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/github-codespaces/)).
* Use a [symbol server](xref:test/debug-aspnetcore-source) for debugging.

:::moniker-end

> [!NOTE]
> Guidance in this article that focuses on using Visual Studio or Visual Studio Code only supports the latest release of the tooling. Confirm that you've updated your IDE to the latest released version.
>
> For Visual Studio Code, the [C# Dev Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) ([Getting Started with C# in VS Code](https://code.visualstudio.com/docs/csharp/get-started)) is a preview product. The guidance in this article should work with the C# Dev Kit. If you encounter warnings or errors, you can [open an issue (microsoft/vscode-dotnettools GitHub repository)](https://github.com/microsoft/vscode-dotnettools/issues) describing the problem.

## Prerequisites

:::moniker range=">= aspnetcore-8.0"

Debugging requires the latest version of the following browsers:

* Google Chrome
* Microsoft Edge
* Firefox (browser developer tools only)

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Debugging requires the latest version of the following browsers:

* Google Chrome (default)
* Microsoft Edge

:::moniker-end

Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

> [!NOTE]
> Apple Safari on macOS isn't currently supported.

### App configuration prerequisites

Open the `Properties/launchSettings.json` file of the startup project. Confirm the presence of the following `inspectUri` property in each launch profile of the file's `profiles` node. If the following property isn't present, add it to each profile:

```json
"inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}"
```

The `inspectUri` property:

* Enables the IDE to detect that the app is a Blazor WebAssembly app.
* Instructs the script debugging infrastructure to connect to the browser through Blazor's debugging proxy.

The placeholder values for the WebSocket protocol (`wsProtocol`), host (`url.hostname`), port (`url.port`), and inspector URI on the launched browser (`browserInspectUri`) are provided by the framework.

### Visual Studio Code prerequisites

Visual Studio Code requires the [C# for Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

> [!NOTE]
> The [C# Dev Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) ([Getting Started with C# in VS Code](https://code.visualstudio.com/docs/csharp/get-started)) automatically installs the C# for Visual Studio Code Extension.

## Packages

:::moniker range=">= aspnetcore-8.0"

Blazor Web Apps: [`Microsoft.AspNetCore.Components.WebAssembly.Server`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Server): References an internal package ([`Microsoft.NETCore.BrowserDebugHost.Transport`](https://github.com/dotnet/runtime/blob/main/src/mono/nuget/Microsoft.NETCore.BrowserDebugHost.Transport/Microsoft.NETCore.BrowserDebugHost.Transport.pkgproj)) for assemblies that share the browser debug host.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Blazor Server: [`Microsoft.AspNetCore.Components.WebAssembly.Server`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Server): References an internal package ([`Microsoft.NETCore.BrowserDebugHost.Transport`](https://github.com/dotnet/runtime/blob/main/src/mono/nuget/Microsoft.NETCore.BrowserDebugHost.Transport/Microsoft.NETCore.BrowserDebugHost.Transport.pkgproj)) for assemblies that share the browser debug host.

:::moniker-end

Standalone Blazor WebAssembly: [`Microsoft.AspNetCore.Components.WebAssembly.DevServer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer): Development server for use when building Blazor apps. Calls <xref:Microsoft.AspNetCore.Builder.WebAssemblyNetDebugProxyAppBuilderExtensions.UseWebAssemblyDebugging%2A?displayProperty=nameWithType> internally to add middleware for debugging Blazor WebAssembly apps inside Chromium developer tools.

:::moniker range="< aspnetcore-8.0"

Hosted Blazor WebAssembly:

* **:::no-loc text="Client":::** project: [`Microsoft.AspNetCore.Components.WebAssembly.DevServer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer): Development server for use when building Blazor apps. Calls <xref:Microsoft.AspNetCore.Builder.WebAssemblyNetDebugProxyAppBuilderExtensions.UseWebAssemblyDebugging%2A?displayProperty=nameWithType> internally to add middleware for debugging Blazor WebAssembly apps inside Chromium developer tools.
* **:::no-loc text="Server":::** project: [`Microsoft.AspNetCore.Components.WebAssembly.Server`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Server): References an internal package ([`Microsoft.NETCore.BrowserDebugHost.Transport`](https://github.com/dotnet/runtime/blob/main/src/mono/nuget/Microsoft.NETCore.BrowserDebugHost.Transport/Microsoft.NETCore.BrowserDebugHost.Transport.pkgproj)) for assemblies that share the browser debug host.

:::moniker-end

[!INCLUDE[](~/includes/package-reference.md)]

:::moniker range=">= aspnetcore-8.0"

## Debug a Blazor Web App in an IDE

# [Visual Studio](#tab/visual-studio)

1. Open the app.
1. Set a breakpoint on the `currentCount++;` line in the `Counter` component (`Pages/Counter.razor`) of the client project (`.Client`).
1. Press <kbd>F5</kbd> to run the app in the debugger.
1. In the browser, navigate to `Counter` page at `/counter`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>F5</kbd> to continue execution.

Breakpoints can also be hit in the server project.

1. Stop the debugger.
1. Add the following component to the server app.

   `Components/Pages/Counter2.razor`:

   ```razor
   @page "/counter-2"
   @rendermode RenderMode.InteractiveServer

   <PageTitle>Counter 2</PageTitle>

   <h1>Counter 2</h1>

   <p role="status">Current count: @currentCount</p>

   <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

   @code {
       private int currentCount = 0;

       private void IncrementCount()
       {
           currentCount++;
       }
   }
   ```

1. Set a breakpoint on the `currentCount++;` line in the `Counter2` component.
1. Press <kbd>F5</kbd> to run the app in the debugger.
1. In the browser, navigate to `Counter2` page at `/counter-2`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. Press <kbd>F5</kbd> to continue execution.

Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in the `Program` file and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

# [Visual Studio Code](#tab/visual-studio-code)

1. Open the app.

   When opening a new app in Visual Studio Code and the IDE requests that you add assets to build and debug the project, select **Yes**.

   If Visual Studio Code doesn't automatically offer to add build and debug assets (the `.vscode` folder with `launch.json` and `tasks.json` files), select **View** > **Command Palette** and type "`.NET`" into the search box. From the list of commands, select the "`.NET: Generate Assets for Build and Debug`" command.

1. Set a breakpoint on the `currentCount++;` line in the `Counter` component (`Pages/Counter.razor`) of the client project (`.Client`).
1. Press <kbd>F5</kbd> to run the app in the debugger.
1. In the browser, navigate to the `Counter2` page at `/counter-2`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. Press <kbd>F5</kbd> to continue execution.

<!-- UPDATE 8.0 Pull this NOTE at RC2 if fixed -->

> [!NOTE]
> During the .NET 8.0 *Release Candidate 1* preview, breakpoints placed anywhere in the server app of the solution aren't hit during debugging. This issue only applies to debugging with Visual Studio Code. This will be addressed in a future preview release or for the final release of .NET 8.

<!-- UPDATE 8.0 Surface the following when the bug is fixed

Breakpoints can also be hit in the server project.

1. Stop the debugger.
1. Add the following component to the server app.

   `Components/Pages/Counter2.razor`:

   ```razor
   @page "/counter-2"
   @rendermode RenderMode.InteractiveServer

   <PageTitle>Counter 2</PageTitle>

   <h1>Counter 2</h1>

   <p role="status">Current count: @currentCount</p>

   <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

   @code {
       private int currentCount = 0;

       private void IncrementCount()
       {
           currentCount++;
       }
   }
   ```

1. Set a breakpoint on the `currentCount++;` line in the `Counter2` component.
1. Press <kbd>F5</kbd> to run the app in the debugger.
1. In the browser, navigate to the `Counter2` page at `/counter-2`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. Press <kbd>F5</kbd> to continue execution.

-->

Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in the `Program` file and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

**Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

---

:::moniker-end

:::moniker range="< aspnetcore-8.0"

## Debug a Blazor Server app in an IDE

# [Visual Studio](#tab/visual-studio)

1. Open the app.
1. Set a breakpoint on the `currentCount++;` line in the `Counter` component (`Pages/Counter.razor`).
1. Press <kbd>F5</kbd> to run the app in the debugger.
1. In the browser, navigate to `Counter` page at `/counter`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>F5</kbd> to continue execution.

Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in the `Program` file and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

# [Visual Studio Code](#tab/visual-studio-code)

1. Open the app.

   When opening a new app in Visual Studio Code and the IDE requests that you add assets to build and debug the project, select **Yes**.

   If Visual Studio Code doesn't automatically offer to add build and debug assets (the `.vscode` folder with `launch.json` and `tasks.json` files), select **View** > **Command Palette** and type "`.NET`" into the search box. From the list of commands, select the "`.NET: Generate Assets for Build and Debug`" command.

1. Set a breakpoint on the `currentCount++;` line in the `Counter` component (`Pages/Counter.razor`).
1. Press <kbd>F5</kbd> to run the app in the debugger.
1. In the browser, navigate to `Counter` page at `/counter`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. Press <kbd>F5</kbd> to continue execution.

Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in the `Program` file and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

**Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

---

:::moniker-end

## Debug a Blazor WebAssembly app in an IDE

# [Visual Studio](#tab/visual-studio)

1. Open the app.
1. Set a breakpoint on the `currentCount++;` line in the `Counter` component (`Pages/Counter.razor`).
1. Press <kbd>F5</kbd> to run the app in the debugger.
1. In the browser, navigate to `Counter` page at `/counter`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>F5</kbd> to continue execution.

Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in the `Program` file and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

# [Visual Studio Code](#tab/visual-studio-code)

1. Open the standalone Blazor WebAssembly app.

   When opening a new app in Visual Studio Code and the IDE requests that you add assets to build and debug the project, select **Yes**.

   If Visual Studio Code doesn't automatically offer to add build and debug assets (the `.vscode` folder with `launch.json` and `tasks.json` files), select **View** > **Command Palette** and type "`.NET`" into the search box. From the list of commands, select the "`.NET: Generate Assets for Build and Debug`" command.

1. Set a breakpoint on the `currentCount++;` line in the `Counter` component (`Pages/Counter.razor`).
1. Press <kbd>F5</kbd> to run the app in the debugger.
1. The standalone app is launched, and a debugging browser is opened.
1. In the browser, navigate to `Counter` page at `/counter`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. Press <kbd>F5</kbd> to continue execution.

Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in the `Program` file and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

**Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

---

:::moniker range="< aspnetcore-8.0"

## Debug a hosted Blazor WebAssembly app in an IDE

# [Visual Studio](#tab/visual-studio)

1. With the **:::no-loc text="Server":::** project selected in **Solution Explorer**, press <kbd>F5</kbd> to run the app in the debugger.

   When debugging with a Chromium-based browser, such as Google Chrome or Microsoft Edge, a new browser window might open with a separate profile for the debugging session instead of opening a tab in an existing browser window with the user's profile. If debugging with the user's profile is a requirement, adopt **one** of the following approaches:
   
   * Close all open browser instances before pressing <kbd>F5</kbd> to start debugging.
   * Configure Visual Studio to launch the browser with the user's profile. For more information on this approach, see [Blazor WASM Debugging in VS launches Edge with a separate user data directory (dotnet/aspnetcore #20915)](https://github.com/dotnet/aspnetcore/issues/20915#issuecomment-614933322).

1. In the **:::no-loc text="Client":::** project, set a breakpoint on the `currentCount++;` line in the `Counter` component (`Pages/Counter.razor`).
1. In the browser, navigate to `Counter` page at `/counter`. Wait a few seconds for the debug proxy to load and run. Select the **Click me** button to hit the breakpoint.
1. In Visual Studio, inspect the value of the `currentCount` field in the **Locals** window.
1. Press <kbd>F5</kbd> to continue execution.

You can also debug server code in the **:::no-loc text="Server":::** project:

1. Set a breakpoint in the `Pages/FetchData.razor` page in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
1. Set a breakpoint in the `WeatherForecastController` in the `Get` action method.
1. Browse to the `Fetch Data` page to hit the first breakpoint in the `FetchData` component just before it issues an HTTP request to the server.
1. Press <kbd>F5</kbd> to continue execution and then hit the breakpoint on the server in the `WeatherForecastController`.
1. Press <kbd>F5</kbd> again to let execution continue and see the weather forecast table rendered in the browser.

Breakpoints are **not** hit during app startup before the debug proxy is running. This includes breakpoints in the `Program` file and breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of components that are loaded by the first page requested from the app.

**Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

# [Visual Studio Code](#tab/visual-studio-code)

When opening a new app in Visual Studio Code and the IDE requests that you add assets to build and debug the project, select **Yes**.

If Visual Studio Code doesn't automatically offer to add build and debug assets (the `.vscode` folder with `launch.json` and `tasks.json` files), select **View** > **Command Palette** and type "`.NET`" into the search box. From the list of commands, select the "`.NET: Generate Assets for Build and Debug`" command for the **:::no-loc text="Server":::** project.

> [!NOTE]
> Only browser debugging is supported at this time.
>
> You can't automatically rebuild the backend **:::no-loc text="Server":::** project of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln) during debugging, for example by running the app with [`dotnet watch run`](xref:tutorials/dotnet-watch).

To debug a **published**, hosted Blazor WebAssembly app, configure debugger support (`DebuggerSupport`) and copy output symbols to the `publish` directory (`CopyOutputSymbolsToPublishDirectory`) in the **:::no-loc text="Client":::** project's project file:

```xml
<DebuggerSupport>true</DebuggerSupport>
<CopyOutputSymbolsToPublishDirectory>true</CopyOutputSymbolsToPublishDirectory>
```

By default, publishing an app disables the preceding properties by setting them to `false`.

> [!WARNING]
> Published, hosted Blazor WebAssembly apps should only enable debugging and copying output symbols when deploying published assets ***locally***. Do **not*** deploy a published app into production with the `DebuggerSupport` and `CopyOutputSymbolsToPublishDirectory` properties set to `true`.

**Start Without Debugging** [<kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS)] isn't supported. When the app is run in Debug configuration, debugging overhead always results in a small performance reduction.

---

:::moniker-end

## Attach to an existing Visual Studio Code debugging session

To attach to a running Blazor app, open the `.vscode/launch.json` file and replace the `{URL}` placeholder with the URL where the app is running:

```json
{
  "name": "Attach and Debug",
  "type": "blazorwasm",
  "request": "attach",
  "url": "{URL}"
}
```

## Visual Studio Code launch options

The launch configuration options in the following table are supported for the `blazorwasm` debug type (`.vscode/launch.json`).

| Option    | Description |
| --------- | ----------- |
| `browser` | The browser to launch for the debugging session. Set to `edge` or `chrome`. Defaults to `edge`. |
| `cwd`     | The working directory to launch the app under. |
| `request` | Use `launch` to launch and attach a debugging session to a Blazor WebAssembly app or `attach` to attach a debugging session to an already-running app. |
| `timeout` | The number of milliseconds to wait for the debugging session to attach. Defaults to 30,000 milliseconds (30 seconds). |
| `trace`   | Used to generate logs from the JS debugger. Set to `true` to generate logs. |
| `url`     | The URL to open in the browser when debugging. |
| `webRoot` | Specifies the absolute path of the web server. Should be set if an app is served from a sub-route. |

:::moniker range="< aspnetcore-8.0"

The additional options in the following table only apply to **hosted Blazor WebAssembly apps**.

| Option    | Description |
| --------- | ----------- |
| `env`     | The environment variables to provide to the launched process. Only applicable if `hosted` is set to `true`. |
| `hosted`  | Must be set to `true` if launching and debugging a hosted Blazor WebAssembly app. |
| `program` | A reference to the executable to run the server of the hosted app. Must be set if `hosted` is `true`. |

:::moniker-end

## Debug Blazor WebAssembly with Google Chrome or Microsoft Edge

*The guidance in this section applies debugging Blazor WebAssembly apps in:*

* *Google Chrome running on Windows or macOS.*
* *Microsoft Edge running on Windows.*

1. Run the app in a command shell with `dotnet run`.
1. Launch a browser and navigate to the app's URL.
1. Start remote debugging by pressing:

   * <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd> on Windows.
   * <kbd>Shift</kbd>+<kbd>&#8984;</kbd>+<kbd>d</kbd> on macOS.

   The browser must be running with remote debugging enabled, which isn't the default. If remote debugging is disabled, an **Unable to find debuggable browser tab** error page is rendered with instructions for launching the browser with the debugging port open. Follow the instructions for your browser.

   After the app opens in a new browser tab, start remote debugging by pressing:

   * <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd> on Windows.
   * <kbd>Shift</kbd>+<kbd>&#8984;</kbd>+<kbd>d</kbd> on macOS.

1. After the new developer tools browser tab opens showing a ghosted image of the app, return to the app's browser tab.
1. Open the browser's developer tools console.
1. After a moment, the **Sources** tab shows a list of the app's .NET assemblies and pages.
1. In component code (`.razor` files) and C# code files (`.cs`), breakpoints that you set are hit when code executes. After a breakpoint is hit, single-step (<kbd>F10</kbd>) through the code or resume (<kbd>F8</kbd>) code execution normally.

For Chromium-based browser debugging, Blazor provides a debugging proxy that implements the [Chrome DevTools Protocol](https://chromedevtools.github.io/devtools-protocol/) and augments the protocol with .NET-specific information. When debugging keyboard shortcut is pressed, Blazor points the Chrome DevTools at the proxy. The proxy connects to the browser window you're seeking to debug (hence the need to enable remote debugging).

:::moniker range=">= aspnetcore-8.0"

## Debug a Blazor WebAssembly app with Firefox

*The guidance in this section applies debugging Blazor WebAssembly apps in Firefox running on Windows.*

<!-- UPDATE 8.0 Update this to include FF on macOS, if supported. -->

Debugging a Blazor WebAssembly app with Firefox requires configuring the browser for remote debugging and connecting to the browser using the browser developer tools through the .NET WebAssembly debugging proxy.

> [!NOTE]
> Debugging in Firefox from Visual Studio isn't supported at this time.

To debug a Blazor WebAssembly app in Firefox during development:

1. Run the app in a command shell with `dotnet run`.
1. Navigate to the app in Firefox.
1. Open the Firefox Web Developer Tools and go to the `Console` tab.
1. With app in focus by selecting the app's UI in the browser's window, start remote debugging by pressing <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd>.
1. Follow the instructions in the console output to configure Firefox for Blazor WebAssembly debugging:
   * Open `about:config` in a new browser tab. Read and dismiss the warning that appears.
   * Enable `devtools.debugger.remote-enabled`.
   * Enable `devtools.chrome.enabled`.
   * Disable `devtools.debugger.prompt-connection`.
1. Close all Firefox instances.
1. Navigate to Firefox's executable location with the following command in a command shell: `cd "C:\Program Files\Mozilla Firefox"` (include the quotes).
1. Execute the following command: `.\firefox.exe --start-debugger-server 6000 -new-tab about:debugging`.
1. In the new Firefox instance, an `about:debugging` tab opens. **Leave this tab open**.
1. Open a new browser tab and navigate to the Blazor WebAssembly app.
1. Press <kbd>Shift</kbd>+<kbd>Alt</kbd>+<kbd>d</kbd> to open the Firefox Web Developer tools and connect to the Firefox browser instance.
1. In the `Debugger` tab, open the app source file you wish to debug under the `file://` node and set a breakpoint. For example, set a breakpoint in the `IncrementCount` method of the `Counter` component (`Counter.razor`).
1. Navigate to the `Counter` component page (`/counter`) and select the counter button to hit the breakpoint.
1. Press <kbd>F5</kbd> to continue execution.

:::moniker-end

## Break on unhandled exceptions

The debugger doesn't break on unhandled exceptions by default because Blazor catches exceptions that are unhandled by developer code.

To break on unhandled exceptions:

* Open the debugger's exception settings (**Debug** > **Windows** > **Exception Settings**) in Visual Studio.
* Set the following **JavaScript Exceptions** settings:
  * **All Exceptions**
  * **Uncaught Exceptions**

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

* Remove breakpoints:
  * Google Chrome: In the **Debugger** tab, open the developer tools in your browser. In the console, execute `localStorage.clear()` to remove any breakpoints.
  * Microsoft Edge: In the **Application** tab, open **Local storage**. Right-click the site and select **Clear**.
* Confirm that you've installed and trusted the ASP.NET Core HTTPS development certificate. For more information, see <xref:security/enforcing-ssl#troubleshoot-certificate-problems-such-as-certificate-not-trusted>.
* Visual Studio requires the **Enable JavaScript debugging for ASP.NET (Chrome and Edge)** option in **Tools** > **Options** > **Debugging** > **General**. This is the default setting for Visual Studio. If debugging isn't working, confirm that the option is selected.
* If your environment uses an HTTP proxy, make sure that `localhost` is included in the proxy bypass settings. This can be done by setting the `NO_PROXY` environment variable in either:
  * The `launchSettings.json` file for the project.
  * At the user or system environment variables level for it to apply to all apps. When using an environment variable, restart Visual Studio for the change to take effect.
* Ensure that firewalls or proxies don't block communication with the debug proxy (`NodeJS` process). For more information, see the [Firewall configuration](#firewall-configuration) section.

### Breakpoints in `OnInitialized{Async}` not hit

The Blazor framework's debugging proxy doesn't launch instantly on app startup, so breakpoints in the [`OnInitialized{Async}` lifecycle methods](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) might not be hit. We recommend adding a delay at the start of the method body to give the debug proxy some time to launch before the breakpoint is hit. You can include the delay based on an [`if` compiler directive](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) to ensure that the delay isn't present for a release build of the app.

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
