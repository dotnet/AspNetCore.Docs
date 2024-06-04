---
title: Build a Blazor movie database app (Part 7 - Add a new field)
author: guardrex
description: This part of the Blazor movie database app tutorial explains how to add a new field to the movie class, CRUD pages, and database.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/29/2024
uid: blazor/tutorials/movie-database-app/part-7
---
# Build a Blazor movie database app (Part 7 - Add a new field)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the seventh part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the series covers adding a new field to the movie class, CRUD pages, and database.

The database update is handled by EF Core code-first migrations. EF Core transparently tracks changes to the database in a migration history table and automatically throws an exception if the app's model classes aren't in sync with the database's tables and columns. EF Core migrations make it possible to quickly troubleshoot database consistency problems.

## Add a movie rating to the app's model

Open the `Models/Movie.cs` file and add a `Rating` property with a regular expression that limits the value of `Rating` to the exact [Motion Picture Association](https://www.motionpictures.org/) film rating designations:

```csharp
[RegularExpression(@"^(G|PG|PG-13|R|NC-17)$"), Required]
public string? Rating { get; set; }
```

## Add the movie rating to the app's CRUD components

Open the `Create` component file (`Components/Pages/MoviePages/Create.razor`).

Add the following `<div>` block after the markup for `Price`:

```razor
<div class="mb-3">
    <label for="rating" class="form-label">Rating:</label> 
    <InputText id="rating" @bind-Value="Movie.Rating" class="form-control" /> 
    <ValidationMessage For="() => Movie.Rating" class="text-danger" /> 
</div>
```

Open the `Delete` component file (`Components/Pages/MoviePages/Delete.razor`).

Add the following description list (`<dl>`) block after the description list block for `Price`:

```razor
<dl class="row">
    <dt class="col-sm-2">Rating</dt>
    <dd class="col-sm-10">@movie.Rating</dd>
</dl>
```

Open the `Details` component file (`Components/Pages/MoviePages/Details.razor`).

Add the following description list term (`<dt>`) and description list element (`<dl>`) after the term and element for `Price`:

```razor
<dt class="col-sm-2">Rating</dt>
<dd class="col-sm-10">@movie.Rating</dd>
```

Open the `Edit` component file (`Components/Pages/MoviePages/Edit.razor`).

Add the following `<div>` block after the markup for `Price`:

```razor
<div class="mb-3">
    <label for="rating" class="form-label">Rating:</label>
    <InputText id="rating" @bind-Value="Movie.Rating" class="form-control" />
    <ValidationMessage For="() => Movie.Rating" class="text-danger" />
</div>
```

Open the `Index` component file (`Components/Pages/MoviePages/Index.razor`).

Update the `QuickGrid` component to include the movie rating. Add the following <xref:Microsoft.AspNetCore.Components.QuickGrid.PropertyColumn`2> immediately after the column for `Price`:

```razor
<PropertyColumn Property="movie => movie.Rating" />
```

Update the `SeedData` class (`Data/SeedData.cs`) to provide a default value for the new `Rating` property for reseeding operations.

The following change is for the *Mad Max* `new Movie` block. `Rating = "R",` is added to the block:

```diff
new Movie
{
    Title = "Mad Max",
    ReleaseDate = DateTime.Parse("1979-4-12"),
    Genre = "Sci-fi (Cyberpunk)",
    Price = 2.51M,
+   Rating = "R",
},
```

Add the `Rating` property to each of the other `new Movie` blocks in the same fashion. Here are the ratings of the remaining *Mad Max* movies when you add the new `Rating` lines:

* *The Road Warrior*: R
* *Mad Max: Beyond Thunderdome*: PG-13
* *Mad Max: Fury Road*: R
* *Furiosa: A Mad Max Saga*: R

**Save all of the updated files.**

:::zone pivot="vs"

Build the app to confirm that there are no errors. In Visual Studio, select **Build** > **Rebuild Solution** from the toolbar. 

:::zone-end

:::zone pivot="vsc"

Build the app to confirm that there are no errors. In the **Terminal** (**Terminal** menu > **New Terminal**), execute the following command:

```powershell
dotnet build
```

:::zone-end

:::zone pivot="cli"

Build the app to confirm that there are no errors. In a command shell opened to the project's root folder, execute the following command:

```dotnetcli
dotnet build
```

:::zone-end

Fix any errors in the app that were introduced by pasting the preceding markup and code before proceeding to the next step.

## Update the database

If you try to run the app at this point, the app fails with a SQL exception because the database doesn't include a `Rating` column in the `Movie` table.

There are three approaches that you can take to resolve the discrepancy between the database's schema and the model's schema:

* Modify the schema of the database so that it matches the model class. The advantage of this approach is that it maintains the database's data. Adopt this approach using either database tooling or by creating a database change script, which are approaches not covered by this tutorial but can be learned using other articles. The downside to this approach is that it requires more time and is more prone to error due to its increased complexity. *This tutorial doesn't adopt this approach.*
* Use EF Core to automatically drop and recreate the database using the new model class schema, losing the data stored in the database in the process. The database is reseeded with fresh data when the app is run. This approach allows you to quickly evolve the model and database schema together. Don't use this approach on a production database with data that must be preserved. *This tutorial only uses this approach for Visual Studio Code and .NET CLI tooling and only when the provider doesn't support EF Core migrations.*
* Use an EF Core migration to update the database schema after the model is changed in the app. This approach is efficient and preserves the database's data. ***This tutorial adopts this approach.***

Create a migration to update the database's schema. The movie rating, as a `Rating` column, is added to the database's `Movie` table.

:::zone pivot="vs"

From the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console** (PMC).

In the PMC, execute the following command to add a migration. The migration name (`AddRatingField`) is an arbitrary description for the migration:

```powershell
Add-Migration AddRatingField
```

The `Add-Migration` command:

* Compares the `Movie` model with the `Movie` database table schema.
* Creates code to migrate the database schema to match the model.

Creating the migration doesn't automatically provision a default value for the rating when the database is updated. However, you can manually make a small change to the migration file to apply a default movie rating value, which can be helpful when there are many records that require a default value. In this case, all but one of the *Mad Max* movies is rated *R*, so a default value of "`R`" for the `Rating` column is appropriate.

Examine the files in the `Migrations` folder of the project in Visual Studio's **Solution Explorer**. Open the migration file that adds the movie rating field, which has a file name of `{NUMBER}_AddRatingField.cs`, where the `{NUMBER}` placeholder is a number (for example, `20240530123755_AddRatingField.cs`).

Find the `AddColumn` block that adds the rating column to the `Movie` table in the database. Modify the last line that applies a default value (`defaultValue`). Change it from an empty string (`""`) to an *R* movie rating (`"R"`):

```diff
migrationBuilder.AddColumn<string>(
    name: "Rating",
    table: "Movie",
    type: "nvarchar(max)",
    nullable: false,
-    defaultValue: "");
+    defaultValue: "R");
```

Save the migration file.

In the PMC, execute the following command to update the database, which preserves the existing data while it adds the movie rating column with a default value:

```powershell
Update-Database
```

Modify the one movie that isn't rated *R*:

1. Run the app.
1. Edit the *Mad Max: Beyond Thunderdome* movie.
1. Update the movie rating from `R` to `PG-13`. Save the change.

> [!NOTE]
> An alternative to modifying the migration file is to delete the records in the database and rerun the app to reseed the database. The seeding code was modified earlier to supply default values. This approach is useful in cases where the assignment of default values to fields is better controlled or faster with C# code during seeding.
>
> To delete all of the records in the database, use one of the following approaches:
>
> * Run the app and use the delete links in the browser. This approach is reasonably fast when there are only a few records to delete.
> * In Visual Studio from **SQL Server Object Explorer** (SSOX), delete the database records. With the database table visible, right-click the table and select **View Data**. When the table opens to show the movie records, select the first record. Hold the <kbd>Shift</kbd> key and select the last record to select all of the records in the database. With all of the records selected, press the <kbd>Delete</kbd> key to delete the records. This approach is reasonably fast when there are many records to delete.
> * In Visual Studio from SSOX, right-click the database and select **New Query**. A blank SQL file (`.sql`) opens. Paste the following command into the file: `DELETE FROM dbo.Movie;`. Select the green **Execute** triangle to execute the query or press <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>E</kbd> on the keyboard. In the **Message** tab, SSOX reports the number of rows affected, deleted in this case, by the query. You can save the query for later use if you wish. Otherwise, close the file without saving it. This approach is especially useful when the table is large and contains hundreds to thousands of records. **CAUTION**: *Deleting records is permanent in most cases, so maintain multiple backup copies of production databases, including off-site copies, and use extreme caution when deleting records.*
>
> After deleting all of the records, run the app. The initializer reseeds the database and includes the correct movie ratings for the `Rating` field based on the seeding code.

:::zone-end

:::zone pivot="vsc"

In the **Terminal** (**Terminal** menu > **New Terminal**), execute the following command to add a migration. The migration name (`AddRatingField`) is an arbitrary description for the migration:

```powershell
dotnet ef migrations AddRatingField
```

The `dotnet-ef migrations` command:

* Compares the `Movie` model with the `Movie` database table schema.
* Creates code to migrate the database schema to match the model.

Creating the migration doesn't automatically provision a default value for the rating when the database is updated. However, you can manually make a small change to the migration file to apply a default movie rating value, which can be helpful when there are many records that require a default value. In this case, all but one of the *Mad Max* movies is rated *R*, so a default value of "`R`" for the `Rating` column is appropriate.

Examine the files in the `Migrations` folder of the project. Open the migration file that adds the movie rating field, which has a file name of `{NUMBER}_AddRatingField.cs`, where the `{NUMBER}` placeholder is a number (for example, `20240530123755_AddRatingField.cs`).

Find the `AddColumn` block that adds the rating column to the `Movie` table in the database. Modify the last line that applies a default value (`defaultValue`). Change it from an empty string (`""`) to an *R* movie rating (`"R"`):

```diff
migrationBuilder.AddColumn<string>(
    name: "Rating",
    table: "Movie",
    type: "nvarchar(max)",
    nullable: false,
-    defaultValue: "");
+    defaultValue: "R");
```

Save the migration file.

In the **Terminal**, execute the following command to update the database, which preserves the existing data while it adds the movie rating column with a default value:

```powershell
dotnet ef database update
```

Modify the one movie that isn't rated *R*:

1. Run the app.
1. Edit the *Mad Max: Beyond Thunderdome* movie.
1. Update the movie rating from `R` to `PG-13`. Save the change.

> [!NOTE]
> An alternative to modifying the migration file is to delete the records in the database and rerun the app to reseed the database. The seeding code was modified earlier to supply default values. This approach is useful in cases where the assignment of default values to fields is better controlled or faster with C# code during seeding.
>
> To delete all of the records in the database, use one of the following approaches:
>
> * Run the app and use the delete links in the browser. This approach is reasonably fast when there are only a few records to delete.
> * Using database tooling&dagger;, delete the database records. In most database tools that permit direct manipulation of data, open the database table's data view in the tooling. When the table opens to show the movie records, select the first record. Hold the <kbd>Shift</kbd> key and select the last record to select all of the records in the database. With all of the records selected, press the <kbd>Delete</kbd> key to delete the records. You may need to adjust these instructions depending on the database tooling in use. Consult the tool's documentation for more information. This approach is reasonably fast when there are many records to delete.
> * Using database tooling&dagger;, execute a SQL query against the movie table to delete the table's records. The SQL command is `DELETE FROM {MOVIE TABLE NAME};`, where the `{MOVIE TABLE NAME}` placeholder is the name of the movie table. You can save the query for later use if you wish. Otherwise, close the file without saving it. Consult the tool's documentation for the exact steps. This approach is especially useful when the table is large and contains hundreds to thousands of records. **CAUTION**: *Deleting records is permanent in most cases, so maintain multiple backup copies of production databases, including off-site copies, and use extreme caution when deleting records.*
>
> &dagger;*database tooling*: There are many free and retail database tools available on the open market that can work with SQL databases. Consult Internet resources to find one suitable for your database and platform.
>
> After deleting all of the records, run the app. The initializer reseeds the database and includes the correct movie ratings for the `Rating` field based on the seeding code.

## Drop and recreate the database for non-SQL Server providers

**Skip this section if you successfully migrated the database using the preceding guidance.**

In this tutorial, EF Core migrations are used when possible. A migration updates the database schema to match changes in the data model. However, migrations can only make changes to the database that the EF Core provider supports. While the SQL Server provider has wide support for migration tasks, other provider's capabilities are limited. For example, support may exist for adding a column (the `ef migrations add` command succeeds), but support may not exist for removing or changing a column (the `ef database update` command fails). Due to these limitations, you can drop and recreate the database using the guidance in this section.

The workaround for the limitations is to manually write migrations code to perform a table rebuild when something in the table changes. A table rebuild involves:

* Creating a new table with a temporary table name.
* Copying data from the old table to the new table.
* Dropping the old table.
* Renaming the new table to match the old table's name.

For more information, see the following resources:

* [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
* [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
* [Data seeding](/ef/core/modeling/data-seeding)
* [SQLite ALTER TABLE statement](https://sqlite.org/lang_altertable.html)

1. Delete the migration folder. This effectively removes all of the existing migrations, which shouldn't be executed again.

1. Use the following command to drop the database:

   ```powershell
   dotnet ef database drop
   ```

1. Use the following command to create an initial migration:

   ```powershell
   dotnet ef migrations add InitialCreate
   ```

1. Use the following command to update the database:

   ```powershell
   dotnet ef database update
   ```

:::zone-end

:::zone pivot="cli"

In a command shell opened to the project's root folder, execute the following command to add a migration. The migration name (`AddRatingField`) is an arbitrary description for the migration:

```dotnetcli
dotnet ef migrations AddRatingField
```

The `dotnet-ef migrations` command:

* Compares the `Movie` model with the `Movie` database table schema.
* Creates code to migrate the database schema to match the model.

Creating the migration doesn't automatically provision a default value for the rating when the database is updated. However, you can manually make a small change to the migration file to apply a default movie rating value, which can be helpful when there are many records that require a default value. In this case, all but one of the *Mad Max* movies is rated *R*, so a default value of "`R`" for the `Rating` column is appropriate.

Examine the files in the `Migrations` folder of the project. Open the migration file that adds the movie rating field, which has a file name of `{NUMBER}_AddRatingField.cs`, where the `{NUMBER}` placeholder is a number (for example, `20240530123755_AddRatingField.cs`).

Find the `AddColumn` block that adds the rating column to the `Movie` table in the database. Modify the last line that applies a default value (`defaultValue`). Change it from an empty string (`""`) to an *R* movie rating (`"R"`):

```diff
migrationBuilder.AddColumn<string>(
    name: "Rating",
    table: "Movie",
    type: "nvarchar(max)",
    nullable: false,
-    defaultValue: "");
+    defaultValue: "R");
```

Save the migration file.

Execute the following command to update the database, which preserves the existing data while it adds the movie rating column with a default value:

```dotnetcli
dotnet ef database update
```

Modify the one movie that isn't rated *R*:

1. Run the app.
1. Edit the *Mad Max: Beyond Thunderdome* movie.
1. Update the movie rating from `R` to `PG-13`. Save the change.

> [!NOTE]
> An alternative to modifying the migration file is to delete the records in the database and rerun the app to reseed the database. The seeding code was modified earlier to supply default values. This approach is useful in cases where the assignment of default values to fields is better controlled or faster with C# code during seeding.
>
> To delete all of the records in the database, use one of the following approaches:
>
> * Run the app and use the delete links in the browser. This approach is reasonably fast when there are only a few records to delete.
> * Using database tooling&dagger;, delete the database records. In most database tools that permit direct manipulation of data, open the database table's data view in the tooling. When the table opens to show the movie records, select the first record. Hold the <kbd>Shift</kbd> key and select the last record to select all of the records in the database. With all of the records selected, press the <kbd>Delete</kbd> key to delete the records. You may need to adjust these instructions depending on the database tooling in use. Consult the tool's documentation for more information. This approach is reasonably fast when there are many records to delete.
> * Using database tooling&dagger;, execute a SQL query against the movie table to delete the table's records. The SQL command is `DELETE FROM {MOVIE TABLE NAME};`, where the `{MOVIE TABLE NAME}` placeholder is the name of the movie table. You can save the query for later use if you wish. Otherwise, close the file without saving it. Consult the tool's documentation for the exact steps. This approach is especially useful when the table is large and contains hundreds to thousands of records. **CAUTION**: *Deleting records is permanent in most cases, so maintain multiple backup copies of production databases, including off-site copies, and use extreme caution when deleting records.*
>
> &dagger;*database tooling*: There are many free and retail database tools available on the open market that can work with SQL databases. Consult Internet resources to find one suitable for your database and platform.
>
> After deleting all of the records, run the app. The initializer reseeds the database and includes the correct movie ratings for the `Rating` field based on the seeding code.

## Drop and recreate the database for non-SQL Server providers

**Skip this section if you successfully migrated the database using the preceding guidance.**

In this tutorial, EF Core migrations are used when possible. A migration updates the database schema to match changes in the data model. However, migrations can only make changes to the database that the EF Core provider supports. While the SQL Server provider has wide support for migration tasks, other provider's capabilities are limited. For example, support may exist for adding a column (the `ef migrations add` command succeeds), but support may not exist for removing or changing a column (the `ef database update` command fails). Due to these limitations, you can drop and recreate the database using the guidance in this section.

The workaround for the limitations is to manually write migrations code to perform a table rebuild when something in the table changes. A table rebuild involves:

* Creating a new table with a temporary table name.
* Copying data from the old table to the new table.
* Dropping the old table.
* Renaming the new table to match the old table's name.

For more information, see the following resources:

* EF Core documentation
  * [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
  * [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
  * [Data seeding](/ef/core/modeling/data-seeding)
* [SQLite ALTER TABLE statement (SQLite documentation)](https://sqlite.org/lang_altertable.html)

1. Delete the migration folder. This effectively removes all of the existing migrations, which shouldn't be executed again.

1. Use the following command to drop the database:

   ```dotnetcli
   dotnet ef database drop
   ```

1. Use the following command to create an initial migration:

   ```dotnetcli
   dotnet ef migrations add InitialCreate
   ```

1. Use the following command to update the database:

   ```dotnetcli
   dotnet ef database update
   ```

:::zone-end

Run the app and verify you can create, edit, and display movies with the new movie rating field.

## Troubleshoot

In the event that the database becomes corrupted, delete the database and use migrations to recreate the database:

:::zone pivot="vs"

1. Select the database in **SQL Server Object Explorer** (SSOX).
1. Right-click on the database, and select **Delete**. *Make sure that you select the correct database in the list.*
1. Check **Close existing connections**.
1. Select **OK**.
1. In the **Package Manager Console** (PMC), execute the following command to run the existing migrations that recreate the database:

   ```powershell
   Update-Database
   ```

:::zone-end

:::zone pivot="vsc"

1. Delete the database. If your database tooling has a connection to the database, close the tooling first or use the tool's features to close the database connection and delete the database. Consult your tool's documentation for guidance. *Make sure that you select the correct database in the list.*
1. In the **Terminal** (**Terminal** menu > **New Terminal**), execute the following command to run the existing migrations that recreate the database:

   ```powershell
   dotnet ef database update
   ```

:::zone-end

:::zone pivot="cli"

1. Delete the database. If your database tooling has a connection to the database, close the tooling first or use the tool's features to close the database connection and delete the database. Consult your tool's documentation for guidance. *Make sure that you select the correct database in the list.*
1. In a command shell opened to the project's root folder, execute the following command to run the existing migrations that recreate the database:

   ```dotnetcli
   dotnet ef database update
   ```

:::zone-end

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* [Migrations (EF Core documentation)](/ef/core/managing-schemas/migrations/)
* [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)

## Legal

[*Max Max*, *The Road Warrior*, *Mad Max: Beyond Thunderdome*, *Mad Max: Fury Road*, and *Furiosa: A Mad Max Saga*](https://warnerbros.fandom.com/wiki/Mad_Max_(franchise)) are trademarks and copyrights of [Warner Bros. Entertainment](https://www.warnerbros.com/).

## Next steps

> [!div class="step-by-step"]
> [Previous: Add Search](xref:blazor/tutorials/movie-database-app/part-6)
> [Next: Add interactivity](xref:blazor/tutorials/movie-database-app/part-8)
