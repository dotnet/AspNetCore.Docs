Protected Sub AddUserToRoleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddUserToRoleButton.Click 
     ' Get the selected role and username 
     Dim selectedRoleName As String = RoleList.SelectedValue 
     Dim userToAddToRole As String = UserNameToAddToRole.Text 
 
     ' Make sure that a value was entered 
     If userToAddToRole.Trim().Length = 0 Then 
          ActionStatus.Text = "You must enter a username in the textbox." 
          Exit Sub 
     End If 
 
     ' Make sure that the user exists in the system 
     Dim userInfo As MembershipUser = Membership.GetUser(userToAddToRole) 
     If userInfo Is Nothing Then 
          ActionStatus.Text = String.Format("The user {0} does not exist in the system.",userNameToAddToRole) 
          Exit Sub 
     End If 
 
     ' Make sure that the user doesn't already belong to this role 
     If Roles.IsUserInRole(userToAddToRole, selectedRoleName) Then 
          ActionStatus.Text = String.Format("User {0} already is a member of role {1}.", UserNameToAddToRole,selectedRoleName) 
          Exit Sub 
     End If 
 
     ' If we reach here, we need to add the user to the role 
     Roles.AddUserToRole(userToAddToRole, selectedRoleName) 
 
     ' Clear out the TextBox 
     userNameToAddToRole.Text = String.Empty 
 
     ' Refresh the GridView 
     DisplayUsersBelongingToRole() 
 
     ' Display a status message 
     ActionStatus.Text = String.Format("User {0} was added to role {1}.", UserNameToAddToRole,selectedRoleName) 
End Sub