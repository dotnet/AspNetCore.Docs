---
title: Adding a model | Microsoft Docs
author: rick-anderson
description: Add a model to a simple ASP.NET Core app.
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 03/30/2017
ms.topic: article
ms.assetid: 8dc28498-eeee-4666-b903-b593059e9f39
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app-xplat/adding-model
---
[!INCLUDE[adding-model](../../includes/mvc-intro/adding-model1.md)]

* Add a folder named *Models*.
* Add a class to the *Models* folder named *Movie.cs*.
* Add the following code to the *Models/Movie.cs* file:

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/MovieNoEF.cs?name=snippet_1&highlight=7)]

In addition to the properties you'd expect to model a movie, the `ID` field is required by the database for the primary key. Build the project. Build the app to verify you don't have any errors.

We've finally added a **M**odel to our **M**VC app.

## Prepare the project for scaffolding

- Add the following highlighted NuGet packages to the *MvcMovie.csproj* file:

             
   [!code-csharp[Main](start-mvc/sample/MvcMovie/MvcMovie.csproj?highlight=5,15-)]

- Select **Restore** to the **Info** message "There are unresolved dependencies".
- Update the *Startup.cs* file and two usings:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Startup.cs?name=snippet1)]

- Add the database context to the *Startup.cs* file:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Startup.cs?name=snippet2&highlight=5-7)]

- Create a *Models/MvcMovieContext.cs* file and add the following `MvcMovieContext` class:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Models/MvcMovieContext.cs)]

- Add a database connection string to the *appsettings.json* file:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/appsettings.json?highlight=7-)]

- Build and run the project to verify there are no errors.

### Scaffold the MovieController

- Open a terminal window in the project folder and run the following commands:

 ```console
 dotnet restore
 dotnet aspnet-codegenerator controller -name MovieController  -m Movie -dc MvcMovieContext
 ```

### Clean up the scaffolding

- Move the `MovieController.cs` file to the *Controlers* folder. By convention, controllers are in the this folder.

- Remove the `Layout` markup in each of the Razor view files in the *Views/Movie* folder. Remove the following  code:

 ```html
    @{
      Layout = null;
  }
 ```

   The `dotnet new mvc` generated code includes the *Views/Shared/_Layout.cshtml* Razor file which we'll use in each view. *Views/Shared/_Layout.cshtml* is automatically imported into each view with the *Views/_ViewStart.cshtml* Razor view file:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Views/_ViewStart.cshtml)]


[!INCLUDE[adding-model](../../includes/mvc-intro/adding-model3.md)]

You now have a database and pages to display, edit, update and delete data. In the next tutorial, we'll work with the database.

### Additional resources

* [Tag Helpers](xref:mvc/views/tag-helpers/intro)
* [Globalization and localization](xref:fundamentals/localization)

>[!div class="step-by-step"]
[Previous](adding-view.md)
<!--
[Next](working-with-sql.md)  
-->
