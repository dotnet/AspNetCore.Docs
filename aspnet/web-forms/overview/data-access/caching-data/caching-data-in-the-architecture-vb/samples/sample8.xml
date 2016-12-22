<DataObjectMethodAttribute(DataObjectMethodType.Update, False)> _
Public Function UpdateProduct(productName As String, _
    unitPrice As Nullable(Of Decimal), productID As Integer) _
    As Boolean
    Dim result As Boolean = API.UpdateProduct(productName, unitPrice, productID)
    ' TODO: Invalidate the cache
    Return result
End Function