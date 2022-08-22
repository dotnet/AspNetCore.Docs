using todo_group.Data;
using todo_group.Services;

namespace todo_group;

public class TodoEndpointsV2
{
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

        return TypedResults.Created($"/public/todos/{newTodo.Id}", newTodo);
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

            return TypedResults.Created($"/public/todos/{existingTodo.Id}", existingTodo);
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
