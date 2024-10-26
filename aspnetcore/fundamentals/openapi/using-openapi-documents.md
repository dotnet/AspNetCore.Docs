---
title: Use the generated OpenAPI documents
author: captainsafia
description: Learn how to use OpenAPI documents in an ASP.NET Core app.
ms.author: safia
monikerRange: '>= aspnetcore-6.0'
ms.custom: mvc
ms.date: 09/04/2024
uid: fundamentals/openapi/using-openapi-documents
---
# Use openAPI documents

:::moniker range=">= aspnetcore-9.0"

## Use Swagger UI for local ad-hoc testing

By default, the `Microsoft.AspNetCore.OpenApi` package doesn't ship with built-in support for visualizing or interacting with the OpenAPI document. Popular tools for visualizing or interacting with the OpenAPI document include [Swagger UI](https://swagger.io/tools/swaggerhub/) and [ReDoc](https://github.com/Redocly/redoc). Swagger UI and ReDoc can be integrated in an app in several ways. Editors such as Visual Studio and VS Code offer extensions and built-in experiences for testing against an OpenAPI document.

The `Swashbuckle.AspNetCore.SwaggerUi` package provides a bundle of Swagger UI's web assets for use in apps. This package can be used to render a UI for the generated document. To configure this:

* Install the `Swashbuckle.AspNetCore.SwaggerUi` package.
* Enable the swagger-ui middleware with a reference to the [OpenAPI route registered earlier](xref:fundamentals/openapi/aspnetcore-openapi#customize-the-openapi-endpoint-route).
* To limit information disclosure and security vulnerability, ***only enable Swagger UI in development environments.***

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_swaggerui)]

## Use Scalar for interactive API documentation

[Scalar](https://scalar.com/) is an open-source interactive document UI for OpenAPI. Scalar can integrate with the OpenAPI endpoint provided by ASP.NET Core. To configure Scalar, install the `Scalar.AspNetCore` package.

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_openapiwithscalar)]

## Lint generated OpenAPI documents with Spectral

[Spectral](https://stoplight.io/open-source/spectral) is an open-source OpenAPI document linter. Spectral can be incorporated into an app build to verify the quality of generated OpenAPI documents. Install Spectral according to the [package installation directions](https://github.com/stoplightio/spectral#-installation).

To take advantage of Spectral, install the `Microsoft.Extensions.ApiDescription.Server` package to enable build-time OpenAPI document generation.

Enable document generation at build time by setting the following properties in the app's `.csproj` file":

```xml
<PropertyGroup>
    <OpenApiDocumentsDirectory>$(MSBuildProjectDirectory)</OpenApiDocumentsDirectory>
    <OpenApiGenerateDocuments>true</OpenApiGenerateDocuments>
</PropertyGroup>
```

Run `dotnet build` to generate the document.

```dotnetcli
dotnet build
```

Create a `.spectral.yml` file with the following contents.

```text
extends: ["spectral:oas"]
```

Run `spectral lint` on the generated file.

```dotnetcli
spectral lint WebMinOpenApi.json
...

The output shows any issues with the OpenAPI document. For example:

```output
1:1  warning  oas3-api-servers       OpenAPI "servers" must be present and non-empty array.
3:10  warning  info-contact           Info object must have "contact" object.                        info
3:10  warning  info-description       Info "description" must be present and non-empty string.       info
9:13  warning  operation-description  Operation "description" must be present and non-empty string.  paths./.get
9:13  warning  operation-operationId  Operation must have "operationId".                             paths./.get

✖ 5 problems (0 errors, 5 warnings, 0 infos, 0 hints)
```
:::moniker-end

[!INCLUDE[](~/fundamentals/openapi/includes/using-openapi-documents-6-8.md)]
