:::moniker range="< aspnetcore-5.0"

This is the first tutorial of a series that teaches the basics of building an ASP.NET Core Razor Pages web app.

For a more advanced introduction aimed at developers who are familiar with controllers and views, see [Introduction to Razor Pages](xref:razor-pages/index).

At the end of the series, you'll have an app that manages a database of movies.  

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie30) ([how to download](xref:index#how-to-download-a-sample)).

In this tutorial, you:

> [!div class="checklist"]
> * Create a Razor Pages web app.
> * Run the app.
> * Examine the project files.

At the end of this tutorial, you'll have a working Razor Pages web app that you'll build on in later tutorials.

![The Home or Index page](~/tutorials/razor-pages/razor-pages-start/_static/home2.2.png)

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs-3.1.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-3.1.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-core-prereqs-mac-3.1.md)]

---

## Create a Razor Pages web app

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project**.
* Create a new ASP.NET Core Web Application and select **Next**.
  ![Create the new project from the start window](~/tutorials/razor-pages/razor-pages-start/_static/np_2.1.png)
* Name the project **RazorPagesMovie**. It's important to name the project *RazorPagesMovie* so the namespaces will match when you copy and paste code.
  ![Name the project](~/tutorials/razor-pages/razor-pages-start/_static/config.png)

* Select **ASP.NET Core 3.1** in the dropdown, **Web Application**, and then select **Create**.

![Select ASP.NET Core Web Application](~/tutorials/razor-pages/razor-pages-start/_static/3/npx.png)

  The following starter project is created:

  ![Solution Explorer](~/tutorials/razor-pages/razor-pages-start/_static/se2.2.png)

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).

* Change to the directory (`cd`) which will contain the project.

* Run the following commands:

  ```dotnetcli
  dotnet new webapp -o RazorPagesMovie
  code -r RazorPagesMovie
  ```

  * The `dotnet new` command creates a new Razor Pages project in the *RazorPagesMovie* folder.
  * The `code` command opens the *RazorPagesMovie* folder in the current instance of Visual Studio Code.

* After the status bar's OmniSharp flame icon turns green, a dialog asks **Required assets to build and debug are missing from 'RazorPagesMovie'. Add them?** Select **Yes**.

  A *.vscode* directory, containing `launch.json` and `tasks.json` files, is added to the project's root directory.

  If Visual Studio Code doesn't offer to add the assets automatically, see the **Linux** operating system guidance in <xref:blazor/tooling?pivot=linux>.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Select **File** > **New Solution**.

  ![macOS New solution](~/tutorials/first-mvc-app/start-mvc/_static/new_project_vsmac.png)

* In Visual Studio for Mac earlier than version 8.6, select **.NET Core** > **App** > **Web Application** > **Next**. In version 8.6 or later, select **Web and Console** > **App** > **Web Application** > **Next**.

  ![macOS web app template selection](~/tutorials/razor-pages/razor-pages-start/_static/web_app_template_vsmac.png)

* In the **Configure the new Web Application** dialog:

  * Confirm that **Authentication** is set to **No Authentication**.
  * If presented an option to select a **Target Framework**, select the latest 3.x version.

  Select **Next**.

* Name the project **RazorPagesMovie**, and then select **Create**.

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

Contains static files, like HTML files, JavaScript files, and CSS files. For more information, see <xref:fundamentals/static-files>.

### `appSettings.json`

Contains configuration data, like connection strings. For more information, see <xref:fundamentals/configuration/index>.

### Program.cs

Contains the entry point for the program. For more information, see <xref:fundamentals/host/generic-host>.

### Startup.cs

Contains code that configures app behavior. For more information, see <xref:fundamentals/startup>.

## Next steps

> [!div class="step-by-step"]
> [Next: Add a model](xref:tutorials/razor-pages/model)

:::moniker-end
