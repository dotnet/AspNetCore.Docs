

using Microsoft.EntityFrameworkCore;

namespace ViewComponentSample.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
                : base(options)
        {
        }
        public DbSet<TodoItem>? ToDo { get; set; }
        
        //The below is used to seeding the DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < 9; i++)
            {
                modelBuilder.Entity<TodoItem>().HasData(
                   new TodoItem
                   {
                       Id = i+1,
                       IsDone = i % 3 == 0,
                       Name = "Task " + (i + 1),
                       Priority = i % 5 + 1
                   });
            }
        }
    }
}
