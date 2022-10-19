using Microsoft.EntityFrameworkCore;

namespace MinApiRouteGroupSample;

public class TodoGroupDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    public TodoGroupDbContext(DbContextOptions<TodoGroupDbContext> options)
        : base(options)
    {
    }
}
