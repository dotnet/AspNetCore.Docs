<a name="cli"></a>

## Perform initial migration

From the command line, run the following .NET Core CLI commands:

```dotnetcli
dotnet ef migrations add InitialCreate
dotnet ef database update
```

The `dotnet ef migrations add InitialCreate` command generates code to create the initial database schema. The schema is based on the model specified in the `DbContext` (In the *Models/MvcMovieContext.cs* file). The `Initial` argument is used to name the migrations. You can use any name, but by convention you choose a name that describes the migration. See [Introduction to migrations](xref:data/ef-mvc/migrations#introduction-to-migrations) for more information.

The `dotnet ef database update` command runs the `Up` method in the *Migrations/\<time-stamp>_InitialCreate.cs* file, which creates the database.
