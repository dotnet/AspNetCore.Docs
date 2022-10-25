using Microsoft.EntityFrameworkCore;
using MinApiRouteGroupSample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoGroupDbContext>(options =>
{
    options.UseSqlite($"Data Source={Path.Join(AppContext.BaseDirectory, "WebMinRouteGroup.db")}");
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // http://localhost:5000/swagger
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<TodoGroupDbContext>();

// <snippet_MapGroup>
app.MapGroup("/public/todos")
    .MapTodosApi(isPrivate: false)
    .WithTags("Public");

app.MapGroup("/private/todos")
    .MapTodosApi(isPrivate: true)
    .WithTags("Private")
    .RequireAuthorization();
// </snippet_MapGroup>

app.Run();
