Private Function ProcessBrochureUpload _
    (BrochureUpload As FileUpload, CancelOperation As Boolean) As String
    
    CancelOperation = False    ' by default, do not cancel operation
    If BrochureUpload.HasFile Then
        ' Make sure that a PDF has been uploaded
        If String.Compare(System.IO.Path.GetExtension(BrochureUpload.FileName), _
            ".pdf", True) <> 0 Then
            
            UploadWarning.Text = _
                "Only PDF documents may be used for a category's brochure."
            UploadWarning.Visible = True
            CancelOperation = True
            Return Nothing
        End If
        Const BrochureDirectory As String = "~/Brochures/"
        Dim brochurePath As String = BrochureDirectory + BrochureUpload.FileName
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
        Return brochurePath
    Else
        ' No file uploaded
        Return Nothing
    End If
End Function
Private Sub DeleteRememberedBrochurePath()
    ' Is there a file to delete?
    If deletedCategorysPdfPath IsNot Nothing Then
        System.IO.File.Delete(Server.MapPath(deletedCategorysPdfPath))
    End If
End Sub