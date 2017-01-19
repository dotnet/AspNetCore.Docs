protected void Page_Load(object sender, EventArgs e)
{
    int categoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
    // Get information about the specified category
    CategoriesBLL categoryAPI = new CategoriesBLL();
    Northwind.CategoriesDataTable categories = _
        categoryAPI.GetCategoryWithBinaryDataByCategoryID(categoryID);
    Northwind.CategoriesRow category = categories[0];
    // For new categories, images are JPGs...
    
    // Output HTTP headers providing information about the binary data
    Response.ContentType = "image/jpeg";
    // Output the binary data
    Response.BinaryWrite(category.Picture);
}