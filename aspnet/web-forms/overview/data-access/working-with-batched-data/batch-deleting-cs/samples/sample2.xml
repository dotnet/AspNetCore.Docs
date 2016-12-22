// Iterate through the Products.Rows property
foreach (GridViewRow row in Products.Rows)
{
    // Access the CheckBox
    CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
    if (cb != null && cb.Checked)
    {
        // Delete row! (Well, not really...)
        atLeastOneRowDeleted = true;
        // First, get the ProductID for the selected row
        int productID = Convert.ToInt32(Products.DataKeys[row.RowIndex].Value);
        // "Delete" the row
        DeleteResults.Text += string.Format
            ("This would have deleted ProductID {0}<br />", productID);
        //... To actually delete the product, use ...
        //ProductsBLL productAPI = new ProductsBLL();
        //productAPI.DeleteProduct(productID);
        //............................................
    }
}