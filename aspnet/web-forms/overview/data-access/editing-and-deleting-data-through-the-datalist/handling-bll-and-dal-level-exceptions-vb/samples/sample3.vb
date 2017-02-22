Protected Sub Products_UpdateCommand(source As Object, e As DataListCommandEventArgs) _
    Handles Products.UpdateCommand
    ' Read in the ProductID from the DataKeys collection
    Dim productID As Integer = Convert.ToInt32(Products.DataKeys(e.Item.ItemIndex))
    ' Read in the product name and price values
    Dim productName As TextBox = CType(e.Item.FindControl("ProductName"), TextBox)
    Dim unitPrice As TextBox = CType(e.Item.FindControl("UnitPrice"), TextBox)
    Dim productNameValue As String = Nothing
    If productName.Text.Trim().Length > 0 Then
        productNameValue = productName.Text.Trim()
    End If
    Dim unitPriceValue As Nullable(Of Decimal) = Nothing
    If unitPrice.Text.Trim().Length > 0 Then
        unitPriceValue = Decimal.Parse(unitPrice.Text.Trim(), _
                         System.Globalization.NumberStyles.Currency)
    End If
    ' Call the ProductsBLL's UpdateProduct method...
    Dim productsAPI As New ProductsBLL()
    productsAPI.UpdateProduct(productNameValue, unitPriceValue, productID)
    ' Revert the DataList back to its pre-editing state
    Products.EditItemIndex = -1
    Products.DataBind()
End Sub