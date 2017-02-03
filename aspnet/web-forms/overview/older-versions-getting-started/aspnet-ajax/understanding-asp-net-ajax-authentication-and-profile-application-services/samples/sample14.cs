protected void Page_Load(object sender, EventArgs e)
{
	this.ScriptManager1.AuthenticationService.Path = "~/AuthService.asmx";
}