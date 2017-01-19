protected void Page_Load(object sender, EventArgs e) 
{ 
     if (!Page.IsPostBack) 
     { 
          // Bind the users and roles 
          BindUsersToUserList(); 
          BindRolesToList(); 

          // Check the selected user's roles 
          CheckRolesForSelectedUser(); 

          // Display those users belonging to the currently selected role 
          DisplayUsersBelongingToRole(); 
     } 
} 

... 

protected void RoleList_SelectedIndexChanged(object sender, EventArgs e) 
{ 
     DisplayUsersBelongingToRole(); 
}