protected void UserGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
     // Determine the username of the user we are editing
     string UserName = UserGrid.DataKeys[e.RowIndex].Value.ToString();

     // Delete the user
     Membership.DeleteUser(UserName);

     // Revert the grid's EditIndex to -1 and rebind the data
     UserGrid.EditIndex = -1;
     BindUserGrid();
}