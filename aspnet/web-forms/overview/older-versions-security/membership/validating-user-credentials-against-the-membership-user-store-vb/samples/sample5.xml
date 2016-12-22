Protected Sub myLogin_LoginError(ByVal sender As Object, ByVal e As System.EventArgs) Handles myLogin.LoginError
    
 ' Determine why the user could not login...
 myLogin.FailureText = "Your login attempt was not successful. Please try again."
    
 ' Does there exist a User account for this user?
 Dim usrInfo As MembershipUser = Membership.GetUser(myLogin.UserName)

 If usrInfo IsNot Nothing Then
 ' Is this user locked out?
 If usrInfo.IsLockedOut Then
 myLogin.FailureText = "Your account has been locked out because of too many invalid login attempts. Please contact the administrator to have your account unlocked."
 ElseIf Not usrInfo.IsApproved Then
 myLogin.FailureText = "Your account has not yet been approved. You cannot login until an administrator has approved your account."
 End If
 End If
End Sub