protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e) 
{ 
     // Get the selected role 
     string selectedRoleName = RoleList.SelectedValue; 

     // Reference the UserNameLabel 
     Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label; 

     // Remove the user from the role 
     Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName); 

     // Refresh the GridView 
     DisplayUsersBelongingToRole(); 

     // Display a status message 
     ActionStatus.Text = string.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName); 
}