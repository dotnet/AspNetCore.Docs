Protected Sub FilesGrid_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)Handles FilesGrid.RowDeleting
 Dim fullFileName As String = FilesGrid.DataKeys(e.RowIndex).Value.ToString()
 FileContents.Text = String.Format("You have opted to delete {0}.", fullFileName)

 ' To actually delete the file, uncomment the following line
 ' File.Delete(fullFileName)
End Sub