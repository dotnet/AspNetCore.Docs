Private Sub DisplayUsersBelongingToRole() 
     ' Get the selected role 
     Dim selectedRoleName As String = RoleList.SelectedValue 
 
     ' Get the list of usernames that belong to the role 
     Dim usersBelongingToRole() As String = Roles.GetUsersInRole(selectedRoleName) 
 
     ' Bind the list of users to the GridView 
     RolesUserList.DataSource = usersBelongingToRole 
     RolesUserList.DataBind() 
End Sub