<System.ComponentModel.DataObjectMethodAttribute_
    (System.ComponentModel.DataObjectMethodType.Update, True)> _
Public Function UpdateProduct( _
    productName As String, supplierID As Nullable(Of Integer), _
    categoryID As Nullable(Of Integer), quantityPerUnit As String, _
    unitPrice As Nullable(Of Decimal), unitsInStock As Nullable(Of Short), _
    unitsOnOrder As Nullable(Of Short), reorderLevel As Nullable(Of Short), _
    discontinued As Boolean, productID As Integer) _
    As Boolean

    Dim products As Northwind.ProductsDataTable = _
        Adapter.GetProductByProductID(productID)

    If products.Count = 0 Then
        Return False
    End If

    Dim product As Northwind.ProductsRow = products(0)

    If discontinued Then
        Dim productsBySupplier As Northwind.ProductsDataTable = _
            Adapter.GetProductsBySupplierID(product.SupplierID)

        If productsBySupplier.Count = 1 Then
            Throw New ApplicationException( _
                "You cannot mark a product as discontinued if it is " & _
                "the only product purchased from a supplier")
        End If
    End If

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

    If quantityPerUnit Is Nothing Then
        product.SetQuantityPerUnitNull()
    Else
        product.QuantityPerUnit = quantityPerUnit
    End If

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

    If Not unitsOnOrder.HasValue Then
        product.SetUnitsOnOrderNull()
    Else
        product.UnitsOnOrder = unitsOnOrder.Value
    End If

    If Not reorderLevel.HasValue Then
        product.SetReorderLevelNull()
    Else
        product.ReorderLevel = reorderLevel.Value
    End If

    product.Discontinued = discontinued

    Dim rowsAffected As Integer = Adapter.Update(product)

    Return rowsAffected = 1
End Function