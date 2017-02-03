private int TotalRowCount
{
    get
    {
        // Return the value from the TotalNumberOfProducts() method
        ProductsBLL productsAPI = new ProductsBLL();
        return productsAPI.TotalNumberOfProducts();
    }
}