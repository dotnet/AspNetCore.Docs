# Work with SQLite in an ASP.NET Core Razor Pages app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The `MovieContext` object handles the task of connecting to the database and mapping `Movie` objects to database records. The database context is registered with the [Dependency Injection (DI)](xref:fundamentals/dependency-injection) container in the `ConfigureServices` method in the *Startup.cs* file:

[!code-csharp[](code/Startup.cs?name=snippet2&highlight=6-8)]

For more information on using `DbContext` with DI, see [Using DbContext with DI](/ef/core/miscellaneous/configuring-dbcontext#using-dbcontext-with-dependency-injection).

## SQLite

The [SQLite](https://www.sqlite.org/) website states:

> SQLite is a self-contained, high-reliability, embedded, full-featured, public-domain, SQL database engine. SQLite is the most used database engine in the world.

There are many third party tools you can download to manage and view a SQLite database. The image below is from [DB Browser for SQLite](https://sqlitebrowser.org/). If you have a favorite SQLite tool, leave a comment on what you like about it.

![DB Browser for SQLite showing movie db](../../tutorials/first-mvc-app-xplat/working-with-sql/_static/dbb.png)

## Seed the database

Create a new class named `SeedData` in the *Models* folder. Replace the generated code with the following:

[!code-csharp[](code/Models/SeedData.cs)]

If there are any movies in the DB, the seed initializer returns.

```csharp
if (context.Movie.Any())
{
    return;   // DB has been seeded.
}
```

<a name="si"></a>

### Add the seed initializer

Add the seed initializer to the `Main` method in the *Program.cs* file:

[!code-csharp[](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Program.cs)]

### Test the app

Delete all the records in the DB (So the seed method will run). Stop and start the app to seed the database.

The app shows the seeded data.
