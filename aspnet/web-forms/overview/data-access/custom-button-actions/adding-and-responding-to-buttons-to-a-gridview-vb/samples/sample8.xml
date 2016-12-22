Public Function UpdateProduct _
    (unitPriceAdjustmentPercentage As Decimal, productID As Integer) As Boolean
    Dim products As Northwind.ProductsDataTable = Adapter.GetProductByProductID(productID)
    If products.Count = 0 Then
        ' no matching record found, return false
        Return False
    End If
    Dim product As Northwind.ProductsRow = products(0)
    ' Adjust the UnitPrice by the specified percentage (if it's not NULL)
    If Not product.IsUnitPriceNull() Then
        product.UnitPrice *= unitPriceAdjustmentPercentage
    End If
    ' Update the product record
    Dim rowsAffected As Integer = Adapter.Update(product)
    ' Return true if precisely one row was updated, otherwise false
    Return rowsAffected = 1
End Function