Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     If Not Page.IsPostBack Then
          BindUserGrid()
     End If
End Sub

Private Sub BindUserGrid()
     Dim allUsers As MembershipUserCollection = Membership.GetAllUsers()
     UserGrid.DataSource = allUsers
     UserGrid.DataBind()
End Sub