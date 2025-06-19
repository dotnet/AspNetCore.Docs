using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Data;

public class AppDb : DbContext
{
    public required DbSet<Customer> Customers { get; set; }

    public AppDb(DbContextOptions<AppDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure entity relationships here if needed
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);
    }
}