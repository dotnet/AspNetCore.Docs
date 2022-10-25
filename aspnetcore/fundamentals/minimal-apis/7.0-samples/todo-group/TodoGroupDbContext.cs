using Microsoft.EntityFrameworkCore;

namespace MinApiRouteGroupSample;

public class TodoGroupDbContext : DbContext
{
    private DbSet<Todo> Todos => Set<Todo>();

    public bool IsPrivate { get; set; }

    public TodoGroupDbContext(DbContextOptions<TodoGroupDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

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
