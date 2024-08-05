---
title: Tooling for ASP.NET Core Blazor
author: guardrex
description: Learn about the tools available to build Blazor apps and how to use them.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 06/13/2024
uid: blazor/tooling
zone_pivot_groups: tooling
---
# Tooling for ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes tools for building Blazor apps using several tools:

* [Visual Studio (VS)](https://visualstudio.microsoft.com): The most comprehensive integrated development environment (IDE) for .NET developers on Windows. Includes an array of tools and features to elevate and enhance every stage of software development.
* [Visual Studio Code (VS Code)](https://code.visualstudio.com) is an open source, cross-platform code editor that can be used to develop Blazor apps.
* [.NET CLI](/dotnet/core/tools/): The .NET command-line interface (CLI) is a cross-platform toolchain for developing, building, running, and publishing .NET applications. The .NET CLI is included with the [.NET SDK](/dotnet/core/sdk) and runs on any platform supported by the SDK.

Select the pivot of this article that matches your tooling choice.

:::zone pivot="vs"

To create a Blazor app with Visual Studio, use the following guidance:

:::moniker range=">= aspnetcore-8.0"

* Install the latest version of [Visual Studio](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the **ASP.NET and web development** workload.

* Create a new project using one of the available Blazor templates:

  * **Blazor Web App**: Creates a Blazor web app that supports interactive server-side rendering (interactive SSR) and client-side rendering (CSR). The Blazor Web App template is recommended for getting started with Blazor to learn about server-side and client-side Blazor features.
  * **Blazor WebAssembly Standalone App**: Creates a standalone client web app that can be deployed as a static site.

Select **Next**.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* Install the latest version of [Visual Studio](https://visualstudio.microsoft.com) with the **ASP.NET and web development** workload.

* Create a new project:
  * For a Blazor Server experience, choose the **Blazor Server App** template, which includes demonstration code and [Bootstrap](https://getbootstrap.com/), or the **Blazor Server App Empty** template without demonstration code and Bootstrap. Select **Next**.
  * For a standalone Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template, which includes demonstration code and Bootstrap, or the **Blazor WebAssembly App Empty** template without demonstration code and Bootstrap. Select **Next**.

:::moniker-end

:::moniker range="< aspnetcore-7.0"

* Install the latest version of [Visual Studio](https://visualstudio.microsoft.com) with the **ASP.NET and web development** workload.

* Create a new project:
  * For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.
  * For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. Select **Next**.

:::moniker-end

* Provide a **Project name** and confirm that the **Location** is correct.

* For more information on the options in the **Additional information** dialog, see the [Blazor project templates and template options](#blazor-project-templates-and-template-options) section.

:::moniker range=">= aspnetcore-8.0"

  > [!NOTE]
  > The hosted Blazor WebAssmebly project template isn't available in ASP.NET Core 8.0 or later. To create a hosted Blazor WebAssembly app, a **Framework** option earlier than .NET 8.0 must be selected with the **ASP.NET Core Hosted** checkbox.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* For a *hosted* Blazor WebAssembly app, select the **ASP.NET Core Hosted** checkbox in the **Additional information** dialog.

:::moniker-end

* Select **Create**.

:::zone-end

:::zone pivot="vsc"

[Visual Studio Code](https://code.visualstudio.com) is an open source, cross-platform Integrated Development Environment (IDE) that can be used to develop Blazor apps.

Install the latest version of [Visual Studio Code](https://code.visualstudio.com/Download) for your platform.

Install the [C# Dev Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit). For more information, see <xref:blazor/debug#visual-studio-code-prerequisites>.

If you're new to VS Code, see the [VS Code documentation](https://code.visualstudio.com/docs). If you're new to the .NET SDK, see [What is the .NET SDK?](/dotnet/core/sdk) and the associated articles in the .NET SDK documentation.

Create a new project:

* Open VS Code. 

* Go to the **Explorer** view and select the **Create .NET Project** button. Alternatively, you can bring up the **Command Palette** using <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>P</kbd>, and then type "`.NET`" and find and select the **.NET: New Project** command.

* Select the Blazor project template from the list.

* In the **Project Location** dialog, create or select a folder for the project.

* In the **Command Palette**, provide a name for the project or accept the default name.

* Select **Create project** to create the project or adjust the project's options by selecting **Show all template options**. For more information on the templates and options, see the [Blazor project templates and template options](#blazor-project-templates-and-template-options) section.

* Press <kbd>F5</kbd> on the keyboard to run the app with the debugger or <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app without the debugger.

  The **Command Palette** asks you to select a debugger. Select **C#** from the list.

  Next, select the **https** launch configuration.

* To stop the app, press <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard.

The Visual Studio Code (VS Code) instructions for ASP.NET Core development in some parts of the Blazor documentation use the [.NET CLI](/dotnet/core/tools/), which is part of the .NET SDK. .NET CLI commands are issued in VS Code's integrated [**Terminal**](https://code.visualstudio.com/docs/editor/integrated-terminal), which defaults to a [PowerShell command shell](/powershell/). The **Terminal** is opened by selecting **New Terminal** from the **Terminal** menu in the menu bar.

For more information on Visual Studio Code configuration and use, see the [Visual Studio Code documentation](https://code.visualstudio.com/docs).

:::moniker range="< aspnetcore-8.0"

**Hosted Blazor WebAssembly launch and task configuration**

For hosted Blazor WebAssembly [solutions](#visual-studio-solution-file-sln), add (or move) the `.vscode` folder with `launch.json` and `tasks.json` files to the solution's parent folder, which is the folder that contains the typical project folders: :::no-loc text="Client":::, :::no-loc text="Server":::, and `Shared`. Update or confirm that the configuration in the `launch.json` and `tasks.json` files execute a hosted Blazor WebAssembly app from the **:::no-loc text="Server":::** project.

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

:::moniker-end

:::zone-end

:::zone pivot="cli"

The .NET SDK is a set of libraries and tools that developers use to create .NET applications and libraries.

Install the [.NET SDK](https://dotnet.microsoft.com/download). Commands are issued in a command shell using the [.NET CLI](/dotnet/core/tools/).

If you previously installed one or more .NET SDKs and want to see your active version, execute the following command in a command shell:

```dotnetcli
dotnet --version
```

If you're new to the .NET SDK, see [What is the .NET SDK?](/dotnet/core/sdk) and the associated articles in the .NET SDK documentation.

:::moniker range=">= aspnetcore-8.0"

Create a new project:

* Change to the directory using the `cd` command to where you want to create the project folder (for example, `cd c:/users/Bernie_Kopell/Documents`).

* For a Blazor Web App experience with default interactive server-side rendering (interactive SSR), execute the following command:

  ```dotnetcli
  dotnet new blazor -o BlazorApp
  ```

* For a standalone Blazor WebAssembly experience, execute the following command in a command shell that uses the `blazorwasm` template:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp
  ```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Create a new project:

* Change to the directory using the `cd` command to where you want to create the project folder (for example, `cd c:/users/Bernie_Kopell/Documents`).

* For a Blazor Server experience with demonstration code and [Bootstrap](https://getbootstrap.com/), execute the following command:

  ```dotnetcli
  dotnet new blazorserver -o BlazorApp
  ```

* For a standalone Blazor WebAssembly experience with demonstration code and Bootstrap, execute the following command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp
  ```

* For a hosted Blazor WebAssembly experience with demonstration code and Bootstrap, add the hosted option (`-ho`/`--hosted`) to the command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp -ho
  ```

  > [!NOTE]
  > The hosted Blazor WebAssmebly project template isn't available in ASP.NET Core 8.0 or later. To create a hosted Blazor WebAssembly app using a .NET 8.0 or later SDK, pass the `-f|--framework` option with a 7.0 target framework (`net7.0`):
  >
  > ```dotnet cli
  > dotnet new blazorwasm -o BlazorApp -ho -f net7.0
  > ```

:::moniker-end

:::moniker range="< aspnetcore-7.0"

Create a new project:

* Change to the directory using the `cd` command to where you want to create the project folder (for example, `cd c:/users/Bernie_Kopell/Documents`).

* For a Blazor WebAssembly experience, execute the following command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp
  ```

* For a hosted Blazor WebAssembly experience, add the hosted option (`-ho` or `--hosted`) option to the command:

  ```dotnetcli
  dotnet new blazorwasm -o BlazorApp -ho
  ```

  > [!NOTE]
  > The hosted Blazor WebAssmebly project template isn't available in ASP.NET Core 8.0 or later. To create a hosted Blazor WebAssembly app using a .NET 8.0 or later SDK, pass the `-f|--framework` option with the target framework moniker (for example, `net6.0`):
  >
  > ```dotnet cli
  > dotnet new blazorwasm -o BlazorApp -ho -f net6.0
  > ```

* For a Blazor Server experience, execute the following command:

  ```dotnetcli
  dotnet new blazorserver -o BlazorApp
  ```

:::moniker-end

For more information on the templates and options, see the [Blazor project templates and template options](#blazor-project-templates-and-template-options) section.

:::zone-end

## Run the app

:::moniker range=">= aspnetcore-8.0"

> [!IMPORTANT]
> When executing a Blazor Web App, run the app from the solution's server project, which is the project with a name that doesn't end in `.Client`.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

> [!IMPORTANT]
> When executing a hosted Blazor WebAssembly app, run the app from the solution's **:::no-loc text="Server":::** project.

:::moniker-end

:::zone pivot="vs"

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> on the keyboard to run the app without the debugger.

Visual Studio displays the following dialog when a project isn't configured to use SSL:

![Trust self-signed certificate dialog](~/blazor/tooling/_static/trust-certificate.png)

Select **Yes** if you trust the ASP.NET Core SSL certificate.

The following dialog is displayed:

![Security warning dialog](~/blazor/tooling/_static/install-certificate.png)

Select **Yes** to acknowledge the risk and install the certificate.

Visual Studio:

* Compiles and runs the app.
* Launches the default browser at `https://localhost:{PORT}`, which displays the app's UI. The `{PORT}` placeholder is the random port assigned at app creation. If you need to change the port due to a local port conflict, change the port in the project's `Properties/launchSettings.json` file.

:::zone-end

:::zone pivot="vsc"

In VS Code, press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

At the **Select debugger** prompt in the **Command Palette** at the top of the VS Code UI, select **C#**. At the next prompt, select the HTTPS profile (`[https]`).

The default browser is launched at `https://localhost:{PORT}`, which displays the app's UI. The `{PORT}` placeholder is the random port assigned at app creation. If you need to change the port due to a local port conflict, change the port in the project's `Properties/launchSettings.json` file.

:::zone-end

:::zone pivot="cli"

In a command shell opened to the project's root folder, execute the [`dotnet watch`](/dotnet/core/tools/dotnet-watch) command to compile and start the app:

```dotnetcli
dotnet watch
```

The default browser is launched at `https://localhost:{PORT}`, which displays the app's UI. The `{PORT}` placeholder is the random port assigned at app creation. If you need to change the port due to a local port conflict, change the port in the project's `Properties/launchSettings.json` file.

When an app created from the Blazor Web App project template is run with the .NET CLI, the app runs at an HTTP (insecure) endpoint because the first profile found in the app's launch settings file (`Properties/launchSettings.json`) is the HTTP (insecure) profile, which is named `http`. The HTTP profile was placed in the first position to ease the transition of adopting SSL/HTTPS security for non-Windows users.

One approach for running the app with SSL/HTTPS is to pass the [`-lp`|`--launch-profile` option](/dotnet/core/tools/dotnet-run#options) with the `https` profile name to the `dotnet watch` command:

```dotnetcli
dotnet watch -lp https
```

An alternative approach is to move the `https` profile above the `http` profile in the `Properties/launchSettings.json` file and save the change. After changing the profile order in the file, the `dotnet watch` command always uses the `https` profile by default.

:::zone-end

## Stop the app

:::zone pivot="vs"

Stop the app using either of the following approaches:

* Close the browser window.
* In Visual Studio, either:
  * Use the Stop button in Visual Studio's menu bar:

    ![Stop button in Visual Studio's menu bar](~/blazor/tooling/_static/stop-button.png)

  * Press <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard.

:::zone-end

:::zone pivot="vsc"

Stop the app using the following approach:

1. Close the browser window.
1. In VS Code, either:
   * From the **Run** menu, select **Stop Debugging**.
   * Press <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard.

:::zone-end

:::zone pivot="cli"

Stop the app using the following approach:

1. Close the browser window.
2. In the command shell, press <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS).

:::zone-end

## Visual Studio solution file (`.sln`)

A *solution* is a container to organize one or more related code projects. Solution files use a unique format and aren't intended to be edited directly.

[Visual Studio](https://visualstudio.microsoft.com/vs/) and [Visual Studio Code (VS Code)](https://code.visualstudio.com) use a solution file (`.sln`) to store settings for a solution. The [.NET CLI](/dotnet/core/tools/) doesn't organize projects using a solution file, but it can create solution files and list/modify the projects in solution files via the [`dotnet sln` command](/dotnet/core/tools/dotnet-sln). Other .NET CLI commands use the path of the solution file for various publishing, testing, and packaging commands.

:::moniker range="< aspnetcore-8.0"

Throughout the Blazor documentation, *solution* is used to describe apps created from the Blazor WebAssembly project template with the **ASP.NET Core Hosted** option enabled or from a Blazor Hybrid project template. Apps produced from these project templates include a solution file (`.sln`) by default. For hosted Blazor WebAssembly apps where the developer isn't using Visual Studio, the solution file can be ignored or deleted if it isn't used with .NET CLI commands.

:::moniker-end

For more information, see the following resources:

* [Introduction to projects and solutions (Visual Studio documentation)](/visualstudio/get-started/tutorial-projects-solutions)
* [What are solutions and projects in Visual Studio? (Visual Studio documentation)](/visualstudio/ide/solutions-and-projects-in-visual-studio)
* [Project management (VS Code documentation)](https://code.visualstudio.com/docs/csharp/project-management)

## Blazor project templates and template options

The Blazor framework provides project templates for creating new apps. The templates are used to create new Blazor projects and solutions regardless of the tooling that you select for Blazor development (Visual Studio, Visual Studio Code, or the [.NET command-line interface (CLI)](/dotnet/core/tools/)):

:::moniker range=">= aspnetcore-8.0"

* Blazor Web App project template: `blazor`
* Standalone Blazor WebAssembly app project template: `blazorwasm`

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

:::moniker range=">= aspnetcore-8.0"

Rendering terms and concepts used in the following subsections are introduced in the following sections of the *Fundamentals* overview article:

* [Client and server rendering concepts](xref:blazor/fundamentals/index#client-and-server-rendering-concepts)
* [Static and interactive rendering concepts](xref:blazor/fundamentals/index#static-and-interactive-rendering-concepts)
* [Render modes](xref:blazor/fundamentals/index#render-modes)

Detailed guidance on render modes is provided by the <xref:blazor/components/render-modes> article.

### Interactive render mode

* Interactive server-side rendering (interactive SSR) is enabled by default with the **Server** option.
* To only enable interactivity with client-side rendering (CSR), use the **WebAssembly** option.
* To enable both interactive rendering modes and the ability to automatically switch between them at runtime, use the **Auto (Server and WebAssembly)** (automatic) render mode option.
* If interactivity is set to `None`, the generated app has no interactivity. The app is only configured for static server-side rendering.

The Interactive Auto render mode initially uses interactive SSR while the .NET app bundle and runtime are download to the browser. After the .NET WebAssembly runtime is activated, the render mode switches to Interactive WebAssembly rendering.

By default, the Blazor Web App template enables both static and interactive SSR using a single project. If you also enable CSR, the project includes an additional client project (`.Client`) for your WebAssembly-based components. The built output from the client project is downloaded to the browser and executed on the client. Any components using the WebAssembly or automatic render modes must be built from the client project.

> [!IMPORTANT]
> When using a Blazor Web App, most of the Blazor documentation example components ***require*** interactivity to function and demonstrate the concepts covered by the articles. When you test an example component provided by an article, make sure that either the app adopts global interactivity or the component adopts an interactive render mode.

### Interactivity location

Interactivity location options:

* **Per page/component**: The default sets up interactivity per page or per component.
* **Global**: Using this option sets up interactivity globally for the entire app.

Interactivity location can only be set if **Interactive render mode** isn't `None` and authentication isn't enabled.

### Sample pages

To include sample pages and a layout based on Bootstrap styling, use the **Include sample pages** option. Disable this option for project without sample pages and Bootstrap styling.

### Additional guidance on template options

* <xref:blazor/components/render-modes>
* The *.NET default templates for dotnet new* article in the .NET Core documentation:
  * [`blazor`](/dotnet/core/tools/dotnet-new-sdk-templates#blazor)
  * [`blazorwasm`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorwasm)
* Passing the help option (`-h` or `--help`) to the [`dotnet new`](/dotnet/core/tools/dotnet-new) CLI command in a command shell:
  * `dotnet new blazor -h`
  * `dotnet new blazorwasm -h`

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

For more information on template options, see the following resources:

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

For more information on template options, see the following resources:

* The *.NET default templates for dotnet new* article in the .NET Core documentation:
  * [`blazorserver`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorserver)
  * [`blazorwasm`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorwasm)
* Passing the help option (`-h` or `--help`) to the [`dotnet new`](/dotnet/core/tools/dotnet-new) CLI command in a command shell:
  * `dotnet new blazorserver -h`
  * `dotnet new blazorwasm -h`

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-6.0"

* [Visual Studio](https://visualstudio.microsoft.com)
* [Visual Studio Code](https://code.visualstudio.com)
* <xref:blazor/tooling/webassembly>
* [.NET command-line interface (CLI)](/dotnet/core/tools/)
* [.NET SDK](/dotnet/core/sdk)
* <xref:test/hot-reload>
* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>
* <xref:blazor/hybrid/tutorials/index>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* [Visual Studio](https://visualstudio.microsoft.com)
* [Visual Studio Code](https://code.visualstudio.com)
* [.NET command-line interface (CLI)](/dotnet/core/tools/)
* [.NET SDK](/dotnet/core/sdk)
* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>

:::moniker-end
