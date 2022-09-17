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
app.MapGroup("public/todos").MapTodosApi().WithTags("Todo Endpoints").AddEndpointFilter(async (context, next) =>
{
    app.Logger.LogInformation("Accessing todo endpoints");
    return await next(context);
});

app.Run();
