

using Microsoft.EntityFrameworkCore;

namespace ViewComponentSample.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
                : base(options)
        {
        }
        public DbSet<TodoItem> ToDo { get; set; }
    }
}
