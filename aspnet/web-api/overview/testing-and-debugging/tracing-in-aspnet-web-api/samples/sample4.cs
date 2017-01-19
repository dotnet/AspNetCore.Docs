using System.Web.Http.Tracing;

public class ProductsController : ApiController
{
    public HttpResponseMessage GetAllProducts()
    {
        Configuration.Services.GetTraceWriter().Info(
            Request, "ProductsController", "Get the list of products.");

        // ...
    }
}