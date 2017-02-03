NorthwindTableAdapters.ProductsTableAdapter productsAdapter =
    new NorthwindTableAdapters.ProductsTableAdapter();
// Delete the product with ProductID 3
productsAdapter.Delete(3);
// Update Chai (ProductID of 1), setting the UnitsOnOrder to 15
productsAdapter.Update("Chai", 1, 1, "10 boxes x 20 bags",
  18.0m, 39, 15, 10, false, 1);
// Add a new product
productsAdapter.Insert("New Product", 1, 1,
  "12 tins per carton", 14.95m, 15, 0, 10, false);