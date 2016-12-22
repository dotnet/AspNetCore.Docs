<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Delete, True)> _
Public Function DeleteCategory(ByVal categoryID As Integer) As Boolean
    Dim rowsAffected As Integer = Adapter.Delete(categoryID)
    ' Return true if precisely one row was deleted, otherwise false
    Return rowsAffected = 1
End Function