protected void SaveLayout_Click(object sender, EventArgs e)
{
	Session["MyMasterPage"] = MasterPageChoice.SelectedValue;
	Response.Redirect("ChooseMasterPage.aspx"); 
}