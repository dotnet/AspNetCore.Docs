protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
{
    // Read in the ProductID from the DataKeys collection
    int productID = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex]);
    // Read in the product name and price values
    TextBox productName = (TextBox)e.Item.FindControl("ProductName");
    TextBox unitPrice = (TextBox)e.Item.FindControl("UnitPrice");
    string productNameValue = null;
    if (productName.Text.Trim().Length > 0)
        productNameValue = productName.Text.Trim();
    decimal? unitPriceValue = null;
    if (unitPrice.Text.Trim().Length > 0)
        unitPriceValue = Decimal.Parse(unitPrice.Text.Trim(),
            System.Globalization.NumberStyles.Currency);
    // Call the ProductsBLL's UpdateProduct method...
    ProductsBLL productsAPI = new ProductsBLL();
    productsAPI.UpdateProduct(productNameValue, unitPriceValue, productID);
    // Revert the DataList back to its pre-editing state
    DataList1.EditItemIndex = -1;
    DataList1.DataBind();
}