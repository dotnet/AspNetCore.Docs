---
title: Build a Blazor movie database app (Part 1 - Create a Blazor Web App)
author: guardrex
description: This part of the Blazor movie database app tutorial explains how to create a Blazor Web App that adopts static server-side rendering (static SSR), where content is only rendered on the server.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/06/2024
uid: blazor/tutorials/movie-database-app/part-1
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 1 - Create a Blazor Web App)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the first part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This article shows you how to create a Blazor Web App that adopts static server-side rendering (static SSR). Static SSR means that content is rendered on the server and sent to the client for display without the capacity for interplay between the user and .NET/C# code. JavaScript and HTML DOM events remain unaffected, but user events on the client can't be processed by the .NET runtime running on the server. The rendered UI on the client can only receive and post database data via ordinary HTML requests. In the last part of the tutorial series, *interactivity* is adopted, and Blazor's built-in event processing is demonstrated.

At the end of this tutorial, you'll have an interactive Blazor Web App that manages a database of movies.

## Prerequisites

<!-- REVIEWER NOTE

Let's not cross-link to specific tooling versions
to avoid content versioning and save on doc 
maintenance costs.

As usual for tutorials, there's minimal
cross-linking to external resources to avoid
distracting the reader.

-->

:::zone pivot="vs"

[Visual Studio (latest release)](https://visualstudio.microsoft.com/downloads/) with the **ASP.NET and web development** workload

:::zone-end

:::zone pivot="vsc"

Latest releases of:

* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [.NET SDK](https://dotnet.microsoft.com/download/dotnet)

The Visual Studio Code (VS Code) instructions for ASP.NET Core development in this tutorial use the [.NET CLI](/dotnet/core/tools/), which is part of the .NET SDK. .NET CLI commands are issued in VS Code's integrated [**Terminal**](https://code.visualstudio.com/docs/editor/integrated-terminal), which is a PowerShell prompt.

:::zone-end

:::zone pivot="cli"

[.NET SDK (latest release)](https://dotnet.microsoft.com/download/dotnet)

:::zone-end

We recommend avoiding preview tooling and preview framework releases when using .NET and Blazor for the first time, as features may be unstable while the tooling and framework are under construction for the upcoming release.

## Create a Blazor Web App with static server-side rendering (static SSR)

:::zone pivot="vs"

In Visual Studio:

* Select **Create a new project** from the **Start Window** or select **File** > **New** > **Project** from the menu bar.
* In the **Create a new project** dialog, select **Blazor Web App** from the list of project templates. Select the **Next** button.
* In the **Configure your new project** dialog, name the project `BlazorWebAppMovies` in the **Project name** field, including matching the capitalization. Using this exact project name is important to ensure that the namespaces match for code that you copy from the tutorial into the app that you're building.
* Confirm that the **Location** for the app is suitable. Leave the **Place solution and project in the same directory** checkbox selected. Select the **Next** button.
* In the **Additional information** dialog, use the following settings:
  * **Framework**: Confirm that the [latest framework](https://dotnet.microsoft.com/download/dotnet) is selected. If Visual Studio's **Framework** dropdown list doesn't include the latest available .NET framework, [update Visual Studio](/visualstudio/install/update-visual-studio) and restart the tutorial.
  * **Authentication type**: **None**
  * **Configure for HTTPS**: Selected
  * **Interactive render mode**: **None**
  * **Interactivity location**: **Global**
  * **Include sample pages**: Selected
  * **Do not use top-level statements**: Not selected
  * Select **Create**.

:::zone-end

:::zone pivot="vsc"

This tutorial assumes that you have familiarity with VS Code. If you're new to VS Code, see the [VS Code documentation](https://code.visualstudio.com/docs). The videos listed on the [Introductory Videos page](https://code.visualstudio.com/docs/getstarted/introvideos) are designed to give you an overview of VS Code's features.

Confirm that you have the latest [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) and [.NET SDK](https://dotnet.microsoft.com/download/dotnet) installed.

In VS Code:

* Select **New Terminal** from the **Terminal** menu.
* Change to the directory using the `cd` command to where you want to create the project folder.
* Use the [`dotnet new` command](/dotnet/core/tools/dotnet-new) with the [`blazor` project template](/dotnet/core/tools/dotnet-new-sdk-templates#blazor) to create a new Blazor Web App project. The [`-o|--output` option](/dotnet/core/tools/dotnet-new#options) passed to the command creates the project in a new folder named `BlazorWebAppMovies` at the current terminal directory location.

  > [!IMPORTANT]
  > Name the project `BlazorWebAppMovies`, including matching the capitalization, so the namespaces match for code that you copy from the tutorial to the app as you follow this tutorial.

  ```powershell
  dotnet new blazor -o BlazorWebAppMovies
  ```

* Use the [`code` command](https://code.visualstudio.com/docs/getstarted/tips-and-tricks#_command-line) to open the `BlazorWebAppMovies` folder in the current instance of VS Code:

  ```powershell
  code -r BlazorWebAppMovies
  ```

:::zone-end

:::zone pivot="cli"

Confirm that you have the latest [.NET SDK](https://dotnet.microsoft.com/download/dotnet) installed.

In a command shell:

* Change to the directory using the `cd` command to where you want to create the project folder.
* Use the [`dotnet new` command](/dotnet/core/tools/dotnet-new) with the [`blazor` project template](/dotnet/core/tools/dotnet-new-sdk-templates#blazor) to create a new Blazor Web App project. The [`-o|--output` option](/dotnet/core/tools/dotnet-new#options) passed to the command creates the project in a new folder named `BlazorWebAppMovies` at the current shell directory location.

  > [!IMPORTANT]
  > Name the project `BlazorWebAppMovies`, including matching the capitalization, so the namespaces match for code that you copy from the tutorial to the app as you follow this tutorial.

  ```dotnetcli
  dotnet new blazor -o BlazorWebAppMovies
  ```

:::zone-end

## Run the app

:::zone pivot="vs"

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> on the keyboard to run the app without the debugger.

Visual Studio displays the following dialog when a project is not yet configured to use SSL:

![Trust self-signed certificate dialog](~/blazor/tutorials/movie-database-app/part-1/_static/trust-certificate.png)

Select **Yes** if you trust the ASP.NET Core SSL certificate.

The following dialog is displayed:

![Security warning dialog](~/blazor/tutorials/movie-database-app/part-1/_static/install-certificate.png)

Select **Yes** to acknowledge the risk and install the certificate.

For information on trusting the development certificate for the Firefox browser, see <xref:security/enforcing-ssl#trust-the-https-certificate-with-firefox-to-prevent-sec_error_inadequate_key_usage-error>.

Visual Studio:

* Compiles and runs the app.
* Launches the default browser at `https://localhost:{PORT}`, which displays the app's UI. The `{PORT}` placeholder is the random port assigned to the app when the app is created. If you need to change the port due to a local port conflict, you may do so in the project's `Properties/launchSettings.json` file.

Navigate to the pages of the app to confirm that the app is working normally.

:::zone-end

:::zone pivot="vsc"

For information on trusting the HTTPS certificate for browsers other than Firefox, see the [HTTPS development certificate trust guidance](xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos). When using the Firefox browser, see the [certificate trust guidance for Firefox](xref:security/enforcing-ssl#trust-the-https-certificate-with-firefox-to-prevent-sec_error_inadequate_key_usage-error).

In VS Code, press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

At the **Select debugger** prompt in the **Command Palette** at the top of the VS Code UI, select **C#**. At the next prompt, select the HTTPS profile (`C#: BlazorWebAppMovies [https]`).

The default browser is launched at `https://localhost:{PORT}`, which displays the app's UI. The `{PORT}` placeholder is the random port assigned to the app when the app is created. If you need to change the port due to a local port conflict, you may do so in the project's `Properties/launchSettings.json` file.

Navigate to the pages of the app to confirm that the app is working normally.

:::zone-end

:::zone pivot="cli"

For information on trusting the HTTPS certificate for browsers other than Firefox, see the [HTTPS development certificate trust guidance](xref:security/enforcing-ssl#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos). When using the Firefox browser, see the [certificate trust guidance for Firefox](xref:security/enforcing-ssl#trust-the-https-certificate-with-firefox-to-prevent-sec_error_inadequate_key_usage-error) section of that article.

In a command shell opened to the project's root folder, execute the [`dotnet run`](/dotnet/core/tools/dotnet-run) command to compile and start the app:

```dotnetcli
dotnet run
```

The default browser is launched at `http://localhost:{PORT}`, which displays the app's UI. The `{PORT}` placeholder is the random port assigned to the app when the app is created. If you need to change the port due to a local port conflict, you may do so in the project's `Properties/launchSettings.json` file.

Open the app in a browser by <kbd>Ctrl</kbd>-clicking the URL of the running app in the command shell (for example, `http://localhost:5252`). Navigate to the pages of the app to confirm that the app is working normally.

> [!NOTE]
> When an app is run with the .NET CLI, the app runs at an HTTP (insecure) endpoint because the first profile found in the app's launch settings file (`Properties/launchSettings.json`) is the HTTP (insecure) profile, which is named `http`. The HTTP profile was placed in the first position to ease the transition of adopting HTTPS security for Linux and macOS users. If you prefer to start the app with HTTPS without having to pass the [`-lp https`|`--launch-profile https` option](/dotnet/core/tools/dotnet-run#options) to the `dotnet run` command, simply move the `https` profile above the `http` profile in the file and save the change.

:::zone-end

<!-- REVIEWER NOTE

I don't assume devs understand their tooling for stopping
an app or that a running app interferes with commands that 
must be issued along the way while working on the app, so 
there are explicit stop instructions at several points 
throughout the series on stopping a running app before
continuing. The guidance on stopping an app is curtailed
in later parts of the series as the dev gets used to the
process.

-->

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

The following sections contain an overview of the project's folders and files. You don't need to make any changes to the project files in the following sections. As you read the descriptions of the folders and files, examine them in the project.

### `Properties` folder

The `Properties` folder holds development environment configuration in the `launchSettings.json` file.

### `wwwroot` folder

The `wwwroot` folder contains static assets, such as image, JavaScript (`.js`), and stylesheet (`.css`) files.

### `Components`, `Components/Pages`, and `Components/Layout` folders

These folders contain *Razor components*, often referred to as "components," and supporting files. A component is a self-contained portion of user interface (UI) with optional processing logic to enable dynamic behavior. Components can be nested, reused, shared among projects, and used in MVC and Razor Pages apps.

Components are implemented using a combination of C# and HTML markup in [Razor](xref:mvc/views/razor) component files with the `.razor` file extension.

Typically, components that are nested within other components and not directly reachable ("routable") at a URL are placed in the `Components` folder. Components that are routable via a URL are usually placed in the `Components/Pages` folder.

Although the name "Razor components" shares some naming with other ASP.NET Core content-rendering technologies, Razor components must be distinguished from *Razor views*, which are [Razor-based](xref:mvc/views/razor) markup pages for MVC apps, and *View components*, which are for rendering chunks of content rather than whole responses in Razor Pages and MVC apps.

The `Components/Layout` folder contains the following layout components and stylesheets:

* `MainLayout` component (`MainLayout.razor`): The app's main layout component.
* `MainLayout.razor.css`: Stylesheet for the app's main layout.
* `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. This component uses several `NavLink` components to render navigation links to other Razor components.
* `NavMenu.razor.css`: Stylesheet for the app's navigation menu.

### `_Imports.razor` file

The `_Imports` file (`_Imports.razor`) includes common *Razor directives* to include in the app's Razor components. Razor directives are reserved keywords prefixed with `@` that appear in Razor markup and change the way component markup or component elements are parsed or function.

### `App.razor` file

The `App` component (`App.razor`) is the root component of the app with HTML `<head>` markup, the `Routes` component (covered in the next section), and the Blazor script (`<script>` tag for `blazor.web.js`). The root component is the first component that the app loads.

### `Routes.razor` file

The `Routes` component (`Routes.razor`) sets up routing for the app.

### `appsettings.json` file

The `appsettings.json` file contains configuration data, such as connection strings.

### `Program.cs` file

The `Program.cs` file contains code to create the app and configure the request processing pipeline of the app.

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

> [!WARNING]
> Don't run a production app in development mode because the developer exception page can leak sensitive information.

HTTPS Redirection Middleware (<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>) enforces the HTTPS protocol by redirecting HTTP requests to HTTPS if an HTTPS port is available:

<!-- REVIEWER NOTE

BTW ... Our main doc set guidance is a bit off
on the description of the middleware in a few 
spots where it uses the word "always" when discussing
HTTPS redirection ... i.e., it doesn't qualify it
with 'when there's an HTTPS port available.'

-->

```csharp
app.UseHttpsRedirection();
```

Static File Middleware (<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>) serves static files, such as images, scripts, and stylesheets from the `wwwroot` folder:

```csharp
app.UseStaticFiles();
```

Antiforgery Middleware (<xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A>) enforces antiforgery protection during form processing:

```csharp
app.UseAntiforgery();
```

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

## Next steps

> [!div class="step-by-step"]
> [Next: Add and scaffold a model](xref:blazor/tutorials/movie-database-app/part-2)
