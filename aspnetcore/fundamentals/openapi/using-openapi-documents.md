---
title: Use the generated OpenAPI documents
author: captainsafia
description: Learn how to use OpenAPI documents in an ASP.NET Core app.
ms.author: safia
monikerRange: '>= aspnetcore-6.0'
ms.custom: mvc
ms.date: 08/04/2025
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

Launch the app and navigate to `https://localhost:<port>/scalar/v1` to view the Scalar UI.

To automatically launch the app at the Scalar UI URL using the `https` profile of `Properties/launchSettings.json`:

* Confirm that `launchBrowser` is enabled (`true`).
* Set the `launchUrl` to `scalar/v1`.

```json
"launchBrowser": true,
"launchUrl": "scalar/v1",
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

You can inject <xref:Microsoft.AspNetCore.OpenApi.Services.IOpenApiDocumentProvider> into your app through the dependency injection (DI) container to access the OpenAPI document, even outside the context of HTTP requests. This enables advanced scenarios, such as using OpenAPI documents in background services or custom middleware.

This capability streamlines tasks that previously required workarounds, such as using `HostFactoryResolver` with a no-op `IServer` implementation to run application startup logic without launching an HTTP server. The API is inspired by Aspire's `IDistributedApplicationPublisher`, part of the Aspire framework for distributed application hosting and publishing.

The following example demonstrates how to inject and use `IOpenApiDocumentProvider` in a background service:

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_iopenapidocumentprovider)]

In this example:

* `IOpenApiDocumentProvider` is injected into the background service constructor.
* The `GetOpenApiDocumentAsync` method is called to retrieve the OpenAPI document for a specific document name (in this case, "v1").
* The document can then be processed, saved, or used for other purposes outside of HTTP request processing.

This is particularly useful for scenarios such as:

* Generating client SDKs during application startup
* Validating API contracts in background processes
* Exporting OpenAPI documents to external systems
* Creating documentation or reports from the API specification

Support for injecting `IOpenApiDocumentProvider` was introduced in ASP.NET Core in .NET 10. For more information, see [dotnet/aspnetcore #61463](https://github.com/dotnet/aspnetcore/pull/61463).
:::moniker-end

[!INCLUDE[](~/fundamentals/openapi/includes/using-openapi-documents-6-8.md)]
[!INCLUDE[](~/fundamentals/openapi/includes/using-openapi-documents-9.md)]
