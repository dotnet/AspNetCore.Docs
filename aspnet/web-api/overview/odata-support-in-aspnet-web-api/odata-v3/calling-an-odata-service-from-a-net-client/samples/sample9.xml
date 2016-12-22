// Use the $orderby option
static void ListProductsSorted(ProductService.Container container)
{
    // Sort by price, highest to lowest.
    var products =
        from p in container.Products
        orderby p.Price descending
        select p;

    foreach (var p in products)
    {
        DisplayProduct(p);
    }
}