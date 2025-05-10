### Support for generating OpenApiSchemas in transformers
<!-- https://github.com/dotnet/aspnetcore/pull/61050 -->

Developers can now generate a schema for a C# type, using the same logic as ASP.NET Core OpenAPI document generation,
and add it to the OpenAPI document. The schema can then be referenced from elsewhere in the OpenAPI document.

The context passed to document, operation, and schema transformers now has a `GetOrCreateSchemaAsync` method that can be used to generate a schema for a type.
This method also has an optional `ApiParameterDescription` parameter to specify additional metadata for the generated schema.

To support adding the schema to the OpenAPI document, a `Document` property has been added to the Operation and Schema transformer contexts. This allows any transformer to add a schema to the OpenAPI document using the document's `AddComponent` method.

#### Example

To use this feature in an document, operation, or schema transformer, create the schema using the `GetOrCreateSchemaAsync` method provided in the context
and add it to the OpenAPI document using the document's `AddComponent` method.

<!-- In the docs, highlight the lines with the call to "GetOrCreateSchemaAsync" and "AddComponent" -->
```csharp
builder.Services.AddOpenApi(options =>
{
    options.AddOperationTransformer(async (operation, context, cancellationToken) =>
    {
        // Generate schema for error responses
        var errorSchema = await context.GetOrCreateSchemaAsync(typeof(ProblemDetails), null, cancellationToken);
        context.Document?.AddComponent("Error", errorSchema);

        operation.Responses ??= new OpenApiResponses();
        // Add a "4XX" response to the operation with the newly created schema
        operation.Responses["4XX"] = new OpenApiResponse
        {
            Description = "Bad Request",
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["application/problem+json"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchemaReference("Error", context.Document)
                }
            }
        };
    });
});
```