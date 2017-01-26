protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
	// Get the RoleNameLabel
	Label RoleNameLabel = RoleList.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;

	// Delete the role
	Roles.DeleteRole(RoleNameLabel.Text, false);

	// Rebind the data to the RoleList grid
	DisplayRolesInGrid();
}