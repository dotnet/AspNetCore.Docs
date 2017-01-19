public class ProductsController : ODataController
{
    [HttpGet]
    public IHttpActionResult MostExpensive()
    {
        var product = db.Products.Max(x => x.Price);
        return Ok(product);
    }

    // Other controller methods not shown.
}