public IQueryable<Product> GetProduct(
		[QueryString("ProductID")] int? productId,
		[RouteData] string productName)
{
	var _db = new WingtipToys.Models.ProductContext();
	IQueryable<Product> query = _db.Products;
	if (productId.HasValue && productId > 0)
	{
		query = query.Where(p => p.ProductID == productId);
	}
	else if (!String.IsNullOrEmpty(productName))
	{
		query = query.Where(p =>
			  String.Compare(p.ProductName, productName) == 0);
	}
	else
	{
		query = null;
	}
	return query;
}