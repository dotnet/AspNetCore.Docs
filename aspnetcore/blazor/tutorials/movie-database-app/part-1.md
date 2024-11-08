---
title: Build a Blazor movie database app (Part 1 - Create a Blazor Web App)
author: guardrex
description: This part of the Blazor movie database app tutorial explains how to create a Blazor Web App that adopts static server-side rendering (static SSR), where content is only rendered on the server.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/26/2024
uid: blazor/tutorials/movie-database-app/part-1
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 1 - Create a Blazor Web App)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the first part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the tutorial series covers how to create a Blazor Web App that adopts static server-side rendering (static SSR). Static SSR means that content is rendered on the server and sent to the client for display in response to individual requests.

## Prerequisites

:::zone pivot="vs"

[Visual Studio (latest release)](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the **ASP.NET and web development** workload

:::zone-end

:::zone pivot="vsc"

Latest releases of:

* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [.NET SDK](https://dotnet.microsoft.com/download/dotnet)

The Visual Studio Code (VS Code) instructions for ASP.NET Core development in this tutorial use the [.NET CLI](/dotnet/core/tools/), which is part of the .NET SDK. .NET CLI commands are issued in VS Code's integrated [**Terminal**](https://code.visualstudio.com/docs/editor/integrated-terminal), which defaults to a [PowerShell command shell](/powershell/). The **Terminal** is opened by selecting **New Terminal** from the **Terminal** menu in the menu bar.

:::zone-end

:::zone pivot="cli"

[.NET SDK (latest release)](https://dotnet.microsoft.com/download/dotnet)

The [.NET CLI](/dotnet/core/tools/) is part of the .NET SDK. To issue commands that affect the project, open the command shell to the project's root folder.

:::zone-end

## Create a Blazor Web App

:::zone pivot="vs"

In Visual Studio:

* Select **Create a new project** from the **Start Window** or select **File** > **New** > **Project** from the menu bar.

* In the **Create a new project** dialog, select **Blazor Web App** from the list of project templates. Select the **Next** button.

* In the **Configure your new project** dialog, name the project `BlazorWebAppMovies` in the **Project name** field, including matching the capitalization. Using this exact project name is important to ensure that the namespaces match for code that you copy from the tutorial into the app that you're building.

* Confirm that the **Location** for the app is suitable. Set the **Place solution and project in the same directory** checkbox to match your preferred solution file location. Select the **Next** button.

:::moniker range=">= aspnetcore-9.0"

* In the **Additional information** dialog, use the following settings:

  * **Framework**: Select **.NET 9.0 (Standard Term Support)**.
  * **Authentication type**: **None**
  * **Configure for HTTPS**: Selected
  * **Interactive render mode**: **Server**
  * **Interactivity location**: **Per page/component**
  * **Include sample pages**: Selected
  * **Do not use top-level statements**: Not selected
  * Select **Create**.

:::moniker-end

:::moniker range="< aspnetcore-9.0"

* In the **Additional information** dialog, use the following settings:

  * **Framework**: Select **.NET 8.0 (Long Term Support)**.
  * **Authentication type**: **None**
  * **Configure for HTTPS**: Selected
  * **Interactive render mode**: **Server**
  * **Interactivity location**: **Per page/component**
  * **Include sample pages**: Selected
  * **Do not use top-level statements**: Not selected
  * Select **Create**.

:::moniker-end

The Visual Studio instructions in parts of this tutorial series use EF Core commands to add database migrations and update the database. EF Core commands are issued using [Visual Studio Connected Services](/visualstudio/azure/overview-connected-services). More information is provided later in this tutorial series.

:::zone-end

:::zone pivot="vsc"

This tutorial assumes that you have familiarity with VS Code. If you're new to VS Code, see the [VS Code documentation](https://code.visualstudio.com/docs). The videos listed by the [Introductory Videos page](https://code.visualstudio.com/docs/getstarted/introvideos) are designed to give you an overview of VS Code's features.

Confirm that you have the latest [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) and [.NET SDK](https://dotnet.microsoft.com/download/dotnet) installed.

In VS Code:

Create a new project:

* Go to the **Explorer** view and select the **Create .NET Project** button. Alternatively, you can bring up the **Command Palette** using <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>P</kbd>, and then type "`.NET`" to find and select the **.NET: New Project** command.

* Select the **Blazor Web App** project template from the list.

* In the **Project Location** dialog, create or select a folder for the project.

* In the **Command Palette**, name the project `BlazorWebAppMovies`, including matching the capitalization. Using this exact project name is important to ensure that the namespaces match for code that you copy from the tutorial into the app that you're building.

* Select **Create project** from the **Command Palette**.

:::zone-end

:::zone pivot="cli"

Confirm that you have the latest [.NET SDK](https://dotnet.microsoft.com/download/dotnet) installed.

In a command shell:

* Use the `cd` command to change to the directory to where you want to create the project folder (for example, `cd c:/users/Bernie_Kopell/Documents`).
* Use the [`dotnet new` command](/dotnet/core/tools/dotnet-new) with the [`blazor` project template](/dotnet/core/tools/dotnet-new-sdk-templates#blazor) to create a new Blazor Web App project. The [`-o|--output` option](/dotnet/core/tools/dotnet-new#options) passed to the command creates the project in a new folder at the current shell directory location. Name the project `BlazorWebAppMovies`, including matching the capitalization, so the namespaces match for code that you copy from the tutorial to the app.

  ```dotnetcli
  dotnet new blazor -o BlazorWebAppMovies
  ```

:::zone-end

## Run the app

:::zone pivot="vs"

Press <kbd>F5</kbd> on the keyboard to run the app.

Visual Studio displays the following dialog when a project isn't configured to use SSL:

![Trust self-signed certificate dialog](~/blazor/tutorials/movie-database-app/part-1/_static/trust-certificate.png)

Select **Yes** if you trust the ASP.NET Core SSL certificate.

The following dialog is displayed:

![Security warning dialog](~/blazor/tutorials/movie-database-app/part-1/_static/install-certificate.png)

Select **Yes** to acknowledge the risk and install the certificate.

Visual Studio:

* Compiles and runs the app.
* Launches the default browser at `https://localhost:{PORT}`, which displays the app's UI. The `{PORT}` placeholder is the random port assigned to the app when the app is created. If you need to change the port due to a local port conflict, change the port in the project's `Properties/launchSettings.json` file.

Navigate the pages of the app to confirm that the app is working normally.

:::zone-end

:::zone pivot="vsc"

In VS Code, press <kbd>F5</kbd> to run the app.

At the **Select debugger** prompt in the **Command Palette** at the top of the VS Code UI, select **C#**. At the next prompt, select the default launch configuration (`C#: BlazorWebAppMovies [Default Configuration]`).

The default browser is launched at `http://localhost:{PORT}`, which displays the app's UI. The `{PORT}` placeholder is the random port assigned to the app when the app is created. If you need to change the port due to a local port conflict, change the port in the project's `Properties/launchSettings.json` file.

Navigate the pages of the app to confirm that the app is working normally.

:::zone-end

:::zone pivot="cli"

In a command shell opened to the project's root folder, execute the [`dotnet watch`](/dotnet/core/tools/dotnet-watch) command to compile and start the app:

```dotnetcli
dotnet watch
```

The app is compiled and run. The app is launched at `http://localhost:{PORT}`, where the `{PORT}` placeholder is the random port assigned to the app when the app is created. If you need to change the port due to a local port conflict, change the port in the project's `Properties/launchSettings.json` file.

Navigate the pages of the app to confirm that the app is working normally.

:::zone-end

## Stop the app

:::zone pivot="vs"

Stop the app using either of the following approaches:

* Close the browser window.
* In Visual Studio, either:
  * Use the Stop button in Visual Studio's menu bar:

    ![Stop button in Visual Studio's menu bar](~/blazor/tutorials/movie-database-app/part-1/_static/stop-button.png)

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

## Examine the project files

The following sections contain an overview of the project's folders and files.

If you're building the app, you don't need to make changes to the project files in the following sections. As you read the descriptions of the folders and files, examine them in the project.

If you're only reading the articles and not building the app, you can refer to the completed sample app in the [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples). Select the latest version folder in the repository. The sample folder for this tutorial's project is named `BlazorWebAppMovies`. The sample app is the *finished version* of the app after following all of the steps of the tutorial series. Code in the sample doesn't always match steps of the tutorial before the end of the series.

### `Properties` folder

The `Properties` folder holds development environment configuration in the `launchSettings.json` file.

### `wwwroot` folder

The `wwwroot` folder contains static assets, such as image, JavaScript (`.js`), and stylesheet (`.css`) files.

### `Components`, `Components/Pages`, and `Components/Layout` folders

These folders contain *Razor components*, often referred to as "components," and supporting files. A component is a self-contained portion of user interface (UI) with optional processing logic. Components can be nested, reused, and shared among projects.

Components are implemented using a combination of C# and HTML markup in [Razor](xref:mvc/views/razor) component files with the `.razor` file extension.

Typically, components that are nested within other components and not directly reachable ("routable") at a URL are placed in the `Components` folder. Components that are routable via a URL are usually placed in the `Components/Pages` folder.

The `Components/Layout` folder contains the following layout components and stylesheets:

* `MainLayout` component (`MainLayout.razor`): The app's main layout component.
* `MainLayout.razor.css`: Stylesheet for the app's main layout.
* `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. This component uses several `NavLink` components to render navigation links to other Razor components.
* `NavMenu.razor.css`: Stylesheet for the app's navigation menu.

### `Components/_Imports.razor` file

The `_Imports` file (`_Imports.razor`) includes common *Razor directives* to include in the app's Razor components. Razor directives are reserved keywords prefixed with `@` that appear in Razor markup and change the way component markup or component elements are compiled or function.

### `Components/App.razor` file

The `App` component (`App.razor`) is the root component of the app that includes:

* HTML markup.
* The `Routes` component.
* The Blazor script (`<script>` tag for `blazor.web.js`).

The root component is the first component that the app loads.

### `Components/Routes.razor` file

The `Routes` component (`Routes.razor`) sets up routing for the app.

### `appsettings.json` file

The `appsettings.json` file contains configuration data, such as connection strings.

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

### `Program.cs` file

The `Program.cs` file contains code to create the app and configure the request processing pipeline of the app.

The order of the lines in the Blazor Web App project template changes across releases of .NET, so the order of the lines in the `Program.cs` file might not match the order of the lines covered in this section. 

A <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> creates the app with preconfigured defaults:

```csharp
var builder = WebApplication.CreateBuilder(args);
```

Razor component services are added to the app by calling <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>, which enables Razor components to render and execute code on the server:

```csharp
builder.Services.AddRazorComponents();
```

The <xref:Microsoft.AspNetCore.Builder.WebApplication> (held by the `app` variable in the following code) is built:

```csharp
var app = builder.Build();
```

Next, the HTTP request pipeline is configured.

In the development environment:

* Exception Handler Middleware (<xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>) processes errors and displays a developer exception page during development app runs.
* [HTTP Strict Transport Security Protocol (HSTS) Middleware](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) (<xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A>) processes [HSTS](https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Strict_Transport_Security_Cheat_Sheet.html).

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
```

HTTPS Redirection Middleware (<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>) enforces the HTTPS protocol by redirecting HTTP requests to HTTPS if an HTTPS port is available:

```csharp
app.UseHttpsRedirection();
```

Antiforgery Middleware (<xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A>) enforces antiforgery protection for form processing:

```csharp
app.UseAntiforgery();
```

:::moniker range=">= aspnetcore-9.0"

Map Static Assets routing endpoint conventions (<xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A>) maps static files, such as images, scripts, and stylesheets, produced during the build as endpoints:

```csharp
app.MapStaticAssets();
```

:::moniker-end

:::moniker range="< aspnetcore-9.0"

Static File Middleware (<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>) serves static files, such as images, scripts, and stylesheets from the `wwwroot` folder:

```csharp
app.UseStaticFiles();
```

:::moniker-end

<xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> maps components defined in the root `App` component to the given .NET assembly and renders routable components:

```csharp
app.MapRazorComponents<App>();
```

The app is run by calling <xref:Microsoft.AspNetCore.Builder.WebApplication.Run%2A> on the <xref:Microsoft.AspNetCore.Builder.WebApplication> (`app`):

```csharp
app.Run();
```

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

When using VS Code or the .NET CLI, this tutorial series adopts insecure HTTP protocol to ease the transition of adopting SSL/HTTPS security for Linux and macOS users. For information on adopting SSL/HTTPS, see <xref:security/enforcing-ssl>.

## Next steps

> [!div class="step-by-step"]
> [Next: Add and scaffold a model](xref:blazor/tutorials/movie-database-app/part-2)
