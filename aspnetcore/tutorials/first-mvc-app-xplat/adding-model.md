---
title: Adding a model to an ASP.NET Core MVC app.
author: rick-anderson
description: Add a model to a simple ASP.NET Core app.
manager: wpickett
ms.author: riande
ms.date: 09/18/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: get-started-article
uid: tutorials/first-mvc-app-xplat/adding-model
---

[!INCLUDE[adding-model1](../../includes/mvc-intro/adding-model1.md)]

* Add a class to the *Models* folder named *Movie.cs*.
* Add the following code to the *Models/Movie.cs* file:

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/MovieNoEF.cs?name=snippet_1)]

The `ID` field is required by the database for the primary key. 

Build the app to verify you don't have any errors, and you've finally added a **M**odel to your **M**VC app.

## Prepare the project for scaffolding

- Add the following highlighted NuGet packages to the *MvcMovie.csproj* file:
             
   [!code-csharp[Main](start-mvc/sample/MvcMovie/MvcMovie.csproj?highlight=7,10)]

- Save the file and select **Restore** to the **Info** message "There are unresolved dependencies".
- Create a *Models/MvcMovieContext.cs* file and add the following `MvcMovieContext` class:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Models/MvcMovieContext.cs)]
   
- Open the *Startup.cs* file and add two usings:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Startup.cs?name=snippet1&highlight=1,2)]

- Add the database context to the *Startup.cs* file:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Startup.cs?name=snippet2&highlight=6-7)]

  This tells Entity Framework which model classes are included in the data model. You're defining one *entity set* of Movie objects, which will be represented in the database as a Movie table.

- Build the project to verify there are no errors.

## Scaffold the MovieController

Open a terminal window in the project folder and run the following commands:

```
dotnet restore
dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries 
```
The scaffolding engine creates the following:

* A movies controller (*Controllers/MoviesController.cs*)
* Razor view files for Create, Delete, Details, Edit and Index pages (*Views/Movies/\*.cshtml*)

The automatic creation of [CRUD](https://wikipedia.org/wiki/Create,_read,_update_and_delete) (create, read, update, and delete) action methods and views is known as *scaffolding*. You'll soon have a fully functional web application that lets you manage a movie database.

[!INCLUDE[adding-model 2x](../../includes/mvc-intro/adding-model2xp.md)]

[!INCLUDE[adding-model](../../includes/mvc-intro/adding-model3.md)]

You now have a database and pages to display, edit, update and delete data. In the next tutorial, we'll work with the database.

### Additional resources

* [Tag Helpers](xref:mvc/views/tag-helpers/intro)
* [Globalization and localization](xref:fundamentals/localization)

>[!div class="step-by-step"]
[Previous - Add a view](adding-view.md)
[Next - Working with SQLite](working-with-sql.md)
