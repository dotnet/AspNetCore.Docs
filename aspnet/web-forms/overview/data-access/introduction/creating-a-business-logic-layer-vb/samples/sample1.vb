Imports NorthwindTableAdapters

<System.ComponentModel.DataObject()> _
Public Class ProductsBLL

    Private _productsAdapter As ProductsTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As ProductsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New ProductsTableAdapter()
            End If

            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProducts() As Northwind.ProductsDataTable
        Return Adapter.GetProducts()
    End Function

    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductByProductID(ByVal productID As Integer) _
        As Northwind.ProductsDataTable
        Return Adapter.GetProductByProductID(productID)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsByCategoryID(ByVal categoryID As Integer) _
        As Northwind.ProductsDataTable
        Return Adapter.GetProductsByCategoryID(categoryID)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsBySupplierID(ByVal supplierID As Integer) _
        As Northwind.ProductsDataTable
        Return Adapter.GetProductsBySupplierID(supplierID)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddProduct( _
        productName As String, supplierID As Nullable(Of Integer), _
        categoryID As Nullable(Of Integer), quantityPerUnit As String, _
        unitPrice As Nullable(Of Decimal), unitsInStock As Nullable(Of Short), _
        unitsOnOrder As Nullable(Of Short), reorderLevel As Nullable(Of Short), _
        discontinued As Boolean) _
        As Boolean

        Dim products As New Northwind.ProductsDataTable()
        Dim product As Northwind.ProductsRow = products.NewProductsRow()

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

        products.AddProductsRow(product)
        Dim rowsAffected As Integer = Adapter.Update(products)

        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateProduct(_
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

        Dim product as Northwind.ProductsRow = products(0)

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

    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteProduct(ByVal productID As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(productID)

        Return rowsAffected = 1
    End Function
End Class