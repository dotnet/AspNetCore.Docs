---
title: Tooling for ASP.NET Core Blazor
author: guardrex
description: Learn about the tooling available to build Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/11/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/tooling
zone_pivot_groups: operating-systems
---
# Tooling for ASP.NET Core Blazor

::: moniker range=">= aspnetcore-6.0"

::: zone pivot="windows"

1. Install the latest version of [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/) with the **ASP.NET and web development** workload.

1. Create a new project.

1. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

1. Provide a **Project name** and confirm that the **Location** is correct. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox for a hosted Blazor WebAssembly app. Select **Create**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app.

For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

::: zone-end

::: zone pivot="linux"

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

   For hosted Blazor WebAssembly solutions, add (or move) the `.vscode` folder with `launch.json` and `tasks.json` files to the solution's parent folder, which is the folder that contains the typical project folders: `Client`, `Server`, and `Shared`. Update or confirm that the configuration in the `launch.json` and `tasks.json` files execute a hosted Blazor WebAssembly app from the **`Server`** project.

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

   The following example from the [tutorial for using SignalR with a Blazor WebAssembly app](xref:tutorials/signalr-blazor) uses a project folder name of `Server` and a project name of `BlazorWebAssemblySignalRApp.Server`:

   ```json
   ...
   "args": [
     "build",
       "${workspaceFolder}/Server/BlazorWebAssemblySignalRApp.Server.csproj",
       ...
   ],
   ...
   ```

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app.

## Trust a development certificate

There's no centralized way to trust a certificate on Linux. Typically, one of the following approaches is adopted:

* Exclude the app's URL in browser's exclude list.
* Trust all self-signed certificates for `localhost`.
* Add the certificate to the list of trusted certificates in the browser.

For more information, see the guidance provided by your browser manufacturer and Linux distribution.

::: zone-end

::: zone pivot="macos"

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

::: zone-end

## Use Visual Studio Code for cross-platform Blazor development

[Visual Studio Code](https://code.visualstudio.com/) is an open source, cross-platform Integrated Development Environment (IDE) that can be used to develop Blazor apps. Use the .NET CLI to create a new Blazor app for development with Visual Studio Code. For more information, see the [Linux version of this article](?pivots=linux).

## Blazor template options

The Blazor framework provides templates for creating new apps for each of the two Blazor hosting models. The templates are used to create new Blazor projects and solutions regardless of the tooling that you select for Blazor development (Visual Studio, Visual Studio for Mac, Visual Studio Code, or the .NET CLI):

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

## .NET Hot reload

.NET Hot Reload applies code changes, including changes to stylesheets, to a running app without restarting the app and without losing app state.

Hot Reload is activated using the [`dotnet watch`](/aspnet/core/tutorials/dotnet-watch) command:

```dotnetcli
dotnet watch
```

To force the app to rebuild and restart, use the keyboard combination <kbd>Ctrl</kbd>+<kbd>R</kbd> in the command shell.

When an unsupported code edit is made, called a *rude edit*, `dotnet watch` asks you if you want to restart the app:

* **Yes**: Restarts the app.
* **No**: Doesn't restart the app and leaves the app running without the changes applied.
* **Always**: Restarts the app as needed when rude edits occur.
* **Never**: Doesn't restart the app and avoids future prompts.

To disable support for Hot Reload, pass the `--no-hot-reload` option to the `dotnet watch` command:

```dotnetcli
dotnet watch --no-hot-reload
```

For Blazor WebAssembly apps, only method body replacement is currently supported. Additional features will be added in upcoming releases of ASP.NET Core. For more information on supported scenarios, see [Supported code changes (C# and Visual Basic)](/visualstudio/debugger/supported-code-changes-csharp).

## Additional resources

* <xref:blazor/hosting-models>
* <xref:blazor/project-structure>

::: moniker-end

::: moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

::: zone pivot="windows"

1. Install the latest version of [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/) with the **ASP.NET and web development** workload.

1. Create a new project.

1. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

1. Provide a **Project name** and confirm that the **Location** is correct. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox for a hosted Blazor WebAssembly app. Select **Create**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app.

For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

::: zone-end

::: zone pivot="linux"

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

   For hosted Blazor WebAssembly solutions, add (or move) the `.vscode` folder with `launch.json` and `tasks.json` files to the solution's parent folder, which is the folder that contains the typical project folders: `Client`, `Server`, and `Shared`. Update or confirm that the configuration in the `launch.json` and `tasks.json` files execute a hosted Blazor WebAssembly app from the **`Server`** project.

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

   The following example from the [tutorial for using SignalR with a Blazor WebAssembly app](xref:tutorials/signalr-blazor) uses a project folder name of `Server` and a project name of `BlazorWebAssemblySignalRApp.Server`:

   ```json
   ...
   "args": [
     "build",
       "${workspaceFolder}/Server/BlazorWebAssemblySignalRApp.Server.csproj",
       ...
   ],
   ...
   ```

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app.

## Trust a development certificate

There's no centralized way to trust a certificate on Linux. Typically, one of the following approaches is adopted:

* Exclude the app's URL in browser's exclude list.
* Trust all self-signed certificates for `localhost`.
* Add the certificate to the list of trusted certificates in the browser.

For more information, see the guidance provided by your browser manufacturer and Linux distribution.

::: zone-end

::: zone pivot="macos"

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

::: zone-end

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

::: moniker-end

::: moniker range="< aspnetcore-5.0"

::: zone pivot="windows"

1. Install the latest version of [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/) with the **ASP.NET and web development** workload.

1. Create a new project.

1. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Next**.

1. Provide a **Project name** and confirm that the **Location** is correct. Select **Next**.

1. In the **Additional information** dialog, select the **ASP.NET Core hosted** checkbox for a hosted Blazor WebAssembly app. Select **Create**.

   For information on the two Blazor hosting models, *Blazor WebAssembly* (standalone and hosted) and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app.

For more information on trusting the ASP.NET Core HTTPS development certificate, see <xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos>.

When executing a hosted Blazor WebAssembly app, run the app from the solution's **`Server`** project.

::: zone-end

::: zone pivot="linux"

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

   For hosted Blazor WebAssembly solutions, add (or move) the `.vscode` folder with `launch.json` and `tasks.json` files to the solution's parent folder, which is the folder that contains the typical project folders: `Client`, `Server`, and `Shared`. Update or confirm that the configuration in the `launch.json` and `tasks.json` files execute a hosted Blazor WebAssembly app from the **`Server`** project.

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

   The following example from the [tutorial for using SignalR with a Blazor WebAssembly app](xref:tutorials/signalr-blazor) uses a project folder name of `Server` and a project name of `BlazorWebAssemblySignalRApp.Server`:

   ```json
   ...
   "args": [
     "build",
       "${workspaceFolder}/Server/BlazorWebAssemblySignalRApp.Server.csproj",
       ...
   ],
   ...
   ```

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app.

## Trust a development certificate

There's no centralized way to trust a certificate on Linux. Typically, one of the following approaches is adopted:

* Exclude the app's URL in browser's exclude list.
* Trust all self-signed certificates for `localhost`.
* Add the certificate to the list of trusted certificates in the browser.

For more information, see the guidance provided by your browser manufacturer and Linux distribution.

::: zone-end

::: zone pivot="macos"

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

::: zone-end

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

::: moniker-end
