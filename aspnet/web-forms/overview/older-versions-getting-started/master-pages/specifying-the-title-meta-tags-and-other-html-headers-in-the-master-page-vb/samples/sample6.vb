Protected Overrides Sub OnLoadComplete(ByVal e As EventArgs)
 ' Set the page's title, if necessary
 If String.IsNullOrEmpty(Page.Title) OrElse Page.Title = "Untitled Page" Then
 ' Determine the filename for this page
 Dim fileName As String = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath)

 Page.Title = fileName
 End If

 MyBase.OnLoadComplete(e)
End Sub