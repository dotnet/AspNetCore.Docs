Protected Sub myLogin_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles myLogin.Authenticate
    
 ' Get the email address entered
 Dim EmailTextBox As TextBox = CType(myLogin.FindControl("Email"), TextBox)
 Dim email As String = EmailTextBox.Text.Trim()
    
 ' Verify that the username/password pair is valid
 If Membership.ValidateUser(myLogin.UserName, myLogin.Password) Then

 ' Username/password are valid, check email
 Dim usrInfo As MembershipUser = Membership.GetUser(myLogin.UserName)
    
 If usrInfo IsNot Nothing AndAlso String.Compare(usrInfo.Email, email, True) = 0 Then
 ' Email matches, the credentials are valid
 e.Authenticated = True
 Else
 ' Email address is invalid...
 e.Authenticated = False
 End If
 Else
 ' Username/password are not valid...
 e.Authenticated = False
 End If
End Sub