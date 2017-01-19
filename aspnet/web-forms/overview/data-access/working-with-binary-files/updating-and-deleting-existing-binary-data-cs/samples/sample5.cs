// A page variable to "remember" the deleted category's BrochurePath value 
string deletedCategorysPdfPath = null;
protected void Categories_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
    // Determine the PDF path for the category being deleted...
    int categoryID = Convert.ToInt32(e.Keys["CategoryID"]);
    CategoriesBLL categoryAPI = new CategoriesBLL();
    Northwind.CategoriesDataTable categories = 
        categoryAPI.GetCategoryByCategoryID(categoryID);
    Northwind.CategoriesRow category = categories[0];
    if (category.IsBrochurePathNull())
        deletedCategorysPdfPath = null;
    else
        deletedCategorysPdfPath = category.BrochurePath;
}
protected void Categories_RowDeleted(object sender, GridViewDeletedEventArgs e)
{
    // Delete the brochure file if there were no problems deleting the record
    if (e.Exception == null)
    {
        // Is there a file to delete?
        if (deletedCategorysPdfPath != null)
        {
            System.IO.File.Delete(Server.MapPath(deletedCategorysPdfPath));
        }
    }
}