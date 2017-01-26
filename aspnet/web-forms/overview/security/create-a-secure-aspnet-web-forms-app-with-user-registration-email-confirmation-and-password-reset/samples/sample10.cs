protected void SendEmailConfirmationToken(object sender, EventArgs e)
{
	var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
	var user = manager.FindByName(Email.Text);
	if (user != null)
	{
		if (!user.EmailConfirmed)
		{
			string code = manager.GenerateEmailConfirmationToken(user.Id);
			string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
			manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

			FailureText.Text = "Confirmation email sent. Please view the email and confirm your account.";
			ErrorMessage.Visible = true;
			ResendConfirm.Visible = false;
		}
	}
}