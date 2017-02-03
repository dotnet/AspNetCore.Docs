protected void Page_Load(object sender, EventArgs e)
{
	string productAction = Request.QueryString["ProductAction"];
	if (productAction == "add")
	{
		LabelAddStatus.Text = "Product added!";
	}

	if (productAction == "remove")
	{
		LabelRemoveStatus.Text = "Product removed!";
	}
}