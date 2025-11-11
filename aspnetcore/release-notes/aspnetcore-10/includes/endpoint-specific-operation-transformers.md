### Endpoint-specific OpenAPI operation transformers

OpenAPI [operation transformers](<xref:fundamentals/openapi/customize-openapi#use-operation-transformers>) can now be registered directly on individual endpoints using the `AddOpenApiOperationTransformer` extension method. This allows customization of OpenAPI metadata to be colocated with the endpoint definition, rather than requiring global configuration with path-based conditional logic.

Prior to this feature, modifying OpenAPI data for specific endpoints required registering a global operation transformer and implementing conditional logic to target specific endpoints. For example:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.AddOperationTransformer((operation, context, ct) =>
    {
        if (context.Description.RelativePath == "deprecated-endpoint")
        {
            operation.Deprecated = true;
        }

        return Task.CompletedTask;
    });
});
```

With the new `AddOpenApiOperationTransformer` API, the same customization can be applied directly to the endpoint, with access to the full operation context as well:

```csharp
app.MapGet("/deprecated-endpoint", () => "This endpoint is old and should not be used anymore")
.AddOpenApiOperationTransformer((operation, context, cancellationToken) =>
{
    operation.Deprecated = true;

    return Task.CompletedTask;
});
```

This approach improves code readability and maintainability by keeping endpoint-specific customizations close to the endpoint definitions. The `AddOpenApiOperationTransformer` method provides access to the full <xref:Microsoft.AspNetCore.OpenApi.OpenApiOperationTransformerContext>, enabling comprehensive customization of the OpenAPI operation, including:

* Setting operation properties like `Deprecated`, `Summary`, or `Description`
* Customizing response descriptions
* Adding or modifying security requirements
* Modifying parameters or request bodies
