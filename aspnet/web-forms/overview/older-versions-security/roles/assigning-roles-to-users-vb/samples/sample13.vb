Private Sub BindRolesToList() 
     ' Get all of the roles 
     Dim roleNames() As String = Roles.GetAllRoles() 
     UsersRoleList.DataSource = roleNames 
     UsersRoleList.DataBind() 
 
     RoleList.DataSource = roleNames 
     RoleList.DataBind() 
End Sub