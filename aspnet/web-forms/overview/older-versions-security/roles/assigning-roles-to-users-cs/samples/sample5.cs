private void BindUsersToUserList() 
{ 
     // Get all of the user accounts 
     MembershipUserCollection users = Membership.GetAllUsers(); 
     UserList.DataSource = users; 
     UserList.DataBind(); 
}
 
private void BindRolesToList() 
{ 
     // Get all of the roles 
     string[] roles = Roles.GetAllRoles(); 
     UsersRoleList.DataSource = roles; 
     UsersRoleList.DataBind(); 
}