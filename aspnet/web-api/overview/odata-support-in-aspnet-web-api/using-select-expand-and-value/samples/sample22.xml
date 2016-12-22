public async Task<IHttpActionResult> GetName(int key)
{
    Product product = await db.Products.FindAsync(key);
    if (product == null)
    {
        return NotFound();
    }
    return Ok(product.Name);
}