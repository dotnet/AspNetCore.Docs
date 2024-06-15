---
title: Get started with Microsoft.AspNetCore.OpenApi
author: captainsafia
description: Learn how to generate and customize OpenAPI documents in an ASP.NET Core app
ms.author: safia
monikerRange: '>= aspnetcore-9.0'
ms.custom: mvc
ms.date: 5/22/2024
uid: fundamentals/minimal-apis/aspnetcore-openapi
---
# Get started with Microsoft.AspNetCore.OpenApi

The [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) package provides built-in support for OpenAPI document generation in ASP.NET Core. The package:

* Is compatible with native AoT.
* Takes advantage of JSON schema support provided by [`System.Text.Json`](/dotnet/api/system.text.json).
* Provides a [transformers](#transformers) API for modifying generated documents.
* Supports managing multiple OpenAPI documents within a single app.

## Package installation

Install the `Microsoft.AspNetCore.OpenApi` package:

### [Visual Studio](#tab/visual-studio)

Run the following command from the **Package Manager Console**:

 ```powershell
 Install-Package Microsoft.AspNetCore.OpenApi -IncludePrerelease
```

### [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```dotnetcli
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```

### [.NET CLI](#tab/net-cli)

Run the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```
---

## Configure OpenAPI document generation

The following code:

* Adds OpenAPI services.
* Enables the endpoint for viewing the OpenAPI document in JSON format.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_first&highlight=3,7)]

Launch the app and navigate to `https://localhost:<port>/openapi/v1.json` to view the generated OpenAPI document.

### The importance of document names

Each OpenAPI document in an app has a unique name. The default document name that is registered is `v1`.

```csharp
builder.Services.AddOpenApi(); // Document name is v1
```

The document name can be modified by passing the name as a parameter to the `AddOpenApi` call.

```csharp
builder.Services.AddOpenApi("internal"); // Document name is internal
```

The document name surfaces in several places in the OpenAPI implementation.

When fetching the generated OpenAPI document, the document name is provided as the `documentName` parameter argument in the request. The following requests resolve the `v1` and `internal` documents.

```bash
GET http://localhost:5000/openapi/v1.json
GET http://localhost:5000/openapi/internal.json
```

## Options to Customize OpenAPI document generation

The following sections demonstrate how to customize OpenAPI document generation.

### Customize the OpenAPI version of a generated document

By default, OpenAPI document generation creates a document that is compliant with [v3.0 of the OpenAPI specification](https://spec.openapis.org/oas/v3.0.0). The following code demonstrates how to modify the default version of the OpenAPI document:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;
});
```

### Customize the OpenAPI endpoint route

By default, the OpenAPI endpoint registered via a call to `MapOpenApi` exposes the document at the `/openapi/{documentName}.json` endpoint. The following code demonstrates how to customize the route at which the OpenAPI document is registered:

```csharp
app.MapOpenApi("/openapi/{documentName}/openapi.json");
```

***Note:*** It's possible, but not recommended, to remove the `documentName` route parameter from the endpoint route. When the `documentName` route parameter is removed from the endpoint route, the framework attempts to resolve the document name from the query parameter. Not providing the `documentName` in either the route or query can result in unexpected behavior.

### Customize the OpenAPI endpoint

Because the OpenAPI document is served via a route handler endpoint, any customization that is available to standard minimal endpoints is available to the OpenAPI endpoint.

### Customize OpenAPI endpoints with endpoint metadata

The following list shows the endpoint metadata that is used to customize the generated OpenAPI document:

* Summaries from <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointSummaryMetadata>
* Descriptions from <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointDescriptionMetadata>
* Request body from <xref:Microsoft.AspNetCore.Http.Metadata.IAcceptsMetadata>
* Response information from <xref:Microsoft.AspNetCore.Http.Metadata.IProducesResponseTypeMetadata>
* Operation IDs from <xref:Microsoft.AspNetCore.Routing.IEndpointNameMetadata>
* OpenAPI tags from <xref:Microsoft.AspNetCore.Http.Metadata.ITagsMetadata>

To learn more about customizing the generated OpenAPI document by modifying endpoint metadata, see <xref:fundamentals/minimal-apis/openapi>.

#### Limit OpenAPI document access to authorized users

The OpenAPI endpoint  doesn't enable any authorization checks by default. However, it's possible to limit access to the OpenAPI document. For example, in the following code, access to the OpenAPI document is limited to those with the `tester` role:

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_mapopenapiwithauth)]

#### Cache generated OpenAPI document

The OpenAPI document is regenerated every time a request to the OpenAPI endpoint is sent. Regeneration enables transformers to incorporate dynamic application state into their operation. For example, regenerating a request with details of the HTTP context. When applicable, the OpenAPI document can be cached to avoid executing the document generation pipeline on each HTTP request.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_mapopenapiwithcaching)]

<a name="transformers"></a>

## OpenAPI document transformers

This section demonstrates how to customize OpenAPI documents with transformers.

### Customize OpenAPI documents with transformers

Transformers provide an API for modifying the OpenAPI document with user-defined customizations. Transformers are useful for scenarios like:

* Adding parameters to all operations in a document.
* Modifying descriptions for parameters or operations.
* Adding top-level information to the OpenAPI document.

Transformers fall into two categories:

* Document transformers have access to the entire OpenAPI document. These can be used to make global modifications to the document.
* Operation transformers apply to each individual operation. Each individual operation is a combination of path and HTTP method. These can be used to modify parameters or responses on endpoints.

Transformers can be registered onto the document via the `UseTransformer` call on the `OpenApiOptions` object. The following snippet shows different ways to register transformers onto the document:

* Register a document transformer using a delegate.
* Register a document transformer using an instance of `IOpenApiDocumentTransformer`.
* Register a document transformer using a DI-activated `IOpenApiDocumentTransformer`.
* Register an operation transformer using a delegate.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_transUse&highlight=8-13)]

### Execution order for transformers

Transformers execute in first-in first-out order based on registration. In the following snippet, the document transformer has access to the modifications made by the operation transformer:

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_transInOut&highlight=3-9)]

### Use document transformers

Document transformers have access to a context object that includes:

* The name of the document being modified.
* The list of `ApiDescriptionGroups` associated with that document.
* The `IServiceProvider` used in document generation.

Document transformers also can mutate the OpenAPI document that is generated. The following example demonstrates a document transformer that adds some information about the API to the OpenAPI document.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_documenttransformer1)]

Service-activated document transformers can utilize instances from DI to modify the app. The following sample demonstrates a document transformer that uses the `IAuthenticationSchemeProvider` service from the authentication layer. It checks if any JWT bearer-related schemes are registered in the app and adds them to the OpenAPI document's top level:

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_documenttransformer2)]

Document transformers are unique to the document instance they're associated with. In the following example, a transformer:

* Registers authentication-related requirements to the `internal` document.
* Leaves the `public` document unmodified.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_multidoc_operationtransformer1)]

### Use operation transformers

Operations are unique combinations of HTTP paths and methods in an OpenAPI document. Operation transformers are helpful when a modification:

* Should be made to each endpoint in an app, or
* Conditionally applied to certain routes.

Operation transformers have access to a context object which contains:

* The name of the document the operation belongs to.
* The `ApiDescription` associated with the operation.
* The `IServiceProvider` used in document generation.

For example, the following operation transformer adds `500` as a response status code supported by all operations in the document.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_operationtransformer1)]

## Using the generated OpenAPI document

OpenAPI documents can plug into a wide ecosystem of existing tools for testing, documentation, and local development.

### Using Swagger UI for local ad-hoc testing

By default, the `Microsoft.AspNetCore.OpenApi` package doesn't ship with built-in support for visualizing or interacting with the OpenAPI document. Popular tools for visualizing or interacting with the OpenAPI document include [Swagger UI](https://swagger.io/tools/swaggerhub/) and [ReDoc](https://github.com/Redocly/redoc). Swagger UI and ReDoc can be integrated in an app in several ways. Editors such as Visual Studio and VS Code offer extensions and built-in experiences for testing against an OpenAPI document.

The `Swashbuckle.AspNetCore.SwaggerUi` package provides a bundle of Swagger UI's web assets for use in apps. This package can be used to render a UI for the generated document. To configure this, install the `Swashbuckle.AspNetCore.SwaggerUi` package.

Enable the swagger-ui middleware with a reference to the OpenAPI route registered earlier. To limit information disclosure and security vulnerability, ***only enable Swagger UI in development environments.***

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_swaggerui)]

### Using Scalar for interactive API documentation

[Scalar](https://scalar.com/) is an open-source interactive document UI for OpenAPI. Scalar can integrate with the OpenAPI endpoint provided by ASP.NET Core. To configure Scalar, install the `Scalar.AspNetCore` package.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_openapiwithscalar)]

### Lint generated OpenAPI documents with Spectral

[Spectral](https://stoplight.io/open-source/spectral) is an open-source OpenAPI document linter. Spectral can be incorporated into an app build to verify the quality of generated OpenAPI documents. Install Spectral according to the [package installation directions](https://github.com/stoplightio/spectral#-installation).

To take advantage of Spectral, install the `Microsoft.Extensions.ApiDescription.Server` package to enable build-time OpenAPI document generation.

Enable document generation at build time by setting the following properties in your app's `.csproj` file":

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

The output shows any issues with the OpenAPI document.

```output
1:1  warning  oas3-api-servers       OpenAPI "servers" must be present and non-empty array.
3:10  warning  info-contact           Info object must have "contact" object.                        info
3:10  warning  info-description       Info "description" must be present and non-empty string.       info
9:13  warning  operation-description  Operation "description" must be present and non-empty string.  paths./.get
9:13  warning  operation-operationId  Operation must have "operationId".                             paths./.get

✖ 5 problems (0 errors, 5 warnings, 0 infos, 0 hints)
```
