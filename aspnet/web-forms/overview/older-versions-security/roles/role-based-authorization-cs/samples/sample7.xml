protected void UserGrid_RowEditing(object sender, GridViewEditEventArgs e)
{
     // Set the grid's EditIndex and rebind the data

     UserGrid.EditIndex = e.NewEditIndex;
     BindUserGrid();
}

protected void UserGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
{
     // Revert the grid's EditIndex to -1 and rebind the data
     UserGrid.EditIndex = -1;
     BindUserGrid();
}

protected void UserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
     // Exit if the page is not valid
     if (!Page.IsValid)
          return;

     // Determine the username of the user we are editing
     string UserName = UserGrid.DataKeys[e.RowIndex].Value.ToString();

     // Read in the entered information and update the user
     TextBox EmailTextBox = UserGrid.Rows[e.RowIndex].FindControl("Email") as TextBox;
     TextBox CommentTextBox = UserGrid.Rows[e.RowIndex].FindControl("Comment") as TextBox;

     // Return information about the user
     MembershipUser UserInfo = Membership.GetUser(UserName);

     // Update the User account information
     UserInfo.Email = EmailTextBox.Text.Trim();
     UserInfo.Comment = CommentTextBox.Text.Trim();

     Membership.UpdateUser(UserInfo);

     // Revert the grid's EditIndex to -1 and rebind the data
     UserGrid.EditIndex = -1;
     BindUserGrid();
}