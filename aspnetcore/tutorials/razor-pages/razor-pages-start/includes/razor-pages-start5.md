:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

This is the first tutorial of a series that teaches the basics of building an ASP.NET Core Razor Pages web app.

For a more advanced introduction aimed at developers who are familiar with controllers and views, see [Introduction to Razor Pages](xref:razor-pages/index).

[!INCLUDE [Choose web UI](~/includes/choose-ui-link.md)]

At the end of the series, you'll have an app that manages a database of movies.  

In this tutorial, you:

> [!div class="checklist"]
> * Create a Razor Pages web app.
> * Run the app.
> * Examine the project files.

At the end of this tutorial, you'll have a working Razor Pages web app that you'll enhance in later tutorials.

![Home or Index page](~/tutorials/razor-pages/razor-pages-start/_static/5/home5.png)

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs-5.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-5.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-core-prereqs-mac-5.0.md)]

---

## Create a Razor Pages web app

# [Visual Studio](#tab/visual-studio)

1. Start Visual Studio and select **Create a new project**. For more information, see [Create a new project in Visual Studio](/visualstudio/ide/create-new-project).

   ![Create a new project from the start window](~/tutorials/razor-pages/razor-pages-start/_static/5/start-window-create-new-project.png)

1. In the **Create a new project** dialog, select **ASP.NET Core Web Application**, and then select **Next**.

   ![Create an ASP.NET Core Web Application](~/tutorials/razor-pages/razor-pages-start/_static/5/np.png)

1. In the **Configure your new project** dialog, enter `RazorPagesMovie` for **Project name**. It's important to name the project *RazorPagesMovie*, including matching the capitalization, so the namespaces will match when you copy and paste example code.

1. Select **Create**.

   ![Configure the project](~/tutorials/razor-pages/razor-pages-start/_static/config.png)

1. In the **Create a new ASP.NET Core web application** dialog, select:
    1. **.NET Core** and **ASP.NET Core 5.0** in the dropdowns.
    1. **Web Application**.
    1. **Create**.

   ![Select ASP.NET Core Web App](~/tutorials/razor-pages/razor-pages-start/_static/5/npx.png)

  The following starter project is created:

   ![Solution Explorer](~/tutorials/razor-pages/razor-pages-start/_static/se2.2.png)

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

  The `code` command opens the *RazorPagesMovie* project folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Select **File** > **New Solution**.

  ![macOS New solution](~/tutorials/first-mvc-app/start-mvc/_static/new_project_vsmac.png)
  
1. In Visual Studio for Mac earlier than version 8.6, select **.NET Core** > **App** > **Web Application** > **Next**. In version 8.6 or later, select **Web and Console** > **App** > **Web Application** > **Next**.

  ![macOS web app template selection](~/tutorials/razor-pages/razor-pages-start/_static/web_app_template_vsmac.png)

1. In the **Configure the new Web Application** dialog:

   1. Confirm that **Authentication** is set to **No Authentication**.
   1. If presented an option to select a **Target Framework**, select the latest .NET 5.x version.
   1. Select **Next**.

1. Name the project *RazorPagesMovie* and select **Create**.

  ![macOS name the project](~/tutorials/razor-pages/razor-pages-start/_static/RazorPagesMovie.png)

<!-- End of VS tabs -->

---

## Run the app

  [!INCLUDE[](~/includes/run-the-app.md)]

## Examine the project files

Here's an overview of the main project folders and files that you'll work with in later tutorials.

### Pages folder

Contains Razor pages and supporting files. Each Razor page is a pair of files:

* A `.cshtml` file that has HTML markup with C# code using Razor syntax.
* A `.cshtml.cs` file that has C# code that handles page events.

Supporting files have names that begin with an underscore. For example, the `_Layout.cshtml` file configures UI elements common to all pages. This file sets up the navigation menu at the top of the page and the copyright notice at the bottom of the page. For more information, see <xref:mvc/views/layout>.

### wwwroot folder

Contains static assets, like HTML files, JavaScript files, and CSS files. For more information, see <xref:fundamentals/static-files>.

### `appsettings.json`

Contains configuration data, like connection strings. For more information, see <xref:fundamentals/configuration/index>.

### Program.cs

Contains the entry point for the app. For more information, see <xref:fundamentals/host/generic-host>.

### Startup.cs

Contains code that configures app behavior. For more information, see <xref:fundamentals/startup>.

## Troubleshooting with the completed sample

If you run into a problem you can't resolve, compare your code to the completed project. [View or download completed project](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie50) ([how to download](xref:index#how-to-download-a-sample)).

## Next steps

> [!div class="step-by-step"]
> [Next: Add a model](xref:tutorials/razor-pages/model)

:::moniker-end
