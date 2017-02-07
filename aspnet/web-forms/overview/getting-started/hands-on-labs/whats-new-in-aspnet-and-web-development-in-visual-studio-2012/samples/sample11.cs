void Application_Start(object sender, EventArgs e)
{
	// Default behavior
	// Bundles all .js files in folders such as "scripts" if URL pointed to it: http://localhost:54716/scripts/custom/js 
	BundleTable.Bundles.EnableDefaultBundles();

	...
}