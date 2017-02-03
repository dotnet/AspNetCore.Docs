public HttpResponseMessage GetProduct(int id)
{
    var product = new Product() 
        { Id = id, Name = "Gizmo", Category = "Widgets", Price = 1.99M };

    IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();

    ContentNegotiationResult result = negotiator.Negotiate(
        typeof(Product), this.Request, this.Configuration.Formatters);
    if (result == null)
    {
        var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
        throw new HttpResponseException(response));
    }

    return new HttpResponseMessage()
    {
        Content = new ObjectContent<Product>(
            product,		        // What we are serializing 
            result.Formatter,           // The media formatter
            result.MediaType.MediaType  // The MIME type
        )
    };
}