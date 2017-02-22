Protected Sub NewCategory_ItemInserting _
    (sender As Object, e As DetailsViewInsertEventArgs) _
    Handles NewCategory.ItemInserting
    
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
    ' Set the value of the picture parameter
    e.Values("picture") = PictureUpload.FileBytes
    ' Reference the FileUpload controls
    Dim BrochureUpload As FileUpload = _
        CType(NewCategory.FindControl("BrochureUpload"), FileUpload)
    If BrochureUpload.HasFile Then
        ' Make sure that a PDF has been uploaded
        If String.Compare(System.IO.Path.GetExtension(BrochureUpload.FileName), _
            ".pdf", True) <> 0 Then
            
            UploadWarning.Text = _
                "Only PDF documents may be used for a category's brochure."
            UploadWarning.Visible = True
            e.Cancel = True
            Exit Sub
        End If
        Const BrochureDirectory As String = "~/Brochures/"
        Dim brochurePath As String = BrochureDirectory & BrochureUpload.FileName
        Dim fileNameWithoutExtension As String = _
            System.IO.Path.GetFileNameWithoutExtension(BrochureUpload.FileName)
        Dim iteration As Integer = 1
        While System.IO.File.Exists(Server.MapPath(brochurePath))
            brochurePath = String.Concat(BrochureDirectory, _
                fileNameWithoutExtension, "-", iteration, ".pdf")
            iteration += 1
        End While
        ' Save the file to disk and set the value of the brochurePath parameter
        BrochureUpload.SaveAs(Server.MapPath(brochurePath))
        e.Values("brochurePath") = brochurePath
    End If
End Sub