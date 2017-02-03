<System.ComponentModel.DataObjectMethodAttribute _
(System.ComponentModel.DataObjectMethodType.Update, False)> _
Public Function UpdateProduct(ByVal productName As String, _
    ByVal quantityPerUnit As String, ByVal productID As Integer) As Boolean
    Dim products As Northwind.ProductsDataTable = Adapter.GetProductByProductID(productID)
    If products.Count = 0 Then
        ' no matching record found, return false
        Return False
    End If
    Dim product As Northwind.ProductsRow = products(0)
    product.ProductName = productName
    If quantityPerUnit Is Nothing Then
        product.SetQuantityPerUnitNull()
    Else
        product.QuantityPerUnit = quantityPerUnit
    End If
    ' Update the product record
    Dim rowsAffected As Integer = Adapter.Update(product)
    ' Return true if precisely one row was updated, otherwise false
    Return rowsAffected = 1
End Function