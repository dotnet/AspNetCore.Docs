<System.ComponentModel.DataObject()> _
Public Class StaticCache
    Public Shared Sub LoadStaticCache()
        ' Get suppliers - cache using application state
        Dim suppliersBLL As New SuppliersBLL()
        HttpContext.Current.Application("key") = suppliers
    End Sub
    
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Shared Function GetSuppliers() As Northwind.SuppliersDataTable
        Return TryCast(HttpContext.Current.Application("key"), _
            Northwind.SuppliersDataTable)
    End Function
End Class