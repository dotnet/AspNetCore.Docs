protected void Products_UpdateCommand(object source, DataListCommandEventArgs e)
{
    // Make sure the page is valid...
    if (!Page.IsValid)
        return;
    // Read in the ProductID from the DataKeys collection
    int productID = Convert.ToInt32(Products.DataKeys[e.Item.ItemIndex]);
    // Read in the product name and price values
    TextBox productName = (TextBox)e.Item.FindControl("ProductName");
    DropDownList categories = (DropDownList)e.Item.FindControl("Categories");
    DropDownList suppliers = (DropDownList)e.Item.FindControl("Suppliers");
    CheckBox discontinued = (CheckBox)e.Item.FindControl("Discontinued");
    string productNameValue = null;
    if (productName.Text.Trim().Length > 0)
        productNameValue = productName.Text.Trim();
    int categoryIDValue = Convert.ToInt32(categories.SelectedValue);
    int supplierIDValue = Convert.ToInt32(suppliers.SelectedValue);
    bool discontinuedValue = discontinued.Checked;
    // Call the ProductsBLL's UpdateProduct method...
    ProductsBLL productsAPI = new ProductsBLL();
    productsAPI.UpdateProduct(productNameValue, categoryIDValue, supplierIDValue,
                              discontinuedValue, productID);
    // Revert the DataList back to its pre-editing state
    Products.EditItemIndex = -1;
    Products.DataBind();
}