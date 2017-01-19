Protected Sub PageList_SelectedIndexChanged(sender As Object, e As System.EventArgs) _
    Handles PageList.SelectedIndexChanged
        ' Jump to the specified page
        Products.PageIndex = Convert.ToInt32(PageList.SelectedValue)
End Sub