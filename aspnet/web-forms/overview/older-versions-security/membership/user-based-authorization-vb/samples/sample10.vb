Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 If Not Page.IsPostBack Then
 Dim appPath As String = Request.PhysicalApplicationPath
 Dim dirInfo As New DirectoryInfo(appPath)

 Dim files() As FileInfo = dirInfo.GetFiles()

 FilesGrid.DataSource = files
 FilesGrid.DataBind()
 End If
End Sub