using Microsoft.EntityFrameworkCore;

public class ContactDbContext(DbContextOptions<ContactDbContext> options) : DbContext(options)
{
    public DbSet<MyWebApp.Contact> Contact { get; set; } = default!;
}
