Imports NorthwindTableAdapters
Partial Public Class Northwind
    Partial Public Class SuppliersRow
        Public Function GetProducts() As Northwind.ProductsDataTable
            Dim productsAdapter As New ProductsTableAdapter
            Return productsAdapter.GetProductsBySupplierID(Me.SupplierID)
        End Function
    End Class
End Class