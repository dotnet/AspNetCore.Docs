<System.ComponentModel.DataObject()> _
Public Class ProductsCL
    Private _productsAPI As ProductsBLL = Nothing
    Protected ReadOnly Property API() As ProductsBLL
        Get
            If _productsAPI Is Nothing Then
                _productsAPI = New ProductsBLL()
            End If
            Return _productsAPI
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute _
    (DataObjectMethodType.Select, True)> _
    Public Function GetProducts() As Northwind.ProductsDataTable
        Const rawKey As String = "Products"
        ' See if the item is in the cache
        Dim products As Northwind.ProductsDataTable = _
            TryCast(GetCacheItem(rawKey), Northwind.ProductsDataTable)
        If products Is Nothing Then
            ' Item not found in cache - retrieve it and insert it into the cache
            products = API.GetProducts()
            AddCacheItem(rawKey, products)
        End If
        Return products
    End Function
    <System.ComponentModel.DataObjectMethodAttribute _
        (DataObjectMethodType.Select, False)> _
    Public Function GetProductsByCategoryID(ByVal categoryID As Integer) _
        As Northwind.ProductsDataTable
        If (categoryID < 0) Then
            Return GetProducts()
        Else
            Dim rawKey As String = String.Concat("ProductsByCategory-", categoryID)
            ' See if the item is in the cache
            Dim products As Northwind.ProductsDataTable = _
                TryCast(GetCacheItem(rawKey), Northwind.ProductsDataTable)
            If products Is Nothing Then
                ' Item not found in cache - retrieve it and insert it into the cache
                products = API.GetProductsByCategoryID(categoryID)
                AddCacheItem(rawKey, products)
            End If
            Return products
        End If
    End Function
End Class