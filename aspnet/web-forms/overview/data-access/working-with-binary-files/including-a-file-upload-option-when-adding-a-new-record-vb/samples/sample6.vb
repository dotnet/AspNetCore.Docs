' Reference the FileUpload controls
Dim BrochureUpload As FileUpload = _
    CType(NewCategory.FindControl("BrochureUpload"), FileUpload)
If BrochureUpload.HasFile Then
    ' Make sure that a PDF has been uploaded
    If String.Compare(System.IO.Path.GetExtension _
        (BrochureUpload.FileName), ".pdf", True) <> 0 Then
        UploadWarning.Text = _
            "Only PDF documents may be used for a category's brochure."
        UploadWarning.Visible = True
        e.Cancel = True
        Exit Sub
    End If
End If