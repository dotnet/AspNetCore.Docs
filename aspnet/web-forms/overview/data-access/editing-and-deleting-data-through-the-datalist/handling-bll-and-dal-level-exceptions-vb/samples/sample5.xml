Protected Sub Products_UpdateCommand(source As Object, e As DataListCommandEventArgs) _
    Handles Products.UpdateCommand
    ' Handle any exceptions raised during the editing process
    Try
        ' Read in the ProductID from the DataKeys collection
        Dim productID As Integer = _
            Convert.ToInt32(Products.DataKeys(e.Item.ItemIndex))
        ... Some code omitted for brevity ...
    Catch ex As Exception
        ' TODO: Display information about the exception in ExceptionDetails
    End Try
End Sub