[PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
[PrincipalPermission(SecurityAction.Demand, Role = "Supervisors")]
protected void UserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
     ...
}

[PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
protected void UserGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
     ...
}