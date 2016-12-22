<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Update, False)> _
    Public Function UpdateProduct(productName As String, _
        unitPrice As Nullable(Of Decimal), productID As Integer) _
        As Boolean

    Dim products As Northwind.ProductsDataTable = _
        Adapter.GetProductByProductID(productID)

    If products.Count = 0 Then
        Return False
    End If

    Dim product As Northwind.ProductsRow = products(0)

    product.ProductName = productName
    If Not unitPrice.HasValue Then
        product.SetUnitPriceNull()
    Else
        product.UnitPrice = unitPrice.Value
    End If

    Dim rowsAffected As Integer = Adapter.Update(product)

    Return rowsAffected = 1
End Function