Protected Sub ProductsInCategory_RowDataBound _
    (sender As Object, e As GridViewRowEventArgs) _
        Handles ProductsInCategory.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then
      ... <i>Increment the running totals</i> ...
    ElseIf e.Row.RowType = DataControlRowType.Footer
      Dim avgUnitPrice As Decimal = _
        _totalUnitPrice / CType(_totalNonNullUnitPriceCount, Decimal)
      e.Row.Cells(1).Text = "Avg.: " & avgUnitPrice.ToString("c")
      e.Row.Cells(2).Text = "Total: " & _totalUnitsInStock.ToString()
      e.Row.Cells(3).Text = "Total: " & _totalUnitsOnOrder.ToString()
    End If
End Sub