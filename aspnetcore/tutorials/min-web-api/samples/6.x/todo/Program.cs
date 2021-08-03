#define FIRST
#if FIRST
#region snippet_all
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/TodoItems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/TodoItems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/TodoItems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/TodoItems", async (Todo todo, TodoDb db) =>
{
    if (!MinimalValidation.TryValidate(todo, out var errors))
        return Results.ValidationProblem(errors);

    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/TodoItems/{todo.Id}", todo);
});

app.Run();

class Todo
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}

class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}
#endregion
#endif