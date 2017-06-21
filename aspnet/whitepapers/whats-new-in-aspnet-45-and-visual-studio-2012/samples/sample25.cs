public IQueryable<Product>
GetProducts(string keyword)
{
	IQueryable<Product> query = _db.Products;
	 
	if (!String.IsNullOrWhiteSpace(keyword))
	{
		query = query.Where(p => p.ProductName.Contains(keyword));
	}
	return query;
}