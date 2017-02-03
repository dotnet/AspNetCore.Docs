Namespace NorthwindTableAdapters
    Partial Public Class ProductsTableAdapter
        Public Property ConnectionString() As String
            Get
                Return Me.Connection.ConnectionString
            End Get
            Set(ByVal value As String)
                Me.Connection.ConnectionString = value
            End Set
        End Property
    End Class
End Namespace