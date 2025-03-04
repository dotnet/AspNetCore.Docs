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

To launch the interactive tool, run `dotnet scaffold`, and use the up and down arrow keys to make selections.

```dotnetcli
dotnet new webapp -o MyWebApp
cd MyWebApp
```


