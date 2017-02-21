public void UpdateCategory(int categoryId)
{
  var category = this.db.Categories.Find(categoryId);

  this.TryUpdateModel(category);

  if (this.ModelState.IsValid)
  {
    try
    {
      this.db.SaveChanges();
    }
    catch (DbUpdateException)
    {
      var message = string.Format("A category with the name {0} already exists.", category.CategoryName);
      this.ModelState.AddModelError("CategoryName", message);
    }
  }
}