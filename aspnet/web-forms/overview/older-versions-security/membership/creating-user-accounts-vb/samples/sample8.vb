Protected Sub RegisterUser_CreatingUser(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles RegisterUser.CreatingUser
 Dim trimmedUserName As String = RegisterUser.UserName.Trim() 
 If RegisterUser.UserName.Length <> trimmedUserName.Length Then 
 ' Show the error message 
 InvalidUserNameOrPasswordMessage.Text = "The username cannot contain leading or trailing spaces." 
 InvalidUserNameOrPasswordMessage.Visible = True 
 ' Cancel the create user workflow 
 e.Cancel = True 
 Else 
 ' Username is valid, make sure that the password does not contain the username 
 If RegisterUser.Password.IndexOf(RegisterUser.UserName, StringComparison.OrdinalIgnoreCase) >= 0 Then 
 ' Show the error message 
 InvalidUserNameOrPasswordMessage.Text = "The username may not appear anywhere in the password." 
 InvalidUserNameOrPasswordMessage.Visible = True 
 ' Cancel the create user workflow 
 e.Cancel = True 
 End If 
 End If 
End Sub