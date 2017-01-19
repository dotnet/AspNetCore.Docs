// GET /Products(1)/Supplier
public Supplier GetSupplier([FromODataUri] int key)
{
    Product product = _context.Products.FirstOrDefault(p => p.ID == key);
    if (product == null)
    {
        throw new HttpResponseException(HttpStatusCode.NotFound);
    }
    return product.Supplier;
}