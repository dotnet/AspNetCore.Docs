### Built-in support for OpenAPI document generation

The [OpenAPI specification](https://www.openapis.org/) is a standard for describing HTTP APIs. The standard allows developers to define the shape of APIs that can be plugged into client generators, server generators, testing tools, documentation, and more. In .NET 9 Preview, ASP.NET Core provides built-in support for generating OpenAPI documents representing controller-based or minimal APIs via the [Microsoft.AspNetCore.OpenApi](https://nuget.org/packages/Microsoft.AspNetCore.OpenApi) package.

The following highlighted code calls:

- `AddOpenApi` to register the required dependencies into the app's DI container.
- `MapOpenApi` to register the required OpenAPI endpoints in the app's routes.

:::code language="csharp" source="~/release-notes/aspnetcore-9/samples/OpenApiExample/Program.cs" highlight="3,7":::

Install the [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) package in the project using the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```

Run the app and navigate to `openapi/v1.json` to view the generated OpenAPI document:

![OpenAPI document](~/release-notes/aspnetcore-9/_static/OpenApiDoc.png)

OpenAPI documents can also be generated at build-time by adding the [`Microsoft.Extensions.ApiDescription.Server`](https://www.nuget.org/packages/Microsoft.Extensions.ApiDescription.Server) package:

```dotnetcli
dotnet add package Microsoft.Extensions.ApiDescription.Server --prerelease
```

In the app's project file, add the following:

:::code language="xml" source="~/release-notes/aspnetcore-9/samples/OpenApiExample/OpenApiExample.csproj" range="9-12":::

Run `dotnet build` and inspect the generated JSON file in the project directory.

![OpenAPI document generation at build-time](~/release-notes/aspnetcore-9/_static/openapidoc2.png)

ASP.NET Core's built-in OpenAPI document generation provides support for various customizations and options. It provides document and operation transformers and has the ability to manage multiple OpenAPI documents for the same application.

To learn more about ASP.NET Core's new OpenAPI document capabilities, see [the new Microsoft.AspNetCore.OpenApi docs](https://aka.ms/aspnet/openapi).
