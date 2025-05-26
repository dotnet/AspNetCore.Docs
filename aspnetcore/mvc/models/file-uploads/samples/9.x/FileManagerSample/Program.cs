using FileManagerSample.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FileManagerService>();

builder.WebHost.ConfigureKestrel(options =>
{
    // if not present, will throw similar exception:
        //   Microsoft.AspNetCore.Server.Kestrel.Core.BadHttpRequestException: Request body too large. The max request body size is 30000000 bytes.
    options.Limits.MaxRequestBodySize = 6L * 1024 * 1024 * 1024; // 6 GB

    // optional: timeout settings
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10L * 1024 * 1024 * 1024; // 10 GB
});

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.MapPost("minimal/multipart", async (FileManagerService fileManager, HttpRequest request, CancellationToken cancellationToken) =>
{
    if (!request.ContentType?.StartsWith("multipart/form-data") ?? true)
    {
        return Results.BadRequest("The request does not contain valid multipart form data.");
    }

    var boundary = HeaderUtilities.RemoveQuotes(MediaTypeHeaderValue.Parse(request.ContentType).Boundary).Value;
    if (string.IsNullOrWhiteSpace(boundary))
    {
        return Results.BadRequest("Missing boundary in multipart form data.");
    }

    var filePath = await fileManager.SaveViaMultipartReaderAsync(boundary, request.Body, cancellationToken);
    return Results.Ok("Saved file at " + filePath);
});

app.MapPost("minimal/pipe", async (FileManagerService fileManager, HttpRequest request, CancellationToken cancellationToken) =>
{
    if (!request.HasFormContentType)
    {
        return Results.BadRequest("The request does not contain a valid form.");
    }

    var filePath = await fileManager.SaveViaPipeReaderAsync(request.BodyReader, cancellationToken);
    return Results.Ok("Saved file at " + filePath);
});

app.MapPost("minimal/form", async (HttpRequest request, CancellationToken cancellationToken) =>
{
    if (!request.HasFormContentType)
    {
        return Results.BadRequest("The request does not contain a valid form.");
    }

    var formFeature = request.HttpContext.Features.GetRequiredFeature<IFormFeature>();
    await formFeature.ReadFormAsync(cancellationToken);

    var filePath = request.Form.Files.First().FileName;
    return Results.Ok("Saved file at " + filePath);
});

app.Run();
