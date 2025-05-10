### Support for generating OpenApiSchemas in transformers
<!-- https://github.com/dotnet/aspnetcore/pull/61050 -->

Developers can now generate a schema for a C# type using the same logic as ASP.NET Core OpenAPI document generation and add it to the OpenAPI document. The schema can then be referenced from elsewhere in the OpenAPI document.

The context passed to document, operation, and schema transformers includes a new `GetOrCreateSchemaAsync` method that can be used to generate a schema for a type.
This method also has an optional `ApiParameterDescription` parameter to specify additional metadata for the generated schema.

To support adding the schema to the OpenAPI document, a `Document` property has been added to the Operation and Schema transformer contexts. This allows any transformer to add a schema to the OpenAPI document using the document's `AddComponent` method.

#### Example

To use this feature in a document, operation, or schema transformer, create the schema using the `GetOrCreateSchemaAsync` method provided in the context and add it to the OpenAPI document using the document's `AddComponent` method.

<!-- In the docs, highlight the lines with the call to "GetOrCreateSchemaAsync" and "AddComponent" -->
:::code language="csharp" source="~/release-notes/aspnetcore-10/samples/WebAppOpenAPI10/Program.cs" id="snippet_Generate_OpenApiSchemas_for_type" highlight="6-7":::
