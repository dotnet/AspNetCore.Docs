public Northwind.SuppliersDataTable GetSuppliersByCountry(string country)
{
    if (string.IsNullOrEmpty(country))
        return GetSuppliers();
    else
        return Adapter.GetSuppliersByCountry(country);
}