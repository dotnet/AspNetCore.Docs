using WebMinRouteGroup.Data;
using WebMinRouteGroup.Services;

namespace WebMinRouteGroup;

public static class TodoEndpointsV2
{
    public static RouteGroupBuilder MapTodosApiV2(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllTodos);
        group.MapGet("/incompleted", GetAllIncompletedTodos);
        group.MapGet("/{id}", GetTodo);

        group.MapPost("/", CreateTodo)
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

        group.MapPut("/{id}", UpdateTodo);
        group.MapDelete("/{id}", DeleteTodo);

        return group;
    }

    // get all todos
    public static async Task<IResult> GetAllTodos(ITodoService todoService)
    {
        var todos = await todoService.GetAll();
        return TypedResults.Ok(todos);
    }

    public static async Task<IResult> GetAllIncompletedTodos(ITodoService todoService)
    {
        var todos = await todoService.GetIncompleteTodos();
        return TypedResults.Ok(todos);
    }

    // get todo by id
    public static async Task<IResult> GetTodo(int id, ITodoService todoService)
    {
        var todo = await todoService.Find(id);

        if (todo != null)
        {
            return TypedResults.Ok(todo);
        }

        return TypedResults.NotFound();
    }

    // create todo
    public static async Task<IResult> CreateTodo(TodoDto todo, ITodoService todoService)
    {
        var newTodo = new Todo
        {
            Title = todo.Title,
            Description = todo.Description,
            IsDone = todo.IsDone
        };

        await todoService.Add(newTodo);

        return TypedResults.Created($"/todos/v1/{newTodo.Id}", newTodo);
    }

    // update todo
    public static async Task<IResult> UpdateTodo(Todo todo, ITodoService todoService)
    {
        var existingTodo = await todoService.Find(todo.Id);

        if (existingTodo != null)
        {
            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.IsDone = todo.IsDone;

            await todoService.Update(existingTodo);

            return TypedResults.Created($"/todos/v1/{existingTodo.Id}", existingTodo);
        }

        return TypedResults.NotFound();
    }

    // delete todo
    public static async Task<IResult> DeleteTodo(int id, ITodoService todoService)
    {
        var todo = await todoService.Find(id);

        if (todo != null)
        {
            await todoService.Remove(todo);
            return TypedResults.NoContent();
        }

        return TypedResults.NotFound();
    }
}
