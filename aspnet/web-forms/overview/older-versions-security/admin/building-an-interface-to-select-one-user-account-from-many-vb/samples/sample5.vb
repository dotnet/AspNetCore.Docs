Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 If Not Page.IsPostBack Then
 BindUserAccounts()
 End If
End Sub

Private Sub BindUserAccounts()
 UserAccounts.DataSource = Membership.GetAllUsers()
 UserAccounts.DataBind()
End Sub