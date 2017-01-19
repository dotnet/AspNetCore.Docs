protected void Products_EditCommand(object source, DataListCommandEventArgs e)
{
    // Set the DataList's EditItemIndex property to the
    // index of the DataListItem that was clicked
    Products.EditItemIndex = e.Item.ItemIndex;
    // Rebind the data to the DataList
    Products.DataBind();
}
protected void Products_CancelCommand(object source, DataListCommandEventArgs e)
{
    // Set the DataList's EditItemIndex property to -1
    Products.EditItemIndex = -1;
    // Rebind the data to the DataList
    Products.DataBind();
}