### OpenAPI Schema Generation Enhancements

#### Model nullable types using oneOf in OpenAPI schema

OpenAPI schema generation for nullable types was improved by using the `oneOf` pattern instead of the nullable property for complex types and collections. The implementation:

- Uses `oneOf` with `null` and the actual type schema for nullable complex types in request and response schemas.
- Detects nullability for parameters, properties, and return types using reflection and `NullabilityInfoContext`.
- Removes null types from componentized schemas to avoid duplication.

#### Fixes and improvements to schema reference resolution

This release improves the handling of JSON schemas for OpenAPI document generation by properly resolving relative JSON schema references (`$ref`) in the root schema document.

#### Include property descriptions as siblings of $ref in OpenAPI schema

Prior to .NET 10, ASP.NET Core discarded descriptions on properties defined with `$ref` in the generated OpenAPI document because OpenAPI v3.0 didn't allow sibling properties alongside `$ref` in schema definitions. OpenAPI 3.1 now lets you include descriptions alongside `$ref`. RC1 adds support for including property descriptions as siblings of `$ref` in the generated OpenAPI schema.

This was a community contribution. Thanks @desjoerd!

#### Add metadata from XML comments on `[AsParameters]` types to OpenAPI schema

OpenAPI schema generation now processes XML comments on properties of `[AsParameters]` parameter classes to extract metadata for documentation.

#### Exclude unknown HTTP methods from OpenAPI

OpenAPI schema generation now excludes unknown HTTP methods from the generated OpenAPI document. Query methods, which are standard HTTP methods but not recognized by OpenAPI, are now gracefully excluded from the generated OpenAPI document.

This was a community contribution. Thanks @martincostello!

#### Improve the description of JSON Patch request bodies

The OpenAPI schema generation for JSON Patch operations now correctly applies the `application/json-patch+json` media type to request bodies that use JSON Patch. This ensures that the generated OpenAPI document accurately reflects the expected media type for JSON Patch operations. In addition, the JSON Patch request body has a detailed schema that describes the structure of the JSON Patch document, including the operations that can be performed.

This was a community contribution. Thanks @martincostello!

#### Use invariant culture for OpenAPI document generation

OpenAPI document generation now uses invariant culture for formatting numbers and dates in the generated OpenAPI document. This ensures that the generated document is consistent and does not vary based on the server's culture settings.

This was a community contribution. Thanks @martincostello!
