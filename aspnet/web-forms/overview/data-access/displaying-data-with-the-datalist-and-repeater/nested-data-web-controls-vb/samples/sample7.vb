Protected Function GetProductsInCategory(ByVal categoryID As Integer) _
    As Northwind.ProductsDataTable
    ' Create an instance of the ProductsBLL class
    Dim productAPI As ProductsBLL = New ProductsBLL()
    ' Return the products in the category
    Return productAPI.GetProductsByCategoryID(categoryID)
End Function