protected void HighlightCheapProducts_RowDataBound(object sender, GridViewRowEventArgs e)
{
    // Get the ProductsRow object from the DataItem property...
    Northwind.ProductsRow product = (Northwind.ProductsRow)
        ((System.Data.DataRowView)e.Row.DataItem).Row;
    if (!product.IsUnitPriceNull() && product.UnitPrice < 10m)
    {
        // TODO: Highlight the row yellow...
    }
}