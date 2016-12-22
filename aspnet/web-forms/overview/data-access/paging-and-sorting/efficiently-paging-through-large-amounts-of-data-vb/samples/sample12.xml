Protected Sub ObjectDataSource1_Deleted( _
    sender As Object, e As ObjectDataSourceStatusEventArgs) _
    Handles ObjectDataSource1.Deleted
    ' If we get back a Boolean value from the DeleteProduct method and it's true, then
    ' we successfully deleted the product. Set AffectedRows to 1
    If TypeOf e.ReturnValue Is Boolean AndAlso CType(e.ReturnValue, Boolean) = True Then
        e.AffectedRows = 1
    End If
End Sub