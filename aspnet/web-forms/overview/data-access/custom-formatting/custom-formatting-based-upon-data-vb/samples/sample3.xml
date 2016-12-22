Protected Sub ExpensiveProductsPriceInBoldItalic_DataBound _
    (sender As Object, e As System.EventArgs) _
    Handles ExpensiveProductsPriceInBoldItalic.DataBound

    Dim product As Northwind.ProductsRow = _
        CType(CType(ExpensiveProductsPriceInBoldItalic.DataItem, _
            System.Data.DataRowView).Row, Northwind.ProductsRow)
    If Not product.IsUnitPriceNull() AndAlso product.UnitPrice > 75 Then
    End If
End Sub