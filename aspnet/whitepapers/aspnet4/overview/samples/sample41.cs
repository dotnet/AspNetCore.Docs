protected void Page_Load(object sender, EventArgs e) 
{ 
	string searchterm = Page.RouteData.Values["searchterm"] as string; 
	label1.Text = searchterm; 
}