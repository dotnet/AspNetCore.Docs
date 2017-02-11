public class ProductsController : ODataController
{
    // GET /Products(1)/Supplier
    [EnableQuery]
    public SingleResult<Supplier> GetSupplier([FromODataUri] int key)
    {
        var result = db.Products.Where(m => m.Id == key).Select(m => m.Supplier);
        return SingleResult.Create(result);
    }
 
   // Other controller methods not shown.
}