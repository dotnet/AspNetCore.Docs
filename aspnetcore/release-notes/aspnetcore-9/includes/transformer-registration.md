### Improvements to transformer registration APIs in Microsoft.AspNetCore.OpenApi

OpenAPI transformers support modifying the OpenAPI document, operations within the document, or schemas associated with types in the API. The APIs for registering transformers on an OpenAPI document provide a variety of options for registering transformers.

Previously, the following APIs were available for registering transformers:

```csharp
OpenApiOptions UseTransformer(Func<OpenApiDocument, OpenApiDocumentTransformerContext, CancellationToken, Task> transformer)
OpenApiOptions UseTransformer(IOpenApiDocumentTransformer transformer)
OpenApiOptions UseTransformer<IOpenApiDocumentTransformer>()
OpenApiOptions UseSchemaTransformer(Func<OpenApiSchema, OpenApiSchemaTransformerContext, CancellationToken, Task>)
OpenApiOptions UseOperationTransformer(Func<OpenApiOperation, OpenApiOperationTransformerContext, CancellationToken, Task>)
```

The new API set is as follows:

```csharp
OpenApiOptions AddDocumentTransformer(Func<OpenApiDocument, OpenApiDocumentTransformerContext, CancellationToken, Task> transformer)
OpenApiOptions AddDocumentTransformer(IOpenApiDocumentTransformer transformer)
OpenApiOptions AddDocumentTransformer<IOpenApiDocumentTransformer>()

OpenApiOptions AddSchemaTransformer(Func<OpenApiSchema, OpenApiSchemaTransformerContext, CancellationToken, Task> transformer)
OpenApiOptions AddSchemaTransformer(IOpenApiSchemaTransformer transformer)
OpenApiOptions AddSchemaTransformer<IOpenApiSchemaTransformer>()

OpenApiOptions AddOperationTransformer(Func<OpenApiOperation, OpenApiOperationTransformerContext, CancellationToken, Task> transformer)
OpenApiOptions AddOperationTransformer(IOpenApiOperationTransformer transformer)
OpenApiOptions AddOperationTransformer<IOpenApiOperationTransformer>()
```
