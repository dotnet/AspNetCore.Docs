protected void RefreshGrid_Click(object sender, EventArgs e)
{
    Products.DataBind();
}
protected void ModifyCategoriesWithTransaction_Click(object sender, EventArgs e)
{
    // Get the set of products
    ProductsBLL productsAPI = new ProductsBLL();
    Northwind.ProductsDataTable products = productsAPI.GetProducts();
    // Update each product's CategoryID
    foreach (Northwind.ProductsRow product in products)
    {
        product.CategoryID = product.ProductID;
    }
    // Update the data using a transaction
    productsAPI.UpdateWithTransaction(products);
    // Refresh the Grid
    Products.DataBind();
}
protected void ModifyCategoriesWithoutTransaction_Click(object sender, EventArgs e)
{
    // Get the set of products
    ProductsBLL productsAPI = new ProductsBLL();
    Northwind.ProductsDataTable products = productsAPI.GetProducts();
    // Update each product's CategoryID
    foreach (Northwind.ProductsRow product in products)
    {
        product.CategoryID = product.ProductID;
    }
    // Update the data WITHOUT using a transaction
    NorthwindTableAdapters.ProductsTableAdapter productsAdapter = 
        new NorthwindTableAdapters.ProductsTableAdapter();
    productsAdapter.Update(products);
    // Refresh the Grid
    Products.DataBind();
}