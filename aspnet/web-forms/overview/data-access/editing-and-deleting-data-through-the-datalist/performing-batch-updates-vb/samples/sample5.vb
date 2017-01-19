Public Function UpdateSupplierAddress _
    (supplierID As Integer, address As String, city As String, country As String) _
    As Boolean
    Dim suppliers As Northwind.SuppliersDataTable = _
        Adapter.GetSupplierBySupplierID(supplierID)
    If suppliers.Count = 0 Then
        ' no matching record found, return false
        Return False
    Else
        Dim supplier As Northwind.SuppliersRow = suppliers(0)
        If address Is Nothing Then
            supplier.SetAddressNull()
        Else
            supplier.Address = address
        End If
        If city Is Nothing Then
            supplier.SetCityNull()
        Else
            supplier.City = city
        End If
        If country Is Nothing Then
            supplier.SetCountryNull()
        Else
            supplier.Country = country
        End If
        ' Update the supplier Address-related information
        Dim rowsAffected As Integer = Adapter.Update(supplier)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End If
End Function