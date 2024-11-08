---
title: Generate OpenAPI documents
author: captainsafia
description: Learn how to generate and customize OpenAPI documents in an ASP.NET Core app
ms.author: safia
monikerRange: '>= aspnetcore-6.0'
ms.custom: mvc
ms.date: 09/05/2024
uid: fundamentals/openapi/aspnetcore-openapi
---
# Generate OpenAPI documents

:::moniker range=">= aspnetcore-9.0"

The [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) package provides built-in support for OpenAPI document generation in ASP.NET Core. The package provides the following features:

* Support for generating OpenAPI documents at run time and accessing them via an endpoint on the application.
* Support for "transformer" APIs that allow modifying the generated document.
* Support for generating multiple OpenAPI documents from a single app.
* Takes advantage of JSON schema support provided by [`System.Text.Json`](/dotnet/api/system.text.json).
* Is compatible with native AoT.

## Package installation

Install the `Microsoft.AspNetCore.OpenApi` package:

### [Visual Studio](#tab/visual-studio)

Run the following command from the **Package Manager Console**:

 ```powershell
 Install-Package Microsoft.AspNetCore.OpenApi -IncludePrerelease
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

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_first&highlight=3,7)]

Launch the app and navigate to `https://localhost:<port>/openapi/v1.json` to view the generated OpenAPI document.

## Options to Customize OpenAPI document generation

The following sections demonstrate how to customize OpenAPI document generation.

### Customize the OpenAPI document name

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

### Customize the OpenAPI version of a generated document

By default, OpenAPI document generation creates a document that is compliant with [v3.0 of the OpenAPI specification](https://spec.openapis.org/oas/v3.0.0). The following code demonstrates how to modify the default version of the OpenAPI document:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;
});
```

### Customize the OpenAPI endpoint route

By default, the OpenAPI endpoint registered via a call to <xref:Microsoft.AspNetCore.Builder.OpenApiEndpointRouteBuilderExtensions.MapOpenApi%2A> exposes the document at the `/openapi/{documentName}.json` endpoint. The following code demonstrates how to customize the route at which the OpenAPI document is registered:

```csharp
app.MapOpenApi("/openapi/{documentName}/openapi.json");
```

It's possible, but not recommended, to remove the `documentName` route parameter from the endpoint route. When the `documentName` route parameter is removed from the endpoint route, the framework attempts to resolve the document name from the query parameter. Not providing the `documentName` in either the route or query can result in unexpected behavior.

### Customize the OpenAPI endpoint

Because the OpenAPI document is served via a route handler endpoint, any customization that is available to standard minimal endpoints is available to the OpenAPI endpoint.

#### Limit OpenAPI document access to authorized users

The OpenAPI endpoint  doesn't enable any authorization checks by default. However, authorization checks can be applied to the OpenAPI document. In the following code, access to the OpenAPI document is limited to those with the `tester` role:

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_mapopenapiwithauth)]

#### Cache generated OpenAPI document

The OpenAPI document is regenerated every time a request to the OpenAPI endpoint is sent. Regeneration enables transformers to incorporate dynamic application state into their operation. For example, regenerating a request with details of the HTTP context. When applicable, the OpenAPI document can be cached to avoid executing the document generation pipeline on each HTTP request.

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_mapopenapiwithcaching)]

## Generate OpenAPI documents at build-time

In typical web applications, OpenAPI documents are generated at run-time and served via an HTTP request to the application server.

In some scenarios, it's helpful to generate the OpenAPI document during the application's build step. These scenarios include:

- Generating OpenAPI documentation that is committed into source control.
- Generating OpenAPI documentation that is used for spec-based integration testing.
- Generating OpenAPI documentation that is served statically from the web server.

To add support for generating OpenAPI documents at build time, install the `Microsoft.Extensions.ApiDescription.Server` package:

### [Visual Studio](#tab/visual-studio)

Run the following command from the **Package Manager Console**:

 ```powershell
 Install-Package Microsoft.Extensions.ApiDescription.Server -IncludePrerelease
```

### [.NET CLI](#tab/net-cli)

Run the following command in the directory that contains the project file:

```dotnetcli
dotnet add package Microsoft.Extensions.ApiDescription.Server --prerelease
```
---

Upon installation, this package will automatically generate the Open API document(s) associated with the application during build and populate them into the application's output directory.

```cli
$ dotnet build
$ cat bin/Debug/net9.0/{ProjectName}.json
```

### Customizing build-time document generation

#### Modifying the output directory of the generated Open API file

By default, the generated OpenAPI document will be emitted to the application's output directory. To modify the location of the emitted file, set the target path in the `OpenApiDocumentsDirectory` property.

```xml
<PropertyGroup>
  <OpenApiDocumentsDirectory>./</OpenApiDocumentsDirectory>
</PropertyGroup>
```

The value of `OpenApiDocumentsDirectory` is resolved relative to the project file. Using the `./` value above will emit the OpenAPI document in the same directory as the project file.

#### Modifying the output file name

By default, the generated OpenAPI document will have the same name as the application's project file. To modify the name of the emitted file, set the `--file-name` argument in the `OpenApiGenerateDocumentsOptions` property.

```xml
<PropertyGroup>
  <OpenApiGenerateDocumentsOptions>--file-name my-open-api</OpenApiGenerateDocumentsOptions>
</PropertyGroup>
```

#### Selecting the OpenAPI document to generate

Some applications may be configured to emit multiple OpenAPI documents, for various versions of an API or to distinguish between public and internal APIs. By default, the build-time document generator will emit files for all documents that are configured in an application. To only emit for a single document name, set the `--document-name` argument in the `OpenApiGenerateDocumentsOptions` property.

```xml
<PropertyGroup>
  <OpenApiGenerateDocumentsOptions>--document-name v2</OpenApiGenerateDocumentsOptions>
</PropertyGroup>
```

### Customizing run-time behavior during build-time document generation

Under the hood, build-time OpenAPI document generation functions by launching the application's entrypoint with an inert server implementation. This is a requirement to produce accurate OpenAPI documents since all information in the OpenAPI document cannot be statically analyzed. Because the application's entrypoint is invoked, any logic in the applications' startup will be invoked. This includes code that injects services into the DI container or reads from configuration. In some scenarios, it's necessary to restrict the codepaths that will run when the application's entry point is being invoked from build-time document generation. These scenarios include:

- Not reading from certain configuration strings.
- Not registering database-related services.

In order to restrict these codepaths from being invoked by the build-time generation pipeline, they can be conditioned behind a check of the entry assembly like so:

```csharp
using System.Reflection;

var builder = WebApplication.CreateBuilder();

if (Assembly.GetEntryAssembly()?.GetName().Name != "GetDocument.Insider")
{
  builder.Services.AddDefaults();
}
```

::: moniker-end

[!INCLUDE[](~/fundamentals/openapi/includes/aspnetcore-openapi6-8.md)]


