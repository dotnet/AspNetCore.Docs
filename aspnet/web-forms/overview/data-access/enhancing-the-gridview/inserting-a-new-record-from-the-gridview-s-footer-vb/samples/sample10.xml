Protected Sub Products_DataBound(sender As Object, e As EventArgs) _
    Handles Products.DataBound
    
    ' Send user to last page of data, if needed
    If SendUserToLastPage Then
        Products.PageIndex = Products.PageCount - 1
    End If
End Sub