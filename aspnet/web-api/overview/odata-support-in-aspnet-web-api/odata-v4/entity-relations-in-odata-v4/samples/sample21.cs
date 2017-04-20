public class SuppliersController : ODataController
{
    public async Task<IHttpActionResult> DeleteRef([FromODataUri] int key, 
        [FromODataUri] string relatedKey, string navigationProperty)
    {
        var supplier = await db.Suppliers.SingleOrDefaultAsync(p => p.Id == key);
        if (supplier == null)
        {
            return StatusCode(HttpStatusCode.NotFound);
        }

        switch (navigationProperty)
        {
            case "Products":
                var productId = Convert.ToInt32(relatedKey);
                var product = await db.Products.SingleOrDefaultAsync(p => p.Id == productId);

                if (product == null)
                {
                    return NotFound();
                }
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