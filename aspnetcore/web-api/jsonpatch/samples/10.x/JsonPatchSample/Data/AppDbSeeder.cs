using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public static class AppDbSeeder
{
    public static async Task Seed(WebApplication app)
    {
        // Create and seed the database
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDb>();
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;
            }

            Customer[] customers = {
                new Customer
                {
                    Id = "1",
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "555-123-4567",
                    Address = "123 Main St, Anytown, USA"
                },
                new Customer
                {
                    Id = "2",
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "555-987-6543",
                    Address = "456 Oak Ave, Somewhere, USA"
                },
                new Customer
                {
                    Id = "3",
                    Name = "Bob Johnson",
                    Email = "bob.johnson@example.com",
                    PhoneNumber = "555-555-5555",
                    Address = "789 Pine Rd, Elsewhere, USA"
                }
            };

            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }
    }
}