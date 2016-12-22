Private ReadOnly Property PageIndex() As Integer
    Get
        If (Not String.IsNullOrEmpty(Request.QueryString("pageIndex"))) Then
            Return Convert.ToInt32(Request.QueryString("pageIndex"))
        Else
            Return 0
        End If
    End Get
End Property
Private ReadOnly Property PageSize() As Integer
    Get
        If (Not String.IsNullOrEmpty(Request.QueryString("pageSize"))) Then
            Return Convert.ToInt32(Request.QueryString("pageSize"))
        Else
            Return 4
        End If
    End Get
End Property
Private ReadOnly Property PageCount() As Integer
    Get
        If TotalRowCount <= 0 OrElse PageSize <= 0 Then
            Return 1
        Else
            Return ((TotalRowCount + PageSize) - 1) / PageSize
        End If
    End Get
End Property