Private Property SortExpression() As String
    Get
        Dim o As Object = ViewState("SortExpression")
        If o Is Nothing Then
            Return "ProductName"
        Else
            Return o.ToString()
        End If
    End Get
    Set(ByVal value As String)
        ViewState("SortExpression") = value
    End Set
End Property