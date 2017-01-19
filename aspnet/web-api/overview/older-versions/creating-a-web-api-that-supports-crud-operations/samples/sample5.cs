public class ProductsController : ApiController
{
    static readonly IProductRepository repository = new ProductRepository();
}