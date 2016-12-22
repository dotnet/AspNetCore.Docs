public class ProductsContext : DbContext
{
    public ProductsContext() 
            : base("name=ProductsContext")
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    // New code:
    public DbSet<ProductRating> Ratings { get; set; }
}