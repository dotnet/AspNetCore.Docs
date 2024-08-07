---
title: Work with OpenAPI documents
author: captainsafia
description: Learn how to generate and customize OpenAPI documents in an ASP.NET Core app
ms.author: safia
monikerRange: '>= aspnetcore-6.0'
ms.custom: mvc
ms.date: 5/22/2024
uid: fundamentals/openapi/aspnetcore-openapi
---
# Work with OpenAPI documents

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

## Configure OpenAPI document generation

The following code:

* Adds OpenAPI services.
* Enables the endpoint for viewing the OpenAPI document in JSON format.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_first&highlight=3,7)]

Launch the app and navigate to `https://localhost:<port>/openapi/v1.json` to view the generated OpenAPI document.

## Including OpenAPI metadata in an ASP.NET web app

ASP.NET collects metadata from the web app's endpoints and uses it to generate an OpenAPI document.
In controller-based apps, metadata is collected from attributes like `[EndpointDescription]`, `[HttpPost]`,
and `[Produces]`.
In minimal APIs, metadata can be collected from attributes, but may also be set by using extension methods
and other strategies, such as returning `TypedResults` from route handlers.
The following table provides an overview of the metadata collected and the strategies for setting it.

| Metadata | Attribute | Extension method | Other strategies |
| --- | --- | --- |
| summary | `[EndpointSummary]` | `WithSummary` | |
| description | `[EndpointDescription]` | `WithDescription` | |
| tags | `[Tags]` | `WithTags` | |
| operationId | `[EndpointName]` | `WithName` | |
| parameters | `[FromQuery]`, `[FromRoute]`, `[FromHeader]`, `[FromForm]` | |
| parameter description | `[Description]` | | |
| requestBody | `[FromBody]` | `Accepts` | |
| responses | `[Produces]`, `[ProducesProblem]` | `Produces`, `ProducesProblem` | `TypedResults` |
| Excluding endpoints | `[ExcludeFromDescription]` | `ExcludeFromDescription` | |

ASP.NET Core does not collect metadata from XML doc comments.

The following sections demonstrate how to include metadata in an app to customize the generated OpenAPI document.

### Summary and description

The endpoint summary and description can be set using the `[EndpointSummary]` and `[EndpointDescription]` attributes,
or in minimal APIs, using the `WithSummary` and `WithDescription` extension methods.

* `[EndpointSummary]`: <xref:Microsoft.AspNetCore.Http.EndpointSummaryAttribute>
* `[EndpointDescription]`: <xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute>
* `WithSummary`: <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithSummary%2A>
* `WithDescription`: <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithDescription%2A>

#### [Minimal APIs](#tab/minimal-apis)

The following sample demonstrates the different strategies for setting summaries and descriptions.

Note that the attributes are placed on the delegate method and not on the app.MapGet method.

```csharp
app.MapGet("/extension-methods", () => "Hello world!")
  .WithSummary("This is a summary.")
  .WithDescription("This is a description.");

app.MapGet("/attributes",
  [EndpointSummary("This is a summary.")]
  [EndpointDescription("This is a description.")]
  () => "Hello world!");
```

#### [Controllers](#tab/controllers)

The following sample demonstrates how to set summaries and descriptions.

```csharp
  [EndpointSummary("This is a summary.")]
  [EndpointDescription("This is a description.")]
  [HttpGet("attributes")]
  public IResult Attributes()
  {
      return Results.Ok("Hello world!");
  }
```
---

### tags

OpenAPI supports specifying tags on each endpoint as a form of categorization.
In controller-based apps, the controller name is automatically added as a tag on each of its endpoints,
but this can be overridden using the `[Tags]` attribute.
In minimal APIs, tags can be set using either the `[Tags]` attribute or the `WithTags` extension method.

* `[Tags]`: <xref:Microsoft.AspNetCore.Http.TagsAttribute>
* `WithTags`: <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithTags%2A>

#### [Minimal APIs](#tab/minimal-apis)

The following sample demonstrates the different strategies for setting tags.

```csharp
app.MapGet("/extension-methods", () => "Hello world!")
  .WithTags("todos", "projects");

app.MapGet("/attributes",
  [Tags("todos", "projects")]
  () => "Hello world!");
```

#### [Controllers](#tab/controllers)

The following sample demonstrates how to set tags.

```csharp
  [Tags(["todos", "projects"])]
  [HttpGet("attributes")]
  public IResult Attributes()
  {
      return Results.Ok("Hello world!");
  }
```
---

### operationId

OpenAPI supports an operationId on each endpoint as a unique identifier or name for the operation. 
In controller-based apps, the operationId can be set using the `[EndpointName]` attribute.
In minimal APIs, the operationId can be set using either the `[EndpointName]` attribute or the `WithName` extension method.

* `[EndpointName]`: <xref:Microsoft.AspNetCore.Routing.EndpointNameAttribute>
* `WithName`: <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithName%2A>

#### [Minimal APIs](#tab/minimal-apis)

The following sample demonstrates the different strategies for setting the operationId.

```csharp
app.MapGet("/extension-methods", () => "Hello world!")
  .WithName("FromExtensionMethods");

app.MapGet("/attributes",
  [EndpointName("FromAttributes")]
  () => "Hello world!");
```

#### [Controllers](#tab/controllers)

The following sample demonstrates how to set the operationId.

```csharp
  [EndpointName("FromAttributes")]
  [HttpGet("attributes")]
  public IResult Attributes()
  {
      return Results.Ok("Hello world!");
  }
```
---

### parameters

OpenAPI supports annotating path, query string, header, and cookie parameters that are consumed by an API.

The framework infers the types for request parameters automatically based on the signature of the route handler.

The `[Description]` attribute can be used to provide a description for a parameter.

* [`Description`](/dotnet/api/system.componentmodel.descriptionattribute)

#### [Minimal APIs](#tab/minimal-apis)

The follow sample demonstrates how to set a description for a parameter.

```csharp
app.MapGet("/attributes",
  ([Description("This is a description.")] string name) => "Hello world!");
```

#### [Controllers](#tab/controllers)

The following sample demonstrates how to set a description for a parameter.

```csharp
  [HttpGet("attributes")]
  public IResult Attributes([Description("This is a description.")] string name)
  {
      return Results.Ok("Hello world!");
  }
```
---

### requestBody

<!-- TODO: Restructure this section to cover both controller-based and minimal API apps -->

To define the type of inputs transmitted as the request body, configure the properties by using the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> extension method to define the object type and content type that are expected by the request handler. In the following example, the endpoint accepts a `Todo` object in the request body with an expected content-type of `application/xml`.

```csharp
app.MapPost("/todos/{id}", (int id, Todo todo) => ...)
  .Accepts<Todo>("application/xml");
```

<!-- TODO: Add more context on this example. Specifically we need to add the BindAsync method 
in the TODO class because without it Minimal will try to deserialize as JSON -->

In addition to the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> extension method, a parameter type can describe its own annotation by implementing the <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider> interface. For example, the following `Todo` type adds an annotation that requires a request body with an `application/xml` content-type.

```csharp
public class Todo : IEndpointParameterMetadataProvider
{
    public static void PopulateMetadata(ParameterInfo parameter, EndpointBuilder builder)
    {
        builder.Metadata.Add(new AcceptsMetadata(["application/xml", "text/xml"], typeof(XmlBody)));
    }
}
```

When no explicit annotation is provided, the framework attempts to determine the default request type if there's a request body parameter in the endpoint handler. The inference uses the following heuristics to produce the annotation:

* Request body parameters that are read from a form via the [`[FromForm]`](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) attribute are described with the `multipart/form-data` content-type.
* All other request body parameters are described with the `application/json` content-type.
* The request body is treated as optional if it's nullable or if the <xref:Microsoft.AspNetCore.Http.Metadata.IFromBodyMetadata.AllowEmpty> property is set on the [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) attribute.

### Describe response types

<!-- TODO: Restructure this section to cover both controller-based and minimal API apps -->

OpenAPI supports providing a description of the responses returned from an API. Minimal APIs support three strategies for setting the response type of an endpoint:

* Via the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method on the endpoint.
* Via the [`ProducesResponseType`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) attribute on the route handler.
* By returning<xref:Microsoft.AspNetCore.Http.TypedResults> from the route handler.

The `Produces` extension method can be used to add `Produces` metadata to an endpoint. When no parameters are provided, the extension method populates metadata for the targeted type under a `200` status code and an `application/json` content type.

```csharp
app.MapGet("/todos", async (TodoDb db) => await db.Todos.ToListAsync())
  .Produces<IList<Todo>>();
```

Using <xref:Microsoft.AspNetCore.Http.TypedResults> in the implementation of an endpoint's route handler automatically includes the response type metadata for the endpoint. For example, the following code automatically annotates the endpoint with a response under the `200` status code with an `application/json` content type.

```csharp
app.MapGet("/todos", async (TodoDb db) =>
{
    var todos = await db.Todos.ToListAsync();
    return TypedResults.Ok(todos);
});
```

#### Set responses for `ProblemDetails`

When setting the response type for endpoints that may return a ProblemDetails response, the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A> extension method or <xref:Microsoft.AspNetCore.Http.TypedResults.Problem%2A?displayProperty=nameWithType> can be used to add the appropriate annotation to the endpoint's metadata.

When there are no explicit annotations provided by one of these strategies, the framework attempts to determine a default response type by examining the signature of the response. This default response is populated under the `200` status code in the OpenAPI definition.

#### Multiple response types

If an endpoint can return different response types in different scenarios, you can provide metadata in the following ways:

* Call the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method multiple times, as shown in the following example:

  [!code-csharp[](~/fundamentals/minimal-apis/samples/todo/Program.cs?name=snippet_getCustom)]

* Use [`Results<TResult1,TResult2,TResultN>`](xref:Microsoft.AspNetCore.Http.HttpResults.Results%606) in the signature and <xref:Microsoft.AspNetCore.Http.TypedResults> in the body of the handler, as shown in the following example:

  :::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MultipleResultTypes/Program.cs" id="snippet_multiple_result_types":::

  The `Results<TResult1,TResult2,TResultN>` [union types](https://en.wikipedia.org/wiki/Union_type) declare that a route handler returns multiple `IResult`-implementing concrete types, and any of those types that implement `IEndpointMetadataProvider` will contribute to the endpoint’s metadata.

  The union types implement implicit cast operators. These operators enable the compiler to automatically convert the types specified in the generic arguments to an instance of the union type. This capability has the added benefit of providing compile-time checking that a route handler only returns the results that it declares it does. Attempting to return a type that isn't declared as one of the generic arguments to `Results<TResult1,TResult2,TResultN>` results in a compilation error.

### Excluding endpoints from the generated document

<!-- TODO: Add information for controller-based apps in this section -->

By default, all endpoints that are defined in an app are documented in the generated OpenAPI file. Minimal APIs support two strategies for excluding a given endpoint from the OpenAPI document, using:

* <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ExcludeFromDescription%2A>
* <xref:Microsoft.AspNetCore.Routing.ExcludeFromDescriptionAttribute>

The following sample demonstrates the different strategies for excluding a given endpoint from the generated OpenAPI document.

```csharp
app.MapGet("/extension-method", () => "Hello world!")
  .ExcludeFromDescription();

app.MapGet("/attributes",
  [ExcludeFromDescription]
  () => "Hello world!");
```

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

By default, the OpenAPI endpoint registered via a call to `MapOpenApi` exposes the document at the `/openapi/{documentName}.json` endpoint. The following code demonstrates how to customize the route at which the OpenAPI document is registered:

```csharp
app.MapOpenApi("/openapi/{documentName}/openapi.json");
```

It's possible, but not recommended, to remove the `documentName` route parameter from the endpoint route. When the `documentName` route parameter is removed from the endpoint route, the framework attempts to resolve the document name from the query parameter. Not providing the `documentName` in either the route or query can result in unexpected behavior.

### Customize the OpenAPI endpoint

Because the OpenAPI document is served via a route handler endpoint, any customization that is available to standard minimal endpoints is available to the OpenAPI endpoint.

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

::: moniker-end

[!INCLUDE[](~/fundamentals/openapi/includes/aspnetcore-openapi6-8.md)]
