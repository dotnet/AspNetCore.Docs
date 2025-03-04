---
title: Scaffold a data model with dotnet scaffold in a Razor Pages project
description: Scaffold a data model with dotnet scaffold in a Razor Pages project
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-9.0'
ms.date: 3/7/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
uid: data/dotnet-scaffold-rp
---

?view=aspnetcore-9.0

# Scaffold a data model with dotnet scaffold in a Razor Pages project

The CLI tool, [dotnet scaffold](https://www.nuget.org/packages/Microsoft.dotnet-scaffold) creates data access UI for many .NET project types, such as API, Aspire, Blazor, MVC, and Razor Pages. `dotnet scaffold` can be run interactively or as a command line tool via passing parameter values.

The following command installs the scaffolder globally:

```dotnetcli
dotnet tool install --global Microsoft.dotnet-scaffold
```

See [How to manage .NET tools](/dotnet/core/tools/global-tools) for imfomation on .NET tools and how to install them locally.

To launch the interactive tool, run `dotnet scaffold`. The UI will change as more features are added. The interactive UI looks simlar to the following:

![scaffold tool initial](~/data/scaffold_RP/images/scaffold1.png)

To naviagte the UI, use the:

- Up and down arrow keys to navigate the meun items.
- Enter key to select the highlighted menu item.
- Select and enter **Back** to return to the previous menu.

## Create and caffold a data model in a Razor Pages project

If you have any problems with the following steps, see [Tutorial: Create a Razor Pages web app with ASP.NET Core](/aspnet/core/tutorials/razor-pages/) and select the **Visual Studio Code** tab.

1. Run the following commands to create a Razor Pages project and naviate to the projects folder:

  ```dotnetcli
  dotnet new webapp -o MyWebApp
  cd MyWebApp
  ```

1. Add the `Contact` class to the `MyWebApp` project:

  :::code language="csharp" source="~/data/scaffold_RP/samples/MyWebApp/Contact.cs":::

1. Run `dotnet scaffold` in the `MyWebApp` folder and select **Razor Pages**, then enter return.
1. Navigate to *** Razor Pages with Entity Framework (CRUD) (dotnet-scaffold-aspnet)**, then enter return.
1. Enter return on the selected **MyWebApp (MyWebApp.csproj)**.
1. Enter return on **Contact (Contact)**.
1. Enter `ContactDbContext`, then enter return.
1. Navigate to a Database Provider, then enter return.
1. Select **CRUD**, then enter return.
1. Select a choice for prerelease packages, then enter return.

  The `dotnet scaffold` tool makes the following changes to the project files:

- A package reference is added for Entity Framework.
- `Program.cs` is updated to initialize the database connection.
- `appsettings.json` is updated with connection information.
- `ContactDbContext.cs` is created and added to the project root directory.
- Razor Pages for CRUD operations are added to the Pages folder.

The content has been generated but the database hasn't been initialized. Run the following commands to initialize the DB.

```dotnetcli
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet ef migrations add initialMigration
dotnet ef database update
```

In  The preceeding commands:
- `dotnet tool uninstall --global dotnet-ef` uninstall the `dotnet-ef` too, to ensure the latest tool is successfully installed in the next step. If `dotnet-ef` isn't installed, an error messages **A tool with the package Id 'dotnet-ef' could not be found.** You can ignore this message.
- `dotnet tool install --global dotnet-ef` installs globally the `dotnet-ef` tool.
- `dotnet ef migrations add initialMigration` adds the initial migration. For more information, see [Create the initial database schema using EF's migration feature](/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-9.0&tabs=visual-studio-code)
- `dotnet ef database update` applies the migrations to the database.

Run the app:

1. Enter `dotnet run` on the command line, which launches the app.
1. Open a browser and navigate the the URL specified on the output **Now listening on: http://localhost:wxyz**, where `wxyz` is the port listed.
1. Append `/ContactPages` to the end of the URL.
1. Test the app by selecting:
  1. **Create New** to create a new app.
  1. Try the **Edit**, **Details**, and **Delete** links.

