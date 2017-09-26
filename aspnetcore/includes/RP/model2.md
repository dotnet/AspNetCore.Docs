Add the following properties to the `Movie` class:

[!code-csharp[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Models/MovieNoEF.cs?name=snippet_MovieNoEF)]

The `ID` field is required by the database for the primary key.

<a name="dc"></a>
### Add a database context class

Add a `DbContext` derived class named *MovieContext.cs* to the *Models* folder.

[!code-csharp[Main](../../tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie/Models/MovieContext.cs?range=1-12,14-17,19-21)]

The preceding code creates a `DbSet` property for the entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table. The `DbSet` property name is `Movies`. Since the database uses singular names, the sample overrides `OnModelCreating` to use the singular form (`Movie`) for the table name.
