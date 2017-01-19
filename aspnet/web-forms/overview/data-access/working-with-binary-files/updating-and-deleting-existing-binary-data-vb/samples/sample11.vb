' Reference the PictureUpload FileUpload
Dim PictureUpload As FileUpload = _
    CType(categories.Rows(e.RowIndex).FindControl("PictureUpload"), _
        FileUpload)
If PictureUpload.HasFile Then
    ' Make sure the picture upload is valid
    If ValidPictureUpload(PictureUpload) Then
        e.NewValues("picture") = PictureUpload.FileBytes
    Else
        ' Invalid file upload, cancel update and exit event handler
        e.Cancel = True
        Exit Sub
    End If
End If