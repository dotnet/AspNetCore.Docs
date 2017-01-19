static void DeleteProduct(ProductService.Container container, int id)
{
    var product = container.Products.Where(p => p.ID == id).SingleOrDefault();
    if (product != null)
    {
        container.DeleteObject(product);
        container.SaveChanges();
    }
}