using System;
using Microsoft.Extensions.DependencyInjection;


namespace ViewComponentSample.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ToDoContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            for (int i = 0; i < 9; i++)
            {
                context.Add(new TodoItem()
                {
                    IsDone = i % 3 == 0,
                    Name = "Task " + (i + 1),
                    Priority = i % 5 + 1
                });
            }
            context.SaveChanges();
        }
    }
}
