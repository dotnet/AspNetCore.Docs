### Microsoft.AspNetCore.OpenApi supports trimming and Native AOT

The new built-in OpenAPI support in ASP.NET Core now also supports trimming and Native AOT.

### Get started

Create a new ASP.NET Core Web API (native AOT) project.

```console
dotnet new webapiaot
```

Add the Microsoft.AspNetCore.OpenAPI package.

```console
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```

For this preview, you also need to add the latest Microsoft.OpenAPI package to avoid trimming warnings.

```console
dotnet add package Microsoft.OpenApi
```

Update *Program.cs* to enable generating OpenAPI documents.

```diff
+ builder.Services.AddOpenApi();

var app = builder.Build();

+ app.MapOpenApi();
```

Publish the app.

```console
dotnet publish
```

The app publishes using Native AOT without warnings.
