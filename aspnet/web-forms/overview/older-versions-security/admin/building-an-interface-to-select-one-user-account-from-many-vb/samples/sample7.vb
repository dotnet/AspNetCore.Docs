Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 If Not Page.IsPostBack Then
 BindUserAccounts()
 BindFilteringUI()
 End If
End Sub

Private Sub BindFilteringUI()
 Dim filterOptions() As String = {"All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
 FilteringUI.DataSource = filterOptions
 FilteringUI.DataBind()
End Sub