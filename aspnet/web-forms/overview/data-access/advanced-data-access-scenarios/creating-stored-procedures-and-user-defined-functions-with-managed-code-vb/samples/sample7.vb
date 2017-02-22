<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Select, False)> _
Public Function GetDiscontinuedProducts() As NorthwindWithSprocs.ProductsDataTable
    Return Adapter.GetDiscontinuedProducts()
End Function
<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Select, False)> _
Public Function GetProductsWithPriceLessThan(ByVal priceLessThan As Decimal) _
    As NorthwindWithSprocs.ProductsDataTable
    Return Adapter.GetProductsWithPriceLessThan(priceLessThan)
End Function