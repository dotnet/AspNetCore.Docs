protected void DeleteSelectedProducts_Click(object sender, EventArgs e)
{
    bool atLeastOneRowDeleted = false;
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
            int productID = 
                Convert.ToInt32(Products.DataKeys[row.RowIndex].Value);
            // "Delete" the row
            DeleteResults.Text += string.Format(
                "This would have deleted ProductID {0}<br />", productID);
        }
    }
    // Show the Label if at least one row was deleted...
    DeleteResults.Visible = atLeastOneRowDeleted;
}