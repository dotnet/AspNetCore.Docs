var builder = WebApplication.CreateBuilder(args);
//add cors
builder.Services.AddCors(option=>{
    option.AddPolicy("AllowAll", p=>p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    option.AddDefaultPolicy(p=>p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();
//add cors
app.UseCors("AllowAll");
app.MapGet("/", () => "Hello World!");

app.MapPost("/fileUp", async (IFormFile file) =>
{
    string tempfile = Path.GetTempFileName();
    using var stream = File.OpenWrite(tempfile);
    await file.CopyToAsync(stream);
    return TypedResults.Redirect("/");
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