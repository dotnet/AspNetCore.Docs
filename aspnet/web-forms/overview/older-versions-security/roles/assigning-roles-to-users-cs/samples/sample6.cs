protected void Page_Load(object sender, EventArgs e) 
{ 
     if (!Page.IsPostBack) 
     { 
          // Bind the users and roles 
          BindUsersToUserList(); 
          BindRolesToList(); 
     } 
}