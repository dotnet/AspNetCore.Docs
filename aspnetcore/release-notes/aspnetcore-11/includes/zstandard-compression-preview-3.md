### Zstandard response compression and request decompression

ASP.NET Core now supports [Zstandard (zstd)](https://facebook.github.io/zstd/) for both response compression and request decompression. This adds zstd support to the existing response-compression and request-decompression middleware and enables zstd by default.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression();
builder.Services.AddRequestDecompression();
builder.Services.Configure<ZstandardCompressionProviderOptions>(options =>
{
    options.CompressionOptions = new ZstandardCompressionOptions
    {
        Quality = 6 // 1-22, higher = better compression, slower
    };
});
```

Thank you [@manandre](https://github.com/manandre) for this contribution!
