<a name="cli"></a>
## Add scaffold tooling and perform initial migration

From the command line, run the following .NET Core CLI commands:

```console
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```

The `add package` command installs the tooling required to run the scaffolding engine.

The `ef migrations add InitialCreate` command generates code to create the initial database schema. The schema is based on the model specified in the `DbContext` (In the *Models/MovieContext.cs* file). The `Initial` argument is used to name the migrations. You can use any name, but by convention you choose a name that describes the migration. See [Introduction to migrations](xref:data/ef-mvc/migrations#introduction-to-migrations) for more information.

The `ef database update` command runs the `Up` method in the *Migrations/\<time-stamp>_InitialCreate.cs* file, which creates the database.