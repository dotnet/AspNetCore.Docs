Protected Sub ProductsInCategory_DataBinding(sender As Object, e As EventArgs) _
    Handles ProductsInCategory.DataBinding
    'Show the Label
    NoProductsMessage.Visible = True
End Sub
 
Protected Sub ProductsInCategory_ItemDataBound(s As Object, e As DataListItemEventArgs) _
    Handles ProductsInCategory.ItemDataBound
    'If we have a data item, hide the Label
    If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = _
        ListItemType.AlternatingItem Then
 
        NoProductsMessage.Visible = False
    End If
End Sub