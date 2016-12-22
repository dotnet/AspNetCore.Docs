Protected Sub Products_EditCommand(source As Object, e As DataListCommandEventArgs) _
    Handles Products.EditCommand
    ' Set the DataList's EditItemIndex property to the
    ' index of the DataListItem that was clicked
    Products.EditItemIndex = e.Item.ItemIndex
    ' Rebind the data to the DataList
    Products.DataBind()
End Sub
Protected Sub Products_CancelCommand(source As Object, e As DataListCommandEventArgs) _
    Handles Products.CancelCommand
    ' Set the DataList's EditItemIndex property to -1
    Products.EditItemIndex = -1
    ' Rebind the data to the DataList
    Products.DataBind()
End Sub