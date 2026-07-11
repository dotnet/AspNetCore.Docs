### OpenAPI 3.2 by default

Generated OpenAPI documents now target OpenAPI 3.2 by default. Documents continue to generate as before; set the document version explicitly if you need to target an earlier version for tooling that hasn't adopted 3.2 yet.

To target an earlier version, specify it when calling <xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi%2A>:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_1;
});
```
