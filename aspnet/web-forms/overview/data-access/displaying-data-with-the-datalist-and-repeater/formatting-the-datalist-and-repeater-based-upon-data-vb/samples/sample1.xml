Protected Sub ItemDataBoundFormattingExample_ItemDataBound _
    (sender As Object, e As DataListItemEventArgs) _
    Handles ItemDataBoundFormattingExample.ItemDataBound
    If e.Item.ItemType = ListItemType.Item OrElse _
       e.Item.ItemType = ListItemType.AlternatingItem Then
        ' Programmatically reference the ProductsRow instance
        ' bound to this DataListItem
        Dim product As Northwind.ProductsRow = _
            CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                Northwind.ProductsRow)
        ' See if the UnitPrice is not NULL and less than $20.00
        If Not product.IsUnitPriceNull() AndAlso product.UnitPrice < 20 Then
            ' TODO: Highlight the product's name and price
        End If
    End If
End Sub