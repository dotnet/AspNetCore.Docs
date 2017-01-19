protected void LowStockedProductsInRed_DataBound(object sender, EventArgs e)
{
    // Get the ProductsRow object from the DataItem property...
    Northwind.ProductsRow product = (Northwind.ProductsRow)
        ((DataRowView)LowStockedProductsInRed.DataItem).Row;
    if (!product.IsUnitsInStockNull() && product.UnitsInStock <= 10)
    {
        // TODO: Make the UnitsInStockLabel text red
    }
}