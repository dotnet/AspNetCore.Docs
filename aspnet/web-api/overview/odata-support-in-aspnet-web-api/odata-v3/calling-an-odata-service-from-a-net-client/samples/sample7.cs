// Use the $filter option.
static void ListProductsInCategory(ProductService.Container container, string category)
{
    var products =
        from p in container.Products
        where p.Category == category
        select p;
    foreach (var p in products)
    {
        DisplayProduct(p);
    }
}