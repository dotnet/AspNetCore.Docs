Protected Sub DataList1_EditCommand(source As Object, e As DataListCommandEventArgs) _
    Handles DataList1.EditCommand
    ' Set the DataList's EditItemIndex property to the
    ' index of the DataListItem that was clicked
    DataList1.EditItemIndex = e.Item.ItemIndex
    ' Rebind the data to the DataList
    DataList1.DataBind()
End Sub