<!-- delete all the model includes except this -->

Add the following properties to the `Movie` class:

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Models/Movie.cs?name=snippet1)]

The `Movie` class contains:

* The `ID` field is required by the database for the primary key.
* `[DataType(DataType.Date)]`:  The [DataType](/dotnet/api/microsoft.aspnetcore.mvc.dataannotations.internal.datatypeattributeadapter) attribute specifies the type of the data (Date). With this attribute:

  * The user is not required to enter time information in the date field.
  * Only the date is displayed, not time information.

[DataAnnotations](/dotnet/api/system.componentmodel.dataannotations) are covered in a later tutorial.

<a name="dc"></a>
### Add a database context class

Add the following *MovieContext.cs* class to the *Models* folder:  

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/snapshot_sample/RazorPagesMovie/Models/MovieContext.cs)]

The preceding code creates a `DbSet` property for the entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.

<a name="cs"></a>

### Add a database connection string

Add a connection string to the *appsettings.json* file:

[!code-json[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/appsettings_SQLite.json?highlight=8-10)]

### Entity Framework Core NuGet package for SQLite

Run the following .NET Core CLI command to add SQLite to the project:

```console
dotnet add package Microsoft.EntityFrameworkCore.SQLite
```

<a name="reg"></a>

### Register the database context

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in the *Startup.cs* file.

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie22/Startup.cs?name=snippet_UseSqlite&highlight=11-12)]

Add the following `using` statements at the top of *Startup.cs*:

```csharp
using RazorPagesMovie.Models;
using Microsoft.EntityFrameworkCore;
```

Build the project as a check for errors.