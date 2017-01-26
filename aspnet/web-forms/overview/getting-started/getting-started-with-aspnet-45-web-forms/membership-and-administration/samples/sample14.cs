public IQueryable GetCategories()
{
  var _db = new WingtipToys.Models.ProductContext();
  IQueryable query = _db.Categories;
  return query;
}