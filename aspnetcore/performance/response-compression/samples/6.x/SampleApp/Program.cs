#define OPT // FIRST SECOND NO_COMP OPT CUST
// Use OPT to Deploy this to Azure sample
#if NEVER
#elif FIRST
#region snippet
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

var app = builder.Build();

app.UseResponseCompression();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif SECOND
#region snippet2
using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.SmallestSize;
});

var app = builder.Build();

app.UseResponseCompression();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif CUST
#region snippet_cust
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<CustomCompressionProvider>();
});

var app = builder.Build();

app.UseResponseCompression();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif NO_COMP
#region snippet_nc
using ResponseCompressionSample;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddResponseCompression();

var app = builder.Build();

//app.UseResponseCompression();

app.Map("/trickle", trickleApp =>
{
    trickleApp.Run(async context =>
    {
        context.Response.ContentType = "text/plain";

        for (int i = 0; i < 20; i++)
        {
            await context.Response.WriteAsync("a");
            await context.Response.Body.FlushAsync();
            await Task.Delay(TimeSpan.FromMilliseconds(50));
        }
    });
});

app.Map("/testfile1kb.txt", fileApp =>
{
    fileApp.Run(context =>
    {
        context.Response.ContentType = "text/plain";
        return context.Response.SendFileAsync("testfile1kb.txt");
    });
});

app.Map("/banner.svg", fileApp =>
{
    fileApp.Run(context =>
    {
        context.Response.ContentType = "image/svg+xml";
        return context.Response.SendFileAsync("banner.svg");
    });
});

app.Run(async context =>
{
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(LoremIpsum.Text);
});

app.Run();
#endregion
#elif OPT  // Deploy this to Azure sample
#region snippet_opt
#region snippet_mime
using Microsoft.AspNetCore.ResponseCompression;
using ResponseCompressionSample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<CustomCompressionProvider>();
    options.MimeTypes =
    ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "image/svg+xml" });
});

var app = builder.Build();

app.UseResponseCompression();
#endregion

app.Map("/trickle", trickleApp =>
{
    trickleApp.Run(async context =>
    {
        context.Response.ContentType = "text/plain";

        for (int i = 0; i < 20; i++)
        {
            await context.Response.WriteAsync("a");
            await context.Response.Body.FlushAsync();
            await Task.Delay(TimeSpan.FromMilliseconds(25));
        }
    });
});

app.Map("/testfile1kb.txt", fileApp =>
{
    fileApp.Run(context =>
    {
        context.Response.ContentType = "text/plain";
        return context.Response.SendFileAsync("testfile1kb.txt");
    });
});

app.Map("/banner.svg", fileApp =>
{
    fileApp.Run(context =>
    {
        context.Response.ContentType = "image/svg+xml";
        return context.Response.SendFileAsync("banner.svg");
    });
});

app.Run(async context =>
{
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(LoremIpsum.Text);
});

app.Run();
#endregion
#endif
