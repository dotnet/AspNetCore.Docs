Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    ' Get the error details
    Dim lastErrorWrapper As HttpException = CType(Server.GetLastError(), HttpException)

    If lastErrorWrapper.GetHttpCode() = 404 Then
        Server.Transfer("~/ErrorPages/404.aspx")
    Else
        Server.Transfer("~/ErrorPages/Oops.aspx")
    End If
End Sub