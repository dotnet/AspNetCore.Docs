<a name="dc"></a>

### Add a database context class

In the RazorPagesMovie project, create a new folder called *Data*. 
Add the following `RazorPagesMovieContext` class to the *Data* folder:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie30/Data/RazorPagesMovieContext.cs)]

The preceding code creates a `DbSet` property for the entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table. The code won't compile until dependencies are added in a later step.

<a name="cs"></a>

### Add a database connection string

Add a connection string to the *appsettings.json* file as shown in the following highlighted code:

::: moniker range=">= aspnetcore-3.0"

[!code-json[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie30/appsettings_SQLite.json?highlight=10-12)]

### Add NuGet packages and EF tools

[!INCLUDE[](~/includes/add-EF-NuGet-SQLite-CLI.md)]

<a name="reg"></a>

### Register the database context

Add the following `using` statements at the top of *Startup.cs*:

```csharp
using RazorPagesMovie.Data;
using Microsoft.EntityFrameworkCore;
```

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in `Startup.ConfigureServices`.

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie30/Startup.cs?name=snippet_UseSqlite&highlight=11-12)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-json[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/appsettings_SQLite.json?highlight=8-9)]

### Add required NuGet packages

Run the following .NET Core CLI command to add SQLite and CodeGeneration.Design to the project:

```dotnetcli
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
```

The `Microsoft.VisualStudio.Web.CodeGeneration.Design` package is required for scaffolding.

<a name="reg"></a>

### Register the database context

Add the following `using` statements at the top of *Startup.cs*:

```csharp
using RazorPagesMovie.Models;
using Microsoft.EntityFrameworkCore;
```

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in `Startup.ConfigureServices`.

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Startup.cs?name=snippet_UseSqlite&highlight=11-12)]

Build the project as a check for errors.

::: moniker-end
