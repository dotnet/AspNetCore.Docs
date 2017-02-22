protected void ProductsInCategory_DataBinding(object sender, EventArgs e)
{
    // Show the Label
    NoProductsMessage.Visible = true;
}
 
protected void ProductsInCategory_ItemDataBound(object sender, DataListItemEventArgs e)
{
    // If we have a data item, hide the Label
    if (e.Item.ItemType == ListItemType.Item ||
        e.Item.ItemType == ListItemType.AlternatingItem)
        NoProductsMessage.Visible = false;
}