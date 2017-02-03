[PrincipalPermission(SecurityAction.Demand, Authenticated=true)]
protected void FilesGrid_SelectedIndexChanged(object sender, EventArgs e)
{
	...
}

[PrincipalPermission(SecurityAction.Demand, Name="Tito")]
protected void FilesGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
	...
}