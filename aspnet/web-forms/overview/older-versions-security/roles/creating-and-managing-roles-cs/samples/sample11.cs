protected void CreateRoleButton_Click(object sender, EventArgs e)    
{    
	string newRoleName = RoleName.Text.Trim();

	if (!Roles.RoleExists(newRoleName))    
	{    
		// Create the role    
		Roles.CreateRole(newRoleName);

		// Refresh the RoleList Grid    
		DisplayRolesInGrid();    
	}

	RoleName.Text = string.Empty;    
}