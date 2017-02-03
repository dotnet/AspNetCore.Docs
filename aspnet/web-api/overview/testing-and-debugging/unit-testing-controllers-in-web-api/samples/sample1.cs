public class ProductsController : ApiController
{
    IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    public HttpResponseMessage Get(int id)
    {
        Product product = _repository.GetById(id);
        if (product == null)
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        return Request.CreateResponse(product);
    }

    public HttpResponseMessage Post(Product product)
    {
        _repository.Add(product);

        var response = Request.CreateResponse(HttpStatusCode.Created, product);
        string uri = Url.Link("DefaultApi", new { id = product.Id });
        response.Headers.Location = new Uri(uri);

        return response;
    }
}