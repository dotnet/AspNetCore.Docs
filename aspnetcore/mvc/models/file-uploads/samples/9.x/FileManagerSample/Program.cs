using System.Drawing;
using Microsoft.AspNetCore.Http.Features;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// allow large files
builder.WebHost.ConfigureKestrel(options =>
{
    // if not present, will throw similar exception:
        // fail: FileManagerSample.Controllers.FileController[0]
        //   Error during file upload
        //   Microsoft.AspNetCore.Server.Kestrel.Core.BadHttpRequestException: Request body too large. The max request body size is 30000000 bytes.
    options.Limits.MaxRequestBodySize = 6L * 1024 * 1024 * 1024; // 6 GB

    // timeout settings
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10); // Extend timeout for large file uploads
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
