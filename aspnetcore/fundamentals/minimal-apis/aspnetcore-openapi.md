---
title: Get started with Microsoft.AspNetCore.OpenApi
author: captainsafia
description: Learn how to generate and customize OpenAPI documents in an ASP.NET Core application
ms.author: safia
monikerRange: '>= aspnetcore-9.0'
ms.custom: mvc
ms.date: 05/10/2024
uid: fundamentals/minimal-apis/aspnetcore-openapi
---
# Get started with Microsoft.AspNetCore.OpenApi

The `Microsoft.AspNetCore.OpenApi` package provides built-in support for OpenAPI document generation in ASP.NET Core. The package is:

* Compatible with native AoT.
* Takes advantage of JSON schema support provided by `System.Text.Json`.
* Provides a transformers API for modifying generated documents.
* Supports managing multiple OpenAPI documents within a single application.

## Package installation

The `Microsoft.AspNetCore.OpenApi` package can be added with the following approaches:

### [Visual Studio](#tab/visual-studio)

* From the **Package Manager Console** window:
  * Go to **View** > **Other Windows** > **Package Manager Console**
  * Navigate to the directory in which the `.csproj` file exists
  * Execute the following command:

    ```powershell
    Install-Package Microsoft.AspNetCore.OpenApi -IncludePrerelease
    ```

* From the **Manage NuGet Packages** dialog:
  * Right-click the project in **Solution Explorer** > **Manage NuGet Packages**
  * Set the **Package source** to "nuget.org"
  * Ensure the "Include prerelease" option is enabled
  * Enter "Microsoft.AspNetCore.OpenApi" in the search box
  * Select the latest "Microsoft.AspNetCore.OpenApi" package from the **Browse** tab and click **Install**

### [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```dotnetcli
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```

### [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```

---

## Add and configure OpenAPI document generation

To get started generating OpenAPI documents for ASP.NET Core applications, add the OpenAPI-related services to `Program.cs`.

```csharp
builder.Services.AddOpenApi();
```

Enable the endpoint for viewing the OpenAPI document in JSON format.

```csharp
app.MapOpenApi();
```

Launch the app and navigate to `https://localhost:<port>/openapi/v1.json` to view the generated OpenAPI document.

## Options for customizing OpenAPI document generation

### The importance of document names

Each OpenAPI document in an application has a unique name. The default document name that is registered is `v1`.

```csharp
builder.Services.AddOpenApi(); // Document name is v1
```

The document name can be modified by passing the name as a parameter to the `AddOpenApi` call.

```csharp
builder.Services.AddOpenApi("internal"); // Document name is internal
```

The document name surfaces in several places in the OpenAPI implementation.

When fetching the generated OpenAPI document, the document name is provided as the `documentName` parameter argument in the request. The requests below will resolve the `v1` and `internal` documents respectively.

```bash
GET http://localhost:5000/openapi/v1.json
GET http://localhost:5000/openapi/internal.json
```

### Customizing the OpenAPI version of a generated document

By default, OpenAPI document generation will generate a document that is compliant with v3.0 of the OpenAPI spec. To modify this version, customize the options that are provided to the document generation services.

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;
});
```

### Customizing the OpenAPI endpoint route

By default, the OpenAPI endpoint registered via a call to `MapOpenApi` will expose the document at the `/openapi/{documentName}.json` endpoint. To customize the route the OpenAPI document is registered at, pass the route template as a parameter to the `MapOpenApi` call.

```csharp
app.MapOpenApi("/openapi/{documentName}/openapi.json");
```

> Note: It's possible, but not recommended, to remove the `documentName` route parameter from the endpoint route. In this case, the framework will attempt to resolve the document name from the query parameter. Not providing the `documentName` in either the route or query can result in unexpected behavior. 

### Customizing the OpenAPI endpoint

Because the OpenAPI document is served via a route handler endpoint, any customization that is available to standard minimal endpoints is available to the OpenAPI endpoint.

#### Limiting access to OpenAPI document to authorized users

The OpenAPI endpoint is not does not enable any authorization checks by default. However, it's possible to limit access to the OpenAPI document to those with the `tester` scope using the following configuration:

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_mapopenapiwithauth)]

#### Caching generated OpenAPI document

The OpenAPI document is re-generated every time a request to the OpenAPI endpoint is sent. This behavior enables the use of transformers that dynamically access application state, like information in the HTTP context, as part of their implementation. When applicable, the OpenAPI document can be cached to avoid executing the document generation pipeline on each HTTP request.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_mapopenapiwithcaching)]

## Customizing OpenAPI documents with transformers

Transformers provide an API for modifying the OpenAPI document that is generated by the framework with user-defined customizations. Transformers are useful for scenarios like adding parameters to all operations in a document, modifying descriptions for parameters or operations, and adding top-level information to the OpenAPI document.

Transformers fall into two categories:

* Document transformers have access to the entire OpenAPI document and can be used to make global modifications to the document.
* Operation transformers apply to each individual operation (combination of path + HTTP method) and can be used to modify parameters or responses on endpoints.

Transformers can be registered onto the document via the `UseTransformer` call on the `OpenApiOptions` object. The following snippet shows different ways to register transformers onto the document:

* Register a document transformer using a delegate.
* Register a document transformer using an instance of `IOpenApiDocumentTransformer`.
* Register a document transformer using a DI-activated `IOpenApiDocumentTransformer`.
* Register an operation transformer using a delegate.

```csharp
builder.Services.AddOpenApi(options =>
{
    options.UseTransformer((document, context, cancellationToken) => {});
    options.UseTransformer(new MyDocumentTransformer());
    options.UseTransformer<MyDocumentTransformer>();
    options.UseOperationTransformer((operation, context, cancellationToken) => {});
})
```

### Execution order for transformers

Transformers execute in first-in first-out order based on registration. In the following snippet, the document transformer will have access to the modifications made by the operation transformer. 

```csharp
builder.Services.AddOpenApi(options =>
{
    options.UseOperationTransformer((operation, context, cancellationToken) => {});
    options.UseTransformer((document, context, cancellationToken) => {});
});
```

### Using document transformers

Document transformers have access to a context object that includes:

* The name of the document being modified.
* The list of ApiDescriptionGroups associated with that document.
* The IServiceProvider used in document generation.

Document transformers also have mutate access to the OpenAPI document that has been generated. The following example demonstrates a document transformer that adds some information about the API to the OpenAPI document.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_documenttransformer1)]

Service-activated document transformers can also be used to implement transformers that rely on instances from DI to modify the application. The sample below demonstrates a document transformer that uses the `IAuthenticationSchemeProvider` service from the authentication layer to check if any JWT bearer-related schemes are registered in the application and add them to the OpenAPI document's top level.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_documenttransformer2)]

Document transformers are unique to the document instance they are associated with. In the example below, a transformer registers authentication-related requirements to the `internal` document but leaves the `public` document unmodified.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_multidoc_operationtransformer1)]

### Using operation transformers

Operations are unique combinations of HTTP paths and methods in an OpenAPI document. Operation transformers are helpful when a modification should be made to each endpoint in an application or conditionally applied to certain routes.

Operation transformers have access to a context object which contains:

* The name of the document the operation belongs to.
* The ApiDescription associated with the operation.
* The IServiceProvider used in document generation.

For example, the following operation transformer adds 500 as a response status code supported by all operations in the document.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_operationtransformer1)]

## Using the generated OpenAPI document

OpenAPI documents can plug into a wide ecosystem of existing tools for testing, documentation, and local development.

### Using Swagger UI for local ad-hoc testing

By default, the `Microsoft.AspNetCore.OpenApi` package does not ship with built-in support for visualizing or interacting with the OpenAPI document. Popular tools for achieving this kind of thing include Swagger UI and ReDoc and can be integrated in your application in a variety of ways. Editors like Visual Studio and VS Code offer extensions and built-in experiences for testing against an OpenAPI document.

The `Swashbuckle.AspNetCore.SwaggerUi` package provides a bundle of Swagger UI's web assets for use in applications. This package can be used to render a UI for the generated document. To configure this, install the `Swashbuckle.AspNetCore.SwaggerUi` package.

### [Visual Studio](#tab/visual-studio)

* From the **Package Manager Console** window:
  * Go to **View** > **Other Windows** > **Package Manager Console**
  * Navigate to the directory in which the `.csproj` file exists
  * Execute the following command:

    ```powershell
    Install-Package Swashbuckle.AspNetCore.SwaggerUi -v 6.5.0
    ```

* From the **Manage NuGet Packages** dialog:
  * Right-click the project in **Solution Explorer** > **Manage NuGet Packages**
  * Set the **Package source** to "nuget.org"
  * Ensure the "Include prerelease" option is enabled
  * Enter "Swashbuckle.AspNetCore.SwaggerUi" in the search box
  * Select the latest "Swashbuckle.AspNetCore.SwaggerUi" package from the **Browse** tab and click **Install**

### [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```dotnetcli
dotnet add package Swashbuckle.AspNetCore.SwaggerUi -v 6.5.0
```

### [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```dotnetcli
dotnet add package Swashbuckle.AspNetCore.SwaggerUi -v 6.5.0
```

---

Enable the swagger-ui middleware with a reference to the OpenAPI route registered earlier. To limit information disclosure and security vulnerability concerns, it's recommended to only enable Swagger UI in development environments.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_swaggerui)]

### Using Scalar for interactive API documentation

[Scalar](https://scalar.com/) is an open-source interactive document UI for OpenAPI. Scalar can integrate with the OpenAPI endpoint provided by ASP.NET Core.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_openapiwithscalar)]

### Linting generated OpenAPI documents with Spectral

Spectral is an open-source OpenAPI document linter. Spectral can be incorporated into your application build to verify the quality of generated OpenAPI documents. Install Spectral according to the [package installation directions](https://github.com/stoplightio/spectral#-installation).

To take advantage of Spectral, install the `Microsoft.Extensions.ApiDescription.Server` package to enable build-time OpenAPI document generation.

### [Visual Studio](#tab/visual-studio)

* From the **Package Manager Console** window:
  * Go to **View** > **Other Windows** > **Package Manager Console**
  * Navigate to the directory in which the `.csproj` file exists
  * Execute the following command:

    ```powershell
    Install-Package Microsoft.Extensions.ApiDescription.Server -IncludePrerelease
    ```

* From the **Manage NuGet Packages** dialog:
  * Right-click the project in **Solution Explorer** > **Manage NuGet Packages**
  * Set the **Package source** to "nuget.org"
  * Ensure the "Include prerelease" option is enabled
  * Enter "Microsoft.Extensions.ApiDescription.Server" in the search box
  * Select the latest "Microsoft.Extensions.ApiDescription.Server" package from the **Browse** tab and click **Install**

### [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```dotnetcli
dotnet add package Microsoft.Extensions.ApiDescription.Server --prerelease
```

### [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```dotnetcli
dotnet add package Microsoft.Extensions.ApiDescription.Server --prerelease
```

---

Enable document generation at build time by setting the following properties in your application's `.csproj` file":

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

The output will show any issues with the OpenAPI document.

```output
1:1  warning  oas3-api-servers       OpenAPI "servers" must be present and non-empty array.
3:10  warning  info-contact           Info object must have "contact" object.                        info
3:10  warning  info-description       Info "description" must be present and non-empty string.       info
9:13  warning  operation-description  Operation "description" must be present and non-empty string.  paths./.get
9:13  warning  operation-operationId  Operation must have "operationId".                             paths./.get

✖ 5 problems (0 errors, 5 warnings, 0 infos, 0 hints)
```
