public class ProductController : ApiController
{
    // modify the type of the db field
    private IStoreAppContext db = new StoreAppContext();

    // add these contructors
    public ProductController() { }

    public ProductController(IStoreAppContext context)
    {
        db = context;
    }
    // rest of class not shown
}