<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Update, True)> _
Public Function UpdateProduct _
    (ByVal productName As String, ByVal unitPrice As Nullable(Of Decimal), _
ByVal unitsInStock As Nullable(Of Short), ByVal productID As Integer) As Boolean
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
    If Not unitsInStock.HasValue Then
        product.SetUnitsInStockNull()
    Else
        product.UnitsInStock = unitsInStock.Value
    End If
    Dim rowsAffected As Integer = Adapter.Update(product)
    Return rowsAffected = 1
End Function