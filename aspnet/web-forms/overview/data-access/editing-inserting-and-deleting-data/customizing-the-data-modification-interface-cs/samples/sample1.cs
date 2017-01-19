[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
public bool UpdateProduct(string productName, int? categoryID,
    int? supplierID, bool discontinued, int productID)
{
    Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
    if (products.Count == 0)
        // no matching record found, return false
        return false;
    Northwind.ProductsRow product = products[0];
    product.ProductName = productName;
    if (supplierID == null) product.SetSupplierIDNull();
      else product.SupplierID = supplierID.Value;
    if (categoryID == null) product.SetCategoryIDNull();
      else product.CategoryID = categoryID.Value;
    product.Discontinued = discontinued;
    // Update the product record
    int rowsAffected = Adapter.Update(product);
    // Return true if precisely one row was updated, otherwise false
    return rowsAffected == 1;
}