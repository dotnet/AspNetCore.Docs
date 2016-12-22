public class ProductsContext : DbContext
{
    public ProductsContext()
        : base("name=ProductsContext")
    {
    }
    public DbSet<Product> Products { get; set; }
}

public class ProductRepository : IDisposable
{
    private ProductsContext db = new ProductsContext();

    public IEnumerable<Product> GetAll()
    {
        return db.Products;
    }
    public Product GetByID(int id)
    {
        return db.Products.FirstOrDefault(p => p.Id == id);
    }
    public void Add(Product product)
    {
        db.Products.Add(product);
        db.SaveChanges();
    }

    protected void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}