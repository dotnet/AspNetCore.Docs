Protected Sub RoleCheckBox_CheckChanged(ByVal sender As Object, ByVal e As EventArgs) 
     'Reference the CheckBox that raised this event 
     Dim RoleCheckBox As CheckBox = CType(sender, CheckBox) 
 
     ' Get the currently selected user and role 
     Dim selectedUserName As String = UserList.SelectedValue 
     Dim roleName As String = RoleCheckBox.Text 
 
     ' Determine if we need to add or remove the user from this role 
     If RoleCheckBox.Checked Then 
          ' Add the user to the role 
          Roles.AddUserToRole(selectedUserName, roleName) 
          ' Display a status message 
          ActionStatus.Text = String.Format("User {0} was added to role {1}.", selectedUserName,roleName) 
     Else 
          ' Remove the user from the role 
          Roles.RemoveUserFromRole(selectedUserName, roleName) 
          ' Display a status message 
          ActionStatus.Text = String.Format("User {0} was removed from role {1}.", selectedUserName,roleName) 
     End If 
End Sub