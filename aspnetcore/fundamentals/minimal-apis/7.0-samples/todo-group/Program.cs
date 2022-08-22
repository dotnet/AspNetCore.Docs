using Microsoft.EntityFrameworkCore;
using todo_group;
using todo_group.Data;
using todo_group.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(o => o.AddPolicy("AdminsOnly",
                                  b => b.RequireClaim("admin", "true")));

builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoGroupDbContext>(options =>
{
    var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    options.UseSqlite($"Data Source={Path.Join(path, "todo_group.db")}");
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<TodoGroupDbContext>();
db?.Database.MigrateAsync();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    // localhost:{port}/swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/admin", () => "Authorized Endpoint")
    .RequireAuthorization("AdminsOnly"); ;

// todoV1 endpoints
var todosV1 = app.MapGroup("/todos/v1")
    .WithTags("Todo Endpoints")
    .AddEndpointFilter(async (context, next) =>
    {
        app.Logger.LogInformation("Accessing todo endpoints");
        return await next(context);
    });

todosV1.MapGet("/", TodoEndpointsV1.GetAllTodos);

todosV1.MapGet("/{id}", TodoEndpointsV1.GetTodo);

todosV1.MapPost("/", TodoEndpointsV1.CreateTodo)
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
        var param = efiContext.GetArgument<TodoDto>(0);

        var validationErrors = Utilities.IsValid(param);

        if (validationErrors.Any())
        {
            return Results.ValidationProblem(validationErrors);
        }

        return await next(efiContext);
    });

todosV1.MapPut("/{id}", TodoEndpointsV1.UpdateTodo)
    .AddEndpointFilter(async (context, next) =>
    {
        // log time taken to process
        var start = DateTime.Now;
        var result = await next(context);
        var end = DateTime.Now;
        app.Logger.LogInformation($"{context.HttpContext.Request.Path.Value} took {(end - start).TotalMilliseconds}ms");
        return result;
    });

todosV1.MapDelete("/{id}", TodoEndpointsV1.DeleteTodo);

// todoV2 endpoints
var todosV2 = app.MapGroup("/todos/v2")
    .WithTags("Todo Endpoints")
    .AddEndpointFilter(async (context, next) =>
    {
        app.Logger.LogInformation("Accessing todo endpoints");
        return await next(context);
    });

todosV2.MapGet("/", TodoEndpointsV2.GetAllTodos);
todosV2.MapGet("/incompleted", TodoEndpointsV2.GetAllIncompletedTodos);
todosV2.MapGet("/{id}", TodoEndpointsV2.GetTodo);

todosV2.MapPost("/", TodoEndpointsV2.CreateTodo)
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
        var param = efiContext.GetArgument<TodoDto>(0);

        var validationErrors = Utilities.IsValid(param);

        if (validationErrors.Any())
        {
            return Results.ValidationProblem(validationErrors);
        }

        return await next(efiContext);
    });

todosV2.MapPut("/{id}", TodoEndpointsV2.UpdateTodo)
    .AddEndpointFilter(async (context, next) =>
    {
        // log time taken to process
        var start = DateTime.Now;
        var result = await next(context);
        var end = DateTime.Now;
        app.Logger.LogInformation($"{context.HttpContext.Request.Path.Value} took {(end - start).TotalMilliseconds}ms");
        return result;
    });

todosV2.MapDelete("/{id}", TodoEndpointsV2.DeleteTodo);

app.Run();

public partial class Program
{ }
