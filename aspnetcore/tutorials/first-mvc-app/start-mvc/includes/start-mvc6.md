:::moniker range="= aspnetcore-6.0"

[!INCLUDE [consider RP](~/includes/razor.md)]

This is the first tutorial of a series that teaches ASP.NET Core MVC web development with controllers and views.

At the end of the series, you'll have an app that manages and displays movie data. You learn how to:

> [!div class="checklist"]
> * Create a web app.
> * Add and scaffold a model.
> * Work with a database.
> * Add search and validation.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/first-mvc-app/start-mvc/sample) ([how to download](xref:index#how-to-download-a-sample)).

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-6.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-6.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

For Visual Studio for Mac, see the .NET 7 version of this tutorial.

<!--
[!INCLUDE[](~/includes/net-core-prereqs-mac-5.0.md)]
-->
>
---

## Create a web app

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio and select **Create a new project**.
* In the **Create a new project** dialog, select **ASP.NET Core Web App (Model-View-Controller)** > **Next**.
* In the **Configure your new project** dialog, enter `MvcMovie` for **Project name**. It's important to name the project *MvcMovie*. Capitalization needs to match each `namespace` when code is copied.
* Select **Next**.
* In the **Additional information** dialog, select **.NET 6.0 (Long-term support)**.
* Select **Create**.

![Additional info dialog](~/tutorials/first-mvc-app/start-mvc/_static/net6-additional-info.png)

For alternative approaches to create the project, see [Create a new project in Visual Studio](/visualstudio/ide/create-new-project).

Visual Studio uses the default project template for the created MVC project. The created project:

* Is a working app.
* Is a basic starter project.

# [Visual Studio Code](#tab/visual-studio-code)

The tutorial assumes familiarity with VS Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs) and [Visual Studio Code help](#visual-studio-code-help).

* Select **New Terminal** from the **Terminal** menu to open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change to the directory (`cd`) that will contain the project.
* Run the following commands:

   ```dotnetcli
   dotnet new mvc -o MvcMovie
   code -r MvcMovie
   ```

  The `dotnet new` command creates a new ASP.NET Core MVC project in the *MvcMovie* folder.

  The `code` command opens the *MvcMovie* project folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

For Visual Studio for Mac, see the .NET 7 version of this tutorial.

<!--
* Select **File** > **New Solution**.

  ![macOS New solution](~/tutorials/first-mvc-app/start-mvc/_static/new_project_vsmac.png)

* In Visual Studio for Mac earlier than version 8.6, select **.NET Core** > **App** > **Web Application (Model-View-Controller)** > **Next**. In version 8.6 or later, select **Web and Console** > **App** > **Web Application (Model-View-Controller)** > **Next**.

  ![macOS web app template selection](~/tutorials/first-mvc-app/start-mvc/_static/web_app_template_vsmac.png)

* In the **Configure your new Web Application** dialog:

  * Confirm that **Authentication** is set to **No Authentication**.
  * If an option to select a **Target Framework** is presented, select the latest 5.x version.
  * Select **Next**.

* Name the project **MvcMovie**, and then select **Create**.

  ![macOS name the project](~/tutorials/first-mvc-app/start-mvc/_static/MvcMovie.png)
-->

---

### Run the app

# [Visual Studio](#tab/visual-studio)

* Select Ctrl+F5 to run the app without the debugger.

  [!INCLUDE[](~/includes/trustCertVS.md)]

Visual Studio runs the app and opens the default browser.

The address bar shows `localhost:<port#>` and not something like `example.com`. The standard hostname for your local computer is `localhost`. When Visual Studio creates a web project, a random port is used for the web server.

Launching the app without debugging by selecting Ctrl+F5 allows you to:

* Make code changes.
* Save the file.
* Quickly refresh the browser and see the code changes.

You can launch the app in debug or non-debug mode from the **Debug** menu:

![Debug menu](~/tutorials/first-mvc-app/start-mvc/_static/debug_menu50.png)

You can debug the app by selecting the **MvcMovie** button in the toolbar:

![MvcMovie debug button](~/tutorials/first-mvc-app/start-mvc/_static/net6-debug-button.png)

The following image shows the app:

![Home or Index page](~/tutorials/first-mvc-app/start-mvc/_static/home50-vs.png)

# [Visual Studio Code](#tab/visual-studio-code)

* Select Ctrl+F5 to run without the debugger.

  [!INCLUDE[](~/includes/trustCertVSC.md)]

  Visual Studio Code:

  * Starts [Kestrel](xref:fundamentals/servers/kestrel)
  * Launches a browser.
  * Navigates to `https://localhost:<port#>`.

  The address bar shows `localhost:<port#>` and not something like `example.com`. The standard hostname for your local computer is `localhost`. Localhost only serves web requests from the local computer.

Launching the app without debugging by selecting Ctrl+F5 allows you to:

* Make code changes.
* Save the file.
* Quickly refresh the browser and see the code changes.

  ![Home or Index page](~/tutorials/first-mvc-app/start-mvc/_static/home50-port5001.png)

# [Visual Studio for Mac](#tab/visual-studio-mac)

For Visual Studio for Mac, see the .NET 7 version of this tutorial.

<!--
* Select **Run** > **Start Without Debugging** to launch the app.

  Visual Studio for Mac:

  * Starts [Kestrel](xref:fundamentals/servers/index#kestrel) server.
  * Launches a browser.
  * Navigates to `http://localhost:port`, where *port* is a randomly chosen port number.

  [!INCLUDE[](~/includes/trustCertMac.md)]

  The address bar shows `localhost:port#` and not something like `example.com`. The standard hostname for your local computer is `localhost`. When Visual Studio creates a web project, a random port is used for the web server.

You can launch the app in debug or non-debug mode from the **Run** menu.

The following image shows the app:

![Home or Index page](./~/tutorials/first-mvc-app/start-mvc/_static/output_macos.png)
-->

---

[!INCLUDE[](~/includes/vs-vsc-vsmac-help.md)]

In the next tutorial in this series, you learn about MVC and start writing some code.

> [!div class="step-by-step"]
> [Next: Add a controller](~/tutorials/first-mvc-app/adding-controller.md)

:::moniker-end
