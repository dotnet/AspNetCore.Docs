private void Page_Error(object sender, EventArgs e)
{
	Exception exc = Server.GetLastError();

	// Handle specific exception.
	if (exc is HttpUnhandledException)
	{
		ErrorMsgTextBox.Text = "An error occurred on this page. Please verify your " +                  
		"information to resolve the issue."
	}
	// Clear the error from the server.
	Server.ClearError();
}