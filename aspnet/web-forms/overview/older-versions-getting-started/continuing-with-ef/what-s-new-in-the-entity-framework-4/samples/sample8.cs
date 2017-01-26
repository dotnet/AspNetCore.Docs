using ContosoUniversity.DAL; 

// ...

protected void AlumniGridView_RowDataBound(object sender, GridViewRowEventArgs e)
{
	if (e.Row.RowType == DataControlRowType.DataRow)
	{
		var alumnus = e.Row.DataItem as Alumnus;
		var donationsGridView = (GridView)e.Row.FindControl("DonationsGridView");
		donationsGridView.DataSource = alumnus.Donations.ToList();
		donationsGridView.DataBind();
	}
}