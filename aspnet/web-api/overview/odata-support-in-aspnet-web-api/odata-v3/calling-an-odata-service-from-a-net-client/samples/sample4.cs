class Program
{
    static void DisplayProduct(ProductService.Product product)
    {
        Console.WriteLine("{0} {1} {2}", product.Name, product.Price, product.Category);
    }

    // Get an entire entity set.
    static void ListAllProducts(ProductService.Container container)
    {
        foreach (var p in container.Products)
        {
            DisplayProduct(p);
        } 
    }
  
    static void Main(string[] args)
    {
        Uri uri = new Uri("http://localhost:18285/odata/");
        var container = new ProductService.Container(uri);
        container.SendingRequest2 += (s, e) =>
        {
            Console.WriteLine("{0} {1}", e.RequestMessage.Method, e.RequestMessage.Url);
        };

        // Get the list of products
        ListAllProducts(container);
    }
}