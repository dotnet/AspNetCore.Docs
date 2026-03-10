### OpenAPI 3.2.0 support (Breaking Change)

`Microsoft.AspNetCore.OpenApi` now supports OpenAPI 3.2.0 through an updated dependency on `Microsoft.OpenApi` 3.3.1 ([dotnet/aspnetcore#65415](https://github.com/dotnet/aspnetcore/pull/65415)). This update includes breaking changes from the underlying library — see the [Microsoft.OpenApi upgrade guide](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-3.md) for details.

To generate an OpenAPI 3.2.0 document, specify the version when calling `AddOpenApi()`:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_2;
});
```

Subsequent updates will take advantage of new capabilities in the 3.2.0 specification, such as item schema support for streaming events ([dotnet/aspnetcore#63754](https://github.com/dotnet/aspnetcore/issues/63754)).

Thank you [@baywet](https://github.com/baywet) for this contribution!
