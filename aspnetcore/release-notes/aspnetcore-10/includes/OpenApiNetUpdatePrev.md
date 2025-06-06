### OpenAPI.NET updated to Preview.18

The OpenAPI.NET library used in ASP.NET Core OpenAPI document generation was upgraded to [v2.0.0-preview18](https://www.nuget.org/packages/Microsoft.OpenApi/2.0.0-preview.18). The v2.0.0-preview18 version improves compatibility with the updated library version.

The previous v2.0.0-preview17 version included a number of bug fixes and improvements and also introduced some breaking changes. The breaking changes should only affect users that use document, operation, or schema transformers. Breaking changes in this iteration that may affect developers include the following:

* [Ephemeral object properties are now in Metadata](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-2.md#ephemeral-object-properties-are-now-in-metadata)
* [Use HTTP Method Object Instead of Enum](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-2.md#use-http-method-object-instead-of-enum)
