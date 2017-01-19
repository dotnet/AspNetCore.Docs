protected void AssignAllProductValues
    (NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyRow product,
    string productName, int? supplierID, int? categoryID, string quantityPerUnit,
    decimal? unitPrice, short? unitsInStock, short? unitsOnOrder,
    short? reorderLevel, bool discontinued)
{
    product.ProductName = productName;
    if (supplierID == null)
        product.SetSupplierIDNull();
    else
        product.SupplierID = supplierID.Value;
    if (categoryID == null)
        product.SetCategoryIDNull();
    else
        product.CategoryID = categoryID.Value;
    if (quantityPerUnit == null)
        product.SetQuantityPerUnitNull();
    else
        product.QuantityPerUnit = quantityPerUnit;
    if (unitPrice == null)
        product.SetUnitPriceNull();
    else
        product.UnitPrice = unitPrice.Value;
    if (unitsInStock == null)
        product.SetUnitsInStockNull();
    else
        product.UnitsInStock = unitsInStock.Value;
    if (unitsOnOrder == null)
        product.SetUnitsOnOrderNull();
    else
        product.UnitsOnOrder = unitsOnOrder.Value;
    if (reorderLevel == null)
        product.SetReorderLevelNull();
    else
        product.ReorderLevel = reorderLevel.Value;
    product.Discontinued = discontinued;
}
[System.ComponentModel.DataObjectMethodAttribute
(System.ComponentModel.DataObjectMethodType.Update, true)]
public bool UpdateProduct(
    // new parameter values
    string productName, int? supplierID, int? categoryID, string quantityPerUnit,
    decimal? unitPrice, short? unitsInStock, short? unitsOnOrder,
    short? reorderLevel, bool discontinued, int productID,
    // original parameter values
    string original_productName, int? original_supplierID, int? original_categoryID,
    string original_quantityPerUnit, decimal? original_unitPrice,
    short? original_unitsInStock, short? original_unitsOnOrder,
    short? original_reorderLevel, bool original_discontinued,
    int original_productID)
{
    // STEP 1: Read in the current database product information
    NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyDataTable products =
        Adapter.GetProductByProductID(original_productID);
    if (products.Count == 0)
        // no matching record found, return false
        return false;
    NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyRow product = products[0];
    // STEP 2: Assign the original values to the product instance
    AssignAllProductValues(product, original_productName, original_supplierID,
        original_categoryID, original_quantityPerUnit, original_unitPrice,
        original_unitsInStock, original_unitsOnOrder, original_reorderLevel,
        original_discontinued);
    // STEP 3: Accept the changes
    product.AcceptChanges();
    // STEP 4: Assign the new values to the product instance
    AssignAllProductValues(product, productName, supplierID, categoryID,
        quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel,
        discontinued);
    // STEP 5: Update the product record
    int rowsAffected = Adapter.Update(product);
    // Return true if precisely one row was updated, otherwise false
    return rowsAffected == 1;
}