Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
    ' Only add the sorting UI if the GridView is sorted
    If Not String.IsNullOrEmpty(ProductList.SortExpression) Then
        ' Determine the index and HeaderText of the column that
        'the data is sorted by
        Dim sortColumnIndex As Integer = -1
        Dim sortColumnHeaderText As String = String.Empty
        For i As Integer = 0 To ProductList.Columns.Count - 1
            If ProductList.Columns(i).SortExpression.CompareTo( _
                ProductList.SortExpression) = 0 Then
                sortColumnIndex = i
                sortColumnHeaderText = ProductList.Columns(i).HeaderText
                Exit For
            End If
        Next
        ' TODO: Scan the rows for differences in the sorted column�s values
End Sub