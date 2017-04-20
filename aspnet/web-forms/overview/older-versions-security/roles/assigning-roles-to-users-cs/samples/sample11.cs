protected void RoleCheckBox_CheckChanged(object sender, EventArgs e) 
{ 
     // Reference the CheckBox that raised this event 
     CheckBox RoleCheckBox = sender as CheckBox; 

     // Get the currently selected user and role 
     string selectedUserName = UserList.SelectedValue; 

     string roleName = RoleCheckBox.Text; 

     // Determine if we need to add or remove the user from this role 
     if (RoleCheckBox.Checked) 
     { 
          // Add the user to the role 
          Roles.AddUserToRole(selectedUserName, roleName); 
          // Display a status message 
          ActionStatus.Text = string.Format("User {0} was added to role {1}.", selectedUserName, roleName); 
     } 
     else 
     { 
          // Remove the user from the role 
          Roles.RemoveUserFromRole(selectedUserName, roleName); 
          // Display a status message 
          ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName); 

     } 
}