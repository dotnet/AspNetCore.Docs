---
title: Build a Blazor movie database app (Part 7 - Add a new field)
author: guardrex
description: This part of the Blazor movie database app tutorial explains ...
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/29/2024
uid: blazor/tutorials/movie-database/new-field
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

Open the `Index` component (`Components/Pages/MoviePages/Index.razor`).

Update the `QuickGrid` to include the movie rating. Add the following `PropertyColumn` immediately after the `PropertyColumn` for `Price`:

```razor
<PropertyColumn Property="movie => movie.Rating" />
```

Open the `Create` component (`Components/Pages/MoviePages/Create.razor`).

Add the following `<div>` block after the markup for `Price`:

```razor
<div class="mb-3">
    <label for="rating" class="form-label">Rating:</label> 
    <InputText id="rating" @bind-Value="Movie.Rating" class="form-control" /> 
    <ValidationMessage For="() => Movie.Rating" class="text-danger" /> 
</div>
```

Open the `Delete` component (`Components/Pages/MoviePages/Delete.razor`).

Add the following description list (`<dl>`) block after the description list block for `Price`:

```razor
<dl class="row">
    <dt class="col-sm-2">Rating</dt>
    <dd class="col-sm-10">@movie.Rating</dd>
</dl>
```

Open the `Details` component (`Components/Pages/MoviePages/Details.razor`).

Add the following description list term (`<dt>`) and description list element (`<dl>`) after the term and element for `Price`:

```razor
<dt class="col-sm-2">Rating</dt>
<dd class="col-sm-10">@movie.Rating</dd>
```

Open the `Edit` component (`Components/Pages/MoviePages/Edit.razor`).

Add the following `<div>` block after the markup for `Price`:

```razor
<div class="mb-3">
    <label for="rating" class="form-label">Rating:</label>
    <InputText id="rating" @bind-Value="Movie.Rating" class="form-control" />
    <ValidationMessage For="() => Movie.Rating" class="text-danger" />
</div>
```

## Update the database

If you try to run the app at this point, the app fails with a SQL exception because the database doesn't include a `Rating` column in the `Movie` table. The database schema doesn't match the model's schema.

There are three approaches to resolve the discrepancy between schemas:

* Use EF Core to automatically drop and recreate the database using the new model class schema, shedding any data stored in the database. The database is reseeded with fresh data when the app is run. This approach allows you to quickly evolve the model and database schema together. Don't use this approach on a production database with data that must be preserved! *This tutorial only uses this approach for Visual Studio Code and .NET CLI tooling and only when the provider doesn't support EF Core migrations.*
* Explicitly modify the schema of the existing database so that it matches the model classes. The advantage of this approach is that it maintains the database's data. Adopt this approach either manually using database tooling or by creating a database change script. The downside to this approach is that it requires more time and is more prone to error. *This tutorial doesn't adopt this approach.*
* Use an EF Core migration to update the database schema after the model is changed in the app. This approach is efficient and preserves the database's data. ***This tutorial adopts this approach.***

Update the `SeedData` class (`Data/SeedData.cs`) so that it provides a value for the new `Rating` property in the event that you ever reseed the database.

The following change is for the *Mad Max* `new Movie` block:

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

Add the `Rating` property to each of the other `new Movie` blocks in the same fashion. Here are the ratings of the remaining *Mad Max* series movies:

* *The Road Warrior*: R
* *Mad Max: Beyond Thunderdome*: PG-13
* *Mad Max: Fury Road*: R
* *Furiosa: A Mad Max Saga*: R

:::zone pivot="vs"

From the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console** (PMC).

In the PMC, enter the following command to add a migration for the movie rating field:

```powershell
Add-Migration AddRatingField
```

The migration name `AddRatingField` is an arbitrary description of the migration.

The `Add-Migration` command:

* Compares the `Movie` model with the `Movie` database schema.
* Creates code to migrate the database schema to the new model.

Creating the migration doesn't automatically provision a default value for the rating when the database is updated. However, you can manually make a small change to the migration file to apply a default movie rating value, which can be helpful when there are many records that require such a value. In this case, all but one of the *Mad Max* movies is rated *R*, so a default value of `R` for the `Rating` column is appropriate.

Open the XXXX file and find the line that adds the column to the `Movie` table in the database. Modify the line to add a default value:

```diff
- AddColumn("dbo.movie", "newProperty", c => c.String(nullable: true));
+ AddColumn("dbo.movie", "newProperty", c => c.String(nullable: true, defaultValue: "R"));
```

Save the migration file.

In the PMC, enter the following command to update the database, which preserves the existing data while it adds the movie rating column:

```powershell
Update-Database
```

At this point, modify the one movie that isn't rated *R*:

1. Run the app.
1. Edit the **Mad Max: Beyond Thunderdome* movie.
1. Update the movie rating from `R` to `PG-13`. Save the change.

> [!NOTE]
> An alternative to modifying the migration file is to delete the records in the database and rerun the app to reseed the database. The seeding code was modified earlier to supply default values. This approach is useful in cases where the assignment of values to fields is better controlled with C# code when seeding occurs.
>
> To delete all of the records in the database, use one of the following approaches:
>
> * Run the app and use the delete links in the browser. This approach is reasonably fast when there are only a few records to delete.
> * In Visual Studio from **SQL Server Object Explorer** (SSOX), delete the database records. With the database table visible, right-click the table and select **View Data**. When the table opens to show the movie records, select the first record. Hold the <kbd>Shift</kbd> key and select the last record to select all of the records in the database. With all of the records selected, press the <kbd>Delete</kbd> key to delete the records. This approach is fast when there are many records to delete.
>
> After deleting all of the records, run the app. The initializer reseeds the database and includes the correct movie ratings for the `Rating` field based on the seeding code.

:::zone-end

:::zone pivot="vsc"

In the **Terminal** (opened with **New Terminal** from the **Terminal** menu if not onscreen), use the following commands to add a migration for the rating field:

```dotnetcli
dotnet ef migrations add rating
dotnet ef database update
```

The `dotnet-ef migrations add rating` command tells the framework to:

* Compare the `Movie` model with the `Movie` database schema.
* Create code to migrate the database schema to the new model.

The name `rating` is arbitrary and is used to name the migration file. It's helpful to use a meaningful name for the migration file.

The `dotnet-ef database update` command tells the framework to apply the schema changes to the database and to preserve existing data.

Delete all the records in the database, the initializer will seed the database and include the `Rating` field.

## Drop and recreate the database for other non-SQL Server providers

**Skip this section if you successfully migrated the database.**

In this tutorial, Entity Framework Core migrations are used when possible. A migration updates the database schema to match changes in the data model. However, migrations can only make changes to the database that the EF Core provider supports. While the SQL Server provider has wide support for migration tasks, other provider's capabilities are limited. For example, support may exist for adding a column (the `ef migrations add` command succeeds), but support may not exist for removing or changing a column (the `ef database update` command fails). Due to these limitations, you can drop and recreate the database using the guidance in this section.

The workaround for the limitations is to manually write migrations code to perform a table rebuild when something in the table changes. A table rebuild involves:

* Creating a new table.
* Copying data from the old table to the new table.
* Dropping the old table.
* Renaming the new table.

For more information, see the following resources:

 * [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
 * [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
 * [Data seeding](/ef/core/modeling/data-seeding)
 * [SQLite ALTER TABLE statement](https://sqlite.org/lang_altertable.html)

1. Delete the migration folder.  

1. Use the following command to drop the database:

   ```dotnetcli
   dotnet ef database drop
   ```

1. Use the following command to create a migration:

   ```dotnetcli
   dotnet ef migrations add InitialCreate
   ```

1. Use the following command to update the database:

   ```dotnetcli
   dotnet ef database update
   ```

:::zone-end

:::zone pivot="cli"

<!-- COPY OVER FROM VSC GUIDANCE -->

:::zone-end

Run the app and verify you can create, edit, and display movies with a `Rating` field.

## Troubleshoot 

Another option is to delete the database and use migrations to re-create the database.

:::zone pivot="vs"

To delete the database in SSOX:

1. Select the database in SSOX.
1. Right-click on the database, and select **Delete**.
1. Check **Close existing connections**.
1. Select **OK**.
1. In the [PMC](xref:tutorials/razor-pages/new-field#pmc), update the database:

   ```powershell
   Update-Database
   ```

:::zone-end

:::zone pivot="vsc"



:::zone-end

:::zone pivot="cli"



:::zone-end



## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* [Migrations (EF Core documentation)](/ef/core/managing-schemas/migrations/)


## Next steps

> [!div class="step-by-step"]
> [Previous: Add Search](xref:blazor/tutorials/movie-database/search)
> [Next: Add interactivity](xref:blazor/tutorials/movie-database/interactivity)
