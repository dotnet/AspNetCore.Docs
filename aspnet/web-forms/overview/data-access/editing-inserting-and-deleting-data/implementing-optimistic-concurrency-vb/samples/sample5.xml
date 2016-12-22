Imports NorthwindOptimisticConcurrencyTableAdapters
<System.ComponentModel.DataObject()> _
Public Class ProductsOptimisticConcurrencyBLL
    Private _productsAdapter As ProductsOptimisticConcurrencyTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As ProductsOptimisticConcurrencyTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New ProductsOptimisticConcurrencyTableAdapter()
            End If
            Return _productsAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProducts() As _
        NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyDataTable
        Return Adapter.GetProducts()
    End Function
End Class