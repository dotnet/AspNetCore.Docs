using Microsoft.EntityFrameworkCore;

namespace todo_group.Data;

public class TodoGroupDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    public TodoGroupDbContext(DbContextOptions<TodoGroupDbContext> options)
        : base(options)
    {
    }
}
