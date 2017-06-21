public partial class _Default : System.Web.UI.Page
{
	protected void Button1_Click(object sender, EventArgs e)
	{
		Label1.Text = DateTime.Now.ToLongTimeString();
		Label2.Text = DateTime.Now.ToLongTimeString();
	}
	protected void Button2_Click(object sender, EventArgs e)
	{
		Label1.Text = DateTime.Now.ToLongTimeString();
	}
}