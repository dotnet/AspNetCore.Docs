# Adding a new field

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial will add a new field to the `Movies` table. We'll drop the database and create a new one when we change the schema (add a new field). This workflow works well early in development when we don't have any production data to perserve.

Once your app is deployed and you have data that you need to perserve, you can't drop your DB when you need to change the schema. Entity Framework [Code First Migrations](https://docs.microsoft.com/ef/core/get-started/aspnetcore/new-db) allows you to update your schema and migrate the database without losing data. Migrations is a popular feature when using SQL Server, but SQLlite does not support many migration schema operations, so only very simply migrations are possible. See [SQLite Limitations](https://docs.microsoft.com/ef/core/providers/sqlite/limitations) for more information.

## Adding a Rating Property to the Movie Model

Open the *Models/Movie.cs* file and add a `Rating` property:

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/MovieDateRating.cs?highlight=11&range=7-18)]

Because you've added a new field to the `Movie` class, you also need to update the binding whitelist so this new property will be included. In *MoviesController.cs*, update the `[Bind]` attribute for both the `Create` and `Edit` action methods to include the `Rating` property:

```csharp
[Bind("ID,Title,ReleaseDate,Genre,Price,Rating")]
   ```

You also need to update the view templates in order to display, create, and edit the new `Rating` property in the browser view.

Edit the */Views/Movies/Index.cshtml* file and add a `Rating` field:

[!code-HTML[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Views/Movies/IndexGenreRating.cshtml?highlight=17,39&range=24-64)]

Update the */Views/Movies/Create.cshtml* with a `Rating` field.

The app won't work until we update the DB to include the new field. If you run it now, you'll get the following `SqliteException`:

```
SqliteException: SQLite Error 1: 'no such column: m.Rating'.
```

You're seeing this error because the updated Movie model class is different than the schema of the Movie table of the existing database. (There's no `Rating` column in the database table.)

There are a few approaches to resolving the error:

1. Drop the database and have the Entity Framework automatically re-create the database based on the new model class schema. With this approach, you lose existing data in the database — so you can't do this with a production database! Using an initializer to automatically seed a database with test data is often a productive way to develop an app.

2. Manually modify the schema of the existing database so that it matches the model classes. The advantage of this approach is that you keep your data. You can make this change either manually or by creating a database change script.

3. Use Code First Migrations to update the database schema.

For this tutorial, we'll drop and re-create the database when the schema changes. Run the following command from a terminal to drop the db:

`dotnet ef database drop`

Update the `SeedData` class so that it provides a value for the new column. A sample change is shown below, but you'll want to make this change for each `new Movie`.

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Models/SeedDataRating.cs?name=snippet1&highlight=6)]

Add the `Rating` field to the `Edit`, `Details`, and `Delete` view.

Run the app and verify you can create/edit/display movies with a `Rating` field. templates.
