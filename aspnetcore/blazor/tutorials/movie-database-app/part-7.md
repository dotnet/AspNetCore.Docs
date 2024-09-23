---
title: Build a Blazor movie database app (Part 7 - Add a new field)
author: guardrex
description: This part of the Blazor movie database app tutorial explains how to add a new field to the movie class, CRUD pages, and database.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/26/2024
uid: blazor/tutorials/movie-database-app/part-7
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 7 - Add a new field)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the seventh part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the tutorial series covers adding a new field to the movie class, CRUD pages, and database.

The database update is handled by EF Core migrations. EF Core transparently tracks changes to the database in a migration history table and automatically throws an exception if the app's model classes aren't synchronized with the database's tables and columns. EF Core migrations make it possible to quickly troubleshoot database consistency problems.

> [!IMPORTANT]
> Confirm that the app isn't running for the next steps.

## Add a movie rating to the app's model

Open the `Models/Movie.cs` file and add a `Rating` property with a regular expression that limits the value of `Rating` to the exact [Motion Picture Association](https://www.motionpictures.org/) film rating designations:

```csharp
[Required]
[RegularExpression(@"^(G|PG|PG-13|R|NC-17)$")]
public string? Rating { get; set; }
```

## Add the movie rating to the app's CRUD components

Open the `Create` component definition file (`Components/Pages/MoviePages/Create.razor`).

Add the following `<div>` block between the `<div>` block for `Price` and the create button (`<button>`):

```razor
<div class="mb-3">
    <label for="rating" class="form-label">Rating:</label> 
    <InputText id="rating" @bind-Value="Movie.Rating" class="form-control" /> 
    <ValidationMessage For="() => Movie.Rating" class="text-danger" /> 
</div>
```

Open the `Delete` component definition file (`Components/Pages/MoviePages/Delete.razor`).

Add the following description list (`<dl>`) block between the description list block for `Price` and the `EditForm` component:

```razor
<dl class="row">
    <dt class="col-sm-2">Rating</dt>
    <dd class="col-sm-10">@movie.Rating</dd>
</dl>
```

Open the `Details` component definition file (`Components/Pages/MoviePages/Details.razor`).

Add the following description list term (`<dt>`) and description list element (`<dl>`) after the term and element for `Price` just inside the closing `</dl>` tag:

```razor
<dt class="col-sm-2">Rating</dt>
<dd class="col-sm-10">@movie.Rating</dd>
```

Open the `Edit` component definition file (`Components/Pages/MoviePages/Edit.razor`).

Add the following `<div>` block between the `<div>` block for `Price` and the save button (`<button>`):

```razor
<div class="mb-3">
    <label for="rating" class="form-label">Rating:</label>
    <InputText id="rating" @bind-Value="Movie.Rating" class="form-control" />
    <ValidationMessage For="() => Movie.Rating" class="text-danger" />
</div>
```

Open the `Index` component definition file (`Components/Pages/MoviePages/Index.razor`).

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
    ReleaseDate = DateOnly.Parse("1979-4-12"),
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

Don't run the app yet. Build the app to confirm that there are no errors.

:::zone pivot="vs"

Select **Build** > **Rebuild Solution** from the menu bar. 

:::zone-end

:::zone pivot="vsc"

In the **Command Palette**, use the `.NET: Build` command.

:::zone-end

:::zone pivot="cli"

In a command shell opened to the project's root folder, execute the following command:

```dotnetcli
dotnet build
```

:::zone-end

Fix any errors in the app that were introduced by pasting the preceding markup and code before proceeding to the next step.

## Update the database

If you were to try and run the app at this point, the app would fail with a SQL exception because the database doesn't include a `Rating` column in its `Movie` table. There are three approaches that you can take to resolve the discrepancy between the database's schema and the model's schema:

* Modify the schema of the database so that it matches the model class. The advantage of this approach is that it maintains the database's data. Adopt this approach using either database tooling or by creating a database change script, which are approaches not covered by this tutorial but can be learned using other articles. The downside to this approach is that it requires more time and is more prone to errors due to its increased complexity. *This tutorial doesn't adopt this approach.*
* Use EF Core to automatically drop and recreate the database using the new model class schema, losing the data stored in the database in the process. The database is reseeded with fresh data when the app is run. This approach allows you to quickly evolve the model and database schema together. Don't use this approach on a production database with data that must be preserved. *This tutorial doesn't adopt this approach.*
* Use an EF Core migration to update the database schema after the model is changed in the app. This approach is efficient and preserves the database's data. ***This tutorial adopts this approach.***

Create a migration to update the database's schema. The movie rating, as a `Rating` column, is added to the database's `Movie` table.

:::zone pivot="vs"

In Visual Studio **Solution Explorer**, double-click **Connected Services**. In the **SQL Server Express LocalDB** area of **Service Dependencies**, select the ellipsis (`...`) followed by **Add migration**.

Give the migration a **Migration name** of `AddRatingField` to describe the migration. Wait for the database context to load in the **DbContext class names** field. Select **Finish** to create the migration. Select **Close** when the operation is complete.

The migration:

* Compares the `Movie` model with the `Movie` database table schema.
* Creates code to migrate the database schema to match the model.

Creating the migration doesn't automatically provision a default value for the rating when the database is updated. However, you can manually make a change to the migration file to apply a default movie rating value, which can be helpful when there are many records that require a default value. In this case, all but one of the *Mad Max* movies is rated *R*, so a default value of "`R`" for the `Rating` column is an appropriate choice. The one movie that doesn't have an *R* rating can be updated later in the running app.

Examine the files in the `Migrations` folder of the project in Visual Studio's **Solution Explorer**. Open the migration file that adds the movie rating field, which has a file name of `{TIME STAMP}_AddRatingField.cs`, where the `{TIME STAMP}` placeholder is a time stamp (for example, `20240530123755_AddRatingField.cs`).

Find the `AddColumn` block that adds the rating column to the `Movie` table in the database. Modify the last line that applies a default value (`defaultValue`). Change it from an empty string (`""`) to an *R* movie rating (`"R"`):

```diff
migrationBuilder.AddColumn<string>(
    name: "Rating",
    table: "Movie",
    type: "nvarchar(max)",
    nullable: false,
-   defaultValue: "");
+   defaultValue: "R");
```

Save the migration file.

In the **SQL Server Express LocalDB** area of **Service Dependencies**, select the ellipsis (`...`) again followed by the **Update database** command.

The **Update database with the latest migration** dialog opens. Wait for the **DbContext class names** field to update and for prior migrations to load. Select the **Finish** button. Select the **Close** button when the operation completes.

Modify the one movie that isn't rated *R*:

1. Run the app.
1. Edit the *Mad Max: Beyond Thunderdome* movie.
1. Update the movie rating from `R` to `PG-13`. Save the change.

> [!NOTE]
> An alternative to modifying the migration file is to delete the records in the database and rerun the app to reseed the database. The seeding code was modified earlier to supply default values. This approach is useful in cases where the assignment of default values to fields is better controlled or faster for you to implement with C# code during seeding. For more information see the [Delete all database records and reseed the database](#delete-all-database-records-and-reseed-the-database) section at the end of this article.

:::zone-end

:::zone pivot="vsc"

In the **Terminal** (**Terminal** menu > **New Terminal**), execute the following command to add a migration. The migration name (`AddRatingField`) is an arbitrary description for the migration:

```dotnetcli
dotnet ef migrations add AddRatingField
```

The `dotnet-ef migrations` command:

* Compares the `Movie` model with the `Movie` database table schema.
* Creates code to migrate the database schema to match the model.

Creating the migration doesn't automatically provision a default value for the rating when the database is updated. However, you can manually make a small change to the migration file to apply a default movie rating value, which can be helpful when there are many records that require a default value. In this case, all but one of the *Mad Max* movies is rated *R*, so a default value of "`R`" for the `Rating` column is appropriate. The one movie that doesn't have an *R* rating can be updated later in the running app.

Examine the files in the `Migrations` folder of the project. Open the migration file that adds the movie rating field, which has a file name of `{TIME STAMP}_AddRatingField.cs`, where the `{TIME STAMP}` placeholder is a time stamp (for example, `20240530123755_AddRatingField.cs`).

Find the `AddColumn` block that adds the rating column to the `Movie` table in the database. Modify the last line that applies a default value (`defaultValue`). Change it from an empty string (`""`) to an *R* movie rating (`"R"`):

```diff
migrationBuilder.AddColumn<string>(
    name: "Rating",
    table: "Movie",
    type: "nvarchar(max)",
    nullable: false,
-   defaultValue: "");
+   defaultValue: "R");
```

Save the migration file.

In the **Terminal**, execute the following command to update the database, which preserves the existing data while it adds the movie rating column with a default value:

```dotnetcli
dotnet ef database update
```

Modify the one movie that isn't rated *R*:

1. Run the app.
1. Edit the *Mad Max: Beyond Thunderdome* movie.
1. Update the movie rating from `R` to `PG-13`. Save the change.

> [!NOTE]
> An alternative to modifying the migration file is to delete the records in the database and rerun the app to reseed the database. The seeding code was modified earlier to supply default values. This approach is useful in cases where the assignment of default values to fields is better controlled or faster with C# code during seeding. For more information see the [Delete all database records and reseed the database](#delete-all-database-records-and-reseed-the-database) section at the end of this article.

:::zone-end

:::zone pivot="cli"

In a command shell opened to the project's root folder, execute the following command to add a migration. The migration name (`AddRatingField`) is an arbitrary description for the migration:

```dotnetcli
dotnet ef migrations add AddRatingField
```

The `dotnet-ef migrations` command:

* Compares the `Movie` model with the `Movie` database table schema.
* Creates code to migrate the database schema to match the model.

Creating the migration doesn't automatically provision a default value for the rating when the database is updated. However, you can manually make a small change to the migration file to apply a default movie rating value, which can be helpful when there are many records that require a default value. In this case, all but one of the *Mad Max* movies is rated *R*, so a default value of "`R`" for the `Rating` column is appropriate. The one movie that doesn't have an *R* rating can be updated later in the running app.

Examine the files in the `Migrations` folder of the project. Open the migration file that adds the movie rating field, which has a file name of `{TIME STAMP}_AddRatingField.cs`, where the `{TIME STAMP}` placeholder is a time stamp (for example, `20240530123755_AddRatingField.cs`).

Find the `AddColumn` block that adds the rating column to the `Movie` table in the database. Modify the last line that applies a default value (`defaultValue`). Change it from an empty string (`""`) to an *R* movie rating (`"R"`):

```diff
migrationBuilder.AddColumn<string>(
    name: "Rating",
    table: "Movie",
    type: "nvarchar(max)",
    nullable: false,
-   defaultValue: "");
+   defaultValue: "R");
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
> An alternative to modifying the migration file is to delete the records in the database and rerun the app to reseed the database. The seeding code was modified earlier to supply default values. This approach is useful in cases where the assignment of default values to fields is better controlled or faster with C# code during seeding. For more information see the [Delete all database records and reseed the database](#delete-all-database-records-and-reseed-the-database) section at the end of this article.

:::zone-end

Run the app and verify you can create, edit, and display movies with the new movie rating field.

## Troubleshoot

In the event that the database becomes corrupted, delete the database and use migrations to recreate the database:

:::zone pivot="vs"

1. Select the database in **SQL Server Object Explorer** (SSOX).
1. Right-click on the database, and select **Delete**. *Make sure that you select the correct database in the list.*
1. Check **Close existing connections**.
1. Select **OK**.
1. In **Solution Explorer**, double-click **Connected Services**. In the **Service Dependencies** area, select the ellipsis (`...`) followed by **Update database** in the **SQL Server Express LocalDB** area. Updating the database executes the existing migrations that recreate the database.

:::zone-end

:::zone pivot="vsc"

1. Delete the database. If your database tooling has a connection to the database, close the tooling first or use the tool's features to close the database connection and delete the database. Consult your tool's documentation for guidance. *Make sure that you select the correct database in the list.*
1. In the **Terminal** (**Terminal** menu > **New Terminal**), execute the following command to run the existing migrations that recreate the database:

   ```dotnetcli
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

## Delete all database records and reseed the database

*This section describes an alternative process for updating the database with a default value for a new model property without modifying the migration file. Following the guidance in this section isn't necessary if you followed all of the steps in the [Update the database](#update-the-database) section earlier in this article.*

To delete all of the records in the database, use one of the following approaches:

:::zone pivot="vs"

* Run the app and use the delete links in the browser. This approach is reasonably fast when there are only a few records to delete.
* In Visual Studio from **SQL Server Object Explorer** (SSOX), delete the database records. With the database table visible, right-click the table and select **View Data**. When the table opens to show the movie records, select the first record. Hold the <kbd>Shift</kbd> key and select the last record to select all of the records in the table. With all of the records selected, press the <kbd>Delete</kbd> key to delete the records. This approach is reasonably fast when there are many records to delete.
* In Visual Studio from SSOX, right-click the database and select **New Query**. A blank SQL file (`.sql`) opens. Paste the following command into the file: `DELETE FROM dbo.Movie;`. Select the green **Execute** triangle to execute the query or press <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>E</kbd> on the keyboard. In the **Message** tab, SSOX reports the number of rows affected, deleted in this case, by the query. You can save the query for later use if you wish. Otherwise, close the file without saving it. This approach is especially useful when the table is large and contains hundreds to thousands of records.

:::zone-end

:::zone pivot="vsc"

* Run the app and use the delete links in the browser. This approach is reasonably fast when there are only a few records to delete.
* Using database tooling&dagger;, delete the database records. In most database tools that permit direct manipulation of data, open the database table's data view in the tooling. When the table opens to show the movie records, select the first record. Hold the <kbd>Shift</kbd> key and select the last record to select all of the records in the database. With all of the records selected, press the <kbd>Delete</kbd> key to delete the records. You may need to adjust these instructions depending on the database tooling in use. Consult the tool's documentation for more information. This approach is reasonably fast when there are many records to delete.
* Using database tooling&dagger;, execute a SQL query against the movie table to delete the table's records. The SQL command is `DELETE FROM dbo.Movie;`. You can save the query for later use if you wish. Otherwise, close the file without saving it. Consult the tool's documentation for the exact steps. This approach is especially useful when the table is large and contains hundreds to thousands of records.

&dagger;*database tooling*: There are many free and retail database tools available on the open market that can work with SQL databases. Consult Internet resources to find one suitable for your database and platform.

:::zone-end

:::zone pivot="cli"

* Run the app and use the delete links in the browser. This approach is reasonably fast when there are only a few records to delete.
* Using database tooling&dagger;, delete the database records. In most database tools that permit direct manipulation of data, open the database table's data view in the tooling. When the table opens to show the movie records, select the first record. Hold the <kbd>Shift</kbd> key and select the last record to select all of the records in the database. With all of the records selected, press the <kbd>Delete</kbd> key to delete the records. You may need to adjust these instructions depending on the database tooling in use. Consult the tool's documentation for more information. This approach is reasonably fast when there are many records to delete.
* Using database tooling&dagger;, execute a SQL query against the movie table to delete the table's records. The SQL command is `DELETE FROM dbo.Movie;`. You can save the query for later use if you wish. Otherwise, close the file without saving it. Consult the tool's documentation for the exact steps. This approach is especially useful when the table is large and contains hundreds to thousands of records.

&dagger;*database tooling*: There are many free and retail database tools available on the open market that can work with SQL databases. Consult Internet resources to find one suitable for your database and platform.

:::zone-end

> [!CAUTION]
> Use extreme caution when deleting records from a database. Deleting records is permanent without taking additional data loss mitigation steps. Production databases often provision automatic backup copies of data, either instantaneously as the database is modified or periodically, including with off-site copies and permanent physical storage of data.

After deleting all of the records, run the app. The initializer reseeds the database and includes the correct movie ratings for the `Rating` field based on the seeding code.

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* [Migrations (EF Core documentation)](/ef/core/managing-schemas/migrations/)
* [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)

## Legal

[*Mad Max*, *The Road Warrior*, *Mad Max: Beyond Thunderdome*, *Mad Max: Fury Road*, and *Furiosa: A Mad Max Saga*](https://warnerbros.fandom.com/wiki/Mad_Max_(franchise)) are trademarks and copyrights of [Warner Bros. Entertainment](https://www.warnerbros.com/).

## Next steps

> [!div class="step-by-step"]
> [Previous: Add Search](xref:blazor/tutorials/movie-database-app/part-6)
> [Next: Add interactivity](xref:blazor/tutorials/movie-database-app/part-8)
