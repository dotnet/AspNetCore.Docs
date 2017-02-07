Protected Sub GridView1_RowUpdated(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) _
    Handles GridView1.RowUpdated
    If e.Exception IsNot Nothing Then
        ExceptionDetails.Visible = True
        ExceptionDetails.Text = "There was a problem updating the product. "
        If e.Exception.InnerException IsNot Nothing Then
            Dim inner As Exception = e.Exception.InnerException
            If TypeOf inner Is System.Data.Common.DbException Then
                ExceptionDetails.Text &= _
                "Our database is currently experiencing problems." & _
                "Please try again later."
            ElseIf TypeOf inner _
             Is System.Data.NoNullAllowedException Then
                ExceptionDetails.Text += _
                    "There are one or more required fields that are missing."
            ElseIf TypeOf inner Is ArgumentException Then
                Dim paramName As String = CType(inner, ArgumentException).ParamName
                ExceptionDetails.Text &= _
                    String.Concat("The ", paramName, " value is illegal.")
            ElseIf TypeOf inner Is ApplicationException Then
                ExceptionDetails.Text += inner.Message
            End If
        End If
        e.ExceptionHandled = True
        e.KeepInEditMode = True
    End If
End Sub