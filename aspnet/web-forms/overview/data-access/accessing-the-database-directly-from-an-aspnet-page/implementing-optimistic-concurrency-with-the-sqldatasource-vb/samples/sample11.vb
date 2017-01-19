Protected Sub Products_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs) _
    Handles Products.RowUpdated
    If e.AffectedRows = 0 Then
        ConcurrencyViolationMessage.Visible = True
        e.KeepInEditMode = True
        ' Rebind the data to the GridView to show the latest changes
        Products.DataBind()
    End If
End Sub
Protected Sub Products_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) _
    Handles Products.RowDeleted
    If e.AffectedRows = 0 Then
        ConcurrencyViolationMessage.Visible = True
    End If
End Sub