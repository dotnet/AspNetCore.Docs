// Use $expand and $select options
static void ListProductNameSupplier(ProductService.Container container)
{
    var products =
        from p in container.Products
        select new
        {
            Name = p.Name,
            Supplier = p.Supplier.Name
        };
    foreach (var p in products)
    {
        Console.WriteLine("{0}\t{1}", p.Name, p.Supplier);
    }
}