public IQueryable<Category>
GetCategories()
{
	var db = new Northwind();
	return db.Categories.Include(c => c.Products);
}