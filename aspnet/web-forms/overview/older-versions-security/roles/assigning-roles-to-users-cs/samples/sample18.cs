protected void AddUserToRoleButton_Click(object sender, EventArgs e) 
{ 
     // Get the selected role and username 

     string selectedRoleName = RoleList.SelectedValue; 
     string userNameToAddToRole = UserNameToAddToRole.Text; 

     // Make sure that a value was entered 
     if (userNameToAddToRole.Trim().Length == 0) 
     { 
          ActionStatus.Text = "You must enter a username in the textbox."; 
          return; 
     } 

     // Make sure that the user exists in the system 
     MembershipUser userInfo = Membership.GetUser(userNameToAddToRole); 
     if (userInfo == null) 
     { 
          ActionStatus.Text = string.Format("The user {0} does not exist in the system.", userNameToAddToRole); 

          return; 
     } 

     // Make sure that the user doesn't already belong to this role 
     if (Roles.IsUserInRole(userNameToAddToRole, selectedRoleName)) 
     { 
          ActionStatus.Text = string.Format("User {0} already is a member of role {1}.", userNameToAddToRole, selectedRoleName); 
          return; 
     } 

     // If we reach here, we need to add the user to the role 
     Roles.AddUserToRole(userNameToAddToRole, selectedRoleName); 

     // Clear out the TextBox 
     UserNameToAddToRole.Text = string.Empty; 

     // Refresh the GridView 
     DisplayUsersBelongingToRole(); 

     // Display a status message 

     ActionStatus.Text = string.Format("User {0} was added to role {1}.", userNameToAddToRole, selectedRoleName); }