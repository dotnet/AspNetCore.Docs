protected void LogIn(object sender, EventArgs e)
{
	if (IsValid)
	{
		// Validate the user password
		var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
		var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

		// Require the user to have a confirmed email before they can log on.
		var user = manager.FindByName(Email.Text);
		if (user != null)
		{
			if (!user.EmailConfirmed)
			{
				FailureText.Text = "Invalid login attempt. You must have a confirmed email account.";
				ErrorMessage.Visible = true;
			}
			else
			{
				// This doen't count login failures towards account lockout
				// To enable password failures to trigger lockout, change to shouldLockout: true
				var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

				switch (result)
				{
					case SignInStatus.Success:
						IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
						break;
					case SignInStatus.LockedOut:
						Response.Redirect("/Account/Lockout");
						break;
					case SignInStatus.RequiresVerification:
						Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
													Request.QueryString["ReturnUrl"],
													RememberMe.Checked),
									  true);
						break;
					case SignInStatus.Failure:
					default:
						FailureText.Text = "Invalid login attempt";
						ErrorMessage.Visible = true;
						break;
				}
			}
		}
	}          
}