protected void ExpensiveProductsPriceInBoldItalic_DataBound(object sender, EventArgs e)
{
    // Get the ProductsRow object from the DataItem property...
    Northwind.ProductsRow product = (Northwind.ProductsRow)
        ((DataRowView)ExpensiveProductsPriceInBoldItalic.DataItem).Row;
    if (!product.IsUnitPriceNull() && product.UnitPrice > 75m)
    {
        ExpensiveProductsPriceInBoldItalic.Rows[4].Cells[1].CssClass =
            "ExpensivePriceEmphasis";
    }
}