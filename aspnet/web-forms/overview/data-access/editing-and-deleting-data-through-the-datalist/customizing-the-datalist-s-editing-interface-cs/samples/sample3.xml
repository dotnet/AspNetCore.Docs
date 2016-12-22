protected void Products_EditCommand(object source, DataListCommandEventArgs e)
{
    // Set the DataList's EditItemIndex property and rebind the data
    Products.EditItemIndex = e.Item.ItemIndex;
    Products.DataBind();
}
protected void Products_CancelCommand(object source, DataListCommandEventArgs e)
{
    // Return to DataList to its pre-editing state
    Products.EditItemIndex = -1;
    Products.DataBind();
}