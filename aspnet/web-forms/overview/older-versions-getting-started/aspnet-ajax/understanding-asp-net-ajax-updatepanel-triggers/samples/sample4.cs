public partial class _Default : System.Web.UI.Page
{
	protected void Button1_Click(object sender, EventArgs e)
	{
		if (cbDate.Checked)
		{
			Label1.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
			Label2.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
		}
		else
		{
			Label1.Text = DateTime.Now.ToLongTimeString();
			Label2.Text = DateTime.Now.ToLongTimeString();
		}
	}
	protected void Button2_Click(object sender, EventArgs e)
	{
		if (cbDate.Checked)
		{
			Label1.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
		}
		else
		{
			Label1.Text = DateTime.Now.ToLongTimeString();
		}
	}
	protected void cbDate_CheckedChanged(object sender, EventArgs e)
	{
		cbDate.Font.Bold = cbDate.Checked;
	}
	protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
	{
		Color c = Color.FromName(ddlColor.SelectedValue);
		Label2.ForeColor = c;
	}
}