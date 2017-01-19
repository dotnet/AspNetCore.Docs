Protected Overrides Sub OnLoadComplete(ByVal e As EventArgs)
 ' Set the page's title, if necessary
 If String.IsNullOrEmpty(Page.Title) OrElse Page.Title = "Untitled Page" Then
 ' Is this page defined in the site map?
 Dim newTitle As String = Nothing

 Dim current As SiteMapNode = SiteMap.CurrentNode
 If current IsNot Nothing Then
 newTitle = current.Title
 Else
 ' Determine the filename for this page
 newTitle = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath)
 End If

 Page.Title = newTitle
 End If

 MyBase.OnLoadComplete(e)
End Sub