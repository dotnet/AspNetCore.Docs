using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Message> ? Messages { get; set; }
    }
}
