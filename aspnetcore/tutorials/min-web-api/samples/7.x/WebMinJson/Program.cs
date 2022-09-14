#define First
#if First
// <snippet_1>
var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.IncludeFields = true;
});

var app = builder.Build();

app.MapGet("/", () => new Todo { Name = "Walk dog", IsComplete = false });

app.Run();

class Todo
{
    public string? Name;
    public bool IsComplete;
}
// </snippet_1>
#else
// <snippet_2>
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var options = new JsonSerializerOptions
{
  PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
  WriteIndented = true
}

app.MapGet("/", () => Results.Json(new Todo {
                      Name = "Walk dog", IsComplete = false }, options));

app.Run();

class Todo
{
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
// </snippet_2>
#endif
