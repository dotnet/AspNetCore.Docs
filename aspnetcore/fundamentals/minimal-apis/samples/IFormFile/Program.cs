var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// End point to support a single file upload
app.MapGet("/singleFile", () => Results.Text(@"<!DOCTYPE html> <html> <head> <meta charset='utf-8'> </head> <body> <form action='/fileup' method='post' enctype='multipart/form-data'> <input multiple name='formfile' type='file'>Swac <input type='submit'> </form> </body> </html>", "text/html"));

// End point to support multiple file uploads
app.MapGet("/multipleFiles", () => Results.Text(@"<!DOCTYPE html> <html> <head> <meta charset='utf-8'> </head> <body> <form action='/filesup' method='post' enctype='multipart/form-data'> <input multiple name='formfile' type='file'>Swac <input type='submit'> </form> </body> </html>", "text/html"));

app.MapPost("/fileup", async (IFormFile file) =>
{
    // save a file
    string tempfile = Path.GetTempFileName();
    using var stream = File.OpenWrite(tempfile);
    await file.CopyToAsync(stream);
    return Results.Accepted();
});

app.MapPost("/filesup", async (IFormFileCollection myFiles) =>
{
    // save file collections
    foreach (var file in myFiles)
    {
        string tempfile = Path.GetTempFileName();
        using var stream = File.OpenWrite(tempfile);
        await file.CopyToAsync(stream);
    }
    return Results.Accepted();
});

app.Run();
