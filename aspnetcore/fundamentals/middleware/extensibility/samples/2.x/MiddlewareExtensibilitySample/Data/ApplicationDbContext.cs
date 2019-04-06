using Microsoft.EntityFrameworkCore;
using MiddlewareExtensibilitySample.Models;

namespace MiddlewareExtensibilitySample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
    }
}
