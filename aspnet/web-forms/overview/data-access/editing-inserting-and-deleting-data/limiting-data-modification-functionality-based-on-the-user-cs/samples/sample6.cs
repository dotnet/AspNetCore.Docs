protected void ProductsBySupplier_RowDataBound(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        // Is this a supplier-specific user?
        if (Suppliers.SelectedValue != "-1")
        {
            // Get a reference to the ProductRow
            Northwind.ProductsRow product =
                (Northwind.ProductsRow)((System.Data.DataRowView)e.Row.DataItem).Row;
            // Is this product discontinued?
            if (product.Discontinued)
            {
                // Get a reference to the Edit LinkButton
                LinkButton editButton = (LinkButton)e.Row.Cells[0].Controls[0];
                // Hide the Edit button
                editButton.Visible = false;
            }
        }
    }
}