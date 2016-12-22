private Northwind.ProductsDataTable allProducts = null;
protected Northwind.ProductsDataTable GetProductsInCategory(int categoryID)
{
    // First, see if we've yet to have accessed all of the product information
    if (allProducts == null)
    {
        ProductsBLL productAPI = new ProductsBLL();
        allProducts = productAPI.GetProducts();
    }
    // Return the filtered view
    allProducts.DefaultView.RowFilter = "CategoryID = " + categoryID;
    return allProducts;
}