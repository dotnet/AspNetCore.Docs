protected void Page_Load(object sender, EventArgs e) 
{ 
     if (!Page.IsPostBack) 
     { 

          // Bind the users and roles 
          BindUsersToUserList(); 
          BindRolesToList(); 
          // Check the selected user's roles 
          CheckRolesForSelectedUser(); 
     } 
} 

... 

protected void UserList_SelectedIndexChanged(object sender, EventArgs e) 
{ 
     CheckRolesForSelectedUser(); 
}