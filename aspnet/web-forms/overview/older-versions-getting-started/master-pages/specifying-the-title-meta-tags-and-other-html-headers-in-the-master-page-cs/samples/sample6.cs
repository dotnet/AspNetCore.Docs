protected override void OnLoadComplete(EventArgs e)
{
	// Set the page's title, if necessary
	if (string.IsNullOrEmpty(Page.Title) || Page.Title == "Untitled Page")
	{
		// Determine the filename for this page
		string fileName = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath);

		Page.Title = fileName;
	}

	base.OnLoadComplete(e);
}