Protected Sub FilesGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FilesGrid.SelectedIndexChanged
 ' Open the file and display it
 Dim fullFileName As String = FilesGrid.SelectedValue.ToString()
 Dim contents As String = File.ReadAllText(fullFileName)
 FileContents.Text = contents
End Sub