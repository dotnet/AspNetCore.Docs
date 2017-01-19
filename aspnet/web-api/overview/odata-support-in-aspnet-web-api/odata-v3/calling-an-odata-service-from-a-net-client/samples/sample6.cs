// Get a single entity.
static void ListProductById(ProductService.Container container, int id)
{
    var product = container.Products.Where(p => p.ID == id).SingleOrDefault();
    if (product != null)
    {
        DisplayProduct(product);
    }
}