[AcceptVerbs("POST", "PUT")]
public async Task<IHttpActionResult> CreateLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
            
    Product product = await db.Products.FindAsync(key);
    if (product == null)
    {
        return NotFound();
    }
            
    switch (navigationProperty)
    {
        case "Supplier":
            string supplierKey = GetKeyFromLinkUri<string>(link);
            Supplier supplier = await db.Suppliers.FindAsync(supplierKey);
            if (supplier == null)
            {
                return NotFound();
            }
            product.Supplier = supplier;
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);

        default:
            return NotFound();
    }
}