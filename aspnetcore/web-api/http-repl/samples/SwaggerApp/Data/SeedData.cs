using SwaggerApp.Models;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace SwaggerApp.Data
{
    public static class SeedData
    {
        public static void Initialize(SampleContext context)
        {
            if (!context.Fruits.Any())
            {
                context.Fruits.AddRange(
                    new Fruit { Name = "Apple" },
                    new Fruit { Name = "Orange" },
                    new Fruit { Name = "Strawberry" }
                );

                context.SaveChanges();
            }

            if (!context.People.Any())
            {
                context.People.AddRange(
                    new Person { Name = "Scott Hunter" },
                    new Person { Name = "Scott Hanselman" },
                    new Person { Name = "Scott Guthrie" }
                );

                context.SaveChanges();
            }
        }
    }
}
