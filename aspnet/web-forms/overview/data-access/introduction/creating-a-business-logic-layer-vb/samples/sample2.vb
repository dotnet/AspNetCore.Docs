<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Update, True)> _
Public Function UpdateSupplierAddress(ByVal supplierID As Integer, _
    ByVal address As String, ByVal city As String, ByVal country As String) _
    As Boolean

    Dim suppliers As Northwind.SuppliersDataTable = _
        Adapter.GetSupplierBySupplierID(supplierID)

    If suppliers.Count = 0 Then
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

        Dim rowsAffected As Integer = Adapter.Update(supplier)

        Return rowsAffected = 1
    End If
End Function