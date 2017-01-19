public void UpdateProduct(int productId)
{
    var product = this.db.Products.Find(productId);

    this.TryUpdateModel(product);

    this.UpdateProductImage(product);

    if (this.ModelState.IsValid)
    {
        this.db.SaveChanges();
    }
}