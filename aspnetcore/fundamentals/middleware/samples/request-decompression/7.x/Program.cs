#define WithDefaultProviders // WithDefaultProviders WithCustomProvider

using Microsoft.AspNetCore.Http.HttpResults;
using RequestDecompressionSample;

#if WithDefaultProviders
#region snippet_WithDefaultProviders
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRequestDecompression();

var app = builder.Build();

app.UseRequestDecompression();

app.MapPost("/", (HttpRequest request) => Results.Stream(request.Body));

app.Run();
#endregion
#elif WithCustomProvider
#region snippet_WithCustomProvider
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRequestDecompression(options =>
{
    options.DecompressionProviders.Add("custom", new CustomDecompressionProvider());
});

var app = builder.Build();

app.UseRequestDecompression();

app.MapPost("/", (HttpRequest request) => Results.Stream(request.Body));

app.Run();
#endregion
#endif
