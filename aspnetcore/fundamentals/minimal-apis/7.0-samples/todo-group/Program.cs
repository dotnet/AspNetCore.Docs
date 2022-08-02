using Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure TodoGroupDbContext to use the in-memory SQLite connection and register it as a service.
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
var todos = app.MapGroup("/todos").WithTags("Todo Endpoints");
todos.MapGet("/", RouteHandlers.GetAllTodos);
todos.MapGet("/{id}", RouteHandlers.GetTodo);
todos.MapPost("/", RouteHandlers.CreateTodo).AddRouteHandlerFilter((context, next) =>
{
    if (context.HttpContext.Request.ContentLength > 80)
    {
        context.HttpContext.Response.StatusCode = 400;
        IDictionary<string, string[]> errors = new Dictionary<string, string[]>()
        {
            { "Error", new[] { "The size of the payload is above 80 characters" } },
        };
        return new ValueTask<object?>(Results.ValidationProblem(errors));
    }
    return next(context);
});
todos.MapPut("/{id}", RouteHandlers.UpdateTodo).AddRouteHandlerFilter((context, next) =>
{
    if (context.HttpContext.Request.ContentLength > 80)
    {
        context.HttpContext.Response.StatusCode = 400;
        return new ValueTask<object?>(Results.BadRequest(new { Message = "Request body is too empty" }));
    }
    return next(context);
});
todos.MapDelete("/{id}", RouteHandlers.DeleteTodo);

app.Run();
