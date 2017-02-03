public IQueryable<Category> GetCategories()
{
  var query = this.db.Categories
    .Include(c => c.Products);

  return query;
}