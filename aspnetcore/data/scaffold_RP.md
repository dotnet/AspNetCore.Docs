---
title: Scaffold a data model with dotnet scaffold in a Razor Pages project
description: Scaffold a data model with dotnet scaffold in a Razor Pages project
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-9.0'
ms.date: 3/15/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
uid: data/dotnet-scaffold-rp
---
# Scaffold a data model with dotnet scaffold in a Razor Pages project

The CLI tool, [dotnet scaffold](https://www.nuget.org/packages/Microsoft.dotnet-scaffold) creates data access UI for many .NET project types, such as API, Aspire, Blazor, MVC, and Razor Pages. `dotnet scaffold` can be run interactively or as a command line tool via passing parameter values.

## Install and update the scaffolding tool

Install the [.NET SDK](https://dotnet.microsoft.com/download).

The following command installs the scaffolder globally:

```dotnetcli
dotnet tool install --global Microsoft.dotnet-scaffold
```

See [How to manage .NET tools](/dotnet/core/tools/global-tools) for information on .NET tools and how to install them locally.

To launch the interactive tool, run `dotnet scaffold`. The UI changes as more features are added. Currently, the interactive UI looks similar to the following image:

![scaffold tool initial](~/data/scaffold_RP/images/scaffold1.png)

To navigate the UI, use the:

* Up and down arrow keys to navigate the menu items.
* Enter key to select the highlighted menu item.
* Select and enter **Back** to return to the previous menu.

## Create and scaffold a data model in a Razor Pages project

If you have any problems with the following steps, see <xref:tutorials/razor-pages/index?tabs=visual-studio-code>.

1. Run the following commands to create a Razor Pages project and navigate to the projects folder:
    ```dotnetcli
    dotnet new webapp -o MyWebApp
    cd MyWebApp
    ```
1. Add the `Contact` class to the `MyWebApp` project:
    :::code language="csharp" source="~/data/scaffold_RP/samples/MyWebApp/Contact.cs":::
1. Run `dotnet scaffold` in the `MyWebApp` folder and select **Razor Pages**, then enter return.
1. Navigate to **Razor Pages with Entity Framework (CRUD) (dotnet-scaffold-aspnet)**, then enter return.
1. Enter return on the selected **MyWebApp (MyWebApp.csproj)**.
1. Enter return on **Contact (Contact)**.
1. Enter `ContactDbContext`, then enter return.
1. Navigate to a Database Provider, then enter return.
1. Select **CRUD**, then enter return.
1. Select a choice for prerelease packages, then enter return.

  The `dotnet scaffold` tool makes the following changes to the project files:

* A package reference is added for Entity Framework.
* `Program.cs` is updated to initialize the database connection.
* `appsettings.json` is updated with connection information.
* `ContactDbContext.cs` is created and added to the project root directory.
* Razor Pages for CRUD operations are added to the Pages folder.

The content has been generated but the database isn't initialized. Run the following commands to initialize the DB.

```dotnetcli
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet ef migrations add initialMigration
dotnet ef database update
```

In  The preceding commands:

* `dotnet tool uninstall --global dotnet-ef` uninstalls the `dotnet-ef` tool. Uninstalling ensures the latest tool is successfully installed. If `dotnet-ef` isn't installed, an error messages **A tool with the package Id 'dotnet-ef' could not be found.** You can ignore this message.
* `dotnet tool install --global dotnet-ef` installs globally the `dotnet-ef` tool.
* `dotnet ef migrations add initialMigration` adds the initial migration. For more information, see <xref:tutorials/razor-pages/model?tabs=visual-studio-code>.
* `dotnet ef database update` applies the migrations to the database.

Run the app:

1. Enter `dotnet run` on the command line, which launches the app.
1. Open a browser and navigate the URL specified in the output **Now listening on: http://localhost:wxyz**, where `wxyz` is the port listed.
1. Append `/ContactPages` to the end of the URL.
1. Test the app by selecting:
    1. **Create New** to create a new app.
    1. Try the **Edit**, **Details**, and **Delete** links.

## Additional resources

* [dotnet scaffold repo on GitHub](https://github.com/dotnet/Scaffolding)
* [How to manage .NET tools](/dotnet/core/tools/global-tools)
* [`Microsoft.dotnet-scaffold`](https://www.nuget.org/packages/Microsoft.dotnet-scaffold) NuGet package.
* <xref:data/dotnet-scaffold-rp>
