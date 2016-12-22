<DataObjectMethodAttribute(DataObjectMethodType.Update, False)> _
Public Function UpdateProduct(ByVal productName As String, _
    ByVal unitPrice As Nullable(Of Decimal), ByVal productID As Integer) _
    As Boolean
    Dim result As Boolean = API.UpdateProduct(productName, unitPrice, productID)
    ' Invalidate the cache
    InvalidateCache()
    Return result
End Function
Public Sub InvalidateCache()
    ' Remove the cache dependency
    HttpRuntime.Cache.Remove(MasterCacheKeyArray(0))
End Sub