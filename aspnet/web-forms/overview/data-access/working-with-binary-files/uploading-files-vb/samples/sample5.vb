Protected Sub UploadButton_Click(sender As Object, e As EventArgs) _
    Handles UploadButton.Click
    
    If UploadTest.HasFile = False Then
        ' No file uploaded!
        UploadDetails.Text = "Please first select a file to upload..."
    Else
        ' Display the uploaded file's details
        UploadDetails.Text = String.Format( _
                "Uploaded file: {0}<br />" & _
                "File size (in bytes): {1:N0}<br />" & _
                "Content-type: {2}", _
                UploadTest.FileName, _
                UploadTest.FileBytes.Length, _
                UploadTest.PostedFile.ContentType)
        ' Save the file
        Dim filePath As String = _
            Server.MapPath("~/Brochures/" & UploadTest.FileName)
        UploadTest.SaveAs(filePath)
    End If
End Sub