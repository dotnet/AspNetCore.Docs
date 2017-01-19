Private Sub DisplayExceptionDetails(ByVal ex As Exception)
    ' Display a user-friendly message
    ExceptionDetails.Text = "There was a problem updating the product. "
    If TypeOf ex Is System.Data.Common.DbException Then
        ExceptionDetails.Text += "Our database is currently experiencing problems." + _
                                 "Please try again later."
    ElseIf TypeOf ex Is System.Data.NoNullAllowedException Then
        ExceptionDetails.Text+="There are one or more required fields that are missing."
    ElseIf TypeOf ex Is ArgumentException Then
        Dim paramName As String = CType(ex, ArgumentException).ParamName
        ExceptionDetails.Text+=String.Concat("The ", paramName, " value is illegal.")
    ElseIf TypeOf ex Is ApplicationException Then
        ExceptionDetails.Text += ex.Message
    End If
End Sub