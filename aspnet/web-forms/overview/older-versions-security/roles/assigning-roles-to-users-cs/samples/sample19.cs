protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e) 
{ 
     ... Code removed for brevity ... 

     // Refresh the "by user" interface 
     CheckRolesForSelectedUser(); 
} 

protected void AddUserToRoleButton_Click(object sender, EventArgs e) 
{ 
     ... Code removed for brevity ... 


     // Refresh the "by user" interface 
     CheckRolesForSelectedUser(); 
}