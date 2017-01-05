Dim _totalUnitPrice As Decimal = 0
Dim _totalNonNullUnitPriceCount As Integer = 0
Dim _totalUnitsInStock As Integer = 0
Dim _totalUnitsOnOrder As Integer = 0
Protected Sub ProductsInCategory_RowDataBound _
    (sender As Object, e As GridViewRowEventArgs) _
        Handles ProductsInCategory.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then
        Dim product As Northwind.ProductsRow = _
            CType(CType(e.Row.DataItem, DataRowView).Row, Northwind.ProductsRow)
        If Not product.IsUnitPriceNull() Then
            _totalUnitPrice += product.UnitPrice
            _totalNonNullUnitPriceCount += 1
        End If
        If Not product.IsUnitsInStockNull() Then
            _totalUnitsInStock += product.UnitsInStock
        End If
        If Not product.IsUnitsOnOrderNull() Then
            _totalUnitsOnOrder += product.UnitsOnOrder
        End If
    ElseIf e.Row.RowType = DataControlRowType.Footer Then
        Dim avgUnitPrice As Decimal = _
            _totalUnitPrice / CType(_totalNonNullUnitPriceCount, Decimal)
        e.Row.Cells(1).Text = "Avg.: " & avgUnitPrice.ToString("c")
        e.Row.Cells(2).Text = "Total: " & _totalUnitsInStock.ToString()
        e.Row.Cells(3).Text = "Total: " & _totalUnitsOnOrder.ToString()
    End If
End Sub