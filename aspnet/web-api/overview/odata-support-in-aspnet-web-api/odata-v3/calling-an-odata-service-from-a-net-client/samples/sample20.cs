// Add entities with links.
static void AddProductWithSupplier(ProductService.Container container, 
    ProductService.Product product, ProductService.Supplier supplier)
{
    container.AddToSuppliers(supplier);
    container.AddToProducts(product);
    container.AddLink(supplier, "Products", product);
    container.SetLink(product, "Supplier", supplier);
    var serviceResponse = container.SaveChanges();
    foreach (var operationResponse in serviceResponse)
    {
        Console.WriteLine(operationResponse.StatusCode);
    }
}