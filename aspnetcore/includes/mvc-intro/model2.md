<a name="dc"></a>
* Add a new folder named *Data* 
* Add the following `MvcMovieContext` class in *Data/MvcMovieContext.cs*:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie22/Data/MvcMovieContext.cs)]

The preceding code creates a `DbSet` property for the entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.

<a name="cs"></a>

### Add a database connection string

Add a connection string to the *appsettings.json* file:

[!code-json[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/appsettings_SQLite.json?highlight=8-10)]

### Add required NuGet packages

Run the following .NET Core CLI command to add SQLite and CodeGeneration.Design  to the project:

```console
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

The `Microsoft.VisualStudio.Web.CodeGeneration.Design` package is required for scaffolding.

<a name="reg"></a>

### Register the database context

Add the following `using` statements at the top of *Startup.cs*:

```csharp
using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;
```

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in `Startup.ConfigureServices`.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie22/Startup.cs?name=snippet_UseSqlite&highlight=11-12)]

Build the project as a check for errors.
