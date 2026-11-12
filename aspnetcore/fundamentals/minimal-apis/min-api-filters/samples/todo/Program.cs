using Microsoft.EntityFrameworkCore;
using TodoApi.EndpointFilters;

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

#region snippet_filter1
app.MapPut("/todoitems/{id}", async (Todo inputTodo, int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;
    
    await db.SaveChangesAsync();

    return Results.NoContent();
}).AddEndpointFilter(async (efiContext, next) =>
{
    var tdparam = efiContext.GetArgument<Todo>(0);

    var validationError = Utilities.IsValid(tdparam);

    if (!string.IsNullOrEmpty(validationError))
    {
        return Results.Problem(validationError);
    }
    return await next(efiContext);
});
#endregion

#region snippet_2flt
app.MapPut("/todoitems2/{id}", async (Todo inputTodo, int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
}).AddEndpointFilter<TodoIsValidFilter>();

app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
}).AddEndpointFilter<TodoIsValidFilter>();
#endregion

#region snippet_UC
app.MapPut("/todoitemsUC/{id}", async (Todo inputTodo, int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
}).AddEndpointFilter<TodoIsValidUcFilter>();

app.MapPost("/todoitemsUC", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
}).AddEndpointFilter<TodoIsValidUcFilter>();
#endregion

// <snippet_filterfactory1>
app.MapPut("/todoitems/{id}", async (Todo inputTodo, int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;
    
    await db.SaveChangesAsync();

    return Results.NoContent();
}).AddEndpointFilterFactory((filterFactoryContext, next) =>
{
    var parameters = filterFactoryContext.MethodInfo.GetParameters();
    if (parameters.Length >= 1 && parameters[0].ParameterType == typeof(Todo))
    {
        return async invocationContext =>
        {
            var todoParam = invocationContext.GetArgument<Todo>(0);

            var validationError = Utilities.IsValid(todoParam);

            if (!string.IsNullOrEmpty(validationError))
            {
                return Results.Problem(validationError);
            }
            return await next(invocationContext);
        };
    }
    return invocationContext => next(invocationContext); 
});
// </snippet_filterfactory1>

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

app.Run();

#region snippet_model
public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
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
