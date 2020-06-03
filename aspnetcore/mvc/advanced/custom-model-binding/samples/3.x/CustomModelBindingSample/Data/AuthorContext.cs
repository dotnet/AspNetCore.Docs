using Microsoft.EntityFrameworkCore;

namespace CustomModelBindingSample.Data
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
    }
}
