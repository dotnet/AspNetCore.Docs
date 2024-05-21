---
title: Build a Blazor movie database app (Part 4 - Work with a database)
author: guardrex
description: This part of the Blazor movie database app tutorial explains ...
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/06/2024
uid: blazor/tutorials/movie-database/database
---
# Build a Blazor movie database app (Part 4 - Work with a database)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the fourth part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the series focuses on the database, including the EF Core database context and seeding the database.

## Database context

The `BlazorWebAppMoviesContext` object handles the task of connecting to the database and mapping `Movie` objects to database entities. The database context is registered in the `Program` file:

```csharp
builder.Services.AddDbContext<BlazorWebAppMoviesContext>(options =>
    options.UseSqlServer(
      builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? 
      throw new InvalidOperationException(
         "Connection string 'BlazorWebAppMoviesContext' not found.")));
```

The ASP.NET Core Configuration system reads the `ConnectionStrings` key for the connection string name passed to <xref:Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString%2A>.

For local development, configuration obtains the connection string from the app settings file (`appsettings.json`):

```json
"ConnectionStrings": {
  "BlazorWebAppMoviesContext": "Server=(localdb)\\mssqllocaldb;Database=BlazorWebAppMoviesContext-56c369bd-6fdf-4730-a32e-e07f106593a3;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

When the app is deployed to a test/staging or production server, an environment variable can be used to set the connection string to a test/staging or production database server.

## Database technology

SQL Server and SQLite databases are the most popular at this time. The Visual Studio version of this tutorial uses SQL Server, while the Visual Studio Code and .NET CLI versions of this tutorial use SQLite.

### SQL Server Express LocalDB

LocalDB is a lightweight version of the SQL Server Express database engine that's targeted for program development. LocalDB starts on demand and runs in user mode, so there's no complex configuration. By default, LocalDB database creates `*.mdf` files in the `C:\Users\{USER}\` directory, where the `{USER}` placeholder is the system's user ID.

From the **View** menu, open **SQL Server Object Explorer** (SSOX).

![View menu](~/blazor/tutorials/movie-database-app/part-4-database/_static/view-ssox.png)

Right-click on the `Movie` table and select **View Designer**:

![Contextual menus to open the Movie table in Solution Explorer (SSOX)](~/blazor/tutorials/movie-database-app/part-4-database/_static/view-designer.png)

![Movie table open in the table designer](~/blazor/tutorials/movie-database-app/part-4-database/_static/movie-table.png)

Note the key icon next to `ID`. By default, EF creates a property named `ID` for the primary key.

Right-click on the `Movie` table and select **View Data**:

![Contextual menus to open the Movie table data in Solution Explorer (SSOX)](~/blazor/tutorials/movie-database-app/part-4-database/_static/view-data.png)

![Movie table open showing table data](~/blazor/tutorials/movie-database-app/part-4-database/_static/movie-data.png)

### SQLite

[SQLite](https://www.sqlite.org/) is a public, self-contained, full-featured SQL database engine.

There are many third-party tools you can download to manage and view a SQLite database. The following image shows [DB Browser for SQLite](https://sqlitebrowser.org/):

![DB Browser for SQLite showing movie database](~/blazor/tutorials/movie-database-app/part-4-database/_static/dbb.png)

For this tutorial, the EF Core *migrations* feature is used where possible. Migrations updates the database schema to match changes in the data model. However, migrations can only perform changes that the EF Core provider supports, and the SQLite provider's capabilities are limited. For example, adding a column is supported, but removing or changing a column isn't supported. If a migration is created to remove or change a column, the `ef migrations add` command succeeds, but the `ef database update` command fails. Due to these limitations, this tutorial doesn't use migrations for SQLite schema changes. Instead, when the schema changes, the database is dropped and recreated.

The workaround for the SQLite limitations is to manually write migrations code to perform a table rebuild when something in the table changes. A table rebuild involves:

* Creating a new table.
* Copying data from the old table to the new table.
* Dropping the old table.
* Renaming the new table.

For more information, see the following resources:

* [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
* [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
* [Data seeding](/ef/core/modeling/data-seeding)
* [SQLite ALTER TABLE statement](https://sqlite.org/lang_altertable.html)

## Seed the database

Create a new class named `SeedData` in the `Data` folder with the following code.

A database context instance is obtained from the dependency injection (DI) container. If movies are present, `return` is called to avoid seeding the database. When the database is empty, the *Max Max* franchise (&copy;[Warner Bros. Entertainment](https://www.warnerbros.com/)) movies are seeded.

```csharp
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.Models;

namespace BlazorWebAppMovies.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new BlazorWebAppMoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BlazorWebAppMoviesContext>>());

            if (context == null || context.Movie == null)
            {
                throw new NullReferenceException(
                    "Null BlazorWebAppMoviesContext or Movie DbSet");
            }

            if (context.Movie.Any())
            {
                return;
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Mad Max",
                    ReleaseDate = DateTime.Parse("1979-4-12"),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 2.51M
                },
                new Movie
                {
                    Title = "The Road Warrior",
                    ReleaseDate = DateTime.Parse("1981-12-24"),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 2.78M
                },
                new Movie
                {
                    Title = "Mad Max: Beyond Thunderdome",
                    ReleaseDate = DateTime.Parse("1985-7-10"),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 3.55M
                },
                new Movie
                {
                    Title = "Mad Max: Fury Road",
                    ReleaseDate = DateTime.Parse("2015-5-15"),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 8.43M
                },
                new Movie
                {
                    Title = "Furiosa: A Mad Max Saga",
                    ReleaseDate = DateTime.Parse("2024-5-24"),
                    Genre = "Sci-fi (Cyberpunk)",
                    Price = 13.49M
                }
            );

            context.SaveChanges();
        }
    }
}
```

To add the seed initializer, add the following code to the `Program` file immediately after the line that builds the app (`var app = builder.Build();`). The [`using` statement](/dotnet/csharp/language-reference/keywords/using-statement) ensures that the database context is disposed after the seeding operation completes.

```csharp
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
```

## Test the app

Run the app and delete any entities that you created in the database.

Stop and restart the app to seed the database.

Navigate to the movies `Index` page:

![Movies Index page showing Mad Max movie list after seeding the database](~/blazor/tutorials/movie-database-app/part-4-database/_static/index-page.png)

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

Configuration articles:

* <xref:fundamentals/configuration/index> (ASP.NET Core Configuration system)
* <xref:blazor/fundamentals/configuration> (Blazor documentation)

## Next steps

> [!div class="step-by-step"]
> [Previous: Learn about Razor components](xref:blazor/tutorials/movie-database/components)
> [Next: Apply data annotations](xref:blazor/tutorials/movie-database/data-annotations)
