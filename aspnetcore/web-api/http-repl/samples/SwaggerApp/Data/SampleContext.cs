using Microsoft.EntityFrameworkCore;
using SwaggerApp.Models;

namespace SwaggerApp.Data
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        {
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
