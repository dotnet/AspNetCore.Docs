Public Function UpdateProductsWithTransaction _
    (ByVal products As Northwind.ProductsDataTable) As Integer
    ' Mark each product as Modified
    products.AcceptChanges()
    For Each product As Northwind.ProductsRow In products
        product.SetModified()
    Next
    ' Update the data via a transaction
    Return UpdateWithTransaction(products)
End Function