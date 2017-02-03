// Use the $select option.
static void ListProductNames(ProductService.Container container)
{

    var products = from p in container.Products select new { Name = p.Name };
    foreach (var p in products)
    {
        Console.WriteLine(p.Name);
    }
}