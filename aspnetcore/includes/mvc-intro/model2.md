<a name="dc"></a>

::: moniker range=">= aspnetcore-3.0"
Add the following `MvcMovieContext` class to the *Data* folder:  

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie3/Data/MvcMovieContext.cs)]
::: moniker-end

::: moniker range="< aspnetcore-3.0"
Add the following `MvcMovieContext` class to the *Models* folder:  

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie22/Data/MvcMovieContext.cs)]
::: moniker-end

The preceding code creates a `DbSet` property for the entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.

<a name="cs"></a>

### Add a database connection string

Add a connection string to the *appsettings.json* file:

[!code-json[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/appsettings_SQLite.json?highlight=8-10)]

::: moniker range=">= aspnetcore-3.0"

### Add NuGet packages and EF tools

Run the following .NET Core CLI commands:

```console
dotnet tool install --global dotnet-ef --version 3.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.SQLite --version 3.0.0-*
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 3.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.0.0-*
```

The preceding commands add Entity Framework Core Tools for the .NET CLI and several packages to the project. The `Microsoft.VisualStudio.Web.CodeGeneration.Design` package is required for scaffolding.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

### Add required NuGet packages

Run the following .NET Core CLI command to add SQLite and CodeGeneration.Design  to the project:

```console
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

The `Microsoft.VisualStudio.Web.CodeGeneration.Design` package is required for scaffolding.
::: moniker-end

<a name="reg"></a>

### Register the database context

Add the following `using` statements at the top of *Startup.cs*:

```csharp
using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;
```

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in `Startup.ConfigureServices`.

::: moniker range=">= aspnetcore-3.0"
[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie30/Startup.cs?name=snippet_UseSqlite&highlight=6-7)]
::: moniker-end

::: moniker range="< aspnetcore-3.0"
[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie22/Startup.cs?name=snippet_UseSqlite&highlight=11-12)]
::: moniker-end

Build the project to check for compiler errors.