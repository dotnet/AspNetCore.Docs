<a name="sqlite-dev"></a>
### Use SQLite for development, SQL Server for production

When SQLite is selected, the template generated code is ready for development. The following code shows how to inject <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> into `Startup`. `IWebHostEnvironment` is injected so `ConfigureServices` can use SQLite in development and SQL Server in production.

[!code-csharp[](~/includes/RP/code/StartupDevProdV5.cs?name=snippet&highlight=5,10,14)]
