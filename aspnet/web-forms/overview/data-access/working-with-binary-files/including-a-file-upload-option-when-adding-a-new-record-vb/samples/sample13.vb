Protected Sub NewCategory_ItemInserted _
    (sender As Object, e As DetailsViewInsertedEventArgs) _
    Handles NewCategory.ItemInserted
    
    If e.Exception IsNot Nothing Then
        ' Need to delete brochure file, if it exists
        If e.Values("brochurePath") IsNot Nothing Then
            System.IO.File.Delete(Server.MapPath _
                (e.Values("brochurePath").ToString()))
        End If
    End If
End Sub