using Microsoft.EntityFrameworkCore;

namespace MinApiRouteGroupSample;

public class TodoDb : DbContext
{
    private DbSet<Todo> Todos => Set<Todo>();

    /// <summary>
    /// If false, only query public todos; if true, only query private todos.
    /// </summary>
    public bool IsPrivate { get; set; }

    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public async Task<Todo?> FindAsync(int id)
    {
        var foundTodo = await Todos.FindAsync(id);

        if (foundTodo?.IsPrivate != IsPrivate)
        {
            return null;
        }

        return foundTodo;
    }

    public Task<List<Todo>> ToListAsync()
    {
        return Todos.Where(todo => todo.IsPrivate == IsPrivate).ToListAsync();
    }

    public Task AddAsync(Todo todo)
    {
        todo.IsPrivate = IsPrivate;
        return Todos.AddAsync(todo).AsTask();
    }

    public void Remove(Todo todo) => Todos.Remove(todo);
}
