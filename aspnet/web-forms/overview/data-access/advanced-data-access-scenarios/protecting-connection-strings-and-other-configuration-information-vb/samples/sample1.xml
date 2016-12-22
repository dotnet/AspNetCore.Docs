Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    'On the first page visit, call DisplayWebConfig method
    If Not Page.IsPostBack Then
        DisplayWebConfig()
    End If
End Sub
Private Sub DisplayWebConfig()
    'Reads in the contents of Web.config and displays them in the TextBox
    Dim webConfigStream As StreamReader = _
        File.OpenText(Path.Combine(Request.PhysicalApplicationPath, "Web.config"))
    Dim configContents As String = webConfigStream.ReadToEnd()
    webConfigStream.Close()
    WebConfigContents.Text = configContents
End Sub