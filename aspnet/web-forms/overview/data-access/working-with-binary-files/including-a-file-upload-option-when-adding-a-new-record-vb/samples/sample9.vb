' Reference the FileUpload controls
Dim PictureUpload As FileUpload = _
    CType(NewCategory.FindControl("PictureUpload"), FileUpload)
If PictureUpload.HasFile Then
    ' Make sure that a JPG has been uploaded
    If  String.Compare(System.IO.Path.GetExtension(PictureUpload.FileName), _
            ".jpg", True) <> 0 AndAlso _
        String.Compare(System.IO.Path.GetExtension(PictureUpload.FileName), _
            ".jpeg", True) <> 0 Then
        
        UploadWarning.Text = _
            "Only JPG documents may be used for a category's picture."
        UploadWarning.Visible = True
        e.Cancel = True
        Exit Sub
    End If
Else
    ' No picture uploaded!
    UploadWarning.Text = _
        "You must provide a picture for the new category."
    UploadWarning.Visible = True
    e.Cancel = True
    Exit Sub
End If