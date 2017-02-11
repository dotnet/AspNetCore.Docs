Imports NorthwindWithSprocsTableAdapters
<System.ComponentModel.DataObject()> _
Public Class SuppliersBLLWithSprocs
    Private _suppliersAdapter As SuppliersTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As SuppliersTableAdapter
        Get
            If _suppliersAdapter Is Nothing Then
                _suppliersAdapter = New SuppliersTableAdapter()
            End If
            Return _suppliersAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSuppliers() As NorthwindWithSprocs.SuppliersDataTable
        Return Adapter.GetSuppliers()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateSupplier(companyName As String, contactName As String, _
        contactTitle As String, supplierID As Integer) As Boolean
        Dim suppliers As NorthwindWithSprocs.SuppliersDataTable = _
            Adapter.GetSupplierBySupplierID(supplierID)
        If suppliers.Count = 0 Then
            ' no matching record found, return false
            Return False
        End If
        Dim supplier As NorthwindWithSprocs.SuppliersRow = suppliers(0)
        supplier.CompanyName = companyName
        If contactName Is Nothing Then 
            supplier.SetContactNameNull() 
        Else 
            supplier.ContactName = contactName
        End If
        If contactTitle Is Nothing Then 
            supplier.SetContactTitleNull() 
        Else 
            supplier.ContactTitle = contactTitle
        End If
        ' Update the product record
        Dim rowsAffected As Integer = Adapter.Update(supplier)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
End Class