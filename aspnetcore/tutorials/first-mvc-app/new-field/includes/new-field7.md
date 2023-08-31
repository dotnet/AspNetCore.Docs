:::moniker range="= aspnetcore-7.0"

In this section [Entity Framework](/ef/core/get-started/aspnetcore/new-db) Code First Migrations is used to:

* Add a new field to the model.
* Migrate the new field to the database.

When EF Code First is used to automatically create a database, Code First:

* Adds a table to the database to  track the schema of the database.
* Verifies the database is in sync with the model classes it was generated from. If they aren't in sync, EF throws an exception. This makes it easier to find inconsistent database/code issues.

## Add a Rating Property to the Movie Model

Add a `Rating` property to `Models/Movie.cs`:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie70/Models/Movie.cs?name=snippet_AddRating&highlight=19)]

Build the app

### [Visual Studio](#tab/visual-studio)

 Ctrl+Shift+B

### [Visual Studio Code](#tab/visual-studio-code)

```dotnetcli
dotnet build
```

### [Visual Studio for Mac](#tab/visual-studio-mac)

Command ⌘ + B

---

Because you've added a new field to the `Movie` class, you need to update the property binding list so this new property will be included. In `MoviesController.cs`, update the `[Bind]` attribute for both the `Create` and `Edit` action methods to include the `Rating` property:

```csharp
[Bind("Id,Title,ReleaseDate,Genre,Price,Rating")]
```

Update the view templates in order to display, create, and edit the new `Rating` property in the browser view.

Edit the `/Views/Movies/Index.cshtml` file and add a `Rating` field:

[!code-cshtml[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie70/Views/Movies/IndexGenreRating.cshtml?highlight=16-18,38-40&range=24-72)]

Update the `/Views/Movies/Create.cshtml` with a `Rating` field.

# [Visual Studio / Visual Studio for Mac](#tab/visual-studio+visual-studio-mac)

You can copy/paste the previous "form group" and let intelliSense help you update the fields. IntelliSense works with [Tag Helpers](xref:mvc/views/tag-helpers/intro).

![The developer has typed the letter R for the attribute value of asp-for in the second label element of the view. An Intellisense contextual menu has appeared showing the available fields, including Rating, which is highlighted in the list automatically. When the developer clicks the field or presses Enter on the keyboard, the value will be set to Rating.](~/tutorials/first-mvc-app/new-field/_static/cr.png)

# [Visual Studio Code](#tab/visual-studio-code)

<!-- This tab intentionally left blank. -->

---

Update the remaining templates.

Update the `SeedData` class so that it provides a value for the new column. A sample change is shown below, but you'll want to make this change for each `new Movie`.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie70/Models/SeedDataRating.cs?name=snippet_SeedRating&highlight=6)]

The app won't work until the DB is updated to include the new field. If it's run now, the following `SqlException` is thrown:

`SqlException: Invalid column name 'Rating'.`

This error occurs because the updated Movie model class is different than the schema of the Movie table of the existing database. (There's no `Rating` column in the database table.)

There are a few approaches to resolving the error:

1. Have the Entity Framework automatically drop and re-create the database based on the new model class schema. This approach is very convenient early in the development cycle when you're doing active development on a test database; it allows you to quickly evolve the model and database schema together. The downside, though, is that you lose existing data in the database — so you don't want to use this approach on a production database! Using an initializer to automatically seed a database with test data is often a productive way to develop an application. This is a good approach for early development and when using SQLite.

2. Explicitly modify the schema of the existing database so that it matches the model classes. The advantage of this approach is that you keep your data. You can make this change either manually or by creating a database change script.

3. Use Code First Migrations to update the database schema.

For this tutorial, Code First Migrations is used.

# [Visual Studio](#tab/visual-studio)

From the **Tools** menu, select **NuGet Package Manager > Package Manager Console**.

  ![PMC menu](~/tutorials/first-mvc-app/adding-model/_static/pmc.png)

In the PMC, enter the following commands:

```powershell
Add-Migration Rating
Update-Database
```

The `Add-Migration` command tells the migration framework to examine the current `Movie` model with the current `Movie` DB schema and create the necessary code to migrate the DB to the new model.

The name "Rating" is arbitrary and is used to name the migration file. It's helpful to use a meaningful name for the migration file.

If all the records in the DB are deleted, the initialize method will seed the DB and include the `Rating` field.

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

[!INCLUDE[](~/includes/RP-mvc-shared/sqlite-warn.md)]

Delete the Migrations folder and the database file, and then run the following .NET CLI commands:

```dotnetcli
dotnet ef migrations add InitialCreate
```

```dotnetcli
dotnet ef database update
```

For more information, see [Resetting all migrations](/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli#resetting-all-migrations).

---
<!-- End of VS tabs -->

Run the app and verify you can create, edit, and display movies with a `Rating` field.

> [!div class="step-by-step"]
> [Previous](~/tutorials/first-mvc-app/search.md)
> [Next](~/tutorials/first-mvc-app/validation.md)

:::moniker-end
