public bool UpdateProduct(decimal unitPriceAdjustmentPercentage, int productID)
{
    Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
    if (products.Count == 0)
        // no matching record found, return false
        return false;
    Northwind.ProductsRow product = products[0];
    // Adjust the UnitPrice by the specified percentage (if it's not NULL)
    if (!product.IsUnitPriceNull())
        product.UnitPrice *= unitPriceAdjustmentPercentage;
    // Update the product record
    int rowsAffected = Adapter.Update(product);
    // Return true if precisely one row was updated, otherwise false
    return rowsAffected == 1;
}