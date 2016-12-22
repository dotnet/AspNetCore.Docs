Public Function UpdateWithTransaction _
    (ByVal dataTable As Northwind.ProductsDataTable) As Integer
    
    Me.BeginTransaction()
    Try
        ' Perform the update on the DataTable
        Dim returnValue As Integer = Me.Adapter.Update(dataTable)
        ' If we reach here, no errors, so commit the transaction
        Me.CommitTransaction()
        Return returnValue
    Catch
        ' If we reach here, there was an error, so rollback the transaction
        Me.RollbackTransaction()
        Throw
    End Try
End Function