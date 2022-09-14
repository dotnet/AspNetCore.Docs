using Microsoft.EntityFrameworkCore;

namespace WebMinRouteGroup.Data;

public class TodoGroupDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    public TodoGroupDbContext(DbContextOptions<TodoGroupDbContext> options)
        : base(options)
    {
    }
}
