public class ProductsController : ApiController
{
    // This line of code is a problem!
    ProductRepository _repository = new ProductRepository();

    public IEnumerable<Product> Get()
    {
        return _repository.GetAll();
    }

    public IHttpActionResult Get(int id)
    {
        var product = _repository.GetByID(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}