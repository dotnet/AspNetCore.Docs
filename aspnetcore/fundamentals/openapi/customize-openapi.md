---
title: Customize OpenAPI documents
author: captainsafia
description: Learn how to customize OpenAPI documents in an ASP.NET Core app
ms.author: safia
monikerRange: '>= aspnetcore-9.0'
ms.custom: mvc
ms.date: 07/09/2025
uid: fundamentals/openapi/customize-openapi
---
# Customize OpenAPI documents

:::moniker range=">= aspnetcore-10.0"

<a name="transformers"></a>

## OpenAPI document transformers

Transformers provide an API for modifying the OpenAPI document with user-defined customizations. Transformers are useful for scenarios like:

* Adding parameters to all operations in a document.
* Modifying descriptions for parameters or operations.
* Adding top-level information to the OpenAPI document.

Transformers fall into three categories:

* Document transformers have access to the entire OpenAPI document. These can be used to make global modifications to the document.
* Operation transformers apply to each individual operation. Each individual operation is a combination of path and HTTP method. These can be used to modify parameters or responses on endpoints.
* Schema transformers apply to each schema in the document. These can be used to modify the schema of request or response bodies, or any nested schemas.

Transformers can be registered onto the document by calling the <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions.AddDocumentTransformer%2A> method on the <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions> object. The following snippet shows different ways to register transformers onto the document:

* Register a document transformer using a delegate.
* Register a document transformer using an instance of <xref:Microsoft.AspNetCore.OpenApi.IOpenApiDocumentTransformer>.
* Register a document transformer using a DI-activated <xref:Microsoft.AspNetCore.OpenApi.IOpenApiDocumentTransformer>.
* Register an operation transformer using a delegate.
* Register an operation transformer using an instance of <xref:Microsoft.AspNetCore.OpenApi.IOpenApiOperationTransformer>.
* Register an operation transformer using a DI-activated <xref:Microsoft.AspNetCore.OpenApi.IOpenApiOperationTransformer>.
* Register a schema transformer using a delegate.
* Register a schema transformer using an instance of <xref:Microsoft.AspNetCore.OpenApi.IOpenApiSchemaTransformer>.
* Register a schema transformer using a DI-activated <xref:Microsoft.AspNetCore.OpenApi.IOpenApiSchemaTransformer>.

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_transUse&highlight=8-19)]

### Execution order for transformers

Transformers execute in the following order:  

* Schema transformers execute when a schema is registered to the document. They execute in the order they're added.
All schemas are added to the document before any operation processing occurs, so schema transformers execute before operation transformers.
* Operation transformers execute when an operation is added to the document. They execute in the order they're added.
All operations are added to the document before any document transformers execute.
* Document transformers execute when the document is generated. This is the final pass over the document, and all operations and schemas are added by this point.
* When an app is configured to generate multiple OpenAPI documents, transformers execute for each document independently.

For example, in the following snippet:
* `SchemaTransformer2` is executed and has access to the modifications made by `SchemaTransformer1`.
* Both `OperationTransformer1` and `OperationTransformer2` have access to the modifications made by both schema transformers for the types involved in the operation they're called to process.
* `OperationTransformer2` is executed after `OperationTransformer1`, so it has access to the modifications made by `OperationTransformer1`.
* Both `DocumentTransformer1` and `DocumentTransformer2` are executed after all operations and schemas have been added to the document, so they have access to all modifications made by the operation and schema transformers.
* `DocumentTransformer2` is executed after `DocumentTransformer1`, so it has access to the modifications made by `DocumentTransformer1`.

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_transInOut&highlight=6-14)]

## Use document transformers

Document transformers have access to a context object that includes:

* The name of the document being modified.
* The <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider.ApiDescriptionGroups> associated with that document.
* The <xref:System.IServiceProvider> used in document generation.

Document transformers can also mutate the OpenAPI document that is generated. The following example demonstrates a document transformer that adds some information about the API to the OpenAPI document.

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_documenttransformer1)]

Service-activated document transformers can utilize instances from DI to modify the app. The following sample demonstrates a document transformer that uses the <xref:Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider> service from the authentication layer. It checks if any JWT bearer-related schemes are registered in the app and adds them to the OpenAPI document's top level:

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_documenttransformer2)]

Document transformers are unique to the document instance they're associated with. In the following example, a transformer:

* Registers authentication-related requirements to the `internal` document.
* Leaves the `public` document unmodified.

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_multidoc_operationtransformer1)]

## Use operation transformers

Operations are unique combinations of HTTP paths and methods in an OpenAPI document. Operation transformers are helpful when a modification:

* Should be made to each endpoint in an app, or
* Conditionally applied to certain routes.

Operation transformers have access to a context object which contains:

* The name of the document the operation belongs to.
* The <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription> associated with the operation.
* The <xref:System.IServiceProvider> used in document generation.

For example, the following operation transformer adds `500` as a response status code supported by all operations in the document.

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_operationtransformer1)]

Operation transformers can also be added to specific endpoint, instead of all endpoints in a document. This can be useful to change specific OpenAPI data for a specific endpoint, like adding a security scheme, response description or other OpenAPI operation properties. The following example demonstrates adding an operation transformer to a deprecated endpoint specifically, which marks the endpoint as deprecated in the OpenAPI document.

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_operationtransformer2)]

## Use schema transformers

Schemas are the data models that are used in request and response bodies in an OpenAPI document. Schema transformers are useful when a modification:

* Should be made to each schema in the document, or
* Conditionally applied to certain schemas.

Schema transformers have access to a context object which contains:

* The name of the document the schema belongs to.
* The JSON type information associated with the target schema.
* The <xref:System.IServiceProvider> used in document generation.

For example, the following schema transformer sets the `format` of decimal types to `decimal` instead of `double`:

[!code-csharp[](~/fundamentals/openapi/samples/10.x/WebMinOpenApi/Program.cs?name=snippet_schematransformer1)]

## Support for generating OpenApiSchemas in transformers
<!-- https://github.com/dotnet/aspnetcore/pull/61050 -->

Developers can generate a schema for a C# type using the same logic as ASP.NET Core OpenAPI document generation and add it to the OpenAPI document. The schema can then be referenced from elsewhere in the OpenAPI document. This capability is available starting with .NET 10.

The context passed to document, operation, and schema transformers includes a new `GetOrCreateSchemaAsync` method that can be used to generate a schema for a type.
This method also has an optional `ApiParameterDescription` parameter to specify additional metadata for the generated schema.

To support adding the schema to the OpenAPI document, a `Document` property has been added to the Operation and Schema transformer contexts. This allows any transformer to add a schema to the OpenAPI document using the document's `AddComponent` method.

### Example

To use this feature in a document, operation, or schema transformer, create the schema using the `GetOrCreateSchemaAsync` method provided in the context and add it to the OpenAPI document using the document's `AddComponent` method.

:::code language="csharp" source="~/fundamentals/openapi/samples/10.x/WebAppOpenAPI10/Program.cs" id="snippet_Generate_OpenApiSchemas_for_type" highlight="6-7":::

## Customize schema reuse

After all transformers have been applied, the framework makes a pass over the document to transfer certain schemas
to the `components.schemas` section, replacing them with `$ref` references to the transferred schema.
This reduces the size of the document and makes it easier to read.

The details of this processing are complicated and might change in future versions of .NET, but in general:

* Schemas for class/record/struct types are replaced with a `$ref` to a schema in `components.schemas`
  if they appear more than once in the document.
* Schemas for primitive types and standard collections are left inline.
* Schemas for enum types are always replaced with a `$ref` to a schema in components.schemas.

Typically the name of the schema in `components.schemas` is the name of the class/record/struct type,
but in some circumstances a different name must be used.

ASP.NET Core lets you customize which schemas are replaced with a `$ref` to a schema in `components.schemas`
using the <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions.CreateSchemaReferenceId> property of <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions>.
This property is a delegate that takes a <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> object and returns the name of the schema
in `components.schemas` that should be used for that type.
The framework provides a default implementation of this delegate, <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions.CreateDefaultSchemaReferenceId%2A>
that uses the name of the type, but you can replace it with your own implementation.

As a simple example of this customization, you might choose to always inline enum schemas.
This is done by setting <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions.CreateSchemaReferenceId> to a delegate
that returns null for enum types, and otherwise returns the value from the default implementation.
The following code demonstrates this:

```csharp
builder.Services.AddOpenApi(options =>
{
    // Always inline enum schemas
    options.CreateSchemaReferenceId = (type) =>
        type.Type.IsEnum ? null : OpenApiOptions.CreateDefaultSchemaReferenceId(type);
});
```

## Additional resources

* <xref:fundamentals/openapi/using-openapi-documents>
* [OpenAPI specification](https://spec.openapis.org/oas/v3.0.3)

:::moniker-end

[!INCLUDE[](~/fundamentals/openapi/includes/customize-openapi9.md)]
