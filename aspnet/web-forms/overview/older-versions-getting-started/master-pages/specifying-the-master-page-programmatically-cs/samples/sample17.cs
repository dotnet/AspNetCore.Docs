protected void Page_Load(object sender, EventArgs e) 
{ 
	if (!Page.IsPostBack) 
	{ 
		if (Session["MyMasterPage"] != null)
		{
			ListItem li = MasterPageChoice.Items.FindByText(Session["MyMasterPage"].ToString());
			if (li != null) 
				li.Selected = true; 
		} 
	}
}