### Microsoft.AspNetCore.OpenApi supports trimming and Native AOT

The new built-in OpenAPI in ASP.NET Core supports trimming and Native AOT. The following steps create and publish an OpenAPI app with trimming and Native AOT:

Create a new ASP.NET Core Web API (Native AOT) project.

```console
dotnet new webapiaot
```

Add the Microsoft.AspNetCore.OpenAPI package.

```console
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```

Update `Program.cs` to enable generating OpenAPI documents.

```diff
+ builder.Services.AddOpenApi();

var app = builder.Build();

+ app.MapOpenApi();
```

Publish the app.

```console
dotnet publish
```
