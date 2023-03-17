#define writeasjsonasync
// First Second writeasjsonasync autojsondeserialization
// readfromjsonasync confighttpjsonoptions jsonoptions writeasjsonasyncwithoptions
// readfromjsonasyncwithoptions resultsjsonwithoptions
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
#elif Second
// <snippet_2>
using System.Text.Json;

var app = WebApplication.Create();

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
#elif writeasjsonasync
var app = WebApplication.Create();

// <snippet_writeasjsonasync>
app.MapGet("/", (HttpContext context) => context.Response.WriteAsJsonAsync
    (new { Message = "Hello World" }));
// </snippet_writeasjsonasync>

app.Run();

// The endpoint returns the following JSON:
//
// {"message":"Hello World"}
#elif readfromjsonasync
// <snippet_readfromjsonasync>
using System.Diagnostics;

var app = WebApplication.Create();

app.MapPost("/", async (HttpContext context) => {
    if (context.Request.HasJsonContentType()) {
        var todo = await context.Request.ReadFromJsonAsync<Todo>();
        return Results.Ok(todo);
    }
    else {
        return Results.BadRequest();
    }
});

app.Run();

class Todo
{
    
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
// If the request body contains the following JSON:
//
// {"name":"Walk dog","isComplete":false}
//
// The endpoint returns the string "Walk dog"
// </snippet_readfromjsonasync>
#elif confighttpjsonoptions
// <snippet_confighttpjsonoptions>
var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.IncludeFields = true;
});

var app = builder.Build();

app.MapPost("/", (Todo todo) => {
    if (todo is not null) {
        todo.Name = todo.NameField;
    }
    return todo;
});

app.Run();

class Todo {
    public string? Name { get; set; }
    public string? NameField;
    public bool IsComplete { get; set; }
}
// If the request body contains the following JSON:
//
// {"nameField":"Walk dog", "isComplete":false}
//
// The endpoint returns the following JSON:
//
// {
//    "name":"Walk dog",
//    "nameField":"Walk dog",
//    "isComplete":false
// }
// </snippet_confighttpjsonoptions>
#elif jsonoptions
// <snippet_jsonoptions>
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();

app.MapGet("/", () => new Todo { Name = "Walk dog", IsComplete = false });

app.Run();

class Todo
{
    
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
// The endpoint returns the following JSON:
//
// {
//   "name": "Walk dog",
//   "isComplete": false
// }
// </snippet_jsonoptions>
#elif writeasjsonasyncwithoptions
// <snippet_writeasjsonasyncwithoptions>
using System.Text.Json;

var app = WebApplication.Create();

var options = new JsonSerializerOptions(JsonSerializerDefaults.Web) {
    WriteIndented = true };

app.MapGet("/", (HttpContext context) =>
    context.Response.WriteAsJsonAsync<Todo>(
        new Todo { Name = "Walk dog", IsComplete = false }, options));

app.Run();

class Todo
{
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
// The endpoint returns the following JSON:
//
// {
//   "name":"Walk dog",
//   "isComplete":false
// }
// </snippet_writeasjsonasyncwithoptions>
#elif readfromjsonasyncwithoptions
// <snippet_readfromjsonasyncwithoptions>
using System.Text.Json;

var app = WebApplication.Create();

var options = new JsonSerializerOptions(JsonSerializerDefaults.Web) { 
    IncludeFields = true, 
    WriteIndented = true
};

app.MapPost("/", async (HttpContext context) => {
    if (context.Request.HasJsonContentType()) {
        var todo = await context.Request.ReadFromJsonAsync<Todo>(options);
        if (todo is not null) {
            todo.Name = todo.NameField;
        }
        return Results.Ok(todo);
    }
    else {
        return Results.BadRequest();
    }
});

app.Run();

class Todo
{
    public string? Name { get; set; }
    public string? NameField;
    public bool IsComplete { get; set; }
}
// If the request body contains the following JSON:
//
// {"nameField":"Walk dog", "isComplete":false}
//
// The endpoint returns the following JSON:
//
// {
//    "name":"Walk dog",
//    "isComplete":false
// }
// </snippet_readfromjsonasyncwithoptions>
#elif resultsjsonwithoptions
// <snippet_resultsjsonwithoptions>
using System.Text.Json;

var app = WebApplication.Create();

var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
    { WriteIndented = true };

app.MapGet("/", () => 
    Results.Json(new Todo { Name = "Walk dog", IsComplete = false }, options));

app.Run();

class Todo
{
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
// The endpoint returns the following JSON:
//
// {
//   "name":"Walk dog",
//   "isComplete":false
// }
// </snippet_resultsjsonwithoptions>

#endif
