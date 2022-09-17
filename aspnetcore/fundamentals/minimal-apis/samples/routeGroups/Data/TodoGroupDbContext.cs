using Microsoft.EntityFrameworkCore;

namespace Data;

public class TodoGroupDbContext : DbContext
{
    public TodoGroupDbContext(DbContextOptions<TodoGroupDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Todo> Todos { get; set; } = default!;
}
