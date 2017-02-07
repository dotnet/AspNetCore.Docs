protected void ItemDataBoundFormattingExample_ItemDataBound
    (object sender, DataListItemEventArgs e)
{
    if (e.Item.ItemType == ListItemType.Item ||
        e.Item.ItemType == ListItemType.AlternatingItem)
    {
        // Programmatically reference the ProductsRow instance bound
        // to this DataListItem
        Northwind.ProductsRow product =
            (Northwind.ProductsRow)((System.Data.DataRowView)e.Item.DataItem).Row;
        // See if the UnitPrice is not NULL and less than $20.00
        if (!product.IsUnitPriceNull() && product.UnitPrice < 20)
        {
            // TODO: Highlight the product's name and price
        }
    }
}