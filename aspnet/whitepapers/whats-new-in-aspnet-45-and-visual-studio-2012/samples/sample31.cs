public IQueryable<Product>
GetProducts(
[QueryString("q")] string keyword,
[Control("categories")] int? categoryId)
{
	IQueryable<Product> query = _db.Products;
	 
	if (!String.IsNullOrWhiteSpace(keyword))
	{
		query = query.Where(p => p.ProductName.Contains(keyword));
	}
	if (categoryId.HasValue && categoryId > 0)
	{
		query = query.Where(p => p.CategoryID == categoryId);
	}
	return query;
}