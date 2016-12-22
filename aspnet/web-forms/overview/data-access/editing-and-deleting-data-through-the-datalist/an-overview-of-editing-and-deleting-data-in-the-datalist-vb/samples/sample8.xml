Protected Sub DataList1_DeleteCommand(source As Object, e As DataListCommandEventArgs) _
    Handles DataList1.DeleteCommand
    ' Read in the ProductID from the DataKeys collection
    Dim productID As Integer = Convert.ToInt32(DataList1.DataKeys(e.Item.ItemIndex))
    ' Delete the data
    Dim productsAPI As New ProductsBLL()
    productsAPI.DeleteProduct(productID)
    ' Rebind the data to the DataList
    DataList1.DataBind()
End Sub