Dim productsAdapter As New NorthwindTableAdapters.ProductsTableAdapter()
Dim products as Northwind.ProductsDataTable
products = productsAdapter.GetProducts()
For Each productRow As Northwind.ProductsRow In products
    Response.Write("Product: " & productRow.ProductName & "<br />")
Next