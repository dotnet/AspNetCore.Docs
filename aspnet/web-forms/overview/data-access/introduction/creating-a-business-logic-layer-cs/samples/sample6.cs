public bool UpdateProduct(string productName, int? supplierID, int? categoryID,
    string quantityPerUnit, decimal? unitPrice, short? unitsInStock,
    short? unitsOnOrder, short? reorderLevel, bool discontinued, int productID)
{
    Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
    if (products.Count == 0)
        // no matching record found, return false
        return false;

    Northwind.ProductsRow product = products[0];

    // Business rule check - cannot discontinue
    // a product that is supplied by only
    // one supplier
    if (discontinued)
    {
        // Get the products we buy from this supplier
        Northwind.ProductsDataTable productsBySupplier =
            Adapter.GetProductsBySupplierID(product.SupplierID);

        if (productsBySupplier.Count == 1)
            // this is the only product we buy from this supplier
            throw new ApplicationException(
                "You cannot mark a product as discontinued if it is the only
                  product purchased from a supplier");
    }

    product.ProductName = productName;
    if (supplierID == null) product.SetSupplierIDNull();
      else product.SupplierID = supplierID.Value;
    if (categoryID == null) product.SetCategoryIDNull();
      else product.CategoryID = categoryID.Value;
    if (quantityPerUnit == null) product.SetQuantityPerUnitNull();
      else product.QuantityPerUnit = quantityPerUnit;
    if (unitPrice == null) product.SetUnitPriceNull();
      else product.UnitPrice = unitPrice.Value;
    if (unitsInStock == null) product.SetUnitsInStockNull();
      else product.UnitsInStock = unitsInStock.Value;
    if (unitsOnOrder == null) product.SetUnitsOnOrderNull();
      else product.UnitsOnOrder = unitsOnOrder.Value;
    if (reorderLevel == null) product.SetReorderLevelNull();
      else product.ReorderLevel = reorderLevel.Value;
    product.Discontinued = discontinued;

    // Update the product record
    int rowsAffected = Adapter.Update(product);

    // Return true if precisely one row was updated,
    // otherwise false
    return rowsAffected == 1;
}