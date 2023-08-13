using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (Todo inputTodo, int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

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
#region snippet_bqs2pa
// Bind query string values to a primitive type array.
// GET  /tags?q=1&q=2&q=3
app.MapGet("/tags", (int[] q) =>
                      $"tag1: {q[0]} , tag2: {q[1]}, tag3: {q[2]}");

// Bind to a string array.
// GET /tags2?names=john&names=jack&names=jane
app.MapGet("/tags2", (string[] names) =>
            $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");

// Bind to StringValues.
// GET /tags3?names=john&names=jack&names=jane
app.MapGet("/tags3", (StringValues names) =>
            $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");
#endregion

#region snippet_binding_arrays

/*
#region batch_post_payload
[
    {
        "id": 1,
        "name": "Have Breakfast",
        "isComplete": true,
        "tag": {
            "name": "home"
        }
    },
    {
        "id": 2,
        "name": "Have Lunch",
        "isComplete": true,
        "tag": {
            "name": "work"
        }
    },
    {
        "id": 3,
        "name": "Have Supper",
        "isComplete": true,
        "tag": {
            "name": "home"
        }
    },
    {
        "id": 4,
        "name": "Have Snacks",
        "isComplete": true,
        "tag": {
            "name": "N/A"
        }
    }
]
#endregion
*/

#region snippet_batch
// POST /todoitems/batch
app.MapPost("/todoitems/batch", async (Todo[] todos, TodoDb db) =>
{
    await db.Todos.AddRangeAsync(todos);
    await db.SaveChangesAsync();

    return Results.Ok(todos);
});
#endregion

// Bind to a string array
#region snippet_bind_str_array
// GET /todoitems/tags?tags=home&tags=work
app.MapGet("/todoitems/tags", async (Tag[] tags, TodoDb db) =>
{
    return await db.Todos
        .Where(t => tags.Select(i => i.Name).Contains(t.Tag.Name))
        .ToListAsync();
});
#endregion

// Bind to headers
// Use Postman or another tool to post Todo item. In the headers tab, set header key: X-Todo-Id and
// Value the ID to fetch
// See https://user-images.githubusercontent.com/3605364/178612632-140db6de-1b4d-453b-aa5a-b3a3475ab3de.png
// https://user-images.githubusercontent.com/6568968/177691682-f74ce81d-dbbe-4691-a643-a87f23e0f186.png
#region snippet_getHeader
// GET /todoitems/header-ids
// The keys of the headers should all be X-Todo-Id with different values
app.MapGet("/todoitems/header-ids", async ([FromHeader(Name = "X-Todo-Id")] int[] ids, TodoDb db) =>
{
    return await db.Todos
        .Where(t => ids.Contains(t.Id))
        .ToListAsync();
});
#endregion

// Bind to a int array
#region snippet_iaray
// GET /todoitems/query-string-ids?ids=1&ids=3
app.MapGet("/todoitems/query-string-ids", async (int[] ids, TodoDb db) =>
{
    return await db.Todos
        .Where(t => ids.Contains(t.Id))
        .ToListAsync();
});
#endregion

// Bind to a string array
// GET /todoitems/query-string-names-v1?names=Have%20Breakfast&names=Have%20Lunch
app.MapGet("/todoitems/query-string-names-v1", async (string[] names, TodoDb db) =>
{
    return await db.Todos
        .Where(t => names.Contains(t.Name))
        .ToListAsync();
});

// Bind to StringValues
// GET /todoitems/query-string-names-v2?names=Have%20Breakfast&names=Have%20Lunch
app.MapGet("/todoitems/query-string-names-v2", async (StringValues names, TodoDb db) =>
{
    return await db.Todos
        .Where(t => names.Contains(t.Name))
        .ToListAsync();
});

#endregion

app.Run();

#region snippet_model
public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    // This is an owned entity. 
    public Tag Tag { get; set; } = new();
}

[Owned]
public class Tag
{
    public string? Name { get; set; } = "n/a";

    public static bool TryParse(string? name, out Tag tag)
    {
        if (name is null)
        {
            tag = default!;
            return false;
        }

        tag = new Tag { Name = name };
        return true;
    }
}
#endregion

#region snippet_cntx
class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}
#endregion
