---
title: Tooling for ASP.NET Core Blazor
author: guardrex
description: Learn about the tools available to build Blazor apps on various platforms.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/tooling
zone_pivot_groups: operating-systems
---
# Tooling for ASP.NET Core Blazor

This article describes tools for building Blazor apps on various platforms.

:::moniker range=">= aspnetcore-6.0"

:::zone pivot="windows"

1. Install the latest version of [Visual Studio 2022](https://visualstudio.microsoft.com) with the **ASP.NET and web development** workload.

1. Create a new project.

1. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

1. Provide a **Project name** and confirm that the **Location** is correct. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox for a hosted Blazor WebAssembly app. Select **Create**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

   When running a hosted Blazor WebAssembly [solution](#visual-studio-solution-file-sln) in Visual Studio, the startup project of the solution is the **`Server`** project.

For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

> [!IMPORTANT]
> When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

:::zone-end

:::zone pivot="linux"

Use the [.NET command-line interface (CLI)](/dotnet/core/tools/) to execute commands in a Linux command shell.

1. Install the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/download). If you previously installed the SDK, you can determine your installed version by executing the following command:

   ```dotnetcli
   dotnet --version
   ```

1. Install the latest version of [Visual Studio Code](https://code.visualstudio.com).

1. Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

1. For a Blazor WebAssembly experience, execute the following command:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1
   ```

   For a hosted Blazor WebAssembly experience, add the hosted option (`-ho` or `--hosted`) option to the command:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1 -ho
   ```

   For a Blazor Server experience, execute the following command:

   ```dotnetcli
   dotnet new blazorserver -o WebApplication1
   ```

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Open the `WebApplication1` folder in Visual Studio Code.

1. The IDE requests that you add assets to build and debug the project. Select **Yes**.

   If Visual Studio Code doesn't offer to create the assets automatically, use the following files:

   `.vscode/launch.json` (configured for launch and debug of a Blazor WebAssembly app):

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

   The project's `Properties/launchSettings.json` file includes the `inspectUri` property for the debugging proxy for any profiles in the `profiles` section of the file:

   ```json
   "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
   ```

   **Hosted Blazor WebAssembly launch and task configuration**

   For hosted Blazor WebAssembly [solutions](#visual-studio-solution-file-sln), add (or move) the `.vscode` folder with `launch.json` and `tasks.json` files to the solution's parent folder, which is the folder that contains the typical project folders: `Client`, `Server`, and `Shared`. Update or confirm that the configuration in the `launch.json` and `tasks.json` files execute a hosted Blazor WebAssembly app from the **`Server`** project.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

   Examine the `Properties/launchSettings.json` file and determine the URL of the app from the `applicationUrl` property (for example, `https://localhost:7268`). Note this value for use in the `launch.json` file.

   In the launch configuration of the `.vscode/launch.json` file:

   * Set the current working directory (`cwd`) to the **`Server`** project folder.
   * Indicate the app's URL with the `url` property. Use the value recorded earlier from the `Properties/launchSettings.json` file.

   ```json
   "cwd": "${workspaceFolder}/{SERVER APP FOLDER}",
   "url": "{URL}"
   ```

   In the preceding configuration:

   * The `{SERVER APP FOLDER}` placeholder is the **`Server`** project's folder, typically `Server`.
   * The `{URL}` placeholder is the app's URL, which is specified in the app's `Properties/launchSettings.json` file in the `applicationUrl` property.

   If Microsoft Edge is used and Google Chrome isn't installed on the system, add an additional property of `"browser": "edge"` to the configuration.

   The follow example `.vscode/launch.json` file:

   * Sets the current working directory to the `Server` folder.
   * Sets the URL for the app to `https://localhost:7268`.
   * Changes the default browser from Google Chrome, which is the default browser, to Microsoft Edge.

   ```json
   "cwd": "${workspaceFolder}/Server",
   "url": "https://localhost:7268",
   "browser": "edge"
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
         "url": "https://localhost:7268",
         "browser": "edge"
       }
     ]
   }
   ```

   In `.vscode/tasks.json`, add a `build` argument that specifies the path to the **`Server`** app's project file:

   ```json
   "${workspaceFolder}/{SERVER APP FOLDER}/{PROJECT NAME}.csproj",
   ```

   In the preceding argument:

   * The `{SERVER APP FOLDER}` placeholder is the **`Server`** project's folder, typically `Server`.
   * The `{PROJECT NAME}` placeholder is the app's name, typically based on the solution's name followed by `.Server` in an app generated from the Blazor WebAssembly project template.

   An example `.vscode/tasks.json` file with a **`Server`** project named `BlazorHosted` in the `Server` folder of the solution:

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

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

> [!NOTE]
> Only [browser debugging](xref:blazor/debug#debug-in-the-browser) is supported at this time.
>
> You can't automatically rebuild the backend **`Server`** app of a hosted Blazor WebAssembly solution during debugging, for example by running the app with [`dotnet watch run`](xref:tutorials/dotnet-watch).

## Trust a development certificate

There's no centralized way to trust a certificate on Linux. Typically, one of the following approaches is adopted:

* Exclude the app's URL in browser's exclude list.
* Trust all self-signed certificates for `localhost`.
* Add the certificate to the list of trusted certificates in the browser.

For more information, see the guidance provided by your browser manufacturer and Linux distribution.

:::zone-end

:::zone pivot="macos"

1. Install [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

   For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Confirm that **Authentication** is set to **No Authentication**. Select **Next**.

1. For a hosted Blazor WebAssembly experience, select the **ASP.NET Core hosted** checkbox.

1. In the **Project Name** field, name the app `WebApplication1`. Select **Create**.

1. Select **Run** > **Start Without Debugging** to run the app *without the debugger*. Run the app with **Run** > **Start Debugging** or the Run (&#9654;) button to run the app *with the debugger*.

If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate. For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

> [!IMPORTANT]
> When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

:::zone-end

## Visual Studio solution file (`.sln`)

A *solution* is a container to organize one or more related code projects. [Visual Studio](https://visualstudio.microsoft.com/vs/) and [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) use a solution file (`.sln`) to store settings for a solution. Solution files use a unique format and aren't intended to be edited directly.

Tooling outside of Visual Studio and Visual Studio for Mac can interact with solution files:

* The [.NET CLI](/dotnet/core/tools/) can create solution files and list/modify the projects in solution files via the [`dotnet sln` command](/dotnet/core/tools/dotnet-sln). Other .NET CLI commands use the path of the solution file for various publishing, testing, and packaging commands.
* [Visual Studio Code](https://code.visualstudio.com) can execute the `dotnet sln` command and other .NET CLI commands through its integrated terminal but doesn't use the settings in a solution file directly.

Throughout the Blazor documentation, *solution* is used to describe apps created from the Blazor WebAssembly project template with the *ASP.NET Core hosted* option enabled or from a Blazor Hybrid project template. Apps produced from these project templates include a solution file (`.sln`) by default. For hosted Blazor WebAssembly apps where the developer isn't using Visual Studio or Visual Studio for Mac, the solution file can be ignored or deleted if it isn't used with .NET CLI commands.

For more information, see the following resources in the Visual Studio documentation:

* [Introduction to projects and solutions](/visualstudio/get-started/tutorial-projects-solutions)
* [What are solutions and projects in Visual Studio?](/visualstudio/ide/solutions-and-projects-in-visual-studio)

## Use Visual Studio Code for cross-platform Blazor development

[Visual Studio Code](https://code.visualstudio.com/) is an open source, cross-platform Integrated Development Environment (IDE) that can be used to develop Blazor apps. Use the [.NET CLI](/dotnet/core/tools/) to create a new Blazor app for development with Visual Studio Code. For more information, see the [Linux version of this article](?pivots=linux).

## Blazor template options

The Blazor framework provides templates for creating new apps for each of the two Blazor hosting models. The templates are used to create new Blazor projects and solutions regardless of the tooling that you select for Blazor development (Visual Studio, Visual Studio for Mac, Visual Studio Code, or the [.NET command-line interface (CLI)](/dotnet/core/tools/)):

* Blazor Server project template: `blazorserver`
* Blazor WebAssembly project template: `blazorwasm`

For more information on Blazor's hosting models, see <xref:blazor/hosting-models>. For more information on Blazor project templates, see <xref:blazor/project-structure>.

For more information on template options, see the following resources:

* *.NET default templates for dotnet new* article in the .NET Core documentation:
  * [`blazorserver`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorserver)
  * [`blazorwasm`](/dotnet/core/tools/dotnet-new-sdk-templates#blazorwasm)
* Passing the help option (`-h` or `--help`) to the [`dotnet new`](/dotnet/core/tools/dotnet-new) CLI command in a command shell:
  * `dotnet new blazorserver -h`
  * `dotnet new blazorwasm -h`

## .NET WebAssembly build tools

The **.NET WebAssembly build tools** are based on [Emscripten](https://emscripten.org/), a compiler toolchain for the web platform. To install the **.NET WebAssembly build tools**, use ***either*** of the following approaches:

* For the **ASP.NET and web development** workload in the Visual Studio installer, select the **.NET WebAssembly build tools** option from the list of optional components.
* Run `dotnet workload install wasm-tools` in a command shell.

For more information, see the following resources:

* [Ahead-of-time (AOT) compilation](xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation)
* [Runtime relinking](xref:blazor/host-and-deploy/webassembly#runtime-relinking)
* <xref:blazor/webassembly-native-dependencies>

## Additional resources

* [.NET command-line interface (CLI)](/dotnet/core/tools/)
* <xref:test/hot-reload>
* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>
* <xref:blazor/hybrid/tutorials/index>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::zone pivot="windows"

1. Install the latest version of [Visual Studio 2022](https://visualstudio.microsoft.com) with the **ASP.NET and web development** workload.

1. Create a new project.

1. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

1. Provide a **Project name** and confirm that the **Location** is correct. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox for a hosted Blazor WebAssembly app. Select **Create**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

   When running a hosted Blazor WebAssembly [solution](#visual-studio-solution-file-sln) in Visual Studio, the startup project of the solution is the **`Server`** project.

For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

> [!IMPORTANT]
> When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

:::zone-end

:::zone pivot="linux"

1. Install the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/download). If you previously installed the SDK, you can determine your installed version by executing the following command in a command shell:

   ```dotnetcli
   dotnet --version
   ```

1. Install the latest version of [Visual Studio Code](https://code.visualstudio.com).

1. Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

1. For a Blazor WebAssembly experience, execute the following command in a command shell:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1
   ```

   For a hosted Blazor WebAssembly experience, add the hosted option (`-ho` or `--hosted`) option to the command:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1 -ho
   ```

   For a Blazor Server experience, execute the following command in a command shell:

   ```dotnetcli
   dotnet new blazorserver -o WebApplication1
   ```

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Open the `WebApplication1` folder in Visual Studio Code.

1. The IDE requests that you add assets to build and debug the project. Select **Yes**.

   If Visual Studio Code doesn't offer to create the assets automatically, use the following files:

   `.vscode/launch.json` (configured for launch and debug of a Blazor WebAssembly app):

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

   **Hosted Blazor WebAssembly launch and task configuration**

   For hosted Blazor WebAssembly [solutions](#visual-studio-solution-file-sln), add (or move) the `.vscode` folder with `launch.json` and `tasks.json` files to the solution's parent folder, which is the folder that contains the typical project folders: `Client`, `Server`, and `Shared`. Update or confirm that the configuration in the `launch.json` and `tasks.json` files execute a hosted Blazor WebAssembly app from the **`Server`** project.

   > [!IMPORTANT]
   > When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

   **`.vscode/launch.json`** (`launch` configuration):

   ```json
   ...
   "cwd": "${workspaceFolder}/{SERVER APP FOLDER}",
   ...
   ```

   In the preceding configuration for the current working directory (`cwd`), the `{SERVER APP FOLDER}` placeholder is the **`Server`** project's folder, typically "`Server`".

   If Microsoft Edge is used and Google Chrome isn't installed on the system, add an additional property of `"browser": "edge"` to the configuration.

   Example for a project folder of `Server` and that spawns Microsoft Edge as the browser for debug runs instead of the default browser Google Chrome:

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

   * The `{SERVER APP FOLDER}` placeholder is the **`Server`** project's folder, typically "`Server`".
   * The `{PROJECT NAME}` placeholder is the app's name, typically based on the solution's name followed by "`.Server`" in an app generated from the [Blazor project template](xref:blazor/project-structure).

   The following example from the [tutorial for using SignalR with a Blazor WebAssembly app](xref:blazor/tutorials/signalr-blazor) uses a project folder name of `Server` and a project name of `BlazorWebAssemblySignalRApp.Server`:

   ```json
   ...
   "args": [
     "build",
       "${workspaceFolder}/Server/BlazorWebAssemblySignalRApp.Server.csproj",
       ...
   ],
   ...
   ```

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

## Trust a development certificate

There's no centralized way to trust a certificate on Linux. Typically, one of the following approaches is adopted:

* Exclude the app's URL in browser's exclude list.
* Trust all self-signed certificates for `localhost`.
* Add the certificate to the list of trusted certificates in the browser.

For more information, see the guidance provided by your browser manufacturer and Linux distribution.

:::zone-end

:::zone pivot="macos"

1. Install [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

   For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Confirm that **Authentication** is set to **No Authentication**. Select **Next**.

1. For a hosted Blazor WebAssembly experience, select the **ASP.NET Core hosted** checkbox.

1. In the **Project Name** field, name the app `WebApplication1`. Select **Create**.

1. Select **Run** > **Start Without Debugging** to run the app *without the debugger*. Run the app with **Run** > **Start Debugging** or the Run (&#9654;) button to run the app *with the debugger*.

If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate. For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

> [!IMPORTANT]
> When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

:::zone-end

## Visual Studio solution file (`.sln`)

A *solution* is a container to organize one or more related code projects. [Visual Studio](https://visualstudio.microsoft.com/vs/) and [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) use a solution file (`.sln`) to store settings for a solution. Solution files use a unique format and aren't intended to be edited directly.

Tooling outside of Visual Studio and Visual Studio for Mac can interact with solution files:

* The [.NET CLI](/dotnet/core/tools/) can create solution files and list/modify the projects in solution files via the [`dotnet sln` command](/dotnet/core/tools/dotnet-sln). Other .NET CLI commands use the path of the solution file for various publishing, testing, and packaging commands.
* [Visual Studio Code](https://code.visualstudio.com) can execute the `dotnet sln` command and other .NET CLI commands through its integrated terminal but doesn't use the settings in a solution file directly.

Throughout the Blazor documentation, *solution* is used to describe apps created from the Blazor WebAssembly project template with the *ASP.NET Core hosted* option enabled or from a Blazor Hybrid project template. Apps produced from these project templates include a solution file (`.sln`) by default. For hosted Blazor WebAssembly apps where the developer isn't using Visual Studio or Visual Studio for Mac, the solution file can be ignored or deleted if it isn't used with .NET CLI commands.

For more information, see the following resources in the Visual Studio documentation:

* [Introduction to projects and solutions](/visualstudio/get-started/tutorial-projects-solutions)
* [What are solutions and projects in Visual Studio?](/visualstudio/ide/solutions-and-projects-in-visual-studio)

## Use Visual Studio Code for cross-platform Blazor development

[Visual Studio Code](https://code.visualstudio.com/) is an open source, cross-platform Integrated Development Environment (IDE) that can be used to develop Blazor apps. Use the .NET CLI to create a new Blazor app for development with Visual Studio Code. For more information, see the [Linux version of this article](?pivots=linux).

## Blazor template options

The Blazor framework provides templates for creating new apps for each of the two Blazor hosting models. The templates are used to create new Blazor projects and solutions regardless of the tooling that you select for Blazor development (Visual Studio, Visual Studio for Mac, Visual Studio Code, or the .NET CLI):

* Blazor WebAssembly project template: `blazorwasm`
* Blazor Server project template: `blazorserver`

For more information on Blazor's hosting models, see <xref:blazor/hosting-models>. For more information on Blazor project templates, see <xref:blazor/project-structure>.

Template options are available by passing the help option (`-h` or `--help`) to the [`dotnet new`](/dotnet/core/tools/dotnet-new) CLI command in a command shell:

```dotnetcli
dotnet new blazorwasm -h
dotnet new blazorserver -h
```

## Additional resources

* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::zone pivot="windows"

1. Install the latest version of [Visual Studio 2022](https://visualstudio.microsoft.com) with the **ASP.NET and web development** workload.

1. Create a new project.

1. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

1. Provide a **Project name** and confirm that the **Location** is correct. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox for a hosted Blazor WebAssembly app. Select **Create**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

   When running a hosted Blazor WebAssembly [solution](#visual-studio-solution-file-sln) in Visual Studio, the startup project of the solution is the **`Server`** project.

For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

:::zone-end

:::zone pivot="linux"

1. Install the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/download). If you previously installed the SDK, you can determine your installed version by executing the following command in a command shell:

   ```dotnetcli
   dotnet --version
   ```

1. Install the latest version of [Visual Studio Code](https://code.visualstudio.com).

1. Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

1. For a Blazor WebAssembly experience, execute the following command in a command shell:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1
   ```

   For a hosted Blazor WebAssembly experience, add the hosted option (`-ho` or `--hosted`) option to the command:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1 -ho
   ```

   For a Blazor Server experience, execute the following command in a command shell:

   ```dotnetcli
   dotnet new blazorserver -o WebApplication1
   ```

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Open the `WebApplication1` folder in Visual Studio Code.

1. The IDE requests that you add assets to build and debug the project. Select **Yes**.

   If Visual Studio Code doesn't offer to create the assets automatically, use the following files:

   `.vscode/launch.json` (configured for launch and debug of a Blazor WebAssembly app):

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

   **Hosted Blazor WebAssembly launch and task configuration**

   For hosted Blazor WebAssembly [solutions](#visual-studio-solution-file-sln), add (or move) the `.vscode` folder with `launch.json` and `tasks.json` files to the solution's parent folder, which is the folder that contains the typical project folders: `Client`, `Server`, and `Shared`. Update or confirm that the configuration in the `launch.json` and `tasks.json` files execute a hosted Blazor WebAssembly app from the **`Server`** project.

   **`.vscode/launch.json`** (`launch` configuration):

   ```json
   ...
   "cwd": "${workspaceFolder}/{SERVER APP FOLDER}",
   ...
   ```

   In the preceding configuration for the current working directory (`cwd`), the `{SERVER APP FOLDER}` placeholder is the **`Server`** project's folder, typically "`Server`".

   If Microsoft Edge is used and Google Chrome isn't installed on the system, add an additional property of `"browser": "edge"` to the configuration.

   Example for a project folder of `Server` and that spawns Microsoft Edge as the browser for debug runs instead of the default browser Google Chrome:

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

   * The `{SERVER APP FOLDER}` placeholder is the **`Server`** project's folder, typically "`Server`".
   * The `{PROJECT NAME}` placeholder is the app's name, typically based on the solution's name followed by "`.Server`" in an app generated from the [Blazor project template](xref:blazor/project-structure).

   The following example from the [tutorial for using SignalR with a Blazor WebAssembly app](xref:blazor/tutorials/signalr-blazor) uses a project folder name of `Server` and a project name of `BlazorWebAssemblySignalRApp.Server`:

   ```json
   ...
   "args": [
     "build",
       "${workspaceFolder}/Server/BlazorWebAssemblySignalRApp.Server.csproj",
       ...
   ],
   ...
   ```

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app.

## Trust a development certificate

There's no centralized way to trust a certificate on Linux. Typically, one of the following approaches is adopted:

* Exclude the app's URL in browser's exclude list.
* Trust all self-signed certificates for `localhost`.
* Add the certificate to the list of trusted certificates in the browser.

For more information, see the guidance provided by your browser manufacturer and Linux distribution.

:::zone-end

:::zone pivot="macos"

1. Install [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).

1. Select **File** > **New Solution** or create a **New** project from the **Start Window**.

1. In the sidebar, select **Web and Console** > **App**.

   For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Confirm that **Authentication** is set to **No Authentication**. Select **Next**.

1. For a hosted Blazor WebAssembly experience, select the **ASP.NET Core hosted** checkbox.

1. In the **Project Name** field, name the app `WebApplication1`. Select **Create**.

1. Select **Run** > **Start Without Debugging** to run the app *without the debugger*. Run the app with **Run** > **Start Debugging** or the Run (&#9654;) button to run the app *with the debugger*.

If a prompt appears to trust the development certificate, trust the certificate and continue. The user and keychain passwords are required to trust the certificate. For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

:::zone-end

## Visual Studio solution file (`.sln`)

A *solution* is a container to organize one or more related code projects. [Visual Studio](https://visualstudio.microsoft.com/vs/) and [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) use a solution file (`.sln`) to store settings for a solution. Solution files use a unique format and aren't intended to be edited directly.

Tooling outside of Visual Studio and Visual Studio for Mac can interact with solution files:

* The [.NET CLI](/dotnet/core/tools/) can create solution files and list/modify the projects in solution files via the [`dotnet sln` command](/dotnet/core/tools/dotnet-sln). Other .NET CLI commands use the path of the solution file for various publishing, testing, and packaging commands.
* [Visual Studio Code](https://code.visualstudio.com) can execute the `dotnet sln` command and other .NET CLI commands through its integrated terminal but doesn't use the settings in a solution file directly.

Throughout the Blazor documentation, *solution* is used to describe apps created from the Blazor WebAssembly project template with the *ASP.NET Core hosted* option enabled or from a Blazor Hybrid project template. Apps produced from these project templates include a solution file (`.sln`) by default. For hosted Blazor WebAssembly apps where the developer isn't using Visual Studio or Visual Studio for Mac, the solution file can be ignored or deleted if it isn't used with .NET CLI commands.

For more information, see the following resources in the Visual Studio documentation:

* [Introduction to projects and solutions](/visualstudio/get-started/tutorial-projects-solutions)
* [What are solutions and projects in Visual Studio?](/visualstudio/ide/solutions-and-projects-in-visual-studio)

## Use Visual Studio Code for cross-platform Blazor development

[Visual Studio Code](https://code.visualstudio.com/) is an open source, cross-platform Integrated Development Environment (IDE) that can be used to develop Blazor apps. Use the .NET CLI to create a new Blazor app for development with Visual Studio Code. For more information, see the [Linux version of this article](?pivots=linux).

## Blazor template options

The Blazor framework provides templates for creating new apps for each of the two Blazor hosting models. The templates are used to create new Blazor projects and solutions regardless of the tooling that you select for Blazor development (Visual Studio, Visual Studio for Mac, Visual Studio Code, or the .NET CLI):

* Blazor WebAssembly project template: `blazorwasm`
* Blazor Server project template: `blazorserver`

For more information on Blazor's hosting models, see <xref:blazor/hosting-models>. For more information on Blazor project templates, see <xref:blazor/project-structure>.

Template options are available by passing the help option (`-h` or `--help`) to the [`dotnet new`](/dotnet/core/tools/dotnet-new) CLI command in a command shell:

```dotnetcli
dotnet new blazorwasm -h
dotnet new blazorserver -h
```

## Additional resources

* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>

:::moniker-end
