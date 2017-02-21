public class ProductsController : ApiController
{
    [HttpGet]
    public string Details(int id);
}