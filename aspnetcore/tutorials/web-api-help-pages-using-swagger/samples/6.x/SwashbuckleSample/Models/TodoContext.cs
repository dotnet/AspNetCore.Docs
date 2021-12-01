using Microsoft.EntityFrameworkCore;

// <snippet_PragmaWarningDisable>
namespace SwashbuckleSample.Models;

#pragma warning disable CS1591
public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
}
#pragma warning restore CS1591
// </snippet_PragmaWarningDisable>
