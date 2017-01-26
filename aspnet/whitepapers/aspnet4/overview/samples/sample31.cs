void Application_Start(object sender, EventArgs e) 
{ 
	HttpCapabilitiesBase.BrowserCapabilitiesProvider =
	new ClassLibrary2.CustomProvider();
	// ... 
 }