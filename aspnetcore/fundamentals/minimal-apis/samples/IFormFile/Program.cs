var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/fileUp", async (IFormFile file) =>
{
    string tempfile = Path.GetTempFileName();
    using var stream = File.OpenWrite(tempfile);
    await file.CopyToAsync(stream);
});

app.MapPost("/FilesUp", async (IFormFileCollection myFiles) =>
{
    foreach (var file in myFiles)
    {
        string tempfile = Path.GetTempFileName();
        using var stream = File.OpenWrite(tempfile);
        await file.CopyToAsync(stream);
    }
});

app.Run();