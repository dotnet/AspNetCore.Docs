### OpenAPI 3.2.0 support (Breaking Change)

`Microsoft.AspNetCore.OpenApi` now supports OpenAPI 3.2.0 through an updated dependency on `Microsoft.OpenApi` 3.3.1. This update includes breaking changes from the underlying library. For more information, see the [Microsoft.OpenApi upgrade guide](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-3.md).

To generate an OpenAPI 3.2.0 document, specify the version when calling <xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi%2A>:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_2;
});
```

Subsequent updates take advantage of new capabilities in the 3.2.0 specification, such as item schema support for streaming events.

Thank you [@baywet](https://github.com/baywet) for this contribution!
