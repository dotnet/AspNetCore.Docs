<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, False)>
Public Function UpdateProduct(
    ByVal productName As String, ByVal categoryID As Nullable(Of Integer), 
    ByVal supplierID As Nullable(Of Integer), ByVal discontinued As Boolean, 
    ByVal productID As Integer)
    As Boolean
    Dim products As Northwind.ProductsDataTable = Adapter.GetProductByProductID(productID)
    If products.Count = 0 Then
        Return False
    End If
    Dim product As Northwind.ProductsRow = products(0)
    product.ProductName = productName
    If Not supplierID.HasValue Then
        product.SetSupplierIDNull()
    Else
        product.SupplierID = supplierID.Value
    End If
    If Not categoryID.HasValue Then
        product.SetCategoryIDNull()
    Else
        product.CategoryID = categoryID.Value
    End If
    product.Discontinued = discontinued
    Dim rowsAffected As Integer = Adapter.Update(product)
    Return rowsAffected = 1
End Function