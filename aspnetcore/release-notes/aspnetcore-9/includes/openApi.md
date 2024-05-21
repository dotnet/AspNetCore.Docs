### Built-in support for OpenAPI document generation

The [OpenAPI specification](https://www.openapis.org/) is a standard for describing HTTP APIs. The standard allows developers to define the shape of APIs that can be plugged into client generators, server generators, testing tools, documentation, and more. In .NET 9 Preview, ASP.NET Core provides built-in support for generating OpenAPI documents representing controller-based or minimal APIs via the [Microsoft.AspNetCore.OpenApi](https://nuget.org/packages/Microsoft.AspNetCore.OpenApi) package.

Install the `Microsoft.AspNetCore.OpenApi` package in your web project using the following command:

```console
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```

:::code language="csharp" source="~release-notes/aspnetcore-9/samples/OpenApiExample/Program.cs" highlight="3,7":::


The preceding highlighted code calls:

- `AddOpenApi` to register the required dependencies into the app's DI container.
- `MapOpenApi` to register the required OpenAPI endpoints in the app's routes.

 Run the app and navigate to `openapi/v1.json` to view the generated OpenAPI document:


![OpenAPI document](~/release-notes/aspnetcore-9/_static/OpenApiDoc.png)

You can also generate OpenAPI documents at build-time using the `Microsoft.Extensions.ApiDescription.Server` package. Add the required dependency to your project:

```console
dotnet add package Microsoft.Extensions.ApiDescription.Server --prerelease
```

In your app's project file, add the following:

```xml
<PropertyGroup>
    <OpenApiDocumentsDirectory>$(MSBuildProjectDirectory)</OpenApiDocumentsDirectory>
    <OpenApiGenerateDocuments>true</OpenApiGenerateDocuments>
</PropertyGroup>
```

Then, run `dotnet build` and inspect the generated JSON file in your project directory.

![OpenAPI document generation at build-time](./media/openapi-doc-build.png)

ASP.NET Core's built-in OpenAPI document generation provides support for various customizations and options, including document and operation transformers and the ability to manage multiple OpenAPI documents for the same application.

To learn more about ASP.NET Core's new OpenAPI document capabilities, check out [the new Microsoft.AspNetCore.OpenApi docs](https://aka.ms/aspnet/openapi).