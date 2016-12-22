Protected Sub RefreshGrid_Click _
    (ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles RefreshGrid.Click
    
    Products.DataBind()
End Sub
Protected Sub ModifyCategoriesWithTransaction_Click _
    (ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles ModifyCategoriesWithTransaction.Click
    
    ' Get the set of products
    Dim productsAPI As New ProductsBLL()
    Dim productsData As Northwind.ProductsDataTable = productsAPI.GetProducts()
    ' Update each product's CategoryID
    For Each product As Northwind.ProductsRow In productsData
        product.CategoryID = product.ProductID
    Next
    ' Update the data using a transaction
    productsAPI.UpdateWithTransaction(productsData)
    ' Refresh the Grid
    Products.DataBind()
End Sub
Protected Sub ModifyCategoriesWithoutTransaction_Click _
    (ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles ModifyCategoriesWithoutTransaction.Click
    
    ' Get the set of products
    Dim productsAPI As New ProductsBLL()
    Dim productsData As Northwind.ProductsDataTable = productsAPI.GetProducts()
    ' Update each product's CategoryID
    For Each product As Northwind.ProductsRow In productsData
        product.CategoryID = product.ProductID
    Next
    ' Update the data WITHOUT using a transaction
    Dim productsAdapter As New NorthwindTableAdapters.ProductsTableAdapter()
    productsAdapter.Update(productsData)
    ' Refresh the Grid
    Products.DataBind()
End Sub