---
title: Tooling for ASP.NET Core Blazor
author: guardrex
description: Learn about the tools available to build Blazor apps on various platforms.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/tooling
zone_pivot_groups: operating-systems
---
# Tooling for ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes tools for building Blazor apps on various platforms. Select your platform at the top of this article.

:::zone pivot="windows"

To create a Blazor app on Windows, use the following guidance:

<!-- UPDATE 8.0 Remove Preview VS install from versioning blocks -->

:::moniker range=">= aspnetcore-8.0"

* Install the latest version of [Visual Studio Preview](https://visualstudio.microsoft.com/vs/preview/) with the **ASP.NET and web development** workload.

<!-- UPDATE 8.0 Confirm whether or not the blazorwasm-empty
     template survives in 8.0+ -->

* Create a new project:
  * For a Blazor Web App experience (*recommended*), choose the **Blazor Web App** template. Select **Next**.
  * For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template, which includes demonstration code and Bootstrap, or the **Blazor WebAssembly App Empty** template without demonstration code and Bootstrap. Select **Next**.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* Install the latest version of [Visual Studio](https://visualstudio.microsoft.com) with the **ASP.NET and web development** workload.

* Create a new project:
  * For a Blazor Server experience, choose the **Blazor Server App** template, which includes demonstration code and [Bootstrap](https://getbootstrap.com/), or the **Blazor Server App Empty** template without demonstration code and Bootstrap. Select **Next**.
  * For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template, which includes demonstration code and Bootstrap, or the **Blazor WebAssembly App Empty** template without demonstration code and Bootstrap. Select **Next**.

:::moniker-end

:::moniker range="< aspnetcore-7.0"

* Install the latest version of [Visual Studio](https://visualstudio.microsoft.com) with the **ASP.NET and web development** workload.

* Create a new project:
  * For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.
  * For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. Select **Next**.

:::moniker-end

* Provide a **Project name** and confirm that the **Location** is correct.

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0 Cross-link SSR -->

* For a Blazor Web App in the **Additional information** dialog:

  * Interactivity with server rendering is enabled by default with the **Use interactive server components** checkbox.
  * To enable interactivity with client rendering, select the **Use interactive WebAssembly components** checkbox.
  * To include sample pages and a layout based on Bootstrap styling, select the **Include sample pages** checkbox. Disable this option for an empty project without Bootstrap styling.

  If both the WebAssembly and Server render modes are selected, the template uses the Auto render mode. The Auto render mode initially uses the Server mode while the .NET app bundle and runtime are download to the browser. After the .NET WebAssembly runtime is activated, Auto switches to the WebAssembly render mode.

  By default, the Blazor Web App template enables both static and interactive server rendering using a single project. If you also enable the WebAssembly render mode, the project includes an additional client project (`.Client`) for your WebAssembly-based components. The built output from the client project is downloaded to the browser and executed on the client. Any components using the WebAssembly or Auto render modes must be built from the client project.

  For more information, see <xref:blazor/components/render-modes>.

<!-- UPDATE 8.0 I think the interactive root component checkbox
     will appear at RC2. -->

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* For a *hosted* Blazor WebAssembly app, select the **ASP.NET Core Hosted** checkbox in the **Additional information** dialog.

:::moniker-end

* Select **Create**.

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

:::moniker range="< aspnetcore-8.0"

When running a hosted Blazor WebAssembly [solution](#visual-studio-solution-file-sln) in Visual Studio, the startup project of the solution is the **:::no-loc text="Server":::** project.

:::moniker-end

For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

:::moniker range="< aspnetcore-8.0"

> [!IMPORTANT]
> When executing a hosted Blazor WebAssembly app, run the app from the solution's **:::no-loc text="Server":::** project.
>
> When the app is launched, only the `Properties/launchSettings.json` file in the :::no-loc text="Server"::: project is used.

:::moniker-end

:::zone-end

:::zone pivot="linux"

To create a Blazor app on Linux, use the following guidance:

Use the [.NET command-line interface (CLI)](/dotnet/core/tools/) to execute commands in a Linux command shell.

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0 Drop preview content -->

Install the latest version of the [.NET Core SDK Preview](https://dotnet.microsoft.com/download/dotnet/8.0). If you previously installed the SDK, you can determine your installed version by executing the following command:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Install the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/download). If you previously installed the SDK, you can determine your installed version by executing the following command:

:::moniker-end

```dotnetcli
dotnet --version
```

Install the latest version of [Visual Studio Code](https://code.visualstudio.com).

Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

:::moniker range=">= aspnetcore-8.0"

Create a new project:

* For a Blazor Web App experience with demonstration code and Bootstrap (*recommended*), execute the following command:

  ```dotnetcli
  dotnet new blazor -o BlazorApp
  ```

  <!-- UPDATE 8.0 Cross-links -->

  <!-- UPDATE 8.0 Confirm default interactivity with SSR without --use-server -->

  Interactivity with server rendering is enabled by default.

  To enable interactivity with client rendering, add the `--use-wasm` option to the command:

  ```dotnetcli
  dotnet new blazor -o BlazorApp --use-wasm
  ```

* For a Blazor WebAssembly experience with demonstration code and Bootstrap, execute the following command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp
  ```

* Alternatively, create a Blazor WebAssembly app without demonstration code and Bootstrap using the `blazorwasm-empty` project template:

  ```dotnetcli
  dotnet new blazorwasm-empty -o BlazorApp
  ```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Create a new project:

* For a Blazor Server experience with demonstration code and [Bootstrap](https://getbootstrap.com/), execute the following command:

  ```dotnetcli
  dotnet new blazorserver -o BlazorApp
  ```

* Alternatively, create a Blazor Server app without demonstration code and Bootstrap using the `blazorserver-empty` project template:

  ```dotnetcli
  dotnet new blazorserver-empty -o BlazorApp
  ```

* For a Blazor WebAssembly experience with demonstration code and Bootstrap, execute the following command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp
  ```

* Alternatively, create a Blazor WebAssembly app without demonstration code and Bootstrap using the `blazorwasm-empty` project template:

  ```dotnetcli
  dotnet new blazorwasm-empty -o BlazorApp
  ```

* For a hosted Blazor WebAssembly experience with demonstration code and Bootstrap, add the hosted option (`-ho`/`--hosted`) to the command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp -ho
  ```

* Alternatively, create a hosted Blazor WebAssembly app without demonstration code and Bootstrap using the `blazorwasm-empty` template with the hosted option:

  ```dotnetcli
  dotnet new blazorwasm-empty -o BlazorApp -ho
  ```

:::moniker-end

:::moniker range="< aspnetcore-7.0"

Create a new project:

* For a Blazor WebAssembly experience, execute the following command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp
  ```

* For a hosted Blazor WebAssembly experience, add the hosted option (`-ho` or `--hosted`) option to the command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp -ho
  ```

* For a Blazor Server experience, execute the following command:

  ```dotnetcli
  dotnet new blazorserver -o BlazorApp
  ```

:::moniker-end

Open the `BlazorApp` folder in Visual Studio Code.

The IDE requests that you add assets to build and debug the project. Select **Yes**.

If Visual Studio Code doesn't offer to create the assets automatically, use the following files:

`.vscode/launch.json` (configured for launch and debug of a Blazor WebAssembly app):

:::moniker range=">= aspnetcore-6.0"

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "type": "blazorwasm",
      "name": "Launch and Debug Blazor WebAssembly Application",
      "request": "launch",
      "cwd": "${workspaceFolder}",
      "browser": "edge"
    }
  ]
}
```

`.vscode/tasks.json`:

```json
{
  "version": "2.0.0",
  "tasks": [
    {
      "label": "build",
      "command": "dotnet",
      "type": "shell",
      "args": [
        "build",
        "/property:GenerateFullPaths=true",
        "/consoleloggerparameters:NoSummary",
      ],
      "group": "build",
      "presentation": {
        "reveal": "silent"
      },
      "problemMatcher": "$msCompile"
    }
  ]
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```json
{
  // Use IntelliSense to learn about possible attributes.
  // Hover to view descriptions of existing attributes.
  // For more information, visit: https://go.microsoft.com/fwlink/?linkid=830387
  "version": "0.2.0",
  "configurations": [
    {
      "type": "blazorwasm",
      "name": "Launch and Debug Blazor WebAssembly Application",
      "request": "launch",
      "cwd": "${workspaceFolder}",
      "browser": "edge"
    }
  ]
}
```

`.vscode/tasks.json`:

```json
{
  // See https://go.microsoft.com/fwlink/?LinkId=733558
  // for the documentation about the tasks.json format
  "version": "2.0.0",
  "tasks": [
    {
      "label": "build",
      "command": "dotnet",
      "type": "shell",
      "args": [
        "build",
        // Ask dotnet build to generate full paths for file names.
        "/property:GenerateFullPaths=true",
        // Do not generate summary otherwise it leads to duplicate errors in Problems panel
        "/consoleloggerparameters:NoSummary",
      ],
      "group": "build",
      "presentation": {
        "reveal": "silent"
      },
      "problemMatcher": "$msCompile"
    }
  ]
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

The project's `Properties/launchSettings.json` file includes the `inspectUri` property for the debugging proxy for any profiles in the `profiles` section of the file:

```json
"inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

**Hosted Blazor WebAssembly launch and task configuration**

For hosted Blazor WebAssembly [solutions](#visual-studio-solution-file-sln), add (or move) the `.vscode` folder with `launch.json` and `tasks.json` files to the solution's parent folder, which is the folder that contains the typical project folders: :::no-loc text="Client":::, :::no-loc text="Server":::, and `Shared`. Update or confirm that the configuration in the `launch.json` and `tasks.json` files execute a hosted Blazor WebAssembly app from the **:::no-loc text="Server":::** project.

> [!IMPORTANT]
> When executing a hosted Blazor WebAssembly app, run the app from the solution's **:::no-loc text="Server":::** project.
>
> When the app is launched, only the `Properties/launchSettings.json` file in the :::no-loc text="Server"::: project is used.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Examine the `Properties/launchSettings.json` file and determine the URL of the app from the `applicationUrl` property. Depending on the framework version, the URL protocol is either secure (HTTPS) `https://localhost:{PORT}` or insecure (HTTP) `http://localhost:{PORT}`, where the `{PORT}` placeholder is an assigned port. Note the URL for use in the `launch.json` file.

In the launch configuration of the `.vscode/launch.json` file:

* Set the current working directory (`cwd`) to the **:::no-loc text="Server":::** project folder.
* Indicate the app's URL with the `url` property. Use the value recorded earlier from the `Properties/launchSettings.json` file.

```json
"cwd": "${workspaceFolder}/{SERVER APP FOLDER}",
"url": "{URL}"
```

In the preceding configuration:

* The `{SERVER APP FOLDER}` placeholder is the **:::no-loc text="Server":::** project's folder, typically :::no-loc text="Server":::.
* The `{URL}` placeholder is the app's URL, which is specified in the app's `Properties/launchSettings.json` file in the `applicationUrl` property.

If Google Chrome is preferred over Microsoft Edge, update or add an additional property of `"browser": "chrome"` to the configuration.

The following example `.vscode/launch.json` file:

* Sets the current working directory to the :::no-loc text="Server"::: folder.
* Sets the URL for the app to `http://localhost:7268`.
* Changes the default browser from Microsoft Edge to Google Chrome.

```json
"cwd": "${workspaceFolder}/Server",
"url": "http://localhost:7268",
"browser": "chrome"
```

The complete `.vscode/launch.json` file:

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "type": "blazorwasm",
      "name": "Launch and Debug Blazor WebAssembly Application",
      "request": "launch",
      "cwd": "${workspaceFolder}/Server",
      "url": "http://localhost:7268",
      "browser": "chrome"
    }
  ]
}
```

In `.vscode/tasks.json`, add a `build` argument that specifies the path to the **:::no-loc text="Server":::** app's project file:

```json
"${workspaceFolder}/{SERVER APP FOLDER}/{PROJECT NAME}.csproj",
```

In the preceding argument:

* The `{SERVER APP FOLDER}` placeholder is the **:::no-loc text="Server":::** project's folder, typically :::no-loc text="Server":::.
* The `{PROJECT NAME}` placeholder is the app's name, typically based on the solution's name followed by `.Server` in an app generated from the Blazor WebAssembly project template.

An example `.vscode/tasks.json` file with a **:::no-loc text="Server":::** project named `BlazorHosted` in the :::no-loc text="Server"::: folder of the solution:

```json
{
  "version": "2.0.0",
  "tasks": [
    {
      "label": "build",
      "command": "dotnet",
      "type": "process",
        "args": [
          "build",
          "${workspaceFolder}/Server/BlazorHosted.Server.csproj",
          "/property:GenerateFullPaths=true",
          "/consoleloggerparameters:NoSummary",
        ],
        "group": "build",
        "presentation": {
          "reveal": "silent"
        },
        "problemMatcher": "$msCompile"
    }
  ]
}
```

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

> [!NOTE]
> Only [browser debugging](xref:blazor/debug#debug-in-the-browser) is supported at this time.
>
> You can't automatically rebuild the backend **:::no-loc text="Server":::** app of a hosted Blazor WebAssembly solution during debugging, for example by running the app with [`dotnet watch run`](xref:tutorials/dotnet-watch).

:::moniker-end

:::moniker range="< aspnetcore-6.0"

**`.vscode/launch.json`** (`launch` configuration):

```json
...
"cwd": "${workspaceFolder}/{SERVER APP FOLDER}",
...
```

In the preceding configuration for the current working directory (`cwd`), the `{SERVER APP FOLDER}` placeholder is the **:::no-loc text="Server":::** project's folder, typically ":::no-loc text="Server":::".

If Microsoft Edge is used and Google Chrome isn't installed on the system, add an additional property of `"browser": "edge"` to the configuration.

Example for a project folder of :::no-loc text="Server"::: and that spawns Microsoft Edge as the browser for debug runs instead of the default browser Google Chrome:

```json
...
"cwd": "${workspaceFolder}/Server",
"browser": "edge"
...
```

**`.vscode/tasks.json`** ([`dotnet` command](/dotnet/core/tools/dotnet) arguments):

```json
...
"${workspaceFolder}/{SERVER APP FOLDER}/{PROJECT NAME}.csproj",
...
```

In the preceding argument:

* The `{SERVER APP FOLDER}` placeholder is the **:::no-loc text="Server":::** project's folder, typically ":::no-loc text="Server":::".
* The `{PROJECT NAME}` placeholder is the app's name, typically based on the solution's name followed by "`.Server`" in an app generated from the [Blazor project template](xref:blazor/project-structure).

The following example from the [tutorial for using SignalR with a Blazor WebAssembly app](xref:blazor/tutorials/signalr-blazor) uses a project folder name of :::no-loc text="Server"::: and a project name of `BlazorWebAssemblySignalRApp.Server`:

```json
...
"args": [
  "build",
    "${workspaceFolder}/Server/BlazorWebAssemblySignalRApp.Server.csproj",
    ...
],
...
```

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

:::moniker-end

## Trust a development certificate

For more information, see <xref:security/enforcing-ssl#trust-https-certificate-on-linux-using-edge-or-chrome>.

:::zone-end

## Visual Studio solution file (`.sln`)

A *solution* is a container to organize one or more related code projects. [Visual Studio](https://visualstudio.microsoft.com/vs/) uses a solution file (`.sln`) to store settings for a solution. Solution files use a unique format and aren't intended to be edited directly.

Tooling outside of Visual Studio can interact with solution files:

* The [.NET CLI](/dotnet/core/tools/) can create solution files and list/modify the projects in solution files via the [`dotnet sln` command](/dotnet/core/tools/dotnet-sln). Other .NET CLI commands use the path of the solution file for various publishing, testing, and packaging commands.
* [Visual Studio Code](https://code.visualstudio.com) can execute the `dotnet sln` command and other .NET CLI commands through its integrated terminal but doesn't use the settings in a solution file directly.

:::moniker range="< aspnetcore-8.0"

Throughout the Blazor documentation, *solution* is used to describe apps created from the Blazor WebAssembly project template with the **ASP.NET Core Hosted** option enabled or from a Blazor Hybrid project template. Apps produced from these project templates include a solution file (`.sln`) by default. For hosted Blazor WebAssembly apps where the developer isn't using Visual Studio, the solution file can be ignored or deleted if it isn't used with .NET CLI commands.

:::moniker-end

For more information, see the following resources in the Visual Studio documentation:

* [Introduction to projects and solutions](/visualstudio/get-started/tutorial-projects-solutions)
* [What are solutions and projects in Visual Studio?](/visualstudio/ide/solutions-and-projects-in-visual-studio)

## Use Visual Studio Code for cross-platform Blazor development

:::zone pivot="windows"

[Visual Studio Code](https://code.visualstudio.com/) is an open source, cross-platform Integrated Development Environment (IDE) that can be used to develop Blazor apps. Use the [.NET CLI](/dotnet/core/tools/) to create a new Blazor app for development with Visual Studio Code. For more information, see the [Linux version of this article](?pivots=linux).

:::zone-end

:::zone pivot="linux"

[Visual Studio Code](https://code.visualstudio.com/) is an open source, cross-platform Integrated Development Environment (IDE) that can be used to develop Blazor apps. Use the [.NET CLI](/dotnet/core/tools/) to create a new Blazor app for development with Visual Studio Code. For more information, see the [Linux version of this article](?pivots=linux).

:::zone-end

## Blazor template options

The Blazor framework provides templates for creating new apps. The templates are used to create new Blazor projects and solutions regardless of the tooling that you select for Blazor development (Visual Studio, Visual Studio Code, or the [.NET command-line interface (CLI)](/dotnet/core/tools/)):

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0 Confirm whether or not the blazorwasm-empty
     template survives in 8.0+ -->

* Blazor Web App project template (*recommended*): `blazor`
* Blazor WebAssembly project templates: `blazorwasm`, `blazorwasm-empty`

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* Blazor Server project templates: `blazorserver`, `blazorserver-empty`
* Blazor WebAssembly project templates: `blazorwasm`, `blazorwasm-empty`

:::moniker-end

:::moniker range="< aspnetcore-7.0"

* Blazor Server project template: `blazorserver`
* Blazor WebAssembly project template: `blazorwasm`

:::moniker-end

For more information on Blazor project templates, see <xref:blazor/project-structure>.

For more information on template options, see the following resources:

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0

* [`blazor`](/dotnet/core/tools/dotnet-new-sdk-templates#blazor)

-->

<!-- UPDATE 8.0 Confirm whether or not the blazorwasm-empty
     template survives in 8.0+ -->

* The *.NET default templates for dotnet new* article in the .NET Core documentation:
  * [`blazorwasm`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorwasm) (includes `blazorwasm-empty` options)
* Passing the help option (`-h` or `--help`) to the [`dotnet new`](/dotnet/core/tools/dotnet-new) CLI command in a command shell:
  * `dotnet new blazor -h`
  * `dotnet new blazorwasm -h`
  * `dotnet new blazorwasm-empty -h`

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* The *.NET default templates for dotnet new* article in the .NET Core documentation:
  * [`blazorserver`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorserver) (includes `blazorserver-empty` options)
  * [`blazorwasm`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorwasm) (includes `blazorwasm-empty` options)
* Passing the help option (`-h` or `--help`) to the [`dotnet new`](/dotnet/core/tools/dotnet-new) CLI command in a command shell:
  * `dotnet new blazorserver -h`
  * `dotnet new blazorserver-empty -h`
  * `dotnet new blazorwasm -h`
  * `dotnet new blazorwasm-empty -h`

:::moniker-end

:::moniker range="< aspnetcore-7.0"

* The *.NET default templates for dotnet new* article in the .NET Core documentation:
  * [`blazorserver`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorserver)
  * [`blazorwasm`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorwasm)
* Passing the help option (`-h` or `--help`) to the [`dotnet new`](/dotnet/core/tools/dotnet-new) CLI command in a command shell:
  * `dotnet new blazorserver -h`
  * `dotnet new blazorwasm -h`

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## .NET WebAssembly build tools

The .NET WebAssembly build tools are based on [Emscripten](https://emscripten.org/), a compiler toolchain for the web platform. To install the build tools, use ***either*** of the following approaches:

* For the **ASP.NET and web development** workload in the Visual Studio installer, select the **.NET WebAssembly build tools** option from the list of optional components.
* Execute `dotnet workload install wasm-tools` in an administrative command shell.

> [!NOTE]
> .NET WebAssembly build tools for .NET 6 projects
>
> The `wasm-tools` workload installs the build tools for the latest release. However, the current version of the build tools are incompatible with existing projects built with .NET 6. Projects using the build tools that must support both .NET 6 and a later release must use multi-targeting.
>
> Use the `wasm-tools-net6` workload for .NET 6 projects when developing apps with the .NET 7 SDK. To install the `wasm-tools-net6` workload, execute the following command from an administrative command shell:
>
> ```dotnetcli
> dotnet workload install wasm-tools-net6
> ```

For more information, see the following resources:

* [Ahead-of-time (AOT) compilation](xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation)
* [Runtime relinking](xref:blazor/host-and-deploy/webassembly#runtime-relinking)
* <xref:blazor/webassembly-native-dependencies>

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

### Ahead-of-time (AOT) compilation

To enable [ahead-of-time (AOT) compilation](xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation), set `<RunAOTCompilation>` to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <RunAOTCompilation>true</RunAOTCompilation>
</PropertyGroup>
```

### Single Instruction, Multiple Data (SIMD)

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

[WebAssembly Single Instruction, Multiple Data (SIMD)](https://github.com/WebAssembly/simd/blob/master/proposals/simd/SIMD.md) can improve the throughput of vectorized computations by performing an operation on multiple pieces of data in parallel using a single instruction. SIMD is enabled by default for all major browsers. 

To disable SIMD, for example when targeting old browsers (on mobile devices), add the `<WasmEnableSIMD>` property set to `false` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableSIMD>false</WasmEnableSIMD>
</PropertyGroup>
```

<!-- UPDATE 8.0 Remove note when https://github.com/dotnet/runtime/issues/89302 is fixed -->

> [!IMPORTANT]
> During 8.0 preview releases, disabling SIMD isn't supported. For more information, see [SIMD cannot be disabled (dotnet/runtime #89302)](https://github.com/dotnet/runtime/issues/89302).

For more information, see [Configuring and hosting .NET WebAssembly applications: SIMD - Single instruction, multiple data](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/features.md#simd---single-instruction-multiple-data).

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

[WebAssembly Single Instruction, Multiple Data (SIMD)](https://github.com/WebAssembly/simd/blob/master/proposals/simd/SIMD.md) can improve the throughput of vectorized computations by performing an operation on multiple pieces of data in parallel using a single instruction. 

To enable SIMD, add the `<WasmEnableSIMD>` property set to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableSIMD>true</WasmEnableSIMD>
</PropertyGroup>
```

For more information, see [Configuring and hosting .NET WebAssembly applications: SIMD - Single instruction, multiple data](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/features.md#simd---single-instruction-multiple-data). Note that the guidance in this document isn't versioned and applies to the latest public release.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

### Exception handling

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Exception handling is enabled by default. To disable exception handling, add the `<WasmEnableExceptionHandling>` property with a value of `false` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableExceptionHandling>false</WasmEnableExceptionHandling>
</PropertyGroup>
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

To enable WebAssembly exception handling, add the `<WasmEnableExceptionHandling>` property with a value of `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableExceptionHandling>true</WasmEnableExceptionHandling>
</PropertyGroup>
```

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-6.0"

* [.NET command-line interface (CLI)](/dotnet/core/tools/)
* <xref:test/hot-reload>
* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>
* <xref:blazor/hybrid/tutorials/index>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* [.NET command-line interface (CLI)](/dotnet/core/tools/)
* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>

:::moniker-end
