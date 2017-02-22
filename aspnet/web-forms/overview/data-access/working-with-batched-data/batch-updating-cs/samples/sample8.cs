public int UpdateProductsWithTransaction(Northwind.ProductsDataTable products)
{
    // Mark each product as Modified
    products.AcceptChanges();
    foreach (Northwind.ProductsRow product in products)
        product.SetModified();
    // Update the data via a transaction
    return UpdateWithTransaction(products);
}