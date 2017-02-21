Private ReadOnly Property SuppliersSelectedIndex() As Integer
    Get
        If String.IsNullOrEmpty(Request.Form("SuppliersGroup")) Then
            Return -1
        Else
            Return Convert.ToInt32(Request.Form("SuppliersGroup"))
        End If
    End Get
End Property