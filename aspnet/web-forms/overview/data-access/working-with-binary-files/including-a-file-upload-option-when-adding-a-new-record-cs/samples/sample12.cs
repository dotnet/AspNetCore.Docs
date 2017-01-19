protected void Page_Load(object sender, EventArgs e)
{
    int categoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
    // Get information about the specified category
    CategoriesBLL categoryAPI = new CategoriesBLL();
    Northwind.CategoriesDataTable categories = 
        categoryAPI.GetCategoryWithBinaryDataByCategoryID(categoryID);
    Northwind.CategoriesRow category = categories[0];
    if (categoryID <= 8)
    {
        // For older categories, we must strip the OLE header... images are bitmaps
        // Output HTTP headers providing information about the binary data
        Response.ContentType = "image/bmp";
        // Output the binary data
        // But first we need to strip out the OLE header
        const int OleHeaderLength = 78;
        int strippedImageLength = category.Picture.Length - OleHeaderLength;
        byte[] strippedImageData = new byte[strippedImageLength];
        Array.Copy(category.Picture, OleHeaderLength, strippedImageData, 
            0, strippedImageLength);
        Response.BinaryWrite(strippedImageData);
    }
    else
    {
        // For new categories, images are JPGs...
        
        // Output HTTP headers providing information about the binary data
        Response.ContentType = "image/jpeg";
        // Output the binary data
        Response.BinaryWrite(category.Picture);
    }
}