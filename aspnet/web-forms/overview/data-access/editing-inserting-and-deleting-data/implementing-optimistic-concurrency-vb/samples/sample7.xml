Protected Sub AssignAllProductValues( _
    ByVal product As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyRow, _
    ByVal productName As String, ByVal supplierID As Nullable(Of Integer), _
    ByVal categoryID As Nullable(Of Integer), ByVal quantityPerUnit As String, _
    ByVal unitPrice As Nullable(Of Decimal), ByVal unitsInStock As Nullable(Of Short), _
    ByVal unitsOnOrder As Nullable(Of Short), ByVal reorderLevel As Nullable(Of Short), _
    ByVal discontinued As Boolean)
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
End Sub
<System.ComponentModel.DataObjectMethodAttribute( _
System.ComponentModel.DataObjectMethodType.Update, True)> _
Public Function UpdateProduct(
    ByVal productName As String, ByVal supplierID As Nullable(Of Integer), _
    ByVal categoryID As Nullable(Of Integer), ByVal quantityPerUnit As String, _
    ByVal unitPrice As Nullable(Of Decimal), ByVal unitsInStock As Nullable(Of Short), _
    ByVal unitsOnOrder As Nullable(Of Short), ByVal reorderLevel As Nullable(Of Short), _
    ByVal discontinued As Boolean, ByVal productID As Integer, _
    _
    ByVal original_productName As String, _
    ByVal original_supplierID As Nullable(Of Integer), _
    ByVal original_categoryID As Nullable(Of Integer), _
    ByVal original_quantityPerUnit As String, _
    ByVal original_unitPrice As Nullable(Of Decimal), _
    ByVal original_unitsInStock As Nullable(Of Short), _
    ByVal original_unitsOnOrder As Nullable(Of Short), _
    ByVal original_reorderLevel As Nullable(Of Short), _
    ByVal original_discontinued As Boolean, _
    ByVal original_productID As Integer) _
    As Boolean
    'STEP 1: Read in the current database product information
    Dim products As _
        NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyDataTable = _
        Adapter.GetProductByProductID(original_productID)
    If products.Count = 0 Then
        ' no matching record found, return false
        Return False
    End If
    Dim product As _
        NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyRow = products(0)
    'STEP 2: Assign the original values to the product instance
    AssignAllProductValues( _
        product, original_productName, original_supplierID, _
        original_categoryID, original_quantityPerUnit, original_unitPrice, _
        original_unitsInStock, original_unitsOnOrder, original_reorderLevel, _
        original_discontinued)
    'STEP 3: Accept the changes
    product.AcceptChanges()
    'STEP 4: Assign the new values to the product instance
    AssignAllProductValues( _
        product, productName, supplierID, categoryID, quantityPerUnit, unitPrice, _
        unitsInStock, unitsOnOrder, reorderLevel, discontinued)
    'STEP 5: Update the product record
    Dim rowsAffected As Integer = Adapter.Update(product)
    ' Return true if precisely one row was updated, otherwise false
    Return rowsAffected = 1
End Function