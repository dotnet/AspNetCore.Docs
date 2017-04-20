Protected Sub ProductsOptimisticConcurrencyDataSource_Deleted _
        (ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs) _
        Handles ProductsOptimisticConcurrencyDataSource.Deleted
    If e.ReturnValue IsNot Nothing AndAlso TypeOf e.ReturnValue Is Boolean Then
        Dim deleteReturnValue As Boolean = CType(e.ReturnValue, Boolean)
        If deleteReturnValue = False Then
            ' No row was deleted, display the warning message
            DeleteConflictMessage.Visible = True
        End If
    End If
End Sub