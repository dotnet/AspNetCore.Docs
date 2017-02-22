public class ProductsController : ODataController
{
    public async Task<IHttpActionResult> DeleteRef([FromODataUri] int key, 
        string navigationProperty, [FromBody] Uri link)
    {
        var product = db.Products.SingleOrDefault(p => p.Id == key);
        if (product == null)
        {
            return NotFound();
        }

        switch (navigationProperty)
        {
            case "Supplier":
                product.Supplier = null;
                break;

            default:
                return StatusCode(HttpStatusCode.NotImplemented);
        }
        await db.SaveChangesAsync();

        return StatusCode(HttpStatusCode.NoContent);
    }        

    // Other controller methods not shown.
}