Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click

 ' Validate the user against the Membership framework user store
 If Membership.ValidateUser(UserName.Text, Password.Text) Then
 ' Log the user into the site
 FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked)
 End If
    
 ' If we reach here, the user's credentials were invalid
 InvalidCredentialsMessage.Visible = True
End Sub