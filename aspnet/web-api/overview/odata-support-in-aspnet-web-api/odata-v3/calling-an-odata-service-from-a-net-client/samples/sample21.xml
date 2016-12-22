static void UpdatePrice(ProductService.Container container, int id, decimal price)
{
    var product = container.Products.Where(p => p.ID == id).SingleOrDefault();
    if (product != null)
    { 
        product.Price = price;
        container.UpdateObject(product);
        container.SaveChanges(SaveChangesOptions.PatchOnUpdate);
    }
}