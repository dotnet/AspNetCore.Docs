using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ModelProvidersSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
