[EnableQuery]
public IQueryable<Product> Get()
{
    return db.Products;
}
[EnableQuery]
public SingleResult<Product> Get([FromODataUri] int key)
{
    IQueryable<Product> result = db.Products.Where(p => p.Id == key);
    return SingleResult.Create(result);
}