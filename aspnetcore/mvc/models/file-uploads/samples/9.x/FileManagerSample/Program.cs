using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to allow large files
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 6L * 1024 * 1024 * 1024; // 6 GB

    // timeout settings
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10); // Extend timeout for large file uploads
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
});

// Configure FormOptions to allow large multipart body
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 6L * 1024 * 1024 * 1024; // 6 GB
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
