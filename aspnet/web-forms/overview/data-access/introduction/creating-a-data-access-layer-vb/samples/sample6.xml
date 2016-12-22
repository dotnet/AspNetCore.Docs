Dim productsAdapter As New NorthwindTableAdapters.ProductsTableAdapter()
Dim products As Northwind.ProductsDataTable = productsAdapter.GetProducts()
For Each product As Northwind.ProductsRow In products
   If Not product.Discontinued AndAlso product.UnitsInStock <= 25 Then
      product.UnitPrice *= 2
   End if
Next
productsAdapter.Update(products)