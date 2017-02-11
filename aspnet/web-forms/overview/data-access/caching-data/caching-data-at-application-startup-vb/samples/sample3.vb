<System.ComponentModel.DataObject()> _
Public Class StaticCache
    Private Shared suppliers As Northwind.SuppliersDataTable = Nothing
    Public Shared Sub LoadStaticCache()
        ' Get suppliers - cache using a static member variable
        Dim suppliersBLL As New SuppliersBLL()
        suppliers = suppliersBLL.GetSuppliers()
    End Sub
    
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Shared Function GetSuppliers() As Northwind.SuppliersDataTable
        Return suppliers
    End Function
End Class