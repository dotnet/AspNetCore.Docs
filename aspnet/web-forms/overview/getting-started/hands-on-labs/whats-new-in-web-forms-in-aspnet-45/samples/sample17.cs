public IEnumerable<Product> GetProducts([Control("categoriesGrid")]int? categoryId)
{
	return this.db.Products.Where(p => p.CategoryId == categoryId);
}