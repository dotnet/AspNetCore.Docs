private void UpdateAllSupplierAddresses()
{
    // Create an instance of the SuppliersBLL class
    SuppliersBLL suppliersAPI = new SuppliersBLL();
    // Iterate through the DataList's items
    foreach (DataListItem item in Suppliers.Items)
    {
        // Get the supplierID from the DataKeys collection
        int supplierID = Convert.ToInt32(Suppliers.DataKeys[item.ItemIndex]);
        // Read in the user-entered values
        TextBox address = (TextBox)item.FindControl("Address");
        TextBox city = (TextBox)item.FindControl("City");
        TextBox country = (TextBox)item.FindControl("Country");
        string addressValue = null, cityValue = null, countryValue = null;
        if (address.Text.Trim().Length > 0)
            addressValue = address.Text.Trim();
        if (city.Text.Trim().Length > 0)
              cityValue = city.Text.Trim();
        if (country.Text.Trim().Length > 0)
            countryValue = country.Text.Trim();
        // Call the SuppliersBLL class's UpdateSupplierAddress method
        suppliersAPI.UpdateSupplierAddress
            (supplierID, addressValue, cityValue, countryValue);
    }
}