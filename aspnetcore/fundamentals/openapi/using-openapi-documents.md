---
title: Use the generated OpenAPI documents
ai-usage: ai-assisted
author: wadepickett
description: Learn how to use OpenAPI documents in an ASP.NET Core app.
monikerRange: '>= aspnetcore-6.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 02/02/2026
uid: fundamentals/openapi/using-openapi-documents
---
# Use openAPI documents

:::moniker range=">= aspnetcore-10.0"

## Use Swagger UI for local ad-hoc testing

By default, the `Microsoft.AspNetCore.OpenApi` package doesn't ship with built-in support for visualizing or interacting with the OpenAPI document. Popular tools for visualizing or interacting with the OpenAPI document include [Swagger UI](https://swagger.io/tools/swaggerhub/) and [ReDoc](https://github.com/Redocly/redoc). Swagger UI and ReDoc can be integrated in an app in several ways. Editors such as Visual Studio and Visual Studio Code offer extensions and built-in experiences for testing against an OpenAPI document.

The `Swashbuckle.AspNetCore.SwaggerUi` package provides a bundle of Swagger UI's web assets for use in apps. This package can be used to render a UI for the generated document. To configure this:

* Install the `Swashbuckle.AspNetCore.SwaggerUi` package.
* Enable the swagger-ui middleware with a reference to the [OpenAPI route registered earlier](xref:fundamentals/openapi/aspnetcore-openapi#customize-the-openapi-endpoint-route).

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_swaggerui)]

As a security best practice on limiting information disclosure, ***OpenAPI user interfaces (Swagger UI, ReDoc, Scalar) should only be enabled in development environments.*** For example, see [Swagger OAuth 2.0 configuration](https://swagger.io/docs/open-source-tools/swagger-ui/usage/oauth2/).

Launch the app and navigate to `https://localhost:<port>/swagger` to view the Swagger UI.

To automatically launch the app at the Swagger UI URL using the `https` profile of `Properties/launchSettings.json`:

* Confirm that `launchBrowser` is enabled (`true`).
* Set the `launchUrl` to `swagger`.

```json
"launchBrowser": true,
"launchUrl": "swagger",
```

## Use Scalar for interactive API documentation

[Scalar](https://scalar.com/) is an open-source interactive document UI for OpenAPI. Scalar can integrate with the OpenAPI endpoint provided by ASP.NET Core. To configure Scalar, install the `Scalar.AspNetCore` package.

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_openapiwithscalar)]

Launch the app and navigate to `https://localhost:<port>/scalar` to view the Scalar UI.

To automatically launch the app at the Scalar UI URL using the `https` profile of `Properties/launchSettings.json`:

* Confirm that `launchBrowser` is enabled (`true`).
* Set the `launchUrl` to `scalar`.

```json
"launchBrowser": true,
"launchUrl": "scalar",
```

## Lint generated OpenAPI documents with Spectral

[Spectral](https://stoplight.io/open-source/spectral) is an open-source OpenAPI document linter. Spectral can be incorporated into an app build to verify the quality of generated OpenAPI documents. Install Spectral according to the [package installation directions](https://github.com/stoplightio/spectral#-installation).

To take advantage of Spectral for linting OpenAPI documents at build time, first install the `Microsoft.Extensions.ApiDescription.Server` package to enable build-time OpenAPI document generation.

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

## Support for injecting `IOpenApiDocumentProvider`

Inject <xref:Microsoft.AspNetCore.OpenApi.IOpenApiDocumentProvider> into services to access OpenAPI documents programmatically, even outside HTTP request contexts. The following example customizes version 2 ("`v2`") of the document with title, version, and description information:

```csharp
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

public class CustomDocumentService(
    [FromKeyedServices("v2")] IOpenApiDocumentProvider documentProvider)
{
    public async Task<OpenApiDocument> GetApiDocumentAsync(
            CancellationToken cancellationToken = default)
    {
        var document = 
            await documentProvider.GetOpenApiDocumentAsync(cancellationToken);

        document.Info = new OpenApiInfo
        {
            Title = "Custom API Title",
            Version = "v2",
            Description = "This is a custom API description for version 2."
        };

        return document;
    }
}
```

Register the service in your DI container. Note that the service key should match the document name passed to <xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi%2A>:

```csharp
builder.Services.AddOpenApi(); // Adds "v1" by default
builder.Services.AddOpenApi("v2");
builder.Services.AddScoped<CustomDocumentService>();
```

This enables scenarios such as generating client SDKs, validating API contracts in background processes, or exporting documents to external systems.

Support for injecting `IOpenApiDocumentProvider` was introduced in ASP.NET Core in .NET 10. For more information, see [dotnet/aspnetcore #61463](https://github.com/dotnet/aspnetcore/pull/61463).

:::moniker-end

[!INCLUDE[](~/fundamentals/openapi/includes/using-openapi-documents-6-8.md)]
[!INCLUDE[](~/fundamentals/openapi/includes/using-openapi-documents-9.md)]
