protected void Page_Load(object sender, EventArgs e)
{

}

public IQueryable<Category> GetCategories()
{
  var _db = new WingtipToys.Models.ProductContext();
  IQueryable<Category> query = _db.Categories;
  return query;
}