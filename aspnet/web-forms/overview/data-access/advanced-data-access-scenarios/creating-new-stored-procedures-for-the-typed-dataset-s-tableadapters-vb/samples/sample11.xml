Imports NorthwindWithSprocsTableAdapters
<System.ComponentModel.DataObject()> _
Public Class ProductsBLLWithSprocs
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
    Public Function GetProducts() As NorthwindWithSprocs.ProductsDataTable
        Return Adapter.GetProducts()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductByProductID(ByVal productID As Integer) _
        As NorthwindWithSprocs.ProductsDataTable
        Return Adapter.GetProductByProductID(productID)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddProduct _
        (ByVal productName As String, ByVal supplierID As Nullable(Of Integer), _
         ByVal categoryID As Nullable(Of Integer), ByVal quantityPerUnit As String, _
         ByVal unitPrice As Nullable(Of Decimal), _
         ByVal unitsInStock As Nullable(Of Short), _
         ByVal unitsOnOrder As Nullable(Of Short), _
         ByVal reorderLevel As Nullable(Of Short), _
         ByVal discontinued As Boolean) _
         As Boolean
         
        ' Create a new ProductRow instance
        Dim products As New NorthwindWithSprocs.ProductsDataTable()
        Dim product As NorthwindWithSprocs.ProductsRow = products.NewProductsRow()
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
        ' Add the new product
        products.AddProductsRow(product)
        Dim rowsAffected As Integer = Adapter.Update(products)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateProduct
        (ByVal productName As String, ByVal supplierID As Nullable(Of Integer), _
         ByVal categoryID As Nullable(Of Integer), ByVal quantityPerUnit As String, _
         ByVal unitPrice As Nullable(Of Decimal), _
         ByVal unitsInStock As Nullable(Of Short), _
         ByVal unitsOnOrder As Nullable(Of Short), _
         ByVal reorderLevel As Nullable(Of Short), _
         ByVal discontinued As Boolean, ByVal productID As Integer) _
         As Boolean
         
        Dim products As NorthwindWithSprocs.ProductsDataTable = _
            Adapter.GetProductByProductID(productID)
        If products.Count = 0 Then
            ' no matching record found, return false
            Return False
        End If
        Dim product As NorthwindWithSprocs.ProductsRow = products(0)
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
        ' Update the product record
        Dim rowsAffected As Integer = Adapter.Update(product)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteProduct(ByVal productID As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(productID)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
End Class