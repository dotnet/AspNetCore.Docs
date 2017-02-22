Imports System.Data
Imports System.Data.SqlClient
Namespace NorthwindTableAdapters
    Partial Public Class ProductsTableAdapter
        Private _transaction As SqlTransaction
        Private Property Transaction() As SqlTransaction
            Get
                Return Me._transaction
            End Get
            Set(ByVal Value As SqlTransaction)
                Me._transaction = Value
            End Set
        End Property
        Public Sub BeginTransaction()
            ' Open the connection, if needed
            If Me.Connection.State <> ConnectionState.Open Then
                Me.Connection.Open()
            End If
            ' Create the transaction and assign it to the Transaction property
            Me.Transaction = Me.Connection.BeginTransaction()
            ' Attach the transaction to the Adapters
            For Each command As SqlCommand In Me.CommandCollection
                command.Transaction = Me.Transaction
            Next
            Me.Adapter.InsertCommand.Transaction = Me.Transaction
            Me.Adapter.UpdateCommand.Transaction = Me.Transaction
            Me.Adapter.DeleteCommand.Transaction = Me.Transaction
        End Sub
        Public Sub CommitTransaction()
            ' Commit the transaction
            Me.Transaction.Commit()
            ' Close the connection
            Me.Connection.Close()
        End Sub
        Public Sub RollbackTransaction()
            ' Rollback the transaction
            Me.Transaction.Rollback()
            ' Close the connection
            Me.Connection.Close()
        End Sub
    End Class
End Namespace