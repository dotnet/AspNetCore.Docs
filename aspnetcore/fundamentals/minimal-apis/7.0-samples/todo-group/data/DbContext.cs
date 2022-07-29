using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Todo> Todos { get; set; } = default!;
    public DbSet<Note> Notes { get; set; } = default!;
}
