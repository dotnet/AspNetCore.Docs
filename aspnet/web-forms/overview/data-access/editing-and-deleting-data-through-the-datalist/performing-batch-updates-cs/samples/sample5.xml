public bool UpdateSupplierAddress
    (int supplierID, string address, string city, string country)
{
    Northwind.SuppliersDataTable suppliers =
        Adapter.GetSupplierBySupplierID(supplierID);
    if (suppliers.Count == 0)
        // no matching record found, return false
        return false;
    else
    {
        Northwind.SuppliersRow supplier = suppliers[0];
        if (address == null)
            supplier.SetAddressNull();
        else
            supplier.Address = address;
        if (city == null)
            supplier.SetCityNull();
        else
            supplier.City = city;
        if (country == null)
            supplier.SetCountryNull();
        else
            supplier.Country = country;
        // Update the supplier Address-related information
        int rowsAffected = Adapter.Update(supplier);
        // Return true if precisely one row was updated,
        // otherwise false
        return rowsAffected == 1;
    }
}