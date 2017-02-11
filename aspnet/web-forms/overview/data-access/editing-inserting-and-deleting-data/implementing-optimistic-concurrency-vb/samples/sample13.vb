Protected Sub ProductsGrid_RowUpdated _
        (ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs) _
        Handles ProductsGrid.RowUpdated
    If e.Exception IsNot Nothing AndAlso e.Exception.InnerException IsNot Nothing Then
        If TypeOf e.Exception.InnerException Is System.Data.DBConcurrencyException Then
            ' Display the warning message and note that the exception has
            ' been handled...
            UpdateConflictMessage.Visible = True
            e.ExceptionHandled = True
        End If
    End If
End Sub