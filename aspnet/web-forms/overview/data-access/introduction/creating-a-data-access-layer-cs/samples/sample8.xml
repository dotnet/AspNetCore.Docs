NorthwindTableAdapters.ProductsTableAdapter productsAdapter =
    new NorthwindTableAdapters.ProductsTableAdapter();
// Add a new product
int new_productID = Convert.ToInt32(productsAdapter.InsertProduct
    ("New Product", 1, 1, "12 tins per carton", 14.95m, 10, 0, 10, false));
// On second thought, delete the product
productsAdapter.Delete(new_productID);