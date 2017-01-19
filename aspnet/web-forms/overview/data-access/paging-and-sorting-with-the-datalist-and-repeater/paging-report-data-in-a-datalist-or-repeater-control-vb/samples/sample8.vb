Protected Sub FirstPage_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles FirstPage.Click
    ' Send the user to the first page
    RedirectUser(0)
End Sub
Protected Sub PrevPage_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles PrevPage.Click
    ' Send the user to the previous page
    RedirectUser(PageIndex - 1)
End Sub
Protected Sub NextPage_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles NextPage.Click
    ' Send the user to the next page
    RedirectUser(PageIndex + 1)
End Sub
Protected Sub LastPage_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles LastPage.Click
    ' Send the user to the last page
    RedirectUser(PageCount - 1)
End Sub
Private Sub RedirectUser(ByVal sendUserToPageIndex As Integer)
    ' Send the user to the requested page
    Response.Redirect(String.Format("Paging.aspx?pageIndex={0}&pageSize={1}", _
        sendUserToPageIndex, PageSize))
End Sub