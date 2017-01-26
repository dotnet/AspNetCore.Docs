void Page_Load()
{
	if (!Page.IsPostBack)
	{
		tbName.Text = lblName.Text;
		tbEmail.Text = lblEmail.Text;
	}
}