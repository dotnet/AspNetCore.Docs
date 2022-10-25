using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MinApiRouteGroupSample;

public static class TodoEndpoints
{
    // <snippet_TodoEndpoints>
    public static RouteGroupBuilder MapTodosApi(this RouteGroupBuilder group, bool isPrivate = false)
    {
        group.MapGet("/", GetAllTodos);
        group.MapGet("/{id}", GetTodo);
        group.MapPost("/", CreateTodo);
        group.MapPut("/{id}", UpdateTodo);
        group.MapDelete("/{id}", DeleteTodo);

        if (isPrivate)
        {
            group.AddEndpointFilterFactory(MakeDbContextParameterPrivate);
        }

        return group;
    }
    // </snippet_TodoEndpoints>

    // get all todos
    public static async Task<Ok<List<Todo>>> GetAllTodos(TodoGroupDbContext database)
    {
        var todos = await database.ToListAsync();
        return TypedResults.Ok(todos);
    }

    // get todo by id
    public static async Task<Results<Ok<Todo>, NotFound>> GetTodo(int id, TodoGroupDbContext database)
    {
        var todo = await database.FindAsync(id);

        if (todo is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(todo);
    }

    // create todo
    // <snippet_Create>
    public static async Task<Created<Todo>> CreateTodo(Todo todo, TodoGroupDbContext database)
    {
        await database.AddAsync(todo);
        await database.SaveChangesAsync();

        return TypedResults.Created($"{todo.Id}", todo);
    }
    // </snippet_Create>

    // update todo
    public static async Task<Results<NoContent, NotFound>> UpdateTodo(Todo todo, TodoGroupDbContext database)
    {
        var existingTodo = await database.FindAsync(todo.Id);

        if (existingTodo is null)
            return TypedResults.NotFound();

        existingTodo.Title = todo.Title;
        existingTodo.Description = todo.Description;
        existingTodo.IsDone = todo.IsDone;

        await database.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    // delete todo
    public static async Task<Results<NoContent, NotFound>> DeleteTodo(int id, TodoGroupDbContext database)
    {
        var todo = await database.FindAsync(id);

        if (todo is null)
            return TypedResults.NotFound();

        database.Remove(todo);
        await database.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    private static EndpointFilterDelegate (EndpointFilterFactoryContext factoryContext, EndpointFilterDelegate next)
    {
        var dbContextIndex = -1;
        
        foreach (var argument in factoryContext.MethodInfo.GetParameters())
        {
            if (argument.ParameterType == typeof(TodoGroupDbContext))
            {
                dbContextIndex = argument.Position;
                break;
            }
        }

        // Skip filter if the method doesn't have a TodoGroupDbContext parameter
        if (dbContextIndex < 0)
        {
            return next;
        }

        return async invocationContext =>
        {
            var dbContext = invocationContext.GetArgument<TodoGroupDbContext>(dbContextIndex);
            dbContext.IsPrivate = true;

            try
            {
                return await next(invocationContext);
            }
            finally
            {
                // This should only be relevant if you're pooling or otherwise reusing the DbContext instance.
                dbContext.IsPrivate = false;
            }
        };
    }
}
