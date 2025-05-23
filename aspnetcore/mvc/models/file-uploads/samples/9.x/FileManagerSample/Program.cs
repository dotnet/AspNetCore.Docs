var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // if not present, will throw similar exception:
        //   Microsoft.AspNetCore.Server.Kestrel.Core.BadHttpRequestException: Request body too large. The max request body size is 30000000 bytes.
    options.Limits.MaxRequestBodySize = 6L * 1024 * 1024 * 1024; // 6 GB

    // optional: timeout settings
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
