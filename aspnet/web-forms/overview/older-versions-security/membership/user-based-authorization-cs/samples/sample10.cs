protected void Page_Load(object sender, EventArgs e)
{
	if (!Page.IsPostBack)
	{
		string appPath = Request.PhysicalApplicationPath;
		DirectoryInfo dirInfo = new DirectoryInfo(appPath);

		FileInfo[] files = dirInfo.GetFiles();

		FilesGrid.DataSource = files;
		FilesGrid.DataBind();
	}
}