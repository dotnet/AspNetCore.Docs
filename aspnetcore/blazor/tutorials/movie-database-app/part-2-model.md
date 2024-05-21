---
title: Build a Blazor movie database app (Part 2 - Add a model)
author: guardrex
description: This part of the Blazor movie database app tutorial explains ...
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/14/2024
ms.custom: mvc
uid: blazor/tutorials/movie-database/model
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 2 - Add a model)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the second part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

In this part of the series, classes are added for managing movies in a database. The app's model classes use [Entity Framework Core (EF Core)](/ef/core) to work with the database. EF Core is an object-relational mapper (O/RM) that simplifies data access. You write the model classes first, and EF Core creates the database.

The model classes are known as POCO classes, an acronym of **P**lain-**O**ld **C**LR **O**bjects, because they don't have a dependency on EF Core. POCO classes define the properties of the data that are stored in the database.

## Add a data model

:::zone pivot="vs"

In **Solution Explorer**, right-click the *BlazorWebAppMovies* project and select **Add** > **New Folder**. Name the folder `Models`.

Right-click the `Models` folder. Select **Add** > **Class**. Name the file `Movie.cs`, which creates a public class `Movie` in the file with the namespace `BlazorWebAppMovies.Models`.

:::zone-end

:::zone pivot="vsc"

Add a folder to the project named `Models`.

Add a class file to the `Models` folder named `Movie.cs`.

:::zone-end

:::zone pivot="cli"

Add a folder to the project named `Models`.

Add a class file to the `Models` folder named `Movie.cs`.

:::zone-end

Add the following properties to the `Movie` class:

```csharp
public int Id { get; set; }

public string? Title { get; set; }

[DataType(DataType.Date)]
public DateTime ReleaseDate { get; set; }

public string? Genre { get; set; }

public decimal Price { get; set; }
```

The `Movie` class contains:

* The `Id` field is required by the database for the primary key.
* A [`[DataType]` attribute](xref:System.ComponentModel.DataAnnotations.DataTypeAttribute) is used to specify the type of data in the `ReleaseDate` property with the following behaviors: 
  * The user isn't required to enter time information in the date field.
  * Only the date is displayed, not time information.
* The question mark after `string` indicates that the property is a [nullable reference type](/dotnet/csharp/nullable-references).

:::zone pivot="vs"

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without the debugger.

:::zone-end

:::zone pivot="vsc"

Execute the following .NET CLI commands in the integrated terminal to add NuGet packages and EF tools:

```dotnetcli
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

The preceding commands add:

* [Command-line interface (CLI) tools for EF Core](/ef/core/miscellaneous/cli/dotnet)
* [aspnet-codegenerator scaffolding tool](xref:fundamentals/tools/dotnet-aspnet-codegenerator)
* Design time tools for EF Core
* The EF Core SQLite provider (installs the EF Core package as a dependency)
* Packages required for scaffolding
  * [`Microsoft.VisualStudio.Web.CodeGeneration.Design`](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design)
  * [`Microsoft.EntityFrameworkCore.SqlServer`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)

For guidance on multiple environment configuration that permits an app to configure its database contexts by environment, see <xref:fundamentals/environments#environment-based-startup-class-and-methods>.

> [!NOTE]
> By default, the .NET binaries architecture installed represents the currently running OS architecture. To specify a different OS architecture, see [`dotnet tool install` (`--arch option`)](/dotnet/core/tools/dotnet-tool-install#options).

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app without the debugger.

In the panel below the editor region of the VS Code UI, select the **PROBLEMS** tab. The panel isn't in view, select **View** > **Problems** from the menu bar or press <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>M</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>Shift</kbd>+<kbd>M</kbd> (macOS) on the keyboard.

:::zone-end

:::zone pivot="cli"

Execute the following .NET CLI commands in in a command shell to add NuGet packages and EF Core tools:

```dotnetcli
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

The preceding commands add:

* [Command-line interface (CLI) tools for EF Core](/ef/core/miscellaneous/cli/dotnet)
* [aspnet-codegenerator scaffolding tool](xref:fundamentals/tools/dotnet-aspnet-codegenerator)
* Design time tools for EF Core
* The EF Core SQLite provider (installs the EF Core package as a dependency)
* Packages required for scaffolding
  * [`Microsoft.VisualStudio.Web.CodeGeneration.Design`](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design)
  * [`Microsoft.EntityFrameworkCore.SqlServer`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)

For guidance on multiple environment configuration that permits an app to configure its database contexts by environment, see <xref:fundamentals/environments#environment-based-startup-class-and-methods>.

> [!NOTE]
> By default, the .NET binaries architecture installed represents the currently running OS architecture. To specify a different OS architecture, see [`dotnet tool install` (`--arch option`)](/dotnet/core/tools/dotnet-tool-install#options).

In a command shell, execute the [`dotnet build`](/dotnet/core/tools/dotnet-build) command.

:::zone-end

Verify that the app compiled without errors.

## Scaffold the model

In this section, the `Movie` model is *scaffolded*. Scaffolding means that a .NET tool produces Razor components for CRUD operations on the `Movie` model.

:::zone pivot="vs"

Right-click on the `Components/Pages` folder and select **Add** > **New Scaffolded Item**.

![New Scaffolded Item](~/blazor/tutorials/movie-database-app/part-2-model/_static/new-scaffolded-item.png)

In the **Add New Scaffold** dialog open to **Installed** > **Common** > **Razor Component**, select **Razor Components using Entity Framework (CRUD)** > **Add**.

![Scaffold item](~/blazor/tutorials/movie-database-app/part-2-model/_static/install-common-razor-component.png)

Complete the **Add Razor Components using Entity Framework (CRUD)** dialog:

* In the **Model class** dropdown list, select **Movie (BlazorWebAppMovies.Models)**.
* For **DbContext class**, select the **+** (plus sign) button.
* In the **Add Data Context** modal dialog, the class name `BlazorWebAppMovies.Data.BlazorWebAppMoviesContext` is generated. Use the default generated value. Select the **Add** button.
* After the model dialog closes, the **Database provider** dropdown list defaults to **SQL Server**. Use the default selected value.
* Select **Add**.

![Add Razor Pages](~/blazor/tutorials/movie-database-app/part-2-model/_static/add-razor-components-using-ef-crud.png)

The `appsettings.json` file is updated with the connection string used to connect to a local database. In the following example, the `{CONNECTION STRING}` is the connection string generated automatically by the scaffolder:

```json
"ConnectionStrings": {
  "BlazorWebAppMoviesContext": "{CONNECTION STRING}"
}
```

:::zone-end

:::zone pivot="vsc"

In the integrated terminal opened to the project's root directory, execute the following command:

<!-- NOTE: Need to check here if using the 'Pages' directory
           results in an auto-generated 'MoviePages' folder. -->

```dotnetcli
dotnet aspnet-codegenerator crud --dbProvider sqlite -dc BlazorWebAppMovies.Data.BlazorWebAppMovies -m Movie -outDir Components/Pages -udl
```

The template name is one of the following values:

* `create`: Produces a component to create an entity.
* **`crud`**: Produces create, edit, delete, details, and index components.
* `delete`: Produces a component to delete an entity.
* `details`: Produces a component to show the details of an entity.
* `edit`: Produces a component to edit an entity.
* `empty`: Scaffolds the database context without creating components.
* `index`: Produces a component to list all of the entities.

The following table details the ASP.NET Core code generator options.

| Option                           | Description |
| -------------------------------- | ----------- |
| `-databaseProvider|--dbProvider` | Database provider to use. Options include `sqlserver` (default), `sqlite`, `cosmos`, `postgres`. |
| `-dc|--dbContext`                | The `DbContext` class to use, including the namespace. |
| `-m|--model`                     | The name of the model. |
| `-namespace|--namespaceName`     | The name of the namespace to use for the generated Razor components. |
| `-outDir|--relativeFolderPath`   | The relative output folder path for the generated components. |

Use the `-h` option to get help on the `dotnet aspnet-codegenerator razorcomponent` command:

```dotnetcli
dotnet aspnet-codegenerator crud -h
```

For more information, see [dotnet aspnet-codegenerator](xref:fundamentals/tools/dotnet-aspnet-codegenerator).

When SQLite is selected, the template-generated code is ready for development, and this tutorial is based on locally running the app.

If the code is for deployment to a server running SQL Server while you're working on the tutorial, the following code shows how to select the SQLite connection string in the Development environment and SQL Server in other environments, such as Staging and Production. You don't need to use the following code in the `Program` file if you merely intend to run the app locally on SQLite during the tutorial. The code is presented only for developers who are deploying the `BlazorWebAppMovies` app to a server running SQL Server.

In the `Program` file after the <xref:Microsoft.AspNetCore.Builder.WebApplication> is created and assigned to `builder`:

```csharp
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("RazorPagesMovieContext")));
}
else
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ProductionMovieContext")));
}
```

> [!NOTE]
> The preceding code doesn't call <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A> in development because <xref:Microsoft.AspNetCore.Builder.WebApplication> automatically adds the developer exception page in development mode.

:::zone-end

:::zone pivot="cli"

In a command shell opened to the project's root directory, execute the following command:

<!-- NOTE: Need to check here if using the 'Pages' directory
           results in an auto-generated 'MoviePages' folder. -->

```dotnetcli
dotnet aspnet-codegenerator razorcomponent -m Movie -dc BlazorWebAppMovies.Data.BlazorWebAppMovies -udl -outDir Components/Pages --databaseProvider sqlite
```

The following table details the ASP.NET Core code generator options.

| Option                       | Description |
| ---------------------------- | ----------- |
| `-m`                         | The name of the model. |
| `-dc`                        | The `DbContext` class to use, including the namespace. |
| `-udl`                       | Use the default layout. |
| `-outDir`                    | The relative output folder path for the generated components. |

Use the `-h` option to get help on the `dotnet aspnet-codegenerator razorcomponent` command:

```dotnetcli
dotnet aspnet-codegenerator razorcomponent -h
```

For more information, see [dotnet aspnet-codegenerator](xref:fundamentals/tools/dotnet-aspnet-codegenerator).

When SQLite is selected, the template-generated code is ready for development, and this tutorial is based on locally running the app.

If the code is for deployment to a server running SQL Server while you're working on the tutorial, the following code shows how to select the SQLite connection string in the Development environment and SQL Server in other environments, such as Staging and Production. You don't need to use the following code in the `Program` file if you merely intend to run the app locally on SQLite during the tutorial. The code is presented only for developers who are deploying the `BlazorWebAppMovies` app to a server running SQL Server.

In the `Program` file after the <xref:Microsoft.AspNetCore.Builder.WebApplication> is created and assigned to `builder`:

```csharp
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("RazorPagesMovieContext")));
}
else
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ProductionMovieContext")));
}
```

> [!NOTE]
> The preceding code doesn't call <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A> in development because <xref:Microsoft.AspNetCore.Builder.WebApplication> automatically adds the developer exception page in development mode.

:::zone-end

## Files created and updated

The scaffold process creates the following component files and movie database context class file:

* `Components/Pages/MoviePages`
  * `Create.razor`: Creates new movie entities.
  * `Delete.razor`: Deletes a movie entity.
  * `Details.razor`: Shows movie entity details.
  * `Edit.razor`: Updates a movie.
  * `Index.razor`: Lists movies in the database.
* `Data/BlazorWebAppMovieContext.cs`: Database context file (<xref:Microsoft.EntityFrameworkCore.DbContext>).

The component files in the `MoviePages` folder are described in greater detail the next part of this tutorial. The database context is described later in this article.

ASP.NET Core is built with [dependency injection](xref:fundamentals/dependency-injection). Services, such as the EF Core database context, are registered with dependency injection during application startup. These services are injected into Razor components.

The scaffolding tool automatically created a database context and registered it with the dependency injection container.

The <xref:Microsoft.AspNetCore.Components.QuickGrid> component ([`QuickGrid` documentation](xref:blazor/components/quickgrid)) is a Razor component for quickly and efficiently displaying data in tabular form. The scaffolder places a <xref:Microsoft.AspNetCore.Components.QuickGrid> component in the `Index` component to display movie entities. Calling <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkAdapterServiceCollectionExtensions.AddQuickGridEntityFrameworkAdapter%2A> on the service collection adds an EF Core adapter for <xref:Microsoft.AspNetCore.Components.QuickGrid> to recognize EF-supplied <xref:System.Linq.IQueryable%601> instances and to resolve database queries asynchronously for efficiency. To supply this EF Core adapter, the scaffolder adds the [`Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter) NuGet package to the app's program file.

The following code is added to the `Program` file by the scaffolder:

```csharp
builder.Services.AddDbContext<BlazorWebAppMoviesContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? 
        throw new InvalidOperationException(
            "Connection string 'BlazorWebAppMoviesContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();
```

The Interactive Server render mode is configured. However, the API only sets the app up for interactive SSR. The API on its own doesn't make the app's components interactive. Interactivity is covered in the last part of this tutorial series, where the `Index` component is made interactive to permit sorting.

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

...

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

The preceding `Program` file changes are explained later in this article.

## Create the initial database schema using EF's migration feature

The migrations feature in EF Core provides a way to:

* Create the initial database schema.
* Incrementally update the database schema to keep it in sync with the app's data model. Existing data in the database is preserved.

:::zone pivot="vs"

In this section, the **Package Manager Console** (PMC) window is used to:

* Add an initial migration.
* Update the database with the initial migration.

To open the PMC from the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console**.

In the PMC, execute the following command to add an initial migration. The `Add-Migration` command generates code to create the initial database schema. The schema is based on the model specified in `DbContext`. The `InitialCreate` argument is used to name the migration. Any name can be used, but the convention is to use a name that describes the migration.

```powershell
Add-Migration InitialCreate
```

After the preceding command completes, update the database with the `Update-Database` command. The `Update-Database` command executes the `Up` method in migrations that haven't been applied. In this case, the command executes the `Up` method in the `Migrations/{TIME STAMP}_InitialCreate.cs` file, which creates the database. The `{TIME STAMP}` placeholder in the preceding example is a time stamp.

```powershell
Update-Database
```

:::zone-end

:::zone pivot="vsc"

Right-click the `BlazorWebAppMovies` project file (`BlazorWebAppMovies.csproj`), and then select **Open in Integrated Terminal**.

The **Terminal** window opens with the command prompt at the project directory, which contains the `Program` file and the `.csproj` file.

Execute the following .NET CLI command to add an initial migration. The `migrations` command generates code to create the initial database schema. The schema is based on the model specified in `DbContext`. The `InitialCreate` argument is used to name the migrations. Any name can be used, but the convention is to use a name that describes the migration.

```dotnetcli
dotnet ef migrations add InitialCreate
```

After the preceding command completes, update the database with the `update` command. The `update` command executes the `Up` method in migrations that have not been applied. In this case, the command executes the `Up` method in the `Migrations/{TIME STAMP}_InitialCreate.cs` file, which creates the database. The `{TIME STAMP}` placeholder in the preceding example is a time stamp.

```dotnetcli
dotnet ef database update
```

> [!NOTE]
> For SQLite, the column type for the `Price` field is set to `TEXT`. This is resolved in a later step.

:::zone-end

:::zone pivot="cli"

From the project's root folder, execute the following .NET CLI command to add an initial migration. The `migrations` command generates code to create the initial database schema. The schema is based on the model specified in `DbContext`. The `InitialCreate` argument is used to name the migrations. Any name can be used, but the convention is to use a name that describes the migration.

```dotnetcli
dotnet ef migrations add InitialCreate
```

After the preceding command completes, update the database with the `update` command. The `update` command executes the `Up` method in migrations that have not been applied. In this case, the command executes the `Up` method in the `Migrations/{TIME STAMP}_InitialCreate.cs` file, which creates the database. The `{TIME STAMP}` placeholder in the preceding example is a time stamp.

```dotnetcli
dotnet ef database update
```

> [!NOTE]
> For SQLite, the column type for the `Price` field is set to `TEXT`. This is resolved in a later step.

:::zone-end

The following warning is displayed, which is addressed in a later step:

> :::no-loc text="No type was specified for the decimal column 'Price' on entity type 'Movie'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.":::

The database context `BlazorWebAppMovieContext`:

* Derives from <xref:Microsoft.EntityFrameworkCore.DbContext?displayProperty=fullName>.
* Specifies which entities are included in the data model.
* Coordinates EF Core functionality, such as CRUD operations, for the `Movie` model.
* Contains a <xref:Microsoft.EntityFrameworkCore.DbSet%601> property for the `Movie` entity set. In EF terminology, an entity set typically corresponds to a database table. An entity corresponds to a row in the table.

```csharp
public class BlazorWebAppMoviesContext : DbContext
{
    public BlazorWebAppMoviesContext(DbContextOptions<BlazorWebAppMoviesContext> options)
        : base(options)
    {
    }

    public DbSet<BlazorWebAppMovies.Models.Movie> Movie { get; set; } = default!;
}
```

The name of the connection string is passed in to the context by calling a method on a <xref:Microsoft.EntityFrameworkCore.DbContextOptions> object. For local development, the connection string is read from the `appsettings.json` file.

## Test the app

Run the app.

Add `/movies` to the URL in the browser's address bar to navigate to the movies `Index` page.

After the `Index` page loads, select the **`Create New`** link.

Add a movie to the database. In the following example, the classic sci-fi movie [*The Matrix*](https://www.warnerbros.com/movies/matrix) (&copy;1999 [Warner Bros. Entertainment Inc.](https://www.warnerbros.com/)) is added as the first movie entry. Selecting the **`Create`** button adds the movie to the database:

![Adding The Matrix movie to the database with the 'Create' component](~/blazor/tutorials/movie-database-app/part-2-model/_static/create-new.png)

When the app returns to the `Index` page, the added entity appears:

![The Matrix movie shown in the movies 'Index' page](~/blazor/tutorials/movie-database-app/part-2-model/_static/movie-added.png)

> [!NOTE]
> For globalization instructions, see [Show support jQuery validation for non-English locales that use a comma (",") for a decimal point (`dotnet/AspNetCore.Docs` #4076)](https://github.com/dotnet/AspNetCore.Docs/issues/4076#issuecomment-326590420).

Test the **`Edit`**, **`Details`**, and **`Delete`** links.

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Next steps

> [!div class="step-by-step"]
> [Previous: Create a Blazor Web App](xref:blazor/tutorials/movie-database/app)
> [Next: Learn about Razor components](xref:blazor/tutorials/movie-database/components)
