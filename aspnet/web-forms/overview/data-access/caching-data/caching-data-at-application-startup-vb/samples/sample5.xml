<System.ComponentModel.DataObject()> _
Public Class StaticCache
    Public Shared Sub LoadStaticCache()
        ' Get suppliers - cache using a static member variable
        Dim suppliersBLL As New SuppliersBLL()
        HttpRuntime.Cache.Insert("key", suppliers, Nothing, _
            Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, _
            CacheItemPriority.NotRemovable, Nothing)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute_
    (System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Shared Function GetSuppliers() As Northwind.SuppliersDataTable
        Return TryCast(HttpRuntime.Cache("key"), Northwind.SuppliersDataTable)
    End Function
End Class