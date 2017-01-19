Dim productsAdapter As New NorthwindTableAdapters.ProductsTableAdapter()
Dim new_productID As Integer = Convert.ToInt32(productsAdapter.InsertProduct( _
    "New Product", 1, 1, "12 tins per carton", 14.95, 10, 0, 10, false))
productsAdapter.Delete(new_productID)