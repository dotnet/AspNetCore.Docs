protected Northwind.ProductsDataTable GetProductsInCategory(int categoryID)
{
    // Create an instance of the ProductsBLL class
    ProductsBLL productAPI = new ProductsBLL();
    // Return the products in the category
    return productAPI.GetProductsByCategoryID(categoryID);
}