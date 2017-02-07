Protected Sub Products_RowCommand(sender As Object, e As GridViewCommandEventArgs) _
    Handles Products.RowCommand
    
    ' Insert data if the CommandName == "Insert" 
    ' and the validation controls indicate valid data...
    If e.CommandName = "Insert" AndAlso Page.IsValid Then
        ' Insert new record
        ProductsDataSource.Insert()
    End If
End Sub