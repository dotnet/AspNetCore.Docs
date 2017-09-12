---
title: Adding a New Field to a Razor Page
author: rick-anderson
description: Shows how to add a new field to a Razor Page with Entity Framework Core
keywords: ASP.NET Core,Entity Framework Core,migrations
ms.author: riande
manager: wpickett
ms.date: 8/7/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: aspnet-core
uid: tutorials/razor-pages/new-field
---
# Adding a new field to a Razor Page

By [Rick Anderson](https://twitter.com/RickAndMSFT)

In this section you'll use [Entity Framework](https://docs.microsoft.com/ef/core/get-started/aspnetcore/new-db) Code First Migrations to add a new field to the model and migrate that change to the database.

When you use EF Code First to automatically create a database, Code First adds a table to the database to help track whether the schema of the database is in sync with the model classes it was generated from. If they aren't in sync, EF throws an exception. This makes it easier to find inconsistent database/code issues.

## Adding a Rating Property to the Movie Model

Open the *Models/Movie.cs* file and add a `Rating` property:

[!code-csharp[Main](razor-pages-start/sample/RazorPagesMovie/Models/MovieDateRating.cs?highlight=11&range=7-18)]

Build the app (Ctrl+Shift+B).

Edit *Pages/Movies/Index.cshtml*, and add a `Rating` field:

[!code-cshtml[Main](razor-pages-start/sample/RazorPagesMovie/Pages/Movies/Index.cshtml?highlight=40-42,61-63)]

Add the `Rating` field to the Delete and Details pages.

Update *Create.cshtml* with a `Rating` field. You can copy/paste the previous `<div>` element and let intelliSense help you update the fields. IntelliSense works with [Tag Helpers](xref:mvc/views/tag-helpers/intro).

![The developer has typed the letter R for the attribute value of asp-for in the second label element of the view. An Intellisense contextual menu has appeared showing the available fields, including Rating, which is highlighted in the list automatically. When the developer clicks the field or presses Enter on the keyboard, the value will be set to Rating.](new-field/_static/cr.png)

The following code shows *Create.cshtml* with a `Rating` field:

[!code-cshtml[Main](razor-pages-start/sample/RazorPagesMovie/Pages/Movies/Create.cshtml?highlight=31-35)]

Add the `Rating` field to the Edit Page.

The app won't work until the DB is updated to include the new field. If run now, the app throws a `SqlException`:

`SqlException: Invalid column name 'Rating'.`

This error is caused by the updated Movie model class being different than the schema of the Movie table of the database. (There's no `Rating` column in the database table.)

There are a few approaches to resolving the error:

1. Have the Entity Framework automatically drop and re-create the database using  the new model class schema. This approach is convenient early in the development cycle; it allows you to quickly evolve the model and database schema together. The downside is that you lose existing data in the database. You don't want to use this approach on a production database! Dropping the DB on schema changes and using an initializer to automatically seed the database with test data is often a productive way to develop an app.

2. Explicitly modify the schema of the existing database so that it matches the model classes. The advantage of this approach is that you keep your data. You can make this change either manually or by creating a database change script.

3. Use Code First Migrations to update the database schema.

For this tutorial, use Code First Migrations.

Update the `SeedData` class so that it provides a value for the new column. A sample change is shown below, but you'll want to make this change for each `new Movie` block.

[!code-csharp[Main](razor-pages-start/sample/RazorPagesMovie/Models/SeedDataRating.cs?name=snippet1&highlight=6)]

See the [completed SeedData.cs file](https://github.com/aspnet/Docs/blob/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Models/SeedDataRating.cs).

Build the solution.

<a name="pmc"></a>

From the **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
In the PMC, enter the following commands:

```PMC
Add-Migration Rating
Update-Database
```

The `Add-Migration` command tells the framework to:

* Compare the `Movie` model with the `Movie` DB schema.
* Create code to migrate the DB schema to the new model.

The name "Rating" is arbitrary and is used to name the migration file. It's helpful to use a meaningful name for the migration file.

<a name="ssox"></a>
If you delete all the records in the DB, the initializer will seed the DB and include the `Rating` field. You can do this with the delete links in the browser or from [Sql Server Object Explorer](xref:tutorials/razor-pages/sql#ssox) (SSOX). To delete the database from SSOX:

* Select the database in SSOX.
* Right click on the database, and select *Delete*.
* Check **Close existing connections*
* Select **OK**
* In the [PMC](xref:tutorials/razor-pages/new-field#pmc), update the database 

    ```PMC
    Update-Database
    ```

Run the app and verify you can create/edit/display movies with a `Rating` field. If the database is not seeded, stop IIS Express, and then run the app.

>[!div class="step-by-step"]
[Previous: Adding Search](xref:tutorials/razor-pages/search)
[Next: Adding Validation](xref:tutorials/razor-pages/validation)
