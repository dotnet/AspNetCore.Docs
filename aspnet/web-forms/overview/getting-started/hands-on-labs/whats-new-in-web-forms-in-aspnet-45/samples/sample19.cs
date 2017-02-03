public Product SelectProduct([QueryString]int? productId)
{
	return this.db.Products.Find(productId);
}