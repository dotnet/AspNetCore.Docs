---
title: "Tutorial: Get started with Razor Pages in ASP.NET Core"
author: wadepickett
description: This is the first tutorial of a series that teaches the basics of building an ASP.NET Core Razor Pages web app.
ms.author: wpickett
monikerRange: '>= aspnetcore-3.1'
ms.date: 10/13/2023
ms.custom: engagement-fy23
uid: tutorials/razor-pages/razor-pages-start
---

# Tutorial: Get started with Razor Pages in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-8.0"

This is the first tutorial of a series that teaches the basics of building an ASP.NET Core Razor Pages web app.

For a more advanced introduction aimed at developers who are familiar with controllers and views, see [Introduction to Razor Pages](xref:razor-pages/index). For a video introduction, see [Entity Framework Core for Beginners](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oXCPdC3fTFA3Z79-eVH3K-s).

[!INCLUDE [Choose web UI](~/includes/choose-ui-link.md)]

At the end of this tutorial, you'll have a Razor Pages web app that manages a database of movies.

![Home or Index page](~/tutorials/razor-pages/razor-pages-start/_static/8/home8.png)

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-8.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-8.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-8.0.md)]

---

## Create a Razor Pages web app

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio and select **New project**.
* In the **Create a new project** dialog, select **ASP.NET Core Web App** > **Next**.
* In the **Configure your new project** dialog, enter `RazorPagesMovie` for **Project name**. It's important to name the project **RazorPagesMovie**, including matching the capitalization, so the namespaces will match when you copy and paste example code.
* Select **Next**.
* In the **Additional information** dialog:
  * Select **.NET 8.0 (Preview)**.
  * Verify: **Do not use top-level statements** is unchecked.
* Select **Create**.

   ![Additional information](~/tutorials/razor-pages/razor-pages-start/_static/8/net8-additional-info.png)

  The following starter project is created:

   ![Solution Explorer](~/tutorials/razor-pages/razor-pages-start/_static/8/solution-explorer-project.png)

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

# [Visual Studio for Mac](#tab/visual-studio-mac)

* In Visual Studio for Mac 2022, select **File** > **New Project...**.

* In the **Choose a template for your new project** dialog:
  * Select **Web and Console** > **App** > **Web Application**.
  * Select **Continue**.

* In the **Configure your new Web Application** dialog:
  * Verify: **Target framework** is set to **.NET 8.0** (or later).
  * Verify: **Authentication** is set to **No Authentication**.
  * Verify: **Do not use top-level statements** is unchecked.
  * Select **Continue**.

* In the **Configure your new Web Application** dialog:
  * Enter `RazorPagesMovie` for **Project name**. It's important to name the project **RazorPagesMovie**, including matching the capitalization, so the namespaces will match when you copy and paste example code.
  * Select **Create**.

---

## Run the app

# [Visual Studio](#tab/visual-studio)

<!-- replace all of this with updated includes  -->

Select **RazorPagesMovie** in **Solution Explorer**, and then press Ctrl+F5 to run without the debugger.

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

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

In Visual Studio Code, press Ctrl+F5 to run the app. At the **Select environment** prompt, select **.NET Core**.

The default browser launched with the following URL: `https://localhost:<port>` where `<port>` is the randomly generated port number.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Select **Debug** > **Start Debugging** to launch the app.

Visual Studio for Mac launches a browser and navigates to `https://localhost:<port>`, where `<port>` is the port number randomly assigned at project creation and is set in `Properties/launchSettings.json`.

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

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie80/Program1Snip.cs?name=snippet_all)]

The following lines of code in this file create a `WebApplicationBuilder` with preconfigured defaults, add Razor Pages support to the [Dependency Injection (DI) container](xref:fundamentals/dependency-injection), and builds the app:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie80/Program1Snip.cs?name=snippet_di)]

The developer exception page is enabled by default and provides helpful information on exceptions. Production apps should not be run in development mode because the developer exception page can leak sensitive information.

The following code sets the exception endpoint to `/Error` and enables [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) when the app is ***not*** running in development mode:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie80/Program1Snip.cs?name=snippet_env)]

For example, the preceding code runs when the app is in production or test mode. For more information, see [Use multiple environments in ASP.NET Core](xref:fundamentals/environments).

The following code enables various [Middleware](xref:fundamentals/middleware/index):

* `app.UseHttpsRedirection();` : Redirects HTTP requests to HTTPS.
* `app.UseStaticFiles();` : Enables static files, such as HTML, CSS, images, and JavaScript to be served. For more information, see <xref:fundamentals/static-files>.
* `app.UseRouting();` : Adds route matching to the middleware pipeline. For more information, see <xref:fundamentals/routing>
* `app.MapRazorPages();`: Configures endpoint routing for Razor Pages.
* `app.UseAuthorization();` : Authorizes a user to access secure resources. This app doesn't use authorization, therefore this line could be removed.
* `app.Run();` : Runs the app.

## Troubleshooting with the completed sample

If you run into a problem you can't resolve, compare your code to the completed project. [View or download completed project](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie80) ([how to download](xref:index#how-to-download-a-sample)).

## Next steps

> [!div class="step-by-step"]
> [Next: Add a model](xref:tutorials/razor-pages/model)

:::moniker-end

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start7.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start6.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start5.md)]

[!INCLUDE[](~/tutorials/razor-pages/razor-pages-start/includes/razor-pages-start3.md)]
