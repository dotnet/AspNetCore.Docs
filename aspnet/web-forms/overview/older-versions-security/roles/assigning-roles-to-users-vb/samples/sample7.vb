Private Sub CheckRolesForSelectedUser() 
     ' Determine what roles the selected user belongs to 
     Dim selectedUserName As String = UserList.SelectedValue 
     Dim selectedUsersRoles() As String = Roles.GetRolesForUser(selectedUserName) 
 
     ' Loop through the Repeater's Items and check or uncheck the checkbox as needed 
     For Each ri As RepeaterItem In UsersRoleList.Items 
          ' Programmatically reference the CheckBox 
          Dim RoleCheckBox As CheckBox = CType(ri.FindControl("RoleCheckBox"), CheckBox) 
          ' See if RoleCheckBox.Text is in selectedUsersRoles 
          If Linq.Enumerable.Contains(Of String)(selectedUsersRoles, RoleCheckBox.Text) Then 
               RoleCheckBox.Checked = True 
          Else 
               RoleCheckBox.Checked = False 
          End If 
     Next 
End Sub