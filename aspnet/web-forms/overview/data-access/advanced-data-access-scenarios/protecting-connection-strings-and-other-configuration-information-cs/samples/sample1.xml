protected void Page_Load(object sender, EventArgs e)
{
    // On the first page visit, call DisplayWebConfig method
    if (!Page.IsPostBack)
        DisplayWebConfig();
}
private void DisplayWebConfig()
{
    // Reads in the contents of Web.config and displays them in the TextBox
    StreamReader webConfigStream = 
        File.OpenText(Path.Combine(Request.PhysicalApplicationPath, "Web.config"));
    string configContents = webConfigStream.ReadToEnd();
    webConfigStream.Close();
    WebConfigContents.Text = configContents;
}