Add the following properties to the `Movie` class:

[!code-csharp[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Models/MovieNoEF.cs?name=snippet_MovieNoEF)]

The `ID` field is required by the database for the primary key. 

<a name="dc"></a>
### Add a database context class

Add a `DbContext` derived class named *MovieContext.cs* to the *Models* folder.

[!code-csharp[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Models/MovieContext.cs)]

The preceding code creates a `DbSet` property for the entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.

<a name="cs"></a>
### Add a database connection string

Add a connection string to the *appsettings.json* file.

[!code-json[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/appsettings_SQLite.json?highlight=8-10)]

<a name="reg"></a>
###  Register the database context

Register the database context with the [dependency injection](xref:fundamentals/dependency-injection) container in the *Startup.cs* file.

[!code-csharp[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Startup.cs?name=snippet_ConfigureServices2&highlight=3-6)]

Build the project to verify you don't have any errors.