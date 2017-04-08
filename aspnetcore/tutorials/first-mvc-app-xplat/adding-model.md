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

In addition to the properties you'd expect to model a movie, the `ID` field is required by the database for the primary key. Build the app to verify you don't have any errors.

We've finally added a **M**odel to our **M**VC app.

## Prepare the project for scaffolding

- Add the following highlighted NuGet packages to the *MvcMovie.csproj* file:
             
   [!code-csharp[Main](start-mvc/sample/MvcMovie/MvcMovie.csproj?highlight=5,15-)]

- Save the file and select **Restore** to the **Info** message "There are unresolved dependencies".
- Create a *Models/MvcMovieContext.cs* file and add the following `MvcMovieContext` class:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Models/MvcMovieContext.cs)]
   
- Update the *Startup.cs* file and add two usings:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Startup.cs?name=snippet1&highlight=1,2)]

- Add the database context to the *Startup.cs* file:

   [!code-csharp[Main](start-mvc/sample/MvcMovie/Startup.cs?name=snippet2&highlight=6-7)]

- Build and run the project to verify there are no errors.

## Scaffold the MovieController

Open a terminal window in the project folder and run the following commands:

```none
dotnet restore
dotnet aspnet-codegenerator controller -name MoviesController  -m Movie -dc MvcMovieContext
```

The scaffolding engine creates the following:

* A movies controller (*MoviesController.cs*)
* Create, Delete, Details, Edit and Index Razor view files (*Views/Movies*)

Scaffolding automatically created the [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) (create, read, update, and delete) action methods and views for you. The automatic creation of CRUD action methods and views is known as *scaffolding*. You'll soon have a fully functional web application that lets you create, list, edit, and delete movie entries.

You can run the following command to get help on the scaffolding engine:

```none
dotnet aspnet-codegenerator controller -name MoviesController  -m Movie -dc MvcMovieContext
```

If you run the app and click on the **Mvc Movie** link, you'll get an error similar to the following:

```
SqliteException: SQLite Error 1: 'no such table: Movie'.
Microsoft.Data.Sqlite.Interop.MarshalEx.ThrowExceptionForRC(int rc, Sqlite3Handle db)
```

We'll fix that after we clean up the scaffolding code.

## Clean up the scaffolding

Move the `MovieController.cs` file to the *Controlers* folder. By convention, controllers are in the this folder.

### Clean up the views

Remove the `Layout` markup in each of the Razor view files in the *Views/Movie* folder. Replace the following Razor markup:

```html
@{
   Layout = null;
}
```

with

```html
@{
   ViewData["Title"] = "<Name of Action/View>";
}
```

Where `<Name of Action/View>` is the name of the view (also the name of the action which returns the view. For example, in the *Views\Details.cshtml* view:

```html
@{
   ViewData["Title"] = "Details";
}
```

The `dotnet new mvc` generated code includes the *Views/Shared/_Layout.cshtml* Razor layout file. The layout file is used by default in each view unless you set `Layout = null;`:

[!code-csharp[Main](start-mvc/sample/MvcMovie/Views/_ViewStart.cshtml)]

The *Views/Shared/_Layout.cshtml* includes the following markup:

```html<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - Movie App</title>
```

The `ViewData["Title"]` is passed from the view to the layout file. When the view is rendered, the HTML title will be set to the value passed from the view.

[!INCLUDE[adding-model](../../includes/mvc-intro/adding-model3.md)]

You now have a database and pages to display, edit, update and delete data. In the next tutorial, we'll work with the database.

### Additional resources

* [Tag Helpers](xref:mvc/views/tag-helpers/intro)
* [Globalization and localization](xref:fundamentals/localization)

>[!div class="step-by-step"]
[Previous Adding a View](adding-view.md)
<!--
[Next Working with SQL](working-with-sql.md)  
-->