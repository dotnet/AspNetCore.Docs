using Microsoft.EntityFrameworkCore;

namespace todo_group.Data;

public sealed class TodoGroupDbContext : DbContext
{
    public TodoGroupDbContext(DbContextOptions<TodoGroupDbContext> options)
        : base(options)
    {
        Database.OpenConnection();
        Database.EnsureCreated();
    }

    public DbSet<Todo> Todos => Set<Todo>();
}
