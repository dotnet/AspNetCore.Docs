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

Run the following commands to create a Razor Pages project and naviate to the projects folder:

```dotnetcli
dotnet new webapp -o MyWebApp
cd MyWebApp
```

Add the `Contact` class to the `MyWebApp` project:

:::code language="csharp" source="~/data/scaffold_RP/samples/MyWebApp/Contact.cs":::


