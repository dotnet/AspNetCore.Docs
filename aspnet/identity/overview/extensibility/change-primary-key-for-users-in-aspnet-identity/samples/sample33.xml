protected void Page_Load(object sender, EventArgs e)
{
    string code = IdentityHelper.GetCodeFromRequest(Request);
    string userId = IdentityHelper.GetUserIdFromRequest(Request);
    if (code != null && userId != null)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var result = manager.ConfirmEmail(Int32.Parse(userId), code);
        if (result.Succeeded)
        {
            StatusMessage = "Thank you for confirming your account.";
            return;
        }
    }

    StatusMessage = "An error has occurred";
}