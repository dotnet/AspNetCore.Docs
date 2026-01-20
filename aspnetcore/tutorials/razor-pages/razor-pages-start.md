---
title: "Tutorial: Get started with Razor Pages in ASP.NET Core"
ai-usage: ai-assisted
author: wadepickett
description: This is the first tutorial of a series that teaches the basics of building an ASP.NET Core Razor Pages web app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 01/07/2026
uid: tutorials/razor-pages/razor-pages-start
---

# Tutorial: Get started with Razor Pages in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-10.0"

This tutorial is the first in a series that teaches the basics of building an ASP.NET Core Razor Pages web app.

For a more advanced introduction aimed at developers who are familiar with controllers and views, see [Introduction to Razor Pages](xref:razor-pages/index). For a video introduction, see [Entity Framework Core for Beginners](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oXCPdC3fTFA3Z79-eVH3K-s).

[!INCLUDE [Choose web UI](~/includes/choose-ui-link.md)]

At the end of this tutorial, you have a Razor Pages web app that manages a database of movies.

:::image type="content" source="~/tutorials/razor-pages/razor-pages-start/media/home10.png" alt-text="Home or Index page.":::

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-10.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-10.0.md)]

---

## Create a Razor Pages web app

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio and select **Create a new project**.
* In the **Create a new project** dialog, select **ASP.NET Core Web App (Razor Pages)** > **Next**.
* In the **Configure your new project** dialog, enter `RazorPagesMovie` for **Project name**. Name the project **RazorPagesMovie**, including matching the capitalization, so the namespaces match when you copy and paste example code.
* Select **Next**.
* In the **Additional information** dialog:
  * Select **.NET 10.0**.
  * Verify: **Do not use top-level statements** is unchecked.
* Select **Create**.

  :::image type="content" source="~/tutorials/razor-pages/razor-pages-start/media/net10-additional-info.png" alt-text="Additional information dialog.":::

  The following starter project is created:

  :::image type="content" source="~/tutorials/razor-pages/razor-pages-start/media/solution-explorer-project.png" alt-text="Solution Explorer showing the RazorPagesMovie project structure.":::

For alternative approaches to create the project, see [Create a new project in Visual Studio](/visualstudio/ide/create-new-project).

# [Visual Studio Code](#tab/visual-studio-code)

This tutorial assumes you're familiar with Visual Studio Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs).

* Select **New Terminal** from the **Terminal** menu to open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change to the directory (`cd`) that contains the project.
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

Visual Studio displays the following dialog when a project isn't yet configured to use SSL:

:::image type="content" source="~/static/trustCertVS22.png" alt-text="This project is configured to use SSL. To avoid SSL warnings in the browser you can choose to trust the self-signed certificate that IIS Express has generated. Would you like to trust the IIS Express SSL certificate?":::

Select **Yes** if you trust the IIS Express SSL certificate.

The following dialog is displayed:

:::image type="content" source="~/static/cert.png" alt-text="Security warning dialog.":::

Select **Yes** if you agree to trust the development certificate.

[!INCLUDE[trust FF](~/includes/trust-ff.md)]

Visual Studio:

* Runs the app, which  launches the [Kestrel server](xref:fundamentals/servers/kestrel).
* Launches the default browser at `https://localhost:<port>`, which displays the app's UI. `<port>` is the random port that is assigned when the app was created.

Close the browser window.

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

In Visual Studio Code, press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app without debugging.

At the **Select debugger** prompt, select **C#**.

:::image type="content" source="~/tutorials/razor-pages/razor-pages-start/media/vsc-select-debugger-csharp-devkit10.png" alt-text="Select environment dialog.":::

At the **Select Launch Configuration** prompt, select **C#: RazorPagesMovie [https] RazorPagesMovie**.

The default browser opens with the following URL: `https://localhost:<port>` where `<port>` is the randomly generated port number.

Close the browser window.

In Visual Studio Code, from the *Run* menu, select *Stop Debugging* or press <kbd>Shift</kbd>+<kbd>F5</kbd> to stop the app.

---

<!-- 
Each new version, change the layout file to use the non-minified CSS. 
See https://github.com/dotnet/AspNetCore.Docs/issues/21193
-->

## Examine the project files

The following sections contain an overview of the main project folders and files that you work with in later tutorials.

### Pages folder

Contains Razor pages and supporting files. Each Razor page is a pair of files:

* A `.cshtml` file that has HTML markup with C# code by using Razor syntax.
* A `.cshtml.cs` file that has C# code that handles page events.

Supporting files have names that begin with an underscore. For example, the `_Layout.cshtml` file configures UI elements common to all pages. `_Layout.cshtml` sets up the navigation menu at the top of the page and the copyright notice at the bottom of the page. For more information, see <xref:mvc/views/layout>.

### wwwroot folder

Contains static assets, like HTML files, JavaScript files, and CSS files. For more information, see <xref:fundamentals/static-files>.

### `appsettings.json`

Contains configuration data, like connection strings. For more information, see <xref:fundamentals/configuration/index>.

### Program.cs

Contains the following code:

<!-- Throughout the tutoiral series, update code in working project (which becomes the clean finished sample) to compile and verify steps, then copy snippets to snapshot sample folder which contains all the various stages of code steps. -->
[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Program1Snip.cs?name=snippet_all)]

The following lines of code in this file create a `WebApplicationBuilder` with preconfigured defaults, add Razor Pages support to the [Dependency Injection (DI) container](xref:fundamentals/dependency-injection), and build the app:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Program1Snip.cs?name=snippet_di)]

The developer exception page is enabled by default and provides helpful information on exceptions. Don't run production apps in development mode because the developer exception page can leak sensitive information.

The following code sets the exception endpoint to `/Error` and enables [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) when the app is ***not*** running in development mode:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot-sample10/Program1Snip.cs?name=snippet_env)]

For example, the preceding code runs when the app is in production or test mode. For more information, see [Use multiple environments in ASP.NET Core](xref:fundamentals/environments).

The following code enables various [Middleware](xref:fundamentals/middleware/index):

* `app.UseHttpsRedirection();` : Redirects HTTP requests to HTTPS.
* `app.UseRouting();` : Adds route matching to the middleware pipeline. For more information, see <xref:fundamentals/routing>.
* `app.UseAuthorization();` : Authorizes a user to access secure resources. This app doesn't use authorization, so you can remove this line.
* `app.MapRazorPages();`: Configures endpoint routing for Razor Pages.
* `app.MapStaticAssets()` : Optimizes the delivery of static assets in an app, such as HTML, CSS, images, and JavaScript. For more information, see <xref:aspnetcore-9#optimizing-static-web-asset-delivery>.
* `.WithStaticAssets();` :  Ensures Razor Pages participate in the optimization system for static assets.
* `app.Run();` : Runs the app.

## Troubleshooting with the completed sample

If you run into a problem you can't resolve, compare your code to the completed project. [View or download completed project](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie10) ([how to download](xref:fundamentals/index#how-to-download-a-sample)).

## Next steps

> [!div class="step-by-step"]
> [Next: Add a model](xref:tutorials/razor-pages/model)

:::moniker-end

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start9.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start8.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start7.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start6.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start5.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start3.md)]
