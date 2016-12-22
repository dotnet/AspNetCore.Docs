// Only assign the values to the SupplierRow's column values if they differ
if (address == null && !supplier.IsAddressNull())
    supplier.SetAddressNull();
else if ((address != null && supplier.IsAddressNull()) ||
         (!supplier.IsAddressNull() &&
         string.Compare(supplier.Address, address) != 0))
    supplier.Address = address;
if (city == null && !supplier.IsCityNull())
    supplier.SetCityNull();
else if ((city != null && supplier.IsCityNull()) ||
         (!supplier.IsCityNull() && string.Compare(supplier.City, city) != 0))
    supplier.City = city;
if (country == null && !supplier.IsCountryNull())
    supplier.SetCountryNull();
else if ((country != null && supplier.IsCountryNull()) ||
         (!supplier.IsCountryNull() &&
         string.Compare(supplier.Country, country) != 0))
    supplier.Country = country;