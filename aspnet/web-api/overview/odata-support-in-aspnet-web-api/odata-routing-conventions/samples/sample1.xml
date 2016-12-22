public class ProductsController : ODataController
{
    // GET /odata/Products
    public IQueryable<Product> Get()

    // GET /odata/Products(1)
    public Product Get([FromODataUri] int key)

    // GET /odata/Products(1)/ODataRouting.Models.Book
    public Book GetBook([FromODataUri] int key)

    // POST /odata/Products 
    public HttpResponseMessage Post(Product item)

    // PUT /odata/Products(1)
    public HttpResponseMessage Put([FromODataUri] int key, Product item)

    // PATCH /odata/Products(1)
    public HttpResponseMessage Patch([FromODataUri] int key, Delta<Product> item)

    // DELETE /odata/Products(1)
    public HttpResponseMessage Delete([FromODataUri] int key)

    // PUT /odata/Products(1)/ODataRouting.Models.Book
    public HttpResponseMessage PutBook([FromODataUri] int key, Book item)

    // PATCH /odata/Products(1)/ODataRouting.Models.Book
    public HttpResponseMessage PatchBook([FromODataUri] int key, Delta<Book> item)

    // DELETE /odata/Products(1)/ODataRouting.Models.Book
    public HttpResponseMessage DeleteBook([FromODataUri] int key)

    //  GET /odata/Products(1)/Supplier
    public Supplier GetSupplierFromProduct([FromODataUri] int key)

    // GET /odata/Products(1)/ODataRouting.Models.Book/Author
    public Author GetAuthorFromBook([FromODataUri] int key)

    // POST /odata/Products(1)/$links/Supplier
    public HttpResponseMessage CreateLink([FromODataUri] int key, 
        string navigationProperty, [FromBody] Uri link)

    // DELETE /odata/Products(1)/$links/Supplier
    public HttpResponseMessage DeleteLink([FromODataUri] int key, 
        string navigationProperty, [FromBody] Uri link)

    // DELETE /odata/Products(1)/$links/Parts(1)
    public HttpResponseMessage DeleteLink([FromODataUri] int key, string relatedKey, string navigationProperty)

    // GET odata/Products(1)/Name
    // GET odata/Products(1)/Name/$value
    public HttpResponseMessage GetNameFromProduct([FromODataUri] int key)

    // GET /odata/Products(1)/ODataRouting.Models.Book/Title
    // GET /odata/Products(1)/ODataRouting.Models.Book/Title/$value
    public HttpResponseMessage GetTitleFromBook([FromODataUri] int key)
}