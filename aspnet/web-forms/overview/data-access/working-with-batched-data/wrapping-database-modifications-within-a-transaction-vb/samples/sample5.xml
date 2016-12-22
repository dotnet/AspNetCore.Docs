Public Sub DeleteProductsWithTransaction _
    (ByVal productIDs As System.Collections.Generic.List(Of Integer))
    
    ' Start the transaction
    Adapter.BeginTransaction()
    Try
        ' Delete each product specified in the list
        For Each productID As Integer In productIDs
            Adapter.Delete(productID)
        Next
        ' Commit the transaction
        Adapter.CommitTransaction()
    Catch
        ' There was an error - rollback the transaction
        Adapter.RollbackTransaction()
        Throw
    End Try
End Sub