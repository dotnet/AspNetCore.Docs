protected void Page_Load()
{
	var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

	HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

	// Enable this after setting up two-factor authentientication
	PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

	TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

	LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

	var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

	if (!IsPostBack)
	{
		// Determine the sections to render
		if (HasPassword(manager))
		{
			ChangePassword.Visible = true;
		}
		else
		{
			CreatePassword.Visible = true;
			ChangePassword.Visible = false;
		}

		// Render success message
		var message = Request.QueryString["m"];
		if (message != null)
		{
			// Strip the query string from action
			Form.Action = ResolveUrl("~/Account/Manage");

			SuccessMessage =
				message == "ChangePwdSuccess" ? "Your password has been changed."
				: message == "SetPwdSuccess" ? "Your password has been set."
				: message == "RemoveLoginSuccess" ? "The account was removed."
				: message == "AddPhoneNumberSuccess" ? "Phone number has been added"
				: message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
				: String.Empty;
			successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
		}
	}
}