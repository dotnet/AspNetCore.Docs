Private Property StartRowIndex() As Integer
    Get
        Dim o As Object = ViewState("StartRowIndex")
        If o Is Nothing Then
            Return 0
        Else
            Return CType(o, Integer)
        End If
    End Get
    Set(ByVal value As Integer)
        ViewState("StartRowIndex") = value
    End Set
End Property
Private Property MaximumRows() As Integer
    Get
        Dim o As Object = ViewState("MaximumRows")
        If o Is Nothing Then
            Return 5
        Else
            Return CType(o, Integer)
        End If
    End Get
    Set(ByVal value As Integer)
        ViewState("MaximumRows") = value
    End Set
End Property