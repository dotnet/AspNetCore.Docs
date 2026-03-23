---
title: Overview of OpenAPI support in ASP.NET Core API apps
ai-usage: ai-assisted
author: wadepickett
description: Learn how to integrate OpenAPI in ASP.NET Core API apps. Discover features, tools, and packages for generating and customizing OpenAPI documents.
monikerRange: '>= aspnetcore-6.0'
ms.author: wpickett
ms.reviewer: wpickett
ms.date: 03/20/2026
uid: fundamentals/openapi/overview
---
# OpenAPI support in ASP.NET Core API apps

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-10.0"

ASP.NET Core supports the generation of OpenAPI documents in controller-based and Minimal API apps.
The [OpenAPI specification](https://spec.openapis.org/oas/latest.html) is a programming language-agnostic standard for documenting HTTP APIs. ASP.NET Core apps support this standard through a combination of built-in APIs and open-source libraries. There are three key aspects to OpenAPI integration in an application:

* Generating information about the endpoints in the app.
* Gathering the information into a format that matches the OpenAPI schema.
* Exposing the generated OpenAPI document through a visual UI or a serialized file.

ASP.NET Core provides first-party support for generating information about endpoints in an app through the `Microsoft.AspNetCore.OpenApi` package.

The ASP.NET Core minimal web API template generates the following code that uses OpenAPI:

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_default&highlight=5,9-12)]

In the preceding highlighted code:

* `AddOpenApi` registers services required for OpenAPI document generation into the application's DI container.
* `MapOpenApi` adds an endpoint into the application for viewing the OpenAPI document serialized into JSON. The OpenAPI endpoint is restricted to the `Development` environment to minimize the risk of exposing sensitive information and reduce the vulnerabilities in production.

<a name="openapinuget"></a>

## `Microsoft.AspNetCore.OpenApi` NuGet package

The [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi/) package provides the following features:

* Support for generating OpenAPI documents at runtime and accessing them through an endpoint on the application.
* Support for "transformer" APIs that modify the generated document.

To use the `Microsoft.AspNetCore.OpenApi` package, add it as a PackageReference to a project file:

[!code-xml[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/projectFile.xml?highlight=15)]

To learn more about the `Microsoft.AspNetCore.OpenApi` package, see <xref:fundamentals/openapi/aspnetcore-openapi>.

## `Microsoft.Extensions.ApiDescription.Server` NuGet package

The [`Microsoft.Extensions.ApiDescription.Server`](https://www.nuget.org/packages/Microsoft.Extensions.ApiDescription.Server/) package supports generating OpenAPI documents at build time and serializing them.

To use `Microsoft.Extensions.ApiDescription.Server`, add it as a PackageReference to a project file.
Enable document generation at build time by setting the `OpenApiGenerateDocuments` property.
By default, the generated OpenAPI document is saved to the `obj` directory, but you can customize
the output directory by setting the `OpenApiDocumentsDirectory` property.

[!code-xml[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/projectFile.xml?highlight=9-12,16-19)]

<!-- Include makes it trivial to move this anywhere in the doc OR add to other docs-->
[!INCLUDE[](~/fundamentals/openapi/includes/api_endpoint_operation.md)]

## ASP.NET Core OpenAPI source code on GitHub

* [AddOpenApi](https://github.com/dotnet/aspnetcore/blob/main/src/OpenApi/src/Extensions/OpenApiServiceCollectionExtensions.cs)
* [OpenApiDocumentService](https://github.com/dotnet/aspnetcore/blob/main/src/OpenApi/src/Services/OpenApiDocumentService.cs)
* [OpenApiOptions](https://github.com/dotnet/aspnetcore/blob/main/src/OpenApi/src/Services/OpenApiOptions.cs)

## Additional Resources

* <xref:fundamentals/minimal-apis/security>

:::moniker-end

[!INCLUDE[](~/fundamentals/openapi/includes/overview-6-8.md)]
[!INCLUDE[](~/fundamentals/openapi/includes/overview-9.md)]
