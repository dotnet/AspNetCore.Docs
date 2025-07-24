using Microsoft.EntityFrameworkCore;

namespace ValidationResultErrorMessage.Data
{
    public class ValidationResultErrorMessageContext : DbContext
    {
        public ValidationResultErrorMessageContext(DbContextOptions<ValidationResultErrorMessageContext> options)
            : base(options)
        {
        }

        public DbSet<ValidationResultErrorMessage.Models.Contact> Contact { get; set; } = default!;
    }
}
