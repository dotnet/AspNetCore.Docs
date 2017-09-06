---
title: Adding a model to a Razor Pages app in ASP.NET Core
author: rick-anderson
description: Adding a model to a Razor Pages app in ASP.NET Core
keywords: ASP.NET Core,Razor Pages,Razor,MVC
ms.author: riande
manager: wpickett
ms.date: 7/27/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: aspnet-core
uid: tutorials/razor-pages/modelz
---
# Adding a model to a Razor Pages app

[!INCLUDE[model1](../../includes/RP/model1.md)]

## Add a data model

In Solution Explorer, right-click the **RazorPagesMovie** project > **Add** > **New Folder**. Name the folder *Models*.

Right click the *Models* folder > **Add** > **Class**. Name the class **Movie** and add the following properties:

[!INCLUDE[model 2](../../includes/RP/model2.md)]

<a name="cs"></a>
### Add a database connection string

Add a connection string to the *appsettings.json* file.

[!code-json[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/appsettings.json?highlight=8-10)]

<a name="reg"></a>
###  Register the database context

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in the *Startup.cs* file.

[!code-csharp[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Startup.cs?name=snippet_ConfigureServices&highlight=3-6)]

Build the project to verify you don't have any errors.

<a name="pmc"></a>
## Add scaffold tooling and perform initial migration

In this section, you use the Package Manager Console (PMC) to:

* Add the Visual Studio web code generation package. This package is required to run the scaffolding engine.
* Add an initial migration.
* Update the database with the initial migration.

From the **Tools** menu, select **NuGet Package Manager > Package Manager Console**.

  ![PMC menu](../first-mvc-app/adding-model/_static/pmc.png)

In the PMC, enter the following commands:

```powershell
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 2.0.0
Add-Migration Initial
Update-Database
```

The `Install-Package` command installs the tooling required to run the scaffolding engine.

The `Add-Migration` command generates code to create the initial database schema. The schema is based on the model specified in the `DbContext` (In the *Models/MovieContext.cs* file). The `Initial` argument is used to name the migrations. You can use any name, but by convention you choose a name that describes the migration. See [Introduction to migrations](xref:data/ef-mvc/migrations#introduction-to-migrations) for more information.

The `Update-Database` command runs the `Up` method in the *Migrations/\<time-stamp>_InitialCreate.cs* file, which creates the database.

[!INCLUDE[model 4windows](../../includes/RP/model4Win.md)]

[!INCLUDE[model 4](../../includes/RP/model4.md)]

The next tutorial explains the files created by scaffolding.

>[!div class="step-by-step"]
[Previous: Getting Started](xref:tutorials/razor-pages/razor-pages-start)
[Next: Scaffolded Razor Pages](xref:tutorials/razor-pages/page)    