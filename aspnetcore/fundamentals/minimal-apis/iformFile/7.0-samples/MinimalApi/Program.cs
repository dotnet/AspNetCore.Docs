using Microsoft.AspNetCore.Http;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/upload", async (IFormFile file) =>
{
    var temFile = Path.GetTempFileName(); // or an existing custome file path
    using var stream = File.OpenWrite(temFile);
    await file.CopyToAsync(stream);
});
app.MapPost("/upload_many", async (IFormFileCollection myFiles) =>
{
    foreach (var file in myFiles)
    {
        var temFile = Path.GetTempFileName(); // or an existing custome file path
        using var stream = File.OpenWrite(temFile);
        await file.CopyToAsync(stream);
    }
});


app.Run();
