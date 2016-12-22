Public Function GetProductsByCategoryID(categoryID As Integer) _
    As Northwind.ProductsDataTable
    If categoryID < 0 Then
        Return GetProducts()
    Else
        Return Adapter.GetProductsByCategoryID(categoryID)
    End If
End Function