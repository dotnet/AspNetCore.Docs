### Microsoft.OpenApi upgraded to 3.x

In .NET 11, `Microsoft.AspNetCore.OpenApi` upgrades its dependency on `Microsoft.OpenApi` from 2.x to 3.x. The transformer interfaces are unchanged, but the object model for `OpenApiDocument`, `OpenApiOperation`, and `OpenApiSchema` has changed shape. Custom document, operation, and schema transformers that inspect or mutate OpenAPI objects must be updated to compile against the 3.x API.

For detailed migration guidance and breaking change details, see [Microsoft.OpenApi upgraded to 3.x (ASP.NET Core 11.0 breaking change announcement)](/aspnet/core/breaking-changes/11/microsoft-openapi-3x) and the [Microsoft.OpenApi 3.x upgrade guide](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-3.md).
