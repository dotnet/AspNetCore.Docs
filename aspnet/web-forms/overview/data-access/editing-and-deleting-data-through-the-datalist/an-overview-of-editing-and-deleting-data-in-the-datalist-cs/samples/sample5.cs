protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
{
    // Set the DataList's EditItemIndex property to -1
    DataList1.EditItemIndex = -1;
    // Rebind the data to the DataList
    DataList1.DataBind();
}