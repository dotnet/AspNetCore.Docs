protected void HighlightCheapProducts_RowDataBound(object sender, GridViewRowEventArgs e)
{
    // Make sure we are working with a DataRow
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        // Get the ProductsRow object from the DataItem property...
        Northwind.ProductsRow product = (Northwind.ProductsRow)
            ((System.Data.DataRowView)e.Row.DataItem).Row;
        if (!product.IsUnitPriceNull() && product.UnitPrice < 10m)
        {
            e.Row.CssClass = "AffordablePriceEmphasis";
        }
    }
}