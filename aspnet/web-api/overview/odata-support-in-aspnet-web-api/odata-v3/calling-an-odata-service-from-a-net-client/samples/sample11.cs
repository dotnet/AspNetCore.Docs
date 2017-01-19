// Use $skip and $top options.
static void ListProductsPaged(ProductService.Container container)
{
    var products =
        (from p in container.Products
          orderby p.Price descending
          select p).Skip(40).Take(10);

    foreach (var p in products)
    {
        DisplayProduct(p);
    }
}