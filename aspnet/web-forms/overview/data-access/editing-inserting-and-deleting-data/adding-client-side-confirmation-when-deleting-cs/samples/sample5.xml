protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        // reference the Delete LinkButton
        LinkButton db = (LinkButton)e.Row.Cells[0].Controls[0];

        // Get information about the product bound to the row
        Northwind.ProductsRow product =
            (Northwind.ProductsRow) ((System.Data.DataRowView) e.Row.DataItem).Row;

        db.OnClientClick = string.Format(
            "return confirm('Are you certain you want to delete the {0} product?');",
            product.ProductName.Replace("'", @"\'"));
    }
}