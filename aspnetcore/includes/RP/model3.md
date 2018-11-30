<a name="cli"></a>

## Add scaffold tooling and perform initial migration

Add the following lines to the *RazorPagesMovie.csproj* file, just before the closing `</Project>` tag:

```xml
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.1.0-preview1-final"/>
</ItemGroup>
```
  
From the command line, run the following .NET Core CLI commands:

```console
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```

The `DotNetCliToolReference` element and the `add package` command install the tooling required to run the scaffolding engine.

The `ef migrations add InitialCreate` command generates code to create the initial database schema. The schema is based on the model specified in the `DbContext` (In the *Models/MovieContext.cs* file). The `InitialCreate` argument is used to name the migrations. You can use any name, but by convention you choose a name that describes the migration. See [Introduction to migrations](xref:data/ef-mvc/migrations#introduction-to-migrations) for more information.

The `ef database update` command runs the `Up` method in the *Migrations/\<time-stamp>_InitialCreate.cs* file, which creates the database.
