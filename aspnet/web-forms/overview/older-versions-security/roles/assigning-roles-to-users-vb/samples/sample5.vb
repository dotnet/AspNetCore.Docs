Private Sub BindUsersToUserList() 
     ' Get all of the user accounts 
     Dim users As MembershipUserCollection = Membership.GetAllUsers() 
     UserList.DataSource = users 
     UserList.DataBind() 
End Sub 
 
Private Sub BindRolesToList() 
     ' Get all of the roles 
     Dim roleNames() As String = Roles.GetAllRoles() 
     UsersRoleList.DataSource = roleNames 
     UsersRoleList.DataBind() 
End Sub