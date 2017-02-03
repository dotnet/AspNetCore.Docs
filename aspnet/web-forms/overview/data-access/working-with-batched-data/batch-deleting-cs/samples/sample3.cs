protected void DeleteSelectedProducts_Click(object sender, EventArgs e)
{
    // Create a List to hold the ProductID values to delete
    System.Collections.Generic.List<int> productIDsToDelete = 
        new System.Collections.Generic.List<int>();
    // Iterate through the Products.Rows property
    foreach (GridViewRow row in Products.Rows)
    {
        // Access the CheckBox
        CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
        if (cb != null && cb.Checked)
        {
            // Save the ProductID value for deletion
            // First, get the ProductID for the selected row
            int productID = Convert.ToInt32(Products.DataKeys[row.RowIndex].Value);
            // Add it to the List...
            productIDsToDelete.Add(productID);
            // Add a confirmation message
            DeleteResults.Text += string.Format
                ("ProductID {0} has been deleted<br />", productID);
        }
    }
    // Call the DeleteProductsWithTransaction method and show the Label 
    // if at least one row was deleted...
    if (productIDsToDelete.Count > 0)
    {
        ProductsBLL productAPI = new ProductsBLL();
        productAPI.DeleteProductsWithTransaction(productIDsToDelete);
        DeleteResults.Visible = true;
        // Rebind the data to the GridView
        Products.DataBind();
    }
}