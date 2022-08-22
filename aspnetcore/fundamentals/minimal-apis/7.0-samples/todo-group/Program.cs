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
app.MapGroup("/todos/v1")
   .MapTodosApiV1()
   .WithTags("Todo Endpoints")
   .AddEndpointFilter(async (context, next) =>
   {
       app.Logger.LogInformation("Accessing todo endpoints");
       return await next(context);
   });

// todoV2 endpoints
app.MapGroup("/todos/v2")
    .MapTodosApiV2()
    .WithTags("Todo Endpoints")
    .AddEndpointFilter(async (context, next) =>
    {
        app.Logger.LogInformation("Accessing todo endpoints");
        return await next(context);
    });

app.Run();

public partial class Program
{ }
