Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     If Not Page.IsPostBack Then
          ' If querystring value is missing, send the user to ManageUsers.aspx
          Dim userName As String = Request.QueryString("user")
          If String.IsNullOrEmpty(userName) Then
               Response.Redirect("ManageUsers.aspx")
          End If

          ' Get information about this user
          Dim usr As MembershipUser = Membership.GetUser(userName)
          If usr Is Nothing Then
               Response.Redirect("ManageUsers.aspx")

          End If

          UserNameLabel.Text = usr.UserName
          IsApproved.Checked = usr.IsApproved

          If usr.LastLockoutDate.Year < 2000 Then
               LastLockoutDateLabel.Text = String.Empty
          Else
               LastLockoutDateLabel.Text = usr.LastLockoutDate.ToShortDateString()
               UnlockUserButton.Enabled = usr.IsLockedOut
          End If
     End If
End Sub