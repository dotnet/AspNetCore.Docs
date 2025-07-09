### OpenAPI 3.1 support

ASP.NET Core has added support for generating [OpenAPI version 3.1] documents in .NET 10.
Despite the minor version bump, OpenAPI 3.1 is a significant update to the OpenAPI specification,
in particular with full support for [JSON Schema draft 2020-12].

[OpenAPI version 3.1]: https://spec.openapis.org/oas/v3.1.1.html
[JSON Schema draft 2020-12]: https://json-schema.org/specification-links#2020-12

Some of the changes you will see in the generated OpenAPI document include:

* Nullable types no longer have the `nullable: true` property in the schema.
* Instead of a `nullable: true` property, they have a `type` keyword whose value is an array that includes `null` as one of the types.
* Properties or parameters defined as a C# `int` or `long` now appear in the generated OpenAPI document without the `type: integer` field
and have a `pattern` field limiting the value to digits.
This happens when the <xref:System.Text.Json.JsonSerializerOptions.NumberHandling> property in the <xref:System.Text.Json.JsonSerializerOptions> is set to `AllowReadingFromString`, the default for ASP.NET Core Web apps. To enable C# `int` and `long` to be represented in the OpenAPI document as `type: integer`, set the <xref:System.Text.Json.JsonSerializerOptions.NumberHandling> property to `Strict`.

With this feature, the default OpenAPI version for generated documents is`3.1`. The version can be changed by explicitly setting the [OpenApiVersion](/dotnet/api/microsoft.aspnetcore.openapi.openapioptions.openapiversion) property of the [OpenApiOptions](/dotnet/api/microsoft.aspnetcore.openapi.openapioptions) in the `configureOptions` delegate parameter of [AddOpenApi](/dotnet/api/microsoft.extensions.dependencyinjection.openapiservicecollectionextensions.addopenapi):

:::code language="csharp" source="~/release-notes/aspnetcore-10/samples/WebAppOpenAPI10/Program.cs" id="snippet_DefaultOpenApiVersion" highlight="3":::

When generating the OpenAPI document at build time, the OpenAPI version can be selected by setting the `--openapi-version` in the `OpenApiGenerateDocumentsOptions` MSBuild item:

:::code language="xml" source="~/release-notes/aspnetcore-10/samples/WebAppOpenAPI10/WebAppOpenAPI10.csproj" id="snippet_ConfigBuildTimeOpenApiDocVersion" highlight="7":::

OpenAPI 3.1 support was primarily added in the following [PR](https://github.com/dotnet/aspnetcore/pull/59480).

### OpenAPI 3.1 breaking changes

Support for OpenAPI 3.1 requires an update to the underlying OpenAPI.NET library to a new major version, 2.0. This new version has some breaking changes from the previous version. The breaking changes may impact apps if they have any document, operation, or schema transformers.
Breaking changes in this iteration include the following:

* Entities within the OpenAPI document, like operations and parameters, are typed as interfaces. Concrete implementations exist for the inlined and referenced variants of an entity. For example, an `IOpenApiSchema` can either be an inlined `OpenApiSchema` or an `OpenApiSchemaReference` that points to a schema defined elsewhere in the document.
* The `Nullable` property has been removed from the `OpenApiSchema` type. To determine if a type is nullable, evaluate if the `OpenApiSchema.Type` property sets `JsonSchemaType.Null`.

One of the most significant changes is that the `OpenApiAny` class has been dropped in favor of using `JsonNode` directly. Transformers that use `OpenApiAny` need to be updated to use `JsonNode`. The following diff shows the changes in schema transformer from .NET 9 to .NET 10:

:::code language="diff" source="~/release-notes/aspnetcore-10/samples/WebAppOpenAPI10/TransformerJsonNode.cs":::

Note that these changes are necessary even when only configuring the OpenAPI version to 3.0.

### OpenAPI in YAML

ASP.NET now supports serving the generated OpenAPI document in YAML format. YAML can be more concise than JSON, eliminating curly braces and quotation marks when these can be inferred. YAML also supports multi-line strings, which can be useful for long descriptions.

To configure an app to serve the generated OpenAPI document in YAML format, specify the endpoint in the MapOpenApi call with a ".yaml" or ".yml" suffix, as shown in the following example:

:::code language="csharp" source="~/release-notes/aspnetcore-10/samples/WebAppOpenAPI10/Program.cs" id="snippet_ConfigOpenApiYAML" highlight="3":::

Support for:

* YAML is currently only available for the OpenAPI served from the OpenAPI endpoint.
* Generating OpenAPI documents in YAML format at build time is added in a future preview.

See [this PR](https://github.com/dotnet/aspnetcore/pull/58616) which added support for serving the generated OpenAPI document in YAML format.
