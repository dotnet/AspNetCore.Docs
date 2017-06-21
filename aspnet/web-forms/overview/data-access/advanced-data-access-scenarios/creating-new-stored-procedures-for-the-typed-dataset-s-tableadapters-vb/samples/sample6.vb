' Create the ProductsTableAdapter and ProductsDataTable
Dim productsAPI As New NorthwindWithSprocsTableAdapters.ProductsTableAdapter 
Dim products As New NorthwindWithSprocs.ProductsDataTable
' Create a new ProductsRow instance and set its properties
Dim product As NorthwindWithSprocs.ProductsRow = products.NewProductsRow()
product.ProductName = "New Product"
product.CategoryID = 1  ' Beverages
product.Discontinued = False
' Add the ProductsRow instance to the DataTable
products.AddProductsRow(product)
' Update the DataTable using the Batch Update pattern
productsAPI.Update(products)
' At this point, we can determine the value of the newly-added record's ProductID
Dim newlyAddedProductIDValue as Integer = product.ProductID