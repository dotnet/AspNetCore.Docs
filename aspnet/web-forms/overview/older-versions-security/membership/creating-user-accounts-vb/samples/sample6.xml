Protected Sub CreateAccountButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateAccountButton.Click 
 Dim createStatus As MembershipCreateStatus 
 Dim newUser As MembershipUser = _ 
 Membership.CreateUser(Username.Text, Password.Text, _ 
 Email.Text, passwordQuestion, _ 
 SecurityAnswer.Text, True, _ 
 createStatus)
 Select Case createStatus 
 Case MembershipCreateStatus.Success 
 CreateAccountResults.Text = "The user account was successfully created!" 
 Case MembershipCreateStatus.DuplicateUserName 
 CreateAccountResults.Text = "There already exists a user with this username." 
 Case MembershipCreateStatus.DuplicateEmail 
 CreateAccountResults.Text = "There already exists a user with this email address." 
 Case MembershipCreateStatus.InvalidEmail
 CreateAccountResults.Text = "There email address you provided in invalid." 
 Case MembershipCreateStatus.InvalidAnswer 
 CreateAccountResults.Text = "There security answer was invalid." 
 Case MembershipCreateStatus.InvalidPassword 
 CreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character." 
 Case Else 
 CreateAccountResults.Text = "There was an unknown error; the user account was NOT created."
 End Select 
End Sub