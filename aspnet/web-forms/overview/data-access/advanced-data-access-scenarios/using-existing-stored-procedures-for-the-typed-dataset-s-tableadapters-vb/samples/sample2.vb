<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Select, False)> _
Public Function GetProductsByCategoryID(ByVal categoryID As Integer) _
    As NorthwindWithSprocs.ProductsDataTable
    Return Adapter.GetProductsByCategoryID(categoryID)
End Function