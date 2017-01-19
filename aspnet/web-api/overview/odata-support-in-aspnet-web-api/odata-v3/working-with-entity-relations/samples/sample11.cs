public async Task<IHttpActionResult> DeleteLink([FromODataUri] int key, string navigationProperty)
{
    Product product = await db.Products.FindAsync(key);
    if (product == null)
    {
        return NotFound();
    }

    switch (navigationProperty)
    {
        case "Supplier":
            product.Supplier = null;
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);

        default:
            return NotFound();

    }
}