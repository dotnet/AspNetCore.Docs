---
title: Adding a model to a Razor Pages app with Visual Studio for Mac
author: rick-anderson
description: Adding a model to a Razor Pages app in ASP.NET Core using Visual Studio for Mac
keywords: ASP.NET Core,Razor Pages,Razor,MVC
ms.author: riande
manager: wpickett
ms.date: 8/27/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: aspnet-core
uid: tutorials/razor-pages-mac/model
---

# Adding a model to a Razor Pages app in ASP.NET Core with Visual Studio for Mac

[!INCLUDE[model1](../../includes/RP/model1.md)]

## Add a data model

* In Solution Explorer, right-click the **RazorPagesMovie** project, and then select **Add** > **New Folder**. Name the folder *Models*.
* Right-click the *Models* folder, and then select **Add** > **New File**. 
* In the **New File** dialog:

  * Select **General** in the left pane.
  * Select **Empty Class** in the center pain.
  * Name the class **Movie** and select **New**.

[!INCLUDE[model2](../../includes/RP/model2.md)]

<a name="cli"></a>
## Add scaffold tooling and perform initial migration

From the command line, run the following .NET Core CLI commands:

```console
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```

The `add package` command installs the tooling required to run the scaffolding engine.

The `ef migrations add InitialCreate` command generates code to create the initial database schema. The schema is based on the model specified in the `DbContext` (In the *Models/MovieContext.cs* file). The `Initial` argument is used to name the migrations. You can use any name, but by convention you choose a name that describes the migration. See [Introduction to migrations](xref:data/ef-mvc/migrations#introduction-to-migrations) for more information.

The `ef database update` command runs the `Up` method in the *Migrations/\<time-stamp>_InitialCreate.cs* file, which creates the database.

<a name="scaffold"></a>
### Scaffold the Movie model

* Open a command window in the project directory (The directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files).
* Run the following command:

  ```console
  dotnet aspnet-codegenerator razorpage -m Movie -dc MovieContext -udl -outDir Pages\Movies --referenceScriptLibraries
  ```

The following table details the ASP.NET Core code generators` parameters:

| Parameter               | Description|
| ----------------- | ------------ |
| -m  | The name of the model. |
| -dc  | The data context. |
| -udl | Use the default layout. |
| -outDir | The relative output folder path to create the views. |
| --referenceScriptLibraries | Adds `_ValidationScriptsPartial` to Edit and Create pages |

Use the `h` switch to get help on the `aspnet-codegenerator razorpage` command:

```console
dotnet aspnet-codegenerator razorpage -h
```
<a name="test"></a>
### Test the app

* Run the app and append `/Movies` to the URL in the browser (`http://localhost:port/movies`).
* Test the **Create** link.

 ![Create page](../razor-pages/model/_static/conan.png)

<a name="scaffold"></a>

* Test the **Edit**, **Details**, and **Delete** links.

If you get the following error, verify you have run migrations and updated the database:

```
An unhandled exception occurred while processing the request.

SqlException: Cannot open database "DB name" requested by the login. The login failed.
Login failed for user 'user name'.
```

The next tutorial explains the files created by scaffolding.


>[!div class="step-by-step"]
[Previous: Getting Started](xref:tutorials/razor-pages/razor-pages-start)
[Next: Scaffolded Razor Pages](xref:tutorials/razor-pages/page)    
