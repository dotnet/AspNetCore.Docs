using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

namespace SampleApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppFile> File { get; set; }
    }
}
