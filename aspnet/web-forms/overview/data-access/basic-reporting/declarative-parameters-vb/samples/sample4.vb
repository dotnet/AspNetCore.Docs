Public Function GetSuppliersByCountry(country As String) _
    As Northwind.SuppliersDataTable
    If String.IsNullOrEmpty(country) Then
        Return GetSuppliers()
    Else
        Return Adapter.GetSuppliersByCountry(country)
    End If
End Function