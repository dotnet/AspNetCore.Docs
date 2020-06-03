---
title: Add a new field to a Razor Page in ASP.NET Core
author: rick-anderson
description: Shows how to add a new field to a Razor Page with Entity Framework Core
ms.author: riande
ms.custom: mvc
ms.date: 7/23/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/razor-pages/new-field
---
# Add a new field to a Razor Page in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

::: moniker range=">= aspnetcore-3.0"

[!INCLUDE[](~/includes/rp/download.md)]

In this section [Entity Framework](/ef/core/get-started/aspnetcore/new-db) Code First Migrations is used to:

* Add a new field to the model.
* Migrate the new field schema change to the database.

When using EF Code First to automatically create a database, Code First:

* Adds an `__EFMigrationsHistory` table to the database to track whether the schema of the database is in sync with the model classes it was generated from.
* If the model classes aren't in sync with the DB, EF throws an exception.

Automatic verification of schema/model in sync makes it easier to find inconsistent database/code issues.

## Adding a Rating Property to the Movie Model

Open the *Models/Movie.cs* file and add a `Rating` property:

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie30/Models/MovieDateRating.cs?highlight=13&name=snippet)]

Build the app.

Edit *Pages/Movies/Index.cshtml*, and add a `Rating` field:

<a name="addrat"></a>

[!code-cshtml[](razor-pages-start/sample/RazorPagesMovie30/SnapShots/IndexRating.cshtml?highlight=40-42,62-64)]

Update the following pages:

* Add the `Rating` field to the Delete and Details pages.
* Update [Create.cshtml](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie30/Pages/Movies/Create.cshtml) with a `Rating` field.
* Add the `Rating` field to the Edit Page.

The app won't work until the DB is updated to include the new field. Running the app without updating the database throws a `SqlException`:

`SqlException: Invalid column name 'Rating'.`

The `SqlException` exception is caused by the updated Movie model class being different than the schema of the Movie table of the database. (There's no `Rating` column in the database table.)

There are a few approaches to resolving the error:

1. Have the Entity Framework automatically drop and re-create the database using the new model class schema. This approach is convenient early in the development cycle; it allows you to quickly evolve the model and database schema together. The downside is that you lose existing data in the database. Don't use this approach on a production database! Dropping the DB on schema changes and using an initializer to automatically seed the database with test data is often a productive way to develop an app.

2. Explicitly modify the schema of the existing database so that it matches the model classes. The advantage of this approach is that you keep your data. You can make this change either manually or by creating a database change script.

3. Use Code First Migrations to update the database schema.

For this tutorial, use Code First Migrations.

Update the `SeedData` class so that it provides a value for the new column. A sample change is shown below, but you'll want to make this change for each `new Movie` block.

[!code-csharp[](razor-pages-start/sample/RazorPagesMovie30/Models/SeedDataRating.cs?name=snippet1&highlight=8)]

See the [completed SeedData.cs file](https://github.com/dotnet/AspNetCore.Docs/blob/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie30/Models/SeedDataRating.cs).

Build the solution.

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

The `Update-Database` command tells the framework to apply the schema changes to the database and to preserve existing data.

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

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

### Drop and re-create the database

[!INCLUDE[](~/includes/RP-mvc-shared/sqlite-warn.md)]

Delete the migration folder.  Use the following commands to recreate the database.

```dotnetcli
dotnet ef database drop
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

Run the app and verify you can create/edit/display movies with a `Rating` field. If the database isn't seeded, set a break point in the `SeedData.Initialize` method.

## Additional resources

* [YouTube version of this tutorial](https://youtu.be/3i7uMxiGGR8)

> [!div class="step-by-step"]
> [Previous: Adding Search](xref:tutorials/razor-pages/search)
> [Next: Adding Validation](xref:tutorials/razor-pages/validation)

::: moniker-end

::: moniker range="< aspnetcore-3.0"

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

[!code-cshtml[](razor-pages-start/sample/RazorPagesMovie22/Pages/Movies/IndexRating.cshtml?highlight=40-42,61-63)]

Update the following pages:

* Add the `Rating` field to the Delete and Details pages.
* Update [Create.cshtml](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Pages/Movies/Create.cshtml) with a `Rating` field.
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

See the [completed SeedData.cs file](https://github.com/dotnet/AspNetCore.Docs/blob/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Models/SeedDataRating.cs).

Build the solution.

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

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

### Drop and re-create the database

[!INCLUDE[](~/includes/RP-mvc-shared/sqlite-warn.md)]

Delete the database and use migrations to re-create the database. To delete the database, delete the database file (*MvcMovie.db*). Then run the `ef database update` command:

```dotnetcli
dotnet ef database update
```

---

Run the app and verify you can create/edit/display movies with a `Rating` field. If the database isn't seeded, set a break point in the `SeedData.Initialize` method.

## Additional resources

* [YouTube version of this tutorial](https://youtu.be/3i7uMxiGGR8)

> [!div class="step-by-step"]
> [Previous: Adding Search](xref:tutorials/razor-pages/search)
> [Next: Adding Validation](xref:tutorials/razor-pages/validation)

::: moniker-end
