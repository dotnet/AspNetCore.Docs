Protected Sub Products_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Products.DataBound
    PagingInformation.Text = String.Format("You are viewing page {0} of {1}...", _
        Products.PageIndex + 1, Products.PageCount)
End Sub