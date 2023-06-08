:::moniker range="= aspnetcore-7.0"

In this section [Entity Framework](/ef/core/get-started/aspnetcore/new-db) Code First Migrations is used to:

* Add a new field to the model.
* Migrate the new field schema change to the database.

When using EF Code First to automatically create and track a database, Code First:

* Adds an [`__EFMigrationsHistory`](/ef/core/managing-schemas/migrations/history-table) table to the database to track whether the schema of the database is in sync with the model classes it was generated from.
* Throws an exception if the model classes aren't in sync with the database.

Automatic verification that the schema and model are in sync makes it easier to find inconsistent database code issues.

## Adding a Rating Property to the Movie Model
<!-- Update Index in working project then copy to snap7 folder -->

1. Open the `Models/Movie.cs` file and add a `Rating` property:
   [!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie70/Models/MovieDateRating.cs?highlight=13&name=snippet)]
1. Edit `Pages/Movies/Index.cshtml`, and add a `Rating` field:
   <a name="addrat7"></a>
   [!code-cshtml[](~/tutorials/razor-pages/razor-pages-start/snap7/IndexRating.cshtml?highlight=40-42,62-64)]

1. Update the following pages with a `Rating` field:
   * *[Pages/Movies/Create.cshtml](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie70/Pages/Movies/Create.cshtml)*.
   * *[Pages/Movies/Delete.cshtml](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie70/Pages/Movies/Delete.cshtml)*.
   * *[Pages/Movies/Details.cshtml](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie70/Pages/Movies/Details.cshtml)*.
   * *[Pages/Movies/Edit.cshtml](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie70/Pages/Movies/Edit.cshtml)*.

The app won't work until the database is updated to include the new field. Running the app without an update to the database throws a `SqlException`:

`SqlException: Invalid column name 'Rating'.`

The `SqlException` exception is caused by the updated Movie model class being different than the schema of the Movie table of the database. There's no `Rating` column in the database table.

There are a few approaches to resolving the error:

1. Have the Entity Framework automatically drop and re-create the database using the new model class schema. This approach is convenient early in the development cycle, it allows developers to quickly evolve the model and database schema together. The downside is that existing data in the database is lost. Don't use this approach on a production database! Dropping the database on schema changes and using an initializer to automatically seed the database with test data is often a productive way to develop an app.
2. Explicitly modify the schema of the existing database so that it matches the model classes. The advantage of this approach is to keep the data. Make this change either manually or by creating a database change script.
3. Use Code First Migrations to update the database schema.

For this tutorial, use Code First Migrations.

Update the `SeedData` class so that it provides a value for the new column. A sample change is shown below, but make this change for each `new Movie` block.

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie60/Models/SeedDataRating.cs?name=snippet1&highlight=8)]

See the [completed SeedData.cs file](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie70/Models/SeedDataRating.cs).

Build the solution.

# [Visual Studio](#tab/visual-studio)

<a name="pmc"></a>

### Add a migration for the rating field

1. From the **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
2. In the PMC, enter the following commands:

   ```powershell
   Add-Migration Rating
   Update-Database
   ```

The `Add-Migration` command tells the framework to:

* Compare the `Movie` model with the `Movie` database schema.
* Create code to migrate the database schema to the new model.

The name "Rating" is arbitrary and is used to name the migration file. It's helpful to use a meaningful name for the migration file.

The `Update-Database` command tells the framework to apply the schema changes to the database and to preserve existing data.

<a name="ssox"></a>

Delete all the records in the database, the initializer will seed the database and include the `Rating` field. Deleting can be done with the delete links in the browser or from [Sql Server Object Explorer](xref:tutorials/razor-pages/sql#ssox) (SSOX).

Another option is to delete the database and use migrations to re-create the database. To delete the database in SSOX:

1. Select the database in SSOX.
1. Right-click on the database, and select **Delete**.
1. Check **Close existing connections**.
1. Select **OK**.
1. In the [PMC](xref:tutorials/razor-pages/new-field#pmc), update the database:

   ```powershell
   Update-Database
   ```

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

### Add a migration for rating
Use the following commands to add a migration for the rating field:

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

### Optional: Drop and re-create the database for other providers

Skip this section if you successfully migrated the database.

In this tutorial, Entity Framework Core *migrations* features are used when possible. Migrations updates the database schema to match changes in the data model. However, migrations can only do the kinds of changes that the EF Core provider supports, and some provider's capabilities are limited. For example, adding a column may be supported, but removing or changing a column is not. If a migration is created to remove or change a column, the `ef migrations add` command succeeds but the `ef database update` command fails. Due to these limitations, you can drop and re-create the database.

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

1. Use the following commands to recreate the database.

   ```dotnetcli
   dotnet ef database drop
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

---

Run the app and verify you can create, edit, and display movies with a `Rating` field. If the database isn't seeded, set a break point in the `SeedData.Initialize` method.

## Next steps

> [!div class="step-by-step"]
> [Previous: Add Search](xref:tutorials/razor-pages/search)
> [Next: Add Validation](xref:tutorials/razor-pages/validation)

:::moniker-end
