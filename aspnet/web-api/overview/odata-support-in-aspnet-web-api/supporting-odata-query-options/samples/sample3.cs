[Queryable(PageSize=10)]
public IQueryable<Product> Get() 
{
    return products.AsQueryable();
}