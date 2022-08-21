using Microsoft.EntityFrameworkCore;
using todo_group;
using todo_group.Data;
using todo_group.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoGroupDbContext>(options =>
{
    options.UseSqlite("DataSource=:memory:");
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
var todos = app.MapGroup("/todos")
                            .WithTags("Todo Endpoints")
                            .AddEndpointFilter(async (context, next) =>
                            {
                                app.Logger.LogInformation("Accessing todo endpoints");
                                return await next(context);
                            });

todos.MapGet("/", TodoEndpoints.GetAllTodos);
todos.MapGet("/{id}", TodoEndpoints.GetTodo);

todos.MapPost("/", TodoEndpoints.CreateTodo)
    .AddEndpointFilter(async (context, next) =>
    {
        // log time taken to process
        var start = DateTime.Now;
        var result = await next(context);
        var end = DateTime.Now;
        app.Logger.LogInformation($"{context.HttpContext.Request.Path.Value} took {(end - start).TotalMilliseconds}ms");
        return result;
    })
    .AddEndpointFilter(async (efiContext, next) =>
    {
        var tdparam = efiContext.GetArgument<TodoDto>(0);

        var validationErrors = Utilities.IsValid(tdparam);

        if (validationErrors.Any())
        {
            return Results.ValidationProblem(validationErrors);
        }

        return await next(efiContext);
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
