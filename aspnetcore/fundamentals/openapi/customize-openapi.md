---
title: Customize OpenAPI documents
author: captainsafia
description: Learn how to customize OpenAPI documents in an ASP.NET Core app
ms.author: safia
monikerRange: '>= aspnetcore-9.0'
ms.custom: mvc
ms.date: 10/26/2024
uid: fundamentals/openapi/customize-openapi
---
# Customize OpenAPI documents

<a name="transformers"></a>

## OpenAPI document transformers

This section demonstrates how to customize OpenAPI documents with transformers.

### Customize OpenAPI documents with transformers

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

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_transUse&highlight=8-19)]

### Execution order for transformers

Transformers execute in first-in first-out order based on registration. In the following snippet, the document transformer has access to the modifications made by the operation transformer:

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_transInOut&highlight=3-9)]

### Use document transformers

Document transformers have access to a context object that includes:

* The name of the document being modified.
* The <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider.ApiDescriptionGroups> associated with that document.
* The <xref:System.IServiceProvider> used in document generation.

Document transformers can also mutate the OpenAPI document that is generated. The following example demonstrates a document transformer that adds some information about the API to the OpenAPI document.

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_documenttransformer1)]

Service-activated document transformers can utilize instances from DI to modify the app. The following sample demonstrates a document transformer that uses the <xref:Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider> service from the authentication layer. It checks if any JWT bearer-related schemes are registered in the app and adds them to the OpenAPI document's top level:

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_documenttransformer2)]

Document transformers are unique to the document instance they're associated with. In the following example, a transformer:

* Registers authentication-related requirements to the `internal` document.
* Leaves the `public` document unmodified.

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_multidoc_operationtransformer1)]

### Use operation transformers

Operations are unique combinations of HTTP paths and methods in an OpenAPI document. Operation transformers are helpful when a modification:

* Should be made to each endpoint in an app, or
* Conditionally applied to certain routes.

Operation transformers have access to a context object which contains:

* The name of the document the operation belongs to.
* The <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription> associated with the operation.
* The <xref:System.IServiceProvider> used in document generation.

For example, the following operation transformer adds `500` as a response status code supported by all operations in the document.

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_operationtransformer1)]

### Use schema transformers

Schemas are the data models that are used in request and response bodies in an OpenAPI document. Schema transformers are useful when a modification:

* Should be made to each schema in the document, or
* Conditionally applied to certain schemas.

Schema transformers have access to a context object which contains:

* The name of the document the schema belongs to.
* The JSON type information associated with the target schema.
* The <xref:System.IServiceProvider> used in document generation.

For example, the following schema transformer sets the `format` of decimal types to `decimal` instead of `double`:

[!code-csharp[](~/fundamentals/openapi/samples/9.x/WebMinOpenApi/Program.cs?name=snippet_schematransformer1)]

## Additional resources

* <xref:fundamentals/openapi/using-openapi-documents>
* [OpenAPI specification](https://spec.openapis.org/oas/v3.0.3)
