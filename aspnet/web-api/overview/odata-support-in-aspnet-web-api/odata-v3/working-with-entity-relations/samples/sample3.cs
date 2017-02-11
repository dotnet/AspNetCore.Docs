public class ProductServiceContext : DbContext
{
    public ProductServiceContext() : base("name=ProductServiceContext")
    {
    }

    public System.Data.Entity.DbSet<ProductService.Models.Product> Products { get; set; }
    // New code:
    public System.Data.Entity.DbSet<ProductService.Models.Supplier> Suppliers { get; set; }
}