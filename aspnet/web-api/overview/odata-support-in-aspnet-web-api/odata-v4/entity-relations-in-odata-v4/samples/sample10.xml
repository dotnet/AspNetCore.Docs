public class SuppliersController : ODataController
{
    // GET /Suppliers(1)/Products
    [EnableQuery]
    public IQueryable<Product> GetProducts([FromODataUri] int key)
    {
        return db.Suppliers.Where(m => m.Id.Equals(key)).SelectMany(m => m.Products);
    }

    // Other controller methods not shown.
}