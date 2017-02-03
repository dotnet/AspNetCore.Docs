<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateProduct(ByVal productName As String, _
    ByVal unitPrice As Nullable(Of Decimal), ByVal unitsInStock As Nullable(Of Short), _
    ByVal productID As Integer) As Boolean
    Dim products As Northwind.ProductsDataTable = Adapter.GetProductByProductID(productID)
    If products.Count = 0 Then
        Return False
    End If
    Dim product As Northwind.ProductsRow = products(0)
    If unitPrice.HasValue AndAlso Not product.IsUnitPriceNull() Then
        If unitPrice > product.UnitPrice * 2 Then
            Throw New ApplicationException( _
                "When updating a product price," & _
                " the new price cannot exceed twice the original price.")
        End If
    End If
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