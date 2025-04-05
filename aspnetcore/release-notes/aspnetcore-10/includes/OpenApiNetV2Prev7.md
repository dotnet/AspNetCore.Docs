### Upgrade to OpenAPI.NET v2.0.0-preview7

The [OpenAPI.NET](https://github.com/microsoft/OpenAPI.NET) library used in ASP.NET Core OpenAPI document generation has been upgraded to v2.0.0-preview7. This version includes various bug fixes and improvements while also introducing some breaking changes. The breaking changes should only impact users that use document, operation, or schema transformers. Breaking changes in this iteration include the following:

* Entities within the OpenAPI document, like operations and parameters, are typed as interfaces. Concrete implementations exist for the inlined and referenced variants of an entity. For example, an `IOpenApiSchema` can either be an inlined `OpenApiSchema` or an `OpenApiSchemaReference` that points to a schema defined elsewhere in the document.
* The `Nullable` property has been removed from the `OpenApiSchema` type. To determine if a type is nullable, evaluate if the `OpenApiSchema.Type` property sets `JsonSchemaType.Null`.