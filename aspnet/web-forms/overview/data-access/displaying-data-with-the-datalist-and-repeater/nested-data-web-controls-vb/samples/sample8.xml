Private allProducts As Northwind.ProductsDataTable = Nothing
Protected Function GetProductsInCategory(ByVal categoryID As Integer) _
    As Northwind.ProductsDataTable
    ' First, see if we've yet to have accessed all of the product information
    If allProducts Is Nothing Then
        Dim productAPI As ProductsBLL = New ProductsBLL()
        allProducts = productAPI.GetProducts()
    End If
    ' Return the filtered view
    allProducts.DefaultView.RowFilter = "CategoryID = " & categoryID
    Return allProducts
End Function