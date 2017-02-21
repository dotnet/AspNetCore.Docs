// Add an entity.
static void AddProduct(ProductService.Container container, ProductService.Product product)
{
    container.AddToProducts(product);
    var serviceResponse = container.SaveChanges();
    foreach (var operationResponse in serviceResponse)
    {
        Console.WriteLine(operationResponse.StatusCode);
    }
}