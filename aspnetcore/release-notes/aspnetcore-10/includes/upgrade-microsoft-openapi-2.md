### Upgrade Microsoft.OpenApi to 2.0.0

The [`Microsoft.OpenApi`](https://www.nuget.org/packages/Microsoft.OpenApi/) library used for OpenAPI document generation in ASP.NET Core has been upgraded to version 2.0.0 (GA).

#### Breaking changes in 2.0.0

The following breaking changes were introduced in the preview releases and remain in the GA version. These primarily affect users who implement document, operation, or schema transformers:

* [Ephemeral object properties are now in Metadata](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-2.md#ephemeral-object-properties-are-now-in-metadata)
* [Use HTTP Method Object Instead of Enum](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-2.md#use-http-method-object-instead-of-enum)

With the update to the GA version, no further breaking changes are expected in OpenAPI document generation.
