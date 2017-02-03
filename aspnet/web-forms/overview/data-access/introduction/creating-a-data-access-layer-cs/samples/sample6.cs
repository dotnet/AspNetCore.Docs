NorthwindTableAdapters.ProductsTableAdapter productsAdapter =
  new NorthwindTableAdapters.ProductsTableAdapter();
// For each product, double its price if it is not discontinued and
// there are 25 items in stock or less
Northwind.ProductsDataTable products = productsAdapter.GetProducts();
foreach (Northwind.ProductsRow product in products)
   if (!product.Discontinued && product.UnitsInStock <= 25)
      product.UnitPrice *= 2;
// Update the products
productsAdapter.Update(products);