---
title: Add a new field to a Razor Page in ASP.NET Core
author: rick-anderson
description: Shows how to add a new field to a Razor Page with Entity Framework Core
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.custom: mvc
ms.date: 12/5/2018
uid: tutorials/razor-pages/new-field
---
# Add a new field to a Razor Page in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[](~/includes/rp/download.md)]

In this section [Entity Framework](/ef/core/get-started/aspnetcore/new-db) Code First Migrations is used to:

* Add a new field to the model.
* Migrate the new field schema change to the database.

When using EF Code First to automatically create a database, Code First:

* Adds a table to the database to track whether the schema of the database is in sync with the model classes it was generated from.
* If the model classes aren't in sync with the DB, EF throws an exception.

Automatic verification of schema/model in sync makes it easier to find inconsistent database/code issues.

## Adding a Rating Property to the Movie Model

Open the *Models/Movie.cs* file and add a `Rating` property:

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie22/Models/MovieDateRating.cs?highlight=13&name=snippet)]

Build the app.

Edit *Pages/Movies/Index.cshtml*, and add a `Rating` field:

[!code-cshtml[](razor-pages-start/sample/RazorPagesMovie22/Pages/Movies/IndexRating.cshtml.?highlight=40-42,61-63)]

Update the following pages:

* Add the `Rating` field to the Delete and Details pages.
* Update [Create.cshtml](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Pages/Movies/Create.cshtml) with a `Rating` field.
* Add the `Rating` field to the Edit Page.

The app won't work until the DB is updated to include the new field. If run now, the app throws a `SqlException`:

`SqlException: Invalid column name 'Rating'.`

This error is caused by the updated Movie model class being different than the schema of the Movie table of the database. (There's no `Rating` column in the database table.)

There are a few approaches to resolving the error:

1. Have the Entity Framework automatically drop and re-create the database using the new model class schema. This approach is convenient early in the development cycle; it allows you to quickly evolve the model and database schema together. The downside is that you lose existing data in the database. Don't use this approach on a production database! Dropping the DB on schema changes and using an initializer to automatically seed the database with test data is often a productive way to develop an app.

2. Explicitly modify the schema of the existing database so that it matches the model classes. The advantage of this approach is that you keep your data. You can make this change either manually or by creating a database change script.

3. Use Code First Migrations to update the database schema.

For this tutorial, use Code First Migrations.

Update the `SeedData` class so that it provides a value for the new column. A sample change is shown below, but you'll want to make this change for each `new Movie` block.

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie22/Models/SeedDataRating.cs?name=snippet1&highlight=8)]

See the [completed SeedData.cs file](https://github.com/aspnet/Docs/blob/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Models/SeedDataRating.cs).

Build the solution.

<!-- VS -------------------------->
# [Visual Studio](#tab/visual-studio)

<a name="pmc"></a>

### Add a migration for the rating field

From the **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
In the PMC, enter the following commands:

```powershell
Add-Migration Rating
Update-Database
```

The `Add-Migration` command tells the framework to:

* Compare the `Movie` model with the `Movie` DB schema.
* Create code to migrate the DB schema to the new model.

The name "Rating" is arbitrary and is used to name the migration file. It's helpful to use a meaningful name for the migration file.

The `Update-Database` command tells the framework to apply the schema changes to the database.

<a name="ssox"></a>

If you delete all the records in the DB, the initializer will seed the DB and include the `Rating` field. You can do this with the delete links in the browser or from [Sql Server Object Explorer](xref:tutorials/razor-pages/sql#ssox) (SSOX).

Another option is to delete the database and use migrations to re-create the database. To delete the database in SSOX:

* Select the database in SSOX.
* Right click on the database, and select *Delete*.
* Check **Close existing connections**.
* Select **OK**.
* In the [PMC](xref:tutorials/razor-pages/new-field#pmc), update the database:

  ```powershell
  Update-Database
  ```

<!-- Code -------------------------->
# [Visual Studio Code](#tab/visual-studio-code)

<!-- copy/paste this tab to the next. Not worth an include  -->

Run the following .NET Core CLI commands:

```console
dotnet ef migrations add Rating
dotnet ef database update
```

The `ef migrations add` command tells the framework to:

* Compare the `Movie` model with the `Movie` DB schema.
* Create code to migrate the DB schema to the new model.

The name "Rating" is arbitrary and is used to name the migration file. It's helpful to use a meaningful name for the migration file.

The `ef database update` command tells the framework to apply the schema changes to the database.

If you delete all the records in the DB, the initializer will seed the DB and include the `Rating` field. You can do this with the delete links in the browser or by using a SQLite tool.

Another option is to delete the database and use migrations to re-create the database. To delete the database, delete the database file (*MvcMovie.db*). Then run the `ef database update` command: 

```console
dotnet ef database update
```

> [!NOTE]
> Many schema change operations are not supported by the EF Core SQLite provider. For example, adding a column is supported, but removing a column is not supported. If you add a migration to remove a column, the `ef migrations add` command succeeds but the `ef database update` command fails. You can work around some of the limitations by manually writing migrations code to perform a table rebuild. A table rebuild involves renaming the existing table, creating a new table, copying data to the new table, and dropping the old table. For more information, see the following resources:
> * [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
> * [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
> * [Data seeding](/ef/core/modeling/data-seeding)

<!-- Mac -------------------------->
# [Visual Studio for Mac](#tab/visual-studio-mac)

Run the following .NET Core CLI commands:

```console
dotnet ef migrations add Rating
dotnet ef database update
```

The `ef migrations add` command tells the framework to:

* Compare the `Movie` model with the `Movie` DB schema.
* Create code to migrate the DB schema to the new model.

The name "Rating" is arbitrary and is used to name the migration file. It's helpful to use a meaningful name for the migration file.

The `ef database update` command tells the framework to apply the schema changes to the database.

If you delete all the records in the DB, the initializer will seed the DB and include the `Rating` field. You can do this with the delete links in the browser or by using a SQLite tool.

Another option is to delete the database and use migrations to re-create the database. To delete the database, delete the database file (*MvcMovie.db*). Then run the `ef database update` command: 

```console
dotnet ef database update
```

> [!NOTE]
> Many schema change operations are not supported by the EF Core SQLite provider. For example, adding a column is supported, but removing a column is not supported. If you add a migration to remove a column, the `ef migrations add` command succeeds but the `ef database update` command fails. You can work around some of the limitations by manually writing migrations code to perform a table rebuild. A table rebuild involves renaming the existing table, creating a new table, copying data to the new table, and dropping the old table. For more information, see the following resources:
> * [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
> * [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
> * [Data seeding](/ef/core/modeling/data-seeding)

---  
<!-- End of VS tabs -->

Run the app and verify you can create/edit/display movies with a `Rating` field. If the database isn't seeded, set a break point in the `SeedData.Initialize` method.

> [!div class="step-by-step"]
> [Previous: Adding Search](xref:tutorials/razor-pages/search)
> [Next: Adding Validation](xref:tutorials/razor-pages/validation)
