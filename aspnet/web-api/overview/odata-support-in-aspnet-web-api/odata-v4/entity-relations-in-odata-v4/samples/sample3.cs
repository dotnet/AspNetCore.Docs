public class ProductsContext : DbContext
{
    static ProductsContext()
    {
        Database.SetInitializer(new ProductInitializer());
    }

    public DbSet<Product> Products { get; set; }
    // New code:
    public DbSet<Supplier> Suppliers { get; set; }
}