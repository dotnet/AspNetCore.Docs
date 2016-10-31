using Microsoft.Data.Entity;

namespace ViewComponentSample.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<TodoItem> ToDo { get; set; }
    }
}
