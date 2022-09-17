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
var todos = app.MapGroup("/todos").WithTags("Todo Endpoints").AddRouteHandlerFilter(async (context, next) =>
{
    app.Logger.LogInformation("Accessing todo endpoints");
    return await next(context);
});
todos.MapGet("/", RouteHandlers.GetAllTodos);
todos.MapGet("/{id}", RouteHandlers.GetTodo);
todos.MapPost("/", RouteHandlers.CreateTodo).AddRouteHandlerFilter(async (context, next) =>
{
    // log time taken to process
    var start = DateTime.Now;
    var result = await next(context);
    var end = DateTime.Now;
    app.Logger.LogInformation($"{context.HttpContext.Request.Path.Value} took {(end - start).TotalMilliseconds}ms");
    return result;
});
todos.MapPut("/{id}", RouteHandlers.UpdateTodo).AddRouteHandlerFilter(async (context, next) =>
{
    // log time taken to process
    var start = DateTime.Now;
    var result = await next(context);
    var end = DateTime.Now;
    app.Logger.LogInformation($"{context.HttpContext.Request.Path.Value} took {(end - start).TotalMilliseconds}ms");
    return result;
});
todos.MapDelete("/{id}", RouteHandlers.DeleteTodo);

app.Run();
