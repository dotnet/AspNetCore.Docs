---
title: Adding a New Field | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 04/14/2017
ms.topic: article
ms.assetid: 1638bacf-fe7b-4b41-84b0-06a1574b7734
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app-xplat/new-field
---
# Adding a New Field

By [Rick Anderson](https://twitter.com/RickAndMSFT)

When you use EF Code First to automatically create a database, Code First adds a table to the database to help track whether the schema of the database is in sync with the model classes it was generated from. If they aren't in sync, EF throws an exception. This makes it easier to find inconsistent database/code issues.

This tutorial will add a new field to the `Movies` table. One option is to use [EF Code First Migrations](http://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html) to add a new field to the model and migrate that change to the database - but SQLlite does not support many migration schema operations, so only very simply migrations are possible. See [SQLite Limitations](https://docs.microsoft.com/ef/core/providers/sqlite/limitations) for more information.

For this tutorial we'll drop our database and create a new one when we change the schema. This workflow works well early in development when we don't have any production data to perserve.

See [Migrations limitations workaround](https://docs.microsoft.com/ef/core/providers/sqlite/limitations?branch=Rick-Anderson-patch-3#migrations-limitations-workaround) for one approch to using migrations with SQLite.

## Adding a Rating Property to the Movie Model

Open the *Models/Movie.cs* file and add a `Rating` property:

[!code-csharp[Main](../first-mvc-app/start-mvc/sample/MvcMovie/Models/MovieDateRating.cs?highlight=11&range=7-18)]

Because you've added a new field to the `Movie` class, you also need to update the binding white list so this new property will be included. In *MoviesController.cs*, update the `[Bind]` attribute for both the `Create` and `Edit` action methods to include the `Rating` property:

```csharp
[Bind("ID,Title,ReleaseDate,Genre,Price,Rating")]
   ```

You also need to update the view templates in order to display, create and edit the new `Rating` property in the browser view.

Edit the */Views/Movies/Index.cshtml* file and add a `Rating` field:

[!code-HTML[Main](../first-mvc-app/start-mvc/sample/MvcMovie/Views/Movies/IndexGenreRating.cshtml?highlight=17,39&range=24-64)]

Update the */Views/Movies/Create.cshtml* with a `Rating` field.

The app won't work until we update the DB to include the new field. If you run it now, you'll get the following `SqliteException`:

`SqliteException: SQLite Error 1: 'no such column: m.Rating'.``

You're seeing this error because the updated Movie model class is different than the schema of the Movie table of the existing database. (There's no `Rating` column in the database table.)

There are a few approaches to resolving the error:

1. Have the Entity Framework automatically drop and re-create the database based on the new model class schema. This approach is very convenient early in the development cycle when you are doing active development on a test database; it allows you to quickly evolve the model and database schema together. The downside, though, is that you lose existing data in the database — so you don't want to use this approach on a production database! Using an initializer to automatically seed a database with test data is often a productive way to develop an app.

2. Explicitly modify the schema of the existing database so that it matches the model classes. The advantage of this approach is that you keep your data. You can make this change either manually or by creating a database change script.

3. Use Code First Migrations to update the database schema.

For this tutorial, we'll drop and re-create the database when the schema changes.

- Delete the *MvcMovie.db* SQLite database file.
- Delete all the files from the *Migrations* folder.

Update the `SeedData` class so that it provides a value for the new column. A sample change is shown below, but you'll want to make this change for each `new Movie`.

[!code-csharp[Main](../first-mvc-app/start-mvc/sample/MvcMovie/Models/SeedDataRating.cs?name=snippet1&highlight=6)]

Build the solution then open a command prompt. Enter the following commands:

```console
dotnet ef migrations add InitialCreate2
dotnet ef database update
```

The `migrations add` command tells the migration framework to examine the current `Movie` model with the current `Movie` DB schema and create the necessary code to migrate the DB to the new model. 


Run the app and verify you can create/edit/display movies with a `Rating` field. You should also add the `Rating` field to the `Edit`, `Details`, and `Delete` view templates.

>[!div class="step-by-step"]
[Previous](search.md)
<!--
[Next](validation.md)  
-->
