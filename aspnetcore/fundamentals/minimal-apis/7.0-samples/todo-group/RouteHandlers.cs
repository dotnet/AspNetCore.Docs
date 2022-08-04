using Data;
using Microsoft.EntityFrameworkCore;

public class RouteHandlers
{
    // get all todos
    public static async Task<IResult> GetAllTodos(TodoGroupDbContext database)
    {
        var todos = await database.Todos.ToListAsync();
        return TypedResults.Ok(todos);
    }

    // get todo by id
    public static async Task<IResult> GetTodo(int id, TodoGroupDbContext database)
    {
        var todo = await database.Todos.FindAsync(id);
        if (todo != null)
        {
            return TypedResults.Ok(todo);
        }
        return TypedResults.NotFound();
    }

    // create todo
    public static async Task<IResult> CreateTodo(TodoDto todo, TodoGroupDbContext database)
    {
        var newTodo = new Todo
        {
            Title = todo.Title,
            Description = todo.Description,
            IsDone = todo.IsDone
        };
        await database.Todos.AddAsync(newTodo);
        await database.SaveChangesAsync();
        return TypedResults.Created($"/public/todos/{newTodo.Id}", newTodo);
    }

    // update todo
    public static async Task<IResult> UpdateTodo(Todo todo, TodoGroupDbContext database)
    {
        var existingTodo = await database.Todos.FindAsync(todo.Id);
        if (existingTodo != null)
        {
            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.IsDone = todo.IsDone;
            await database.SaveChangesAsync();
            return TypedResults.Created($"/public/todos/{existingTodo.Id}", existingTodo);
        }

        return TypedResults.NotFound();
    }

    // delete todo
    public static async Task<IResult> DeleteTodo(int id, TodoGroupDbContext database)
    {
        var todo = await database.Todos.FindAsync(id);
        if (todo != null)
        {
            database.Todos.Remove(todo);
            await database.SaveChangesAsync();
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
}
