protected override void OnLoadComplete(EventArgs e)
{
	// Set the page's title, if necessary
	if (string.IsNullOrEmpty(Page.Title) || Page.Title == "Untitled Page")
	{
		// Is this page defined in the site map?
		string newTitle = null;

		SiteMapNode current = SiteMap.CurrentNode;
		if (current != null)
		{
			newTitle = current.Title;
		}
		else
		{
			// Determine the filename for this page
			newTitle = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath);
		}

		Page.Title = newTitle;
	}

	base.OnLoadComplete(e);
}