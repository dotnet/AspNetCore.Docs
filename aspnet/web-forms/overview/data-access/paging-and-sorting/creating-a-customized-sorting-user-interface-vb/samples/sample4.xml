Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
    ' Only add the sorting UI if the GridView is sorted
    If Not String.IsNullOrEmpty(ProductList.SortExpression) Then
        ' ... Code for finding the sorted column index removed for brevity ...
        ' Reference the Table the GridView has been rendered into
        Dim gridTable As Table = CType(ProductList.Controls(0), Table)
        ' Enumerate each TableRow, adding a sorting UI header if
        ' the sorted value has changed
        Dim lastValue As String = String.Empty
        For Each gvr As GridViewRow In ProductList.Rows
            Dim currentValue As String = gvr.Cells(sortColumnIndex).Text
            If lastValue.CompareTo(currentValue) <> 0 Then
                ' there's been a change in value in the sorted column
                Dim rowIndex As Integer = gridTable.Rows.GetRowIndex(gvr)
                ' Add a new sort header row
                Dim sortRow As New GridViewRow(rowIndex, rowIndex, _
                    DataControlRowType.DataRow, DataControlRowState.Normal)
                Dim sortCell As New TableCell()
                sortCell.ColumnSpan = ProductList.Columns.Count
                sortCell.Text = String.Format("{0}: {1}", _
                    sortColumnHeaderText, currentValue)
                sortCell.CssClass = "SortHeaderRowStyle"
                ' Add sortCell to sortRow, and sortRow to gridTable
                sortRow.Cells.Add(sortCell)
                gridTable.Controls.AddAt(rowIndex, sortRow)
                ' Update lastValue
                lastValue = currentValue
            End If
        Next
    End If
    MyBase.Render(writer)
End Sub