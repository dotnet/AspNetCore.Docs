protected void Categories_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
    // Reference the RadioButtonList
    RadioButtonList BrochureOptions = 
        (RadioButtonList)Categories.Rows[e.RowIndex].FindControl("BrochureOptions");
    // Get BrochurePath information about the record being updated
    int categoryID = Convert.ToInt32(e.Keys["CategoryID"]);
    CategoriesBLL categoryAPI = new CategoriesBLL();
    Northwind.CategoriesDataTable categories = 
        categoryAPI.GetCategoryByCategoryID(categoryID);
    Northwind.CategoriesRow category = categories[0];
    if (BrochureOptions.SelectedValue == "1")
    {
        // Use current value for BrochurePath
        if (category.IsBrochurePathNull())
            e.NewValues["brochurePath"] = null;
        else
            e.NewValues["brochurePath"] = category.BrochurePath;
    }
    else if (BrochureOptions.SelectedValue == "2")
    {
        // Remove the current brochure (set it to NULL in the database)
        e.NewValues["brochurePath"] = null;
    }
    else if (BrochureOptions.SelectedValue == "3")
    {
        // Reference the BrochurePath FileUpload control
        FileUpload BrochureUpload = 
            (FileUpload)Categories.Rows[e.RowIndex].FindControl("BrochureUpload");
        // Process the BrochureUpload
        bool cancelOperation = false;
        e.NewValues["brochurePath"] = 
            ProcessBrochureUpload(BrochureUpload, out cancelOperation);
        e.Cancel = cancelOperation;
    }
    else
    {
        // Unknown value!
        throw new ApplicationException(
            string.Format("Invalid BrochureOptions value, {0}", 
                BrochureOptions.SelectedValue));
    }
    if (BrochureOptions.SelectedValue == "2" || 
        BrochureOptions.SelectedValue == "3")
    {
        // "Remember" that we need to delete the old PDF file
        if (category.IsBrochurePathNull())
            deletedCategorysPdfPath = null;
        else
            deletedCategorysPdfPath = category.BrochurePath;
    }
}
protected void Categories_RowUpdated(object sender, GridViewUpdatedEventArgs e)
{
    // If there were no problems and we updated the PDF file, 
    // then delete the existing one
    if (e.Exception == null)
    {
        DeleteRememberedBrochurePath();
    }
}