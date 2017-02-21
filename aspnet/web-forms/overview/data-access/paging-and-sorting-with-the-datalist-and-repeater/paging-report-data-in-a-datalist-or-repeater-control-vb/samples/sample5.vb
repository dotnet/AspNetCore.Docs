Private Property TotalRowCount() As Integer
    Get
        Dim o As Object = ViewState("TotalRowCount")
        If (o Is Nothing) Then
            Return -1
        Else
            Return Convert.ToInt32(o)
        End If
    End Get
    set(Value as Integer)
        ViewState("TotalRowCount") = value
    End Set
End Property