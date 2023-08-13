#define TYPEDR // MINIMAL FINAL TYPEDR
#if MINIMAL
// <snippet_min>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet_min>
#elif FINAL
// <snippet_all>
using Microsoft.EntityFrameworkCore;

// <snippet_DI>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
// </snippet_DI>

// <snippet_get>
app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

// <snippet_getCustom>
app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());
// </snippet_getCustom>
// </snippet_get>

// <snippet_post>
app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});
// </snippet_post>

// <snippet_put>
app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});
// </snippet_put>

// <snippet_delete>
app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});
// </snippet_delete>

app.Run();
// </snippet_all>
#elif TYPEDR
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

// <snippet_1b>
 app.MapGet("/todos/{id}", async Task<Results<Ok<Todo>, NotFound>> (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
     is Todo todo
        ? TypedResults.Ok(todo)
        : TypedResults.NotFound());
// </snippet_1b>

/*
// <snippet_111>
app.MapGet("/todos/{id}", async (int id, TodoDb db) =>
     await db.Todos.FindAsync(id)
     is Todo todo
        ? TypedResults.Ok(todo)
        : TypedResults.NotFound());
// </snippet_111>
*/

// <snippet_11b>
app.MapGet("/hello", () => Results.Ok(new Message() { Text = "Hello World!" }))
    .Produces<Message>();
// </snippet_11b>

// <snippet_112b>
app.MapGet("/hello2", () => TypedResults.Ok(new Message() { Text = "Hello World!" }));
// </snippet_112b>

app.Run();
#endif

