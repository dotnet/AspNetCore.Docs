Protected Sub Products_UpdateCommand(source As Object, e As DataListCommandEventArgs) _
    Handles Products.UpdateCommand
    If Not Page.IsValid Then
        Exit Sub
    End If
    ' Read in the ProductID from the DataKeys collection
    Dim productID As Integer = Convert.ToInt32(Products.DataKeys(e.Item.ItemIndex))
    ' Read in the product name and price values
    Dim productName As TextBox = CType(e.Item.FindControl("ProductName"), TextBox)
    Dim categories As DropDownList=CType(e.Item.FindControl("Categories"), DropDownList)
    Dim suppliers As DropDownList = CType(e.Item.FindControl("Suppliers"), DropDownList)
    Dim discontinued As CheckBox = CType(e.Item.FindControl("Discontinued"), CheckBox)
    Dim productNameValue As String = Nothing
    If productName.Text.Trim().Length > 0 Then
        productNameValue = productName.Text.Trim()
    End If
    Dim categoryIDValue As Integer = Convert.ToInt32(categories.SelectedValue)
    Dim supplierIDValue As Integer = Convert.ToInt32(suppliers.SelectedValue)
    Dim discontinuedValue As Boolean = discontinued.Checked
    ' Call the ProductsBLL's UpdateProduct method...
    Dim productsAPI As New ProductsBLL()
    productsAPI.UpdateProduct(productNameValue, categoryIDValue, supplierIDValue, _
        discontinuedValue, productID)
    ' Revert the DataList back to its pre-editing state
    Products.EditItemIndex = -1
    Products.DataBind()
End Sub