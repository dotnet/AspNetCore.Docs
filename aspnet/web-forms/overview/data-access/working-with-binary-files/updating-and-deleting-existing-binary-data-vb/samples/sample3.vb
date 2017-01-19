<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Update, False)> _
Public Function UpdateCategory(categoryName As String, description As String, _
    brochurePath As String, picture() As Byte, categoryID As Integer) As Boolean
    
    ' If no picture is specified, use other overload
    If picture Is Nothing Then
        Return UpdateCategory(categoryName, description, brochurePath, categoryID)
    End If
    ' Update picture, as well
    Dim rowsAffected As Integer = Adapter.UpdateWithPicture _
        (categoryName, description, brochurePath, picture, categoryID)
    ' Return true if precisely one row was updated, otherwise false
    Return rowsAffected = 1
End Function
<System.ComponentModel.DataObjectMethodAttribute _
    (System.ComponentModel.DataObjectMethodType.Update, True)> _
Public Function UpdateCategory(categoryName As String, description As String, _
    brochurePath As String, categoryID As Integer) As Boolean
    Dim rowsAffected As Integer = Adapter.Update _
        (categoryName, description, brochurePath, categoryID)
    ' Return true if precisely one row was updated, otherwise false
    Return rowsAffected = 1
End Function