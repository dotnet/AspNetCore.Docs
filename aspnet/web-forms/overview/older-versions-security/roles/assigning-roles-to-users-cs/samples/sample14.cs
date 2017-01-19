private void DisplayUsersBelongingToRole() 
{ 
     // Get the selected role 
     string selectedRoleName = RoleList.SelectedValue; 

     // Get the list of usernames that belong to the role 
     string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName); 

     // Bind the list of users to the GridView 
     RolesUserList.DataSource = usersBelongingToRole; 
     RolesUserList.DataBind(); 
}