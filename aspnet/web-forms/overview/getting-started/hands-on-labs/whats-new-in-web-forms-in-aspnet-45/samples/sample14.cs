public IQueryable<Category> GetCategories([Control]int? minProductsCount)
{
	var query = this.db.Categories
	.Include(c => c.Products);

	if (minProductsCount.HasValue)
	{
		query = query.Where(c => c.Products.Count >= minProductsCount);
	}

	return query;
}