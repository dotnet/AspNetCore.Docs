// Use the $expand option.
static void ListProductsAndSupplier(ProductService.Container container)
{
    var products = container.Products.Expand(p => p.Supplier);
    foreach (var p in products)
    {
        Console.WriteLine("{0}\t{1}\t{2}", p.Name, p.Price, p.Supplier.Name);
    }
}