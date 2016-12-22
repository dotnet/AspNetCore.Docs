private void CheckRolesForSelectedUser() 
{ 
     // Determine what roles the selected user belongs to 
     string selectedUserName = UserList.SelectedValue; 
     string[] selectedUsersRoles = Roles.GetRolesForUser(selectedUserName); 

     // Loop through the Repeater's Items and check or uncheck the checkbox as needed 

     foreach (RepeaterItem ri in UsersRoleList.Items) 
     { 
          // Programmatically reference the CheckBox 
          CheckBox RoleCheckBox = ri.FindControl("RoleCheckBox") as CheckBox; 
          // See if RoleCheckBox.Text is in selectedUsersRoles 
          if (selectedUsersRoles.Contains<string>(RoleCheckBox.Text)) 
               RoleCheckBox.Checked = true; 
          else 
               RoleCheckBox.Checked = false; 
     } 
}