Private Function ValidPictureUpload(ByVal PictureUpload As FileUpload) As Boolean
    ' Make sure that a JPG has been uploaded
    If String.Compare(System.IO.Path.GetExtension(PictureUpload.FileName), _
        ".jpg", True) <> 0 AndAlso _
        String.Compare(System.IO.Path.GetExtension(PictureUpload.FileName), _
        ".jpeg", True) <> 0 Then
        
        UploadWarning.Text = _
            "Only JPG documents may be used for a category's picture."
        UploadWarning.Visible = True
        Return False
    Else
        Return True
    End If
End Function