public bool UpdateProduct(string productName, decimal? unitPrice, short? unitsInStock,
    int productID)
{
    Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
    if (products.Count == 0)
        // no matching record found, return false
        return false;
    Northwind.ProductsRow product = products[0];
    // Make sure the price has not more than doubled
    if (unitPrice != null && !product.IsUnitPriceNull())
        if (unitPrice > product.UnitPrice * 2)
          throw new ApplicationException(
            "When updating a product price," +
            " the new price cannot exceed twice the original price.");
    product.ProductName = productName;
    if (unitPrice == null) product.SetUnitPriceNull();
      else product.UnitPrice = unitPrice.Value;
    if (unitsInStock == null) product.SetUnitsInStockNull();
      else product.UnitsInStock = unitsInStock.Value;
    // Update the product record
    int rowsAffected = Adapter.Update(product);
    // Return true if precisely one row was updated, otherwise false
    return rowsAffected == 1;
}