<System.ComponentModel.DataObjectMethodAttribute _
(System.ComponentModel.DataObjectMethodType.Delete, True)> _
Public Function DeleteProduct( _
    ByVal original_productID As Integer, ByVal original_productName As String, _
    ByVal original_supplierID As Nullable(Of Integer), _
    ByVal original_categoryID As Nullable(Of Integer), _
    ByVal original_quantityPerUnit As String, _
    ByVal original_unitPrice As Nullable(Of Decimal), _
    ByVal original_unitsInStock As Nullable(Of Short), _
    ByVal original_unitsOnOrder As Nullable(Of Short), _
    ByVal original_reorderLevel As Nullable(Of Short), _
    ByVal original_discontinued As Boolean) _
    As Boolean
    Dim rowsAffected As Integer = Adapter.Delete(
                                    original_productID, _
                                    original_productName, _
                                    original_supplierID, _
                                    original_categoryID, _
                                    original_quantityPerUnit, _
                                    original_unitPrice, _
                                    original_unitsInStock, _
                                    original_unitsOnOrder, _
                                    original_reorderLevel, _
                                    original_discontinued)
    ' Return true if precisely one row was deleted, otherwise false
    Return rowsAffected = 1
End Function