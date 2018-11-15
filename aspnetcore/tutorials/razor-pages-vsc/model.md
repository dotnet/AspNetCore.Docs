---
title: Add a model to an ASP.NET Core Razor Pages app with Visual Studio Code
author: rick-anderson
description: Learn how to add a model to a Razor Pages app in ASP.NET Core using Visual Studio Code.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.date: 08/27/2017
uid: tutorials/razor-pages-vsc/model
---

# Add a model to an ASP.NET Core Razor Pages app with Visual Studio Code

[!INCLUDE [model1](../../includes/RP/model1.md)]

## Add a data model

* Add a folder named *Models*.
* Add a class to the *Models* folder named *Movie.cs*.
* Add the following code to the *Models/Movie.cs* file:

[!INCLUDE [model 2](../../includes/RP/model2.md)]

### Entity Framework Core NuGet package for SQLite

From the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal), run the following .NET Core CLI command:

```console
dotnet add package Microsoft.EntityFrameworkCore.SQLite
```

<a name="reg"></a>

### Register the database context

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in the *Startup.cs* file.

[!code-csharp[](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Startup.cs?name=snippet_ConfigureServices2&highlight=10-11)]

Add the following `using` statements at the top of *Startup.cs*:

```csharp
using RazorPagesMovie.Models;
using Microsoft.EntityFrameworkCore;
```

Build the project to verify you don't have any errors.

[!INCLUDE [model 3](../../includes/RP/model3.md)]

<a name="scaffold"></a>

### Scaffold the Movie model

* Open a command window in the project directory (The directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files).
* **For Windows**: Run the following command:

  ```console
  dotnet aspnet-codegenerator razorpage -m Movie -dc MovieContext -udl -outDir Pages\Movies --referenceScriptLibraries
  ```

* **For macOS and Linux**: Run the following command:

  ```console
  dotnet aspnet-codegenerator razorpage -m Movie -dc MovieContext -udl -outDir Pages/Movies --referenceScriptLibraries
  ```

[!INCLUDE [model 4](../../includes/RP/model4.md)]

The next tutorial explains the files created by scaffolding.

> [!div class="step-by-step"]
> [Previous: Get Started](xref:tutorials/razor-pages-vsc/razor-pages-start)
> [Next: Scaffolded Razor Pages](xref:tutorials/razor-pages-vsc/page)
