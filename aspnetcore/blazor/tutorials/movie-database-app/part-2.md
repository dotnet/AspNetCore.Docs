---
title: Build a Blazor movie database app (Part 2 - Add and scaffold a model)
author: guardrex
description: This part of the Blazor movie database app tutorial explains how to add a movie class to the app and scaffold the database and UI from the movie class.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/14/2024
uid: blazor/tutorials/movie-database-app/part-2
zone_pivot_groups: tooling
---
# Build a Blazor movie database app (Part 2 - Add and scaffold a model)

<!-- UPDATE 9.0 Activate after release

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article is the second part of the Blazor movie database app tutorial that teaches you the basics of building an ASP.NET Core Blazor Web App with features to manage a movie database.

In this part of the series:

* A class is added to the app representing a movie in a database.
* [Entity Framework Core (EF Core)](/ef/core) services and tooling create a database context and database. EF Core is an object-relational mapper (O/RM) that simplifies data access. You write model classes first, and EF Core creates the database from the model classes, which is called *scaffolding*.
* Tooling scaffolds a Razor component-based UI for interacting with the movie records in the database via the database context.

## Add a data model

:::zone pivot="vs"

In **Solution Explorer**, right-click the `BlazorWebAppMovies` project and select **Add** > **New Folder**. Name the folder `Models`.

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

* A record identifier property (`Id`), which is required by EF Core and the database to track records. In the database, the `Id` property is the database record's primary key.
* Other properties that describe aspects of a movie: the movie's title (`Title`), release date (`ReleaseDate`), genre (`Genre`), and price (`Price`). 

The question mark on a `string` type indicates that the property is nullable (it can hold a `null` value).

The EF Core database provider selects data types based on the .NET types of the model's properties. The provider also takes into account other metadata provided by *data annotations*. <xref:System.ComponentModel.DataAnnotations> are a set of attribute classes that define metadata about a model's properties. They're placed above a model's property with the following format, where the `{ANNOTATION}` placeholder is the annotation name:

```csharp
[{ANNOTATION}]
```

Multiple annotations can appear on multiple lines, or they can appear on the same line separated by commas:

```csharp
[{ANNOTATION_1}]
[{ANNOTATION_2}]
[{ANNOTATION_3}, {ANNOTATION_4}, [{ANNOTATION_5}]
```

In the `Movie` model, the `ReleaseDate` property has a [`[DataType]` attribute](xref:System.ComponentModel.DataAnnotations.DataTypeAttribute) to specify an additional type to associate with `ReleaseDate`. In this case, the type of data is a date (<xref:System.ComponentModel.DataAnnotations.DataType.Date?displayProperty=nameWithType>):

```csharp
[DataType(DataType.Date)]
public DateTime ReleaseDate { get; set; }
```

Add the following two data annotation attributes immediately above the `Price` property:

```csharp
[DataType(DataType.Currency)]
[Column(TypeName = "decimal(18, 2)")]
```

The `Price` property in the `Movie` class file after adding the data annotations:

```csharp
[DataType(DataType.Currency)]
[Column(TypeName = "decimal(18, 2)")]
public decimal Price { get; set; }
```

These annotations:

* Specify that the property holds a currency data type.
* Specifies the database column as a decimal of 18 digits with two decimal places.

More information on data annotations, including adding data annotations for validation, is covered in a later part of the tutorial series.

:::zone pivot="vs"

Select **Build** > **Build Solution** from the menu bar or press <kbd>F6</kbd> on the keyboard. Confirm in the **Output** panel that the build succeeded.

:::zone-end

:::zone pivot="vsc"

To add the required NuGet packages and tools, execute the following .NET CLI commands in the **Terminal** (**Terminal** menu > **New Terminal**).

<!-- REVIEWER NOTE

The following mirrors the RP/MVC tutorial approach for showing multiple
commands by placing them all into one code block.

Problem: The readers were copy-pasting all of them at once into
a command prompt/PS prompt. The last command doesn't run but
just sits on the prompt. Thinking they're done, the reader moves
on. Later, they hit an unexpected error because the last command
didn't execute.

This behavior of not executing the last command when
multiple commands are pasted is the same for both Powershell
and command shell prompts (on Windows anyway; not sure about 
macOS Terminal app).

This happened so many times to the team for database migrations
that they sprinkled in about eight or nine little messages in 
later docs of each series telling devs the error language and 
that they missed updating their database. IMO, that's not the
best way to go with the guidance.

I prefer to separate commands, and that's what I've done for 
database migration steps in this series. However, I'm going to 
leave the following block of commands here with a remark that 
they should be executed one at a time. If devs still open issues
because Microsoft.EntityFrameworkCore.Tools isn't getting 
installed due to them not following my guidance, then I'll
separate these commands to force the reader to run them one
at a time.

-->

***The following commands must be executed one at a time***. Do ***not*** paste all of the commands into the **Terminal** at once.

```powershell
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
* [`aspnet-codegenerator` scaffolding tool](xref:fundamentals/tools/dotnet-aspnet-codegenerator)
* Design time tools for EF Core
* The SQLite and SQL Server providers with the EF Core package as a dependency
* [`Microsoft.VisualStudio.Web.CodeGeneration.Design`](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design) for scaffolding

By default, the .NET binaries architecture installed represents the currently running OS architecture. To specify a different OS architecture, see [`dotnet tool install` (`--arch option`)](/dotnet/core/tools/dotnet-tool-install#options).

In the **Terminal**, build the app:

```powershell
dotnet build
```

Confirm that the app built successfully.

:::zone-end

:::zone pivot="cli"

To add the required NuGet packages and tools, execute the following .NET CLI commands in a command shell opened to the project's root folder.

***The following commands must be executed one at a time***. Do ***not*** paste all of the commands into the command shell at once.

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
* [`aspnet-codegenerator` scaffolding tool](xref:fundamentals/tools/dotnet-aspnet-codegenerator)
* Design time tools for EF Core
* The SQLite and SQL Server providers with the EF Core package as a dependency
* [`Microsoft.VisualStudio.Web.CodeGeneration.Design`](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design) for scaffolding

By default, the .NET binaries architecture installed represents the currently running OS architecture. To specify a different OS architecture, see [`dotnet tool install` (`--arch option`)](/dotnet/core/tools/dotnet-tool-install#options).

In a command shell opened to the project's root folder, execute the [`dotnet build`](/dotnet/core/tools/dotnet-build) command:

```dotnetcli
dotnet build
```

Confirm that the app built successfully.

:::zone-end

## Scaffold the model

In this section, the `Movie` model is *scaffolded* into a database, database context, and a UI for managing movies in the database. .NET scaffolding is a code generation framework for .NET applications. You add scaffolding to your project when you want to quickly add code that interacts with data models.

:::zone pivot="vs"

Right-click on the `Components/Pages` folder and select **Add** > **New Scaffolded Item**.

![New Scaffolded Item](~/blazor/tutorials/movie-database-app/part-2/_static/new-scaffolded-item.png)

In the **Add New Scaffold** dialog open to **Installed** > **Common** > **Razor Component**, select **Razor Components using Entity Framework (CRUD)** > **Add**.

*CRUD* is an acronym for Create, Read, Update, and Delete. The template produces create, edit, delete, details, and index components for the app.

![Scaffold item](~/blazor/tutorials/movie-database-app/part-2/_static/install-common-razor-component.png)

Complete the **Add Razor Components using Entity Framework (CRUD)** dialog:

* In the **Model class** dropdown list, select **Movie (BlazorWebAppMovies.Models)**.
* For **DbContext class**, select the **+** (plus sign) button.
* In the **Add Data Context** modal dialog, the class name `BlazorWebAppMovies.Data.BlazorWebAppMoviesContext` is generated. Use the default generated value. Select the **Add** button.
* After the model dialog closes, the **Database provider** dropdown list defaults to **SQL Server**. Use the default selected value.
* Select **Add**.

![Add Razor components using EF CRUD dialog](~/blazor/tutorials/movie-database-app/part-2/_static/add-razor-components-using-ef-crud.png)

:::zone-end

:::zone pivot="vsc"

In the **Terminal** (**Terminal** menu > **New Terminal**) opened to the project's root directory, execute the following command. SQLite is used as the database for users adopting VS Code tooling for this tutorial series.

```powershell
dotnet aspnet-codegenerator crud --dbProvider sqlite -dc BlazorWebAppMovies.Data.BlazorWebAppMovies -m Movie -outDir Components/Pages -udl
```

*CRUD* is an acronym for Create, Read, Update, and Delete. The `crud` template produces create, edit, delete, details, and index components for the app.

The following table details the ASP.NET Core code generator options used in the preceding command:

* `--dbProvider`: Database provider to use. Options include `sqlserver` (default), `sqlite`, `cosmos`, `postgres`.
* `-dc`: The `DbContext` class to use, including the namespace.
* `-m`: The name of the model.
* `-outDir`: The output directory for the generated components. A folder is created from the model name in the output directory to hold the components (for example, `MoviePages`).
* `-udl`: Indicates that the default layout should be used.

:::zone-end

:::zone pivot="cli"

In a command shell opened to the project's root folder, execute the following command. SQLite is used as the database for users adopting VS Code tooling for this tutorial series.

```dotnetcli
dotnet aspnet-codegenerator crud --dbProvider sqlite -dc BlazorWebAppMovies.Data.BlazorWebAppMovies -m Movie -outDir Components/Pages -udl
```

*CRUD* is an acronym for Create, Read, Update, and Delete. The `crud` template produces create, edit, delete, details, and index components for the app.

The following table details the ASP.NET Core code generator options used in the preceding command:

* `--dbProvider`: Database provider to use. Options include `sqlserver` (default), `sqlite`, `cosmos`, `postgres`.
* `-dc`: The `DbContext` class to use, including the namespace.
* `-m`: The name of the model.
* `-outDir`: The output directory for the generated components. A folder is created from the model name in the output directory to hold the components (for example, `MoviePages`).
* `-udl`: Indicates that the default layout should be used.

:::zone-end

The `appsettings.json` file is updated with the connection string used to connect to a local database. In the following example, the `{CONNECTION STRING}` is the connection string generated automatically by the scaffolder:

```json
"ConnectionStrings": {
  "BlazorWebAppMoviesContext": "{CONNECTION STRING}"
}
```

## Files created and updated

The scaffolding process creates the following component files and movie database context class file:

* `Components/Pages/MoviePages`
  * `Create.razor`: Creates new movie entities.
  * `Delete.razor`: Deletes a movie entity.
  * `Details.razor`: Shows movie entity details.
  * `Edit.razor`: Updates a movie entity.
  * `Index.razor`: Lists movie entities (records) in the database.
* `Data/BlazorWebAppMovieContext.cs`: Database context file (<xref:Microsoft.EntityFrameworkCore.DbContext>).

The component files in the `MoviePages` folder are described in greater detail the next part of this tutorial. The database context is described later in this article.

ASP.NET Core is built with [dependency injection](xref:fundamentals/dependency-injection). Services, such as the EF Core database context, are registered with dependency injection during application startup. These services are injected into Razor components.

The <xref:Microsoft.AspNetCore.Components.QuickGrid> component is a Razor component for efficiently displaying data in tabular form. The scaffolder places a <xref:Microsoft.AspNetCore.Components.QuickGrid> component in the `Index` component (`Components/Pages/Index.razor`) to display movie entities. Calling <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkAdapterServiceCollectionExtensions.AddQuickGridEntityFrameworkAdapter%2A> on the service collection adds an EF Core adapter for <xref:Microsoft.AspNetCore.Components.QuickGrid> to recognize EF-supplied <xref:System.Linq.IQueryable%601> instances and to resolve database queries asynchronously for efficiency. To supply this EF Core adapter, the scaffolder automatically adds the [`Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter) NuGet package to the app.

The following code is added to the `Program` file by the scaffolder:

```csharp
builder.Services.AddDbContext<BlazorWebAppMoviesContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? 
        throw new InvalidOperationException(
            "Connection string 'BlazorWebAppMoviesContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();
```

Static server-side rendering (static SSR) is enabled by calling:

* The service collection extension method <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A> to register services for server-side rendering (SSR) of Razor components.
* The request pipeline extension method <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A>, which maps the page components defined in the `App` component to the given assembly and renders the `App` component when the route matches:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

...

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

To only adopt static SSR, <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A> is the only extension method required. As you can see in the preceding example, scaffolding enables interactive SSR. The app isn't required to adopt interactive SSR just because this extension method is called, and the tutorial doesn't require it for the next several articles, but the app is capable of adopting interactive SSR. In the last part of the tutorial series on interactivity, the app is modified to adopt interactive SSR, and that's when calling <xref:Microsoft.Extensions.DependencyInjection.ServerRazorComponentsBuilderExtensions.AddInteractiveServerComponents%2A> is required. For now, we'll leave the call in place.

<xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> configures the app to support interactive SSR with the Blazor SignalR&dagger; hub. The call to <xref:Microsoft.AspNetCore.Builder.ServerRazorComponentsEndpointConventionBuilderExtensions.AddInteractiveServerRenderMode%2A> also isn't required for the next several articles. The call only enables interactive features for the app's SignalR hub. We'll also leave this call in place.

&dagger;*SignalR* is a library that simplifies adding real-time web functionality to apps. Real-time web functionality enables server-side code to push content to clients instantly. An interactive Blazor app uses a SignalR "hub" to communicate with code running on client devices.

## Create the initial database schema using EF Core's migration feature

The migrations feature in EF Core:

* Creates the initial database schema.
* Incrementally updates the database schema to keep it synchronized with the app's data model. Existing data in the database is preserved.

EF Core adopts the *code-first* approach for database design and maintenance:

* Entity classes are created and updated first in the app.
* The database is created and updated from the app's entity classes.

This is the reverse procedure of *database-first* approaches, where the database is designed, built, and updated first. Adopting EF Core's code-first approach speeds up the process of app development because most of the difficult and time-consuming database creation and management is handled transparently by the EF Core tooling, so you can focus on app development.

:::zone pivot="vs"

In this section, the **Package Manager Console** (PMC) window is used to:

* Add an initial migration.
* Update the database with the initial migration.

To open the PMC from the **Tools** menu, select **NuGet Package Manager** > **Package Manager Console** (PMC).

<!-- REVIEWER NOTE

The following is an example delta between RP/MVC tutorials
and my approach for dealing with PS/command shell multiple
commands. I separate them to make sure the dev isn't pasting
multiple commands into the prompt and failing to execute the 
last command before they proceed.

-->

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

Right-click the `BlazorWebAppMovies` project file (`BlazorWebAppMovies.csproj`) and select **Open in Integrated Terminal**.

The **Terminal** window opens with the command prompt at the project directory, which contains the `Program` file and the app's project file (`.csproj`).

Execute the following .NET CLI command to add an initial migration. The `migrations` command generates code to create the initial database schema. The schema is based on the model specified in `DbContext`. The `InitialCreate` argument is used to name the migration. Any name can be used, but the convention is to use a name that describes the migration.

```powershell
dotnet ef migrations add InitialCreate
```

After the preceding command completes, update the database with the `update` command. The `update` command executes the `Up` method in migrations that have not been applied. In this case, the command executes the `Up` method in the `Migrations/{TIME STAMP}_InitialCreate.cs` file, which creates the database. The `{TIME STAMP}` placeholder in the preceding example is a time stamp.

```powershell
dotnet ef database update
```

:::zone-end

:::zone pivot="cli"

From the project's root folder, execute the following .NET CLI command to add an initial migration. The `migrations` command generates code to create the initial database schema. The schema is based on the model specified in `DbContext`. The `InitialCreate` argument is used to name the migration. Any name can be used, but the convention is to use a name that describes the migration.

```dotnetcli
dotnet ef migrations add InitialCreate
```

After the preceding command completes, update the database with the `update` command. The `update` command executes the `Up` method in migrations that have not been applied. In this case, the command executes the `Up` method in the `Migrations/{TIME STAMP}_InitialCreate.cs` file, which creates the database. The `{TIME STAMP}` placeholder in the preceding example is a time stamp.

```dotnetcli
dotnet ef database update
```

:::zone-end

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

![Adding The Matrix movie to the database with the 'Create' component](~/blazor/tutorials/movie-database-app/part-2/_static/create-new.png)

When the app returns to the `Index` page, the added entity appears:

![The Matrix movie shown in the movies 'Index' page](~/blazor/tutorials/movie-database-app/part-2/_static/movie-added.png)

> [!NOTE]
> For globalization instructions, see [Show support jQuery validation for non-English locales that use a comma (",") for a decimal point (`dotnet/AspNetCore.Docs` #4076)](https://github.com/dotnet/AspNetCore.Docs/issues/4076#issuecomment-326590420).

Test the **`Edit`**, **`Details`** pages. Use the **`Delete`** page to delete the movie from the database. New movies are added to the database in a later part of the tutorial series.

## Stop the app

:::zone pivot="vs"

Stop the app using either of the following approaches:

* Close the browser window.
* In Visual Studio, either:
  * Use the Stop button in Visual Studio's menu bar.
  * Press <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard.

:::zone-end

:::zone pivot="vsc"

Stop the app using the following approach:

1. Close the browser window.
1. In VS Code, either:
   * From the **Run** menu, select **Stop Debugging**.
   * Press <kbd>Shift</kbd>+<kbd>F5</kbd> on the keyboard.

:::zone-end

:::zone pivot="cli"

Stop the app using the following approach:

1. Close the browser window.
2. From the command shell, press <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS).

:::zone-end

## Troubleshoot with the completed sample

[!INCLUDE[](~/blazor/tutorials/movie-database-app/includes/troubleshoot.md)]

## Additional resources

EF Core documentation:

* [Entity Framework Core](/ef/core/)
* [Entity Framework Core tools reference - .NET Core CLI](/ef/core/cli/dotnet)
* [Data Types](/ef/core/modeling/relational/data-types)
* [Environment-based `Startup` class and methods](xref:fundamentals/environments#environment-based-startup-class-and-methods)
* [`dotnet aspnet-codegenerator`](xref:fundamentals/tools/dotnet-aspnet-codegenerator)
* <xref:blazor/components/quickgrid>

## Legal

[*The Matrix*](https://www.warnerbros.com/movies/matrix) is a trademark and copyright of [Warner Bros. Entertainment Inc.](https://www.warnerbros.com/).

## Next steps

> [!div class="step-by-step"]
> [Previous: Create a Blazor Web App](xref:blazor/tutorials/movie-database-app/part-1)
> [Next: Learn about Razor components](xref:blazor/tutorials/movie-database-app/part-3)
