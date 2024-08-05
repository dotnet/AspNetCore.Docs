---
title: "Tutorial: Get started with Razor Pages in ASP.NET Core"
author: wadepickett
description: This is the first tutorial of a series that teaches the basics of building an ASP.NET Core Razor Pages web app.
ms.author: wpickett
monikerRange: '>= aspnetcore-3.1'
ms.date: 08/04/2024
uid: tutorials/razor-pages/razor-pages-start
---

# Tutorial: Get started with Razor Pages in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-9.0"

This is the first tutorial of a series that teaches the basics of building an ASP.NET Core Razor Pages web app.

For a more advanced introduction aimed at developers who are familiar with controllers and views, see [Introduction to Razor Pages](xref:razor-pages/index). For a video introduction, see [Entity Framework Core for Beginners](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oXCPdC3fTFA3Z79-eVH3K-s).

[!INCLUDE [Choose web UI](~/includes/choose-ui-link.md)]

At the end of this tutorial, you'll have a Razor Pages web app that manages a database of movies.

![Home or Index page](~/tutorials/razor-pages/razor-pages-start/_static/9/home9.png)

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-9.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-9.0.md)]

---

## Create a Razor Pages web app

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio and select **New project**.
* In the **Create a new project** dialog, select **ASP.NET Core Web App (Razor Pages)** > **Next**.
* In the **Configure your new project** dialog, enter `RazorPagesMovie` for **Project name**. It's important to name the project **RazorPagesMovie**, including matching the capitalization, so the namespaces will match when you copy and paste example code.
* Select **Next**.
* In the **Additional information** dialog:
  * Select **.NET 9.0 (Preview)**.
  * Verify: **Do not use top-level statements** is unchecked.
* Select **Create**.

   ![Additional information](~/tutorials/razor-pages/razor-pages-start/_static/9/net9-additional-info.png)

  The following starter project is created:

   ![Solution Explorer](~/tutorials/razor-pages/razor-pages-start/_static/9/solution-explorer-project.png)

For alternative approaches to create the project, see [Create a new project in Visual Studio](/visualstudio/ide/create-new-project).

# [Visual Studio Code](#tab/visual-studio-code)

The tutorial assumes familiarity with VS Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs).

* Select **New Terminal** from the **Terminal** menu to open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change to the directory (`cd`) that will contain the project.
* Run the following commands:

  ```dotnetcli
  dotnet new webapp -o RazorPagesMovie
  code -r RazorPagesMovie
  ```

  The `dotnet new` command creates a new Razor Pages project in the *RazorPagesMovie* folder.

  The `code` command opens the *RazorPagesMovie* folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

---

## Run the app

# [Visual Studio](#tab/visual-studio)

<!-- replace all of this with updated includes  -->

Select **RazorPagesMovie** in **Solution Explorer**, and then press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app without the debugger.

Visual Studio displays the following dialog when a project is not yet configured to use SSL:

![This project is configured to use SSL. To avoid SSL warnings in the browser you can choose to trust the self-signed certificate that IIS Express has generated. Would you like to trust the IIS Express SSL certificate?](~/getting-started/_static/trustCertVS22.png)

Select **Yes** if you trust the IIS Express SSL certificate.

The following dialog is displayed:

![Security warning dialog](~/getting-started/_static/cert.png)

Select **Yes** if you agree to trust the development certificate.

[!INCLUDE[trust FF](~/includes/trust-ff.md)]

Visual Studio:

* Runs the app, which  launches the [Kestrel server](xref:fundamentals/servers/kestrel).
* Launches the default browser at `https://localhost:<port>`, which displays the apps UI. `<port>` is the random port that is assigned when the app was created.

Close the browser window.

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

In Visual Studio Code, press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without debugging.

At the **Select debugger** prompt, select **C#**.

![Select environment dialog](~/tutorials/razor-pages/razor-pages-start/_static/9/vsc-select-debugger-csharp-devkit9.png)

At the **Select Launch Configuration** prompt, select **C#: RazorPagesMovie [https] RazorPagesMovie**.

The default browser launched with the following URL: `https://localhost:<port>` where `<port>` is the randomly generated port number.

Close the browser window.

In Visual Studio Code, from the *Run* menu, select *Stop Debugging* or press <kbd>Shift</kbd>+<kbd>F5</kbd> to stop the app.

---

<!-- 
Each new version, change the layout file to use the non-minified CSS. 
See https://github.com/dotnet/AspNetCore.Docs/issues/21193
-->

## Examine the project files

The following sections contain an overview of the main project folders and files that you'll work with in later tutorials.

### Pages folder

Contains Razor pages and supporting files. Each Razor page is a pair of files:

* A `.cshtml` file that has HTML markup with C# code using Razor syntax.
* A `.cshtml.cs` file that has C# code that handles page events.

Supporting files have names that begin with an underscore. For example, the `_Layout.cshtml` file configures UI elements common to all pages. `_Layout.cshtml` sets up the navigation menu at the top of the page and the copyright notice at the bottom of the page. For more information, see <xref:mvc/views/layout>.

### wwwroot folder

Contains static assets, like HTML files, JavaScript files, and CSS files. For more information, see <xref:fundamentals/static-files>.

### `appsettings.json`

Contains configuration data, like connection strings. For more information, see <xref:fundamentals/configuration/index>.

### Program.cs

Contains the following code:

<!-- Throughout the tutoiral series, update code in working project (which becomes the clean finished sample) to compile and verify steps, then copy snippets to snapshot sample folder which contains all the various stages of code steps. -->
[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample9/Program1Snip.cs?name=snippet_all)]

The following lines of code in this file create a `WebApplicationBuilder` with preconfigured defaults, add Razor Pages support to the [Dependency Injection (DI) container](xref:fundamentals/dependency-injection), and builds the app:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample9/Program1Snip.cs?name=snippet_di)]

The developer exception page is enabled by default and provides helpful information on exceptions. Production apps should not be run in development mode because the developer exception page can leak sensitive information.

The following code sets the exception endpoint to `/Error` and enables [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) when the app is ***not*** running in development mode:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample9/Program1Snip.cs?name=snippet_env)]

For example, the preceding code runs when the app is in production or test mode. For more information, see [Use multiple environments in ASP.NET Core](xref:fundamentals/environments).

The following code enables various [Middleware](xref:fundamentals/middleware/index):

* `app.UseHttpsRedirection();` : Redirects HTTP requests to HTTPS.
* `app.UseRouting();` : Adds route matching to the middleware pipeline. For more information, see <xref:fundamentals/routing>.
* `app.UseAuthorization();` : Authorizes a user to access secure resources. This app doesn't use authorization, therefore this line could be removed.
* `app.MapRazorPages();`: Configures endpoint routing for Razor Pages.
* `app.MapStaticAssets();` : Optimize the delivery of static assets in an app such as such as HTML, CSS, images, and JavaScript to be served. For more information, see <xref:aspnetcore-9#optimizing-static-web-asset-delivery>.
* `app.Run();` : Runs the app.

## Troubleshooting with the completed sample

If you run into a problem you can't resolve, compare your code to the completed project. [View or download completed project](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie90) ([how to download](xref:index#how-to-download-a-sample)).

## Next steps

> [!div class="step-by-step"]
> [Next: Add a model](xref:tutorials/razor-pages/model)

:::moniker-end

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start8.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start7.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start6.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start5.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start3.md)]
