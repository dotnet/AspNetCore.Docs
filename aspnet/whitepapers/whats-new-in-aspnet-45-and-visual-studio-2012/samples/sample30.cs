public IQueryable<Category>
GetCategories()
{
	return _db.Categories;
}