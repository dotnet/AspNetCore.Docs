Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    ' Get the error details
    Dim lastErrorWrapper As HttpException = CType(Server.GetLastError(), HttpException)

    Dim lastError As Exception = lastErrorWrapper
    If lastErrorWrapper.InnerException IsNot Nothing Then
        lastError = lastErrorWrapper.InnerException
    End If

    Dim lastErrorTypeName As String = lastError.GetType().ToString()
    Dim lastErrorMessage As String = lastError.Message
    Dim lastErrorStackTrace As String = lastError.StackTrace
End Sub