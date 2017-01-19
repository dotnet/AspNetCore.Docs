Protected Sub HighlightCheapProducts_RowDataBound _
    (sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) _
    Handles HighlightCheapProducts.RowDataBound

    Dim product As Northwind.ProductsRow = _
        CType(CType(e.Row.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)
    If Not product.IsUnitPriceNull() AndAlso product.UnitPrice < 10 Then
    End If
End Sub