using Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoGroupDbContext>(options =>
{
    options.UseSqlite(connection);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // localhost:{port}/swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

// todo endpoints
var todos = app.MapGroup("/todos").WithTags("Todo Endpoints").AddEndpointFilter(async (context, next) =>
{
    app.Logger.LogInformation("Accessing todo endpoints");
    return await next(context);
});
todos.MapGet("/", TodoEndpoints.GetAllTodos);
todos.MapGet("/{id}", TodoEndpoints.GetTodo);
todos.MapPost("/", TodoEndpoints.CreateTodo).AddEndpointFilter(async (context, next) =>
{
    // log time taken to process
    var start = DateTime.Now;
    var result = await next(context);
    var end = DateTime.Now;
    app.Logger.LogInformation($"{context.HttpContext.Request.Path.Value} took {(end - start).TotalMilliseconds}ms");
    return result;
});
todos.MapPut("/{id}", TodoEndpoints.UpdateTodo).AddEndpointFilter(async (context, next) =>
{
    // log time taken to process
    var start = DateTime.Now;
    var result = await next(context);
    var end = DateTime.Now;
    app.Logger.LogInformation($"{context.HttpContext.Request.Path.Value} took {(end - start).TotalMilliseconds}ms");
    return result;
});
todos.MapDelete("/{id}", TodoEndpoints.DeleteTodo);

app.Run();
