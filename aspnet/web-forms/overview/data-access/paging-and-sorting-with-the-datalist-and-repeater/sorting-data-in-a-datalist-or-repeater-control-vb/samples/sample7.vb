Private ReadOnly Property SortExpression() As String
    Get
        If Not String.IsNullOrEmpty(Request.QueryString("sortExpression")) Then
            Return Request.QueryString("sortExpression")
        Else
            Return "ProductName"
        End If
    End Get
End Property
Private Sub RedirectUser(ByVal sendUserToPageIndex As Integer)
    ' Use the SortExpression property to get the sort expression
    ' from the querystring
    RedirectUser(sendUserToPageIndex, SortExpression)
End Sub
Private Sub RedirectUser(ByVal sendUserToPageIndex As Integer,
    ByVal sendUserSortingBy As String)
    ' Send the user to the requested page with the
    ' requested sort expression
    Response.Redirect(String.Format("SortingWithDefaultPaging.aspx?" & _
        "pageIndex={0}&pageSize={1}&sortExpression={2}", _
        sendUserToPageIndex, PageSize, sendUserSortingBy))
End Sub