---
title: Adding a model | Microsoft Docs
author: rick-anderson
description: Add a model to a simple ASP.NET Core app.
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 03/30/2017
ms.topic: get-started-article
ms.assetid: 8dc28498-eeee-4666-b903-b593059e9f39
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app-xplat/adding-model
---

[!INCLUDE[adding-model1](../../includes/mvc-intro/adding-model1.md)]

* Add a folder named *Models*.
* Add a class to the *Models* folder named *Movie.cs*.
* Add the following code to the *Models/Movie.cs* file:

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/MovieNoEF.cs?name=snippet_1)]

The `ID` field is required by the database for the primary key. 

Build the app to verify you don't have any errors, and you've finally added a **M**odel to your **M**VC app.

## Prepare the project for scaffolding

- Add the following highlighted NuGet packages to the *MvcMovie.csproj* file:
             
   [!code-csharp[Main](start-mvc/sample/MvcMovie/MvcMovie.csproj?highlight=5,17-18,21-)]

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

> [!NOTE]
> If you get an error when the scaffolding command runs, see [issue 444 in the scaffolding repository](https://github.com/aspnet/scaffolding/issues/444) for a workaround.

The scaffolding engine creates the following:

* A movies controller (*Controllers/MoviesController.cs*)
* Razor view files for Create, Delete, Details, Edit and Index pages (*Views/Movies/\*.cshtml*)

The automatic creation of [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) (create, read, update, and delete) action methods and views is known as *scaffolding*. You'll soon have a fully functional web application that lets you manage a movie database.

### Create the database

You'll call the `EnsureCreated` method to cause EF Core to create the database if it doesn't exist. 

This is a method you typically use only in a development environment. It creates a database to match your data model when you run the app for the first time. When you change your data model, you drop the database. The next time the app runs, EF Core creates a new database to match your new data model.

This approach doesn't work well in production, because you have data you don't want to lose by dropping the database. EF Core includes a [Migrations](xref:data/ef-mvc/migrations) feature that lets you preserve data when you make data model changes, but you won't be using Migrations in this tutorial. You'll learn more about data model changes in the [Add a field](xref:tutorials/first-mvc-app-xplat/new-field) tutorial.

Create a *Models\DBinitialize.cs* file and add the following code:

<!-- todo - replace this with code import -->

```c#
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MvcMovie.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>());
            context.Database.EnsureCreated();
        }
    }
}
```

Call the `EnsureCreated` method from the `Configure` method in the *Startup.cs* file. Add the call to the end of the method:

<!-- todo - replace this with code import -->

```c#
    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });

    DBinitialize.EnsureCreated(app.ApplicationServices);
}
```

[!INCLUDE[adding-model](../../includes/mvc-intro/adding-model3.md)]

You now have a database and pages to display, edit, update and delete data. In the next tutorial, we'll work with the database.

### Additional resources

* [Tag Helpers](xref:mvc/views/tag-helpers/intro)
* [Globalization and localization](xref:fundamentals/localization)

>[!div class="step-by-step"]
[Previous - Add a view](adding-view.md)
[Next - Working with SQLite](working-with-sql.md)
