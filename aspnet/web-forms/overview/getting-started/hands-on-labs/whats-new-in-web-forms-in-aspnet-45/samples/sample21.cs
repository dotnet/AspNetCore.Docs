public void UpdateCategory(int categoryId)
{
	var category = this.db.Categories.Find(categoryId);

	this.TryUpdateModel(category);

	if (this.ModelState.IsValid)
	{
		this.db.SaveChanges();
	}
}