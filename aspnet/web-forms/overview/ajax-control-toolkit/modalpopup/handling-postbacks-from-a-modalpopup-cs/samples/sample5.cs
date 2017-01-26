protected void SaveData(object sender, EventArgs e)
{
	lblName.Text = HttpUtility.HtmlEncode(tbName.Text);
	lblEmail.Text = HttpUtility.HtmlEncode(tbEmail.Text);
}