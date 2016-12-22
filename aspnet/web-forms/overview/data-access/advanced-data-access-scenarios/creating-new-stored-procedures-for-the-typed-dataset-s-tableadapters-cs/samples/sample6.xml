// Create the ProductsTableAdapter and ProductsDataTable
NorthwindWithSprocsTableAdapters.ProductsTableAdapter productsAPI = 
    new NorthwindWithSprocsTableAdapters.ProductsTableAdapter();
NorthwindWithSprocs.ProductsDataTable products = 
    new NorthwindWithSprocs.ProductsDataTable();
// Create a new ProductsRow instance and set its properties
NorthwindWithSprocs.ProductsRow product = products.NewProductsRow();
product.ProductName = "New Product";
product.CategoryID = 1;  // Beverages
product.Discontinued = false;
// Add the ProductsRow instance to the DataTable
products.AddProductsRow(product);
// Update the DataTable using the Batch Update pattern
productsAPI.Update(products);
// At this point, we can determine the value of the newly-added record's ProductID
int newlyAddedProductIDValue = product.ProductID;