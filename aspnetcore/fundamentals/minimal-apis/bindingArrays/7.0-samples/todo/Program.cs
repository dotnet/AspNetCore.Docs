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
        return Results.Ok(todo);
    }

    return Results.NotFound();
});

#region snippet_binding_arrays

#region batch_post_payload
/*
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
*/
#endregion

// POST /todoitems/batch
app.MapPost("/todoitems/batch", async (Todo[] todos, TodoDb db) =>
{
    await db.Todos.AddRangeAsync(todos);
    await db.SaveChangesAsync();

    return Results.Ok(todos);
});

// Bind to a string array
// GET /todoitems/tags?tags=home&tags=work
app.MapGet("/todoitems/tags", async (Tag[] tags, TodoDb db) =>
{
    return await db.Todos
        .Where(t => tags.Select(i => i.Name).Contains(t.Tag.Name))
        .ToListAsync();
});

// Bind to headers
// GET /todoitems/header-ids
app.MapGet("/todoitems/header-ids", async ([FromHeader(Name = "X-Todo-Id")] int[] ids, TodoDb db) =>
{
    return await db.Todos
        .Where(t => ids.Contains(t.Id))
        .ToListAsync();
});

// Bind to a int array
// GET /todoitems/querystring-ids?ids=1&ids=2
app.MapGet("/todoitems/query-string-ids", async (int[] ids, TodoDb db) =>
{
    return await db.Todos
        .Where(t => ids.Contains(t.Id))
        .ToListAsync();
});

// Bind to a string array
// GET /todoitems//query-string-names-v1?names=Have%20Breakfast&names=Have%20Lunch
app.MapGet("/todoitems/query-string-names-v1", async (string[] names, TodoDb db) =>
{
    return await db.Todos
        .Where(t => names.Contains(t.Name))
        .ToListAsync();
});

// Bind to StringValues
// GET /todoitems//query-string-names-v2?names=Have%20Breakfast&names=Have%20Lunch
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
