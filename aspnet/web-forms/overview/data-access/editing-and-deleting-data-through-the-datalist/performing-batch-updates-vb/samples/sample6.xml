' Only assign the values to the SupplierRow's column values if they differ
If address Is Nothing AndAlso Not supplier.IsAddressNull() Then
    supplier.SetAddressNull()
ElseIf (address IsNot Nothing AndAlso supplier.IsAddressNull) _
    OrElse (Not supplier.IsAddressNull() AndAlso _
                String.Compare(supplier.Address, address) <> 0) Then
    supplier.Address = address
End If
If city Is Nothing AndAlso Not supplier.IsCityNull() Then
    supplier.SetCityNull()
ElseIf (city IsNot Nothing AndAlso supplier.IsCityNull) _
    OrElse (Not supplier.IsCityNull() AndAlso _
                String.Compare(supplier.City, city) <> 0) Then
    supplier.City = city
End If
If country Is Nothing AndAlso Not supplier.IsCountryNull() Then
    supplier.SetCountryNull()
ElseIf (country IsNot Nothing AndAlso supplier.IsCountryNull) _
    OrElse (Not supplier.IsCountryNull() AndAlso _
                String.Compare(supplier.Country, country) <> 0) Then
    supplier.Country = country
End If