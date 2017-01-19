Protected Sub LowStockedProductsInRed_DataBound _
    (sender As Object, e As System.EventArgs) _
    Handles LowStockedProductsInRed.DataBound

    Dim product As Northwind.ProductsRow = _
        CType(CType(LowStockedProductsInRed.DataItem, System.Data.DataRowView).Row, _
            Northwind.ProductsRow)
    If Not product.IsUnitsInStockNull() AndAlso product.UnitsInStock <= 10 Then
        Dim unitsInStock As Label = _
            CType(LowStockedProductsInRed.FindControl("UnitsInStockLabel"), Label)

        If unitsInStock IsNot Nothing Then
            unitsInStock.CssClass = "LowUnitsInStockEmphasis"
        End If
    End If
End Sub