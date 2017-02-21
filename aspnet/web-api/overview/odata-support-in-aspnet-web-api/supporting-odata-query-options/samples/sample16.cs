// Globally:
config.EnableQuerySupport(new MyQueryableAttribute());

// Per controller:
public class ValuesController : ApiController
{
    [MyQueryable]
    public IQueryable<Product> Get()
    {
        return products.AsQueryable();
    }
}