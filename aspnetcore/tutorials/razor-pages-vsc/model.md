---
title: Adding a model to a Razor Pages app with Visual Studio for Mac
author: rick-anderson
description: Adding a model to a Razor Pages app in ASP.NET Core using Visual Studio for Mac
keywords: ASP.NET Core,Razor Pages,Razor,MVC,model
ms.author: riande
manager: wpickett
ms.date: 8/27/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: aspnet-core
uid: tutorials/razor-pages-vsc/model
---

# Adding a model to a Razor Pages app in ASP.NET Core with Visual Studio for Mac

[!INCLUDE[model1](../../includes/RP/model1.md)]

## Add a data model

* Add a folder named *Models*.
* Add a class to the *Models* folder named *Movie.cs*.
* Add the following code to the *Models/Movie.cs* file:

[!INCLUDE[model 2](../../includes/RP/model2.md)]
[!INCLUDE[model 2a](../../includes/RP/model2a.md)]

[!code-csharp[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Startup.cs?name=snippet_ConfigureServices2&highlight=3-6)]

Build the project to verify you don't have any errors.

### Entity Framework Core NuGet packages for migrations

The EF tools for the command-line interface (CLI) are provided in [Microsoft.EntityFrameworkCore.Tools.DotNet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools.DotNet). To install this package, add it to the `DotNetCliToolReference` collection in the *.csproj* file. **Note:** You have to install this package by editing the *.csproj* file; you can't use the `install-package` command or the package manager GUI.

Edit the *RazorPagesMovie.csproj* file:

* Select **File > Open File**, and then select the *RazorPagesMovie.csproj* file.
* Add `<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />` as highlighted in the following code:

[!code-xml[](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/RazorPagesMovie.cli.csproj?highlight=10)]
[!INCLUDE[model 3](../../includes/RP/model3.md)]

<a name="scaffold"></a>
### Scaffold the Movie model

* Open a command window in the project directory (The directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files).
* Run the following command:

**Note: Run the following command on Windows. For MacOS and Linux, see the next command**

  ```console
  dotnet aspnet-codegenerator razorpage -m Movie -dc MovieContext -udl -outDir Pages\Movies --referenceScriptLibraries
  ```

* On MacOS and Linux, run the following command:

  ```console
  dotnet aspnet-codegenerator razorpage -m Movie -dc MovieContext -udl -outDir Pages/Movies --referenceScriptLibraries
  ```

If you get the error:
  ```
  The process cannot access the file 
 'RazorPagesMovie/bin/Debug/netcoreapp2.0/RazorPagesMovie.dll' 
  because it is being used by another process.
  ```

Exit Visual Studio and run the command again.

[!INCLUDE[model 4](../../includes/RP/model4.md)]
The next tutorial explains the files created by scaffolding.

>[!div class="step-by-step"]
[Previous: Getting Started](xref:tutorials/razor-pages-vsc/razor-pages-start)
[Next: Scaffolded Razor Pages](xref:tutorials/razor-pages/page)
