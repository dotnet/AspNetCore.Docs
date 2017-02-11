protected void myLogin_LoginError(object sender, EventArgs e)
{
	// Determine why the user could not login...
	myLogin.FailureText = "Your login attempt was not successful. Please try again.";

	// Does there exist a User account for this user?
	MembershipUser usrInfo = Membership.GetUser(myLogin.UserName);
	if (usrInfo != null)
	{
		// Is this user locked out?
		if (usrInfo.IsLockedOut)
		{
			myLogin.FailureText = "Your account has been locked out because of too many invalid login attempts. Please contact the administrator to have your account unlocked.";
		}
		else if (!usrInfo.IsApproved)
		{
			myLogin.FailureText = "Your account has not yet been approved. You cannot login until an administrator has approved your account.";
		}
	}
}