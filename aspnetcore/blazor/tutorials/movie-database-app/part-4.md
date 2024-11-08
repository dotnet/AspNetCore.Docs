---
title: Build a Blazor movie database app (Part 4 - Work with a database)
author: guardrex
description: This part of the Blazor movie database app tutorial explains the database context and directly working with the database's schema and data. Seeding the database with data is also covered.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/26/2024
uid: blazor/tutorials/movie-database-app/part-4
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 4 - Work with a database)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the fourth part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

This part of the tutorial series focuses on the database context and directly working with the database's schema and data. Seeding the database with data is also covered.

## Secure authentication flow required for production apps

This tutorial uses a local database that doesn't require user authentication. Production apps should use the most secure authentication flow available. For more information on authentication for deployed test and production Blazor Web Apps, see the following resources:

* <xref:blazor/security/index>
* <xref:blazor/security/server/index> and the following articles in the *Server* security node
* <xref:blazor/security/blazor-web-app-oidc>
* <xref:blazor/security/blazor-web-app-entra>

For Microsoft Azure services, we recommend using *managed identities*. Managed identities securely authenticate to Azure services without storing credentials in app code. For more information, see the following resources:

* [What are managed identities for Azure resources? (Microsoft Entra documentation)](/entra/identity/managed-identities-azure-resources/overview)
* Azure services documentation
  * [Managed identities in Microsoft Entra for Azure SQL](/azure/azure-sql/database/authentication-azure-ad-user-assigned-managed-identity)
  * [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)

## Database context

The database context, `BlazorWebAppMoviesContext`, connects to the database and maps model objects to database records. The database context was created in the second part of this series. The scaffolded database context code appears in the `Program` file:

:::zone pivot="vs"

```csharp
builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? 
        throw new InvalidOperationException(
            "Connection string 'BlazorWebAppMoviesContext' not found.")));
```

:::zone-end

:::zone pivot="vsc"

```csharp
builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? 
        throw new InvalidOperationException(
            "Connection string 'BlazorWebAppMoviesContext' not found.")));
```

:::zone-end

:::zone pivot="cli"

```csharp
builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? 
        throw new InvalidOperationException(
            "Connection string 'BlazorWebAppMoviesContext' not found.")));
```

:::zone-end

<xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContextFactory%2A> registers a factory for the given context as a service in the app's service collection.

<xref:Microsoft.EntityFrameworkCore.SqlServerDbContextOptionsExtensions.UseSqlServer%2A> or <xref:Microsoft.EntityFrameworkCore.SqliteDbContextOptionsBuilderExtensions.UseSqlite%2A> configures the context to connect to either a Microsoft SQL Server or SQLite database. Other providers are available to connect to additional types of databases.

<xref:Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString%2A> uses the ASP.NET Core Configuration system to read the `ConnectionStrings` key for the connection string name provided, which in the preceding example is `BlazorWebAppMoviesContext`.

For local development, configuration obtains the database connection string from the app settings file (`appsettings.json`). The `{CONNECTION STRING}` placeholder in the following example is the connection string:

```json
"ConnectionStrings": {
  "BlazorWebAppMoviesContext": "{CONNECTION STRING}"
}
```

The following is an example connection string:

> :::no-loc text="Server=(localdb)\\mssqllocaldb;Database=BlazorWebAppMoviesContext-00001111-aaaa-2222-bbbb-3333cccc4444;Trusted_Connection=True;MultipleActiveResultSets=true":::

When the app is deployed to a test/staging or production server, securely store the connection string outside of the project's configuration files.

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

## Database technology

:::zone pivot="vs"

The Visual Studio version of this tutorial uses SQL Server.

SQL Server Express LocalDB is a lightweight version of the SQL Server Express database engine that's targeted for program development. LocalDB starts on demand and runs in user mode, so there's no complex configuration. Master database files (`*.mdf`) are placed in the `C:/Users/{USER}` directory, where the `{USER}` placeholder is the system's user ID.

From the **View** menu, open **SQL Server Object Explorer** (SSOX).

![View menu](~/blazor/tutorials/movie-database-app/part-4/_static/view-ssox.png)

Right-click on the `Movie` table and select **View Designer**:

![Contextual menus to open the Movie table in Solution Explorer (SSOX)](~/blazor/tutorials/movie-database-app/part-4/_static/view-designer.png)

The **View Designer** opens:

![Movie table open in the table designer](~/blazor/tutorials/movie-database-app/part-4/_static/movie-table.png)

Note the key icon next to `ID`. EF creates a property named `ID` for the primary key.

Right-click on the `Movie` table and select **View Data**:

![Contextual menus to open the Movie table data in Solution Explorer (SSOX)](~/blazor/tutorials/movie-database-app/part-4/_static/view-data.png)

The table's data opens in a new tab in Visual Studio:

![Movie table open showing movie table data](~/blazor/tutorials/movie-database-app/part-4/_static/movie-data.png)

:::zone-end

:::zone pivot="vsc"

The VS Code version of this tutorial uses [SQLite](https://www.sqlite.org/), which is a public, self-contained, full-featured SQL database engine.

There are many third-party tools you can use to manage and view SQLite databases. The following image shows [DB Browser for SQLite](https://sqlitebrowser.org/):

![DB Browser for SQLite showing movie database](~/blazor/tutorials/movie-database-app/part-4/_static/dbb.png)

In this tutorial, EF Core migrations are used. A migration updates the database schema to match changes in the data model. However, migrations can only make changes to the database that the EF Core provider supports. Resources are listed at the end of this article for further reading.

:::zone-end

:::zone pivot="cli"

The VS Code version of this tutorial uses [SQLite](https://www.sqlite.org/), which is a public, self-contained, full-featured SQL database engine.

There are many third-party tools you can use to manage and view SQLite databases. The following image shows [DB Browser for SQLite](https://sqlitebrowser.org/):

![DB Browser for SQLite showing movie database](~/blazor/tutorials/movie-database-app/part-4/_static/dbb.png)

In this tutorial, EF Core migrations are used. A migration updates the database schema to match changes in the data model. However, migrations can only make changes to the database that the EF Core provider supports. Resources are listed at the end of this article for further reading.

:::zone-end

## Seed the database

Seeding code can create a set of records for development testing or even be used to create the initial data for a new production database.

Create a new class named `SeedData` in the `Data` folder with the following code.

`Data/SeedData.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.Models;

namespace BlazorWebAppMovies.Data;

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
                ReleaseDate = new DateOnly(1979, 4, 12),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 2.51M,
            },
            new Movie
            {
                Title = "The Road Warrior",
                ReleaseDate = new DateOnly(1981, 12, 24),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 2.78M,
            },
            new Movie
            {
                Title = "Mad Max: Beyond Thunderdome",
                ReleaseDate = new DateOnly(1985, 7, 10),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 3.55M,
            },
            new Movie
            {
                Title = "Mad Max: Fury Road",
                ReleaseDate = new DateOnly(2015, 5, 15),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 8.43M,
            },
            new Movie
            {
                Title = "Furiosa: A Mad Max Saga",
                ReleaseDate = new DateOnly(2024, 5, 24),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 13.49M,
            });

        context.SaveChanges();
    }
}
```

A database context instance is obtained from the dependency injection (DI) container. If movies are present, `return` is called to avoid seeding the database. When the database is empty, the [*Mad Max* franchise](https://warnerbros.fandom.com/wiki/Mad_Max_(franchise)) (&copy;[Warner Bros. Entertainment](https://www.warnerbros.com/)) movies are seeded.

To execute the seed initializer, add the following code to the `Program` file immediately after the line that builds the app (`var app = builder.Build();`). The [`using` statement](/dotnet/csharp/language-reference/keywords/using-statement) ensures that the database context is disposed after the seeding operation completes.

```csharp
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
```

:::zone pivot="vs"

If the database contains records from earlier testing, run the app and delete the entities that you created in the database. Stop the app by closing the browser's window.

:::zone-end

:::zone pivot="vsc"

If the database contains records from earlier testing, run the app and delete the entities that you created in the database. Stop the app by closing the browser's window and pressing <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard in VS Code.

:::zone-end

:::zone pivot="cli"

If the database contains records from earlier testing, run the app and delete the entities that you created in the database. Stop the app by closing the browser's window and pressing <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS) in the command shell.

:::zone-end

When the database is empty, run the app.

Navigate to the movies `Index` page to see the seeded movies:

![Movies Index page showing Mad Max movie list after seeding the database](~/blazor/tutorials/movie-database-app/part-4/_static/index-page.png)

## Bind a form to a model

Review the the `Edit` component (`Components/Pages/MoviePages/Edit.razor`).

When an HTTP GET request is made for the `Edit` component page (for example at the relative URL: `/movies/edit?id=6`):

* The <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> method fetches the movie with an `Id` of `6` from the database and assigns it to the `Movie` property.
* The <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> parameter specifies the top-level model object for the form. An edit context is constructed for the form using the assigned model.
* The form is displayed with the values from the movie.

When the `Edit` page is posted to the server, the form values on the page are bound to the `Movie` property because the [`[SupplyParameterFromForm]` attribute](xref:Microsoft.AspNetCore.Components.SupplyParameterFromFormAttribute) is annotated on the `Movie` property:

```csharp
[SupplyParameterFromForm]
private Movie? Movie { get; set; }
```

If the model state has errors when the form is posted, for example if `ReleaseDate` can't be converted into a date, the form is redisplayed with the submitted values. If no model errors exist, the movie is saved using the form's posted values.

## Concurrency exception handling

Review the `UpdateMovie` method of the `Edit` component (`Components/Pages/MoviePages/Edit.razor`):

```csharp
private async Task UpdateMovie()
{
    using var context = DbFactory.CreateDbContext();
    context.Attach(Movie!).State = EntityState.Modified;

    try
    {
        await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!MovieExists(Movie!.Id))
        {
            NavigationManager.NavigateTo("notfound");
        }
        else
        {
            throw;
        }
    }

    NavigationManager.NavigateTo("/movies");
}
```

Concurrency exceptions are detected when one client deletes the movie and a different client posts changes to the movie.

To test how concurrency is handled by the preceding code:

1. Select **:::no-loc text="Edit":::** for a movie, make changes, but don't select **:::no-loc text="Save":::**.
1. In a different browser window, open the app to the movie `Index` page and select the **:::no-loc text="Delete":::** link for the same movie to delete the movie.
1. In the previous browser window, post changes to the movie by selecting the **:::no-loc text="Save":::** button.
1. The browser is navigated to the `notfound` endpoint, which doesn't exist and yields a 404 (Not Found) result.

Additional guidance on handling concurrency with EF Core in Blazor apps is available in the Blazor documentation.

## Stop the app

:::zone pivot="vs"

If the app is running, shut the app down by closing the browser's window.

:::zone-end

:::zone pivot="vsc"

If the app is running, shut the app down by closing the browser's window and pressing <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard in VS Code.

:::zone-end

:::zone pivot="cli"

If the app is running, shut the app down by closing the browser's window and pressing <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS) in the command shell.

:::zone-end

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

* Configuration articles:
  * <xref:fundamentals/configuration/index> (ASP.NET Core Configuration system)
  * <xref:blazor/fundamentals/configuration> (Blazor documentation)
  * [Data seeding (EF Core documentation)](/ef/core/modeling/data-seeding)
* [Concurrency with EF Core in Blazor apps](xref:blazor/blazor-ef-core)
* Database provider resources:
  * EF Core documentation
    * [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
    * [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
  * [SQLite ALTER TABLE statement (SQLite documentation)](https://sqlite.org/lang_altertable.html)
* Blazor Web App security
  * <xref:blazor/security/index>
  * <xref:blazor/security/server/index> and the following articles in the *Server* security node
  * <xref:blazor/security/blazor-web-app-oidc>
  * <xref:blazor/security/blazor-web-app-entra>

## Legal

[*Mad Max*, *The Road Warrior*, *Mad Max: Beyond Thunderdome*, *Mad Max: Fury Road*, and *Furiosa: A Mad Max Saga*](https://warnerbros.fandom.com/wiki/Mad_Max_(franchise)) are trademarks and copyrights of [Warner Bros. Entertainment](https://www.warnerbros.com/).

## Next steps

> [!div class="step-by-step"]
> [Previous: Learn about Razor components](xref:blazor/tutorials/movie-database-app/part-3)
> [Next: Add Validation](xref:blazor/tutorials/movie-database-app/part-5)
