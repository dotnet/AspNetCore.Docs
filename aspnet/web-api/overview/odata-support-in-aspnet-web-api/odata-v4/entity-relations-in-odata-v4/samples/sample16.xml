public class ProductsController : ODataController
{
    [AcceptVerbs("POST", "PUT")]
    public async Task<IHttpActionResult> CreateRef([FromODataUri] int key, 
        string navigationProperty, [FromBody] Uri link)
    {
        var product = await db.Products.SingleOrDefaultAsync(p => p.Id == key);
        if (product == null)
        {
            return NotFound();
        }
        switch (navigationProperty)
        {
            case "Supplier":
                // Note: The code for GetKeyFromUri is shown later in this topic.
                var relatedKey = Helpers.GetKeyFromUri<int>(Request, link);
                var supplier = await db.Suppliers.SingleOrDefaultAsync(f => f.Id == relatedKey);
                if (supplier == null)
                {
                    return NotFound();
                }

                product.Supplier = supplier;
                break;

            default:
                return StatusCode(HttpStatusCode.NotImplemented);
        }
        await db.SaveChangesAsync();
        return StatusCode(HttpStatusCode.NoContent);
    }

    // Other controller methods not shown.
}