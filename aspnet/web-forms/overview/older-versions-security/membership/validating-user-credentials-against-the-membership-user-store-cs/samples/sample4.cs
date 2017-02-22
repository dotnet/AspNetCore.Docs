protected void myLogin_Authenticate(object sender, AuthenticateEventArgs e)
{
	// Get the email address entered
	TextBox EmailTextBox = myLogin.FindControl("Email") as TextBox;
	string email = EmailTextBox.Text.Trim();

	// Verify that the username/password pair is valid
	if (Membership.ValidateUser(myLogin.UserName, myLogin.Password))
	{
		// Username/password are valid, check email
		MembershipUser usrInfo = Membership.GetUser(myLogin.UserName);
		if (usrInfo != null && string.Compare(usrInfo.Email, email, true) == 0)
		{
			// Email matches, the credentials are valid
			e.Authenticated = true;
		}
		else
		{
			// Email address is invalid...
			e.Authenticated = false;
		}
	}
	else
	{
		// Username/password are not valid...
		e.Authenticated = false;
	}
}