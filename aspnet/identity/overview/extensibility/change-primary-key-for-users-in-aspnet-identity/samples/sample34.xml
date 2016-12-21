protected void Page_Load()
{
    // Process the result from an auth provider in the request
    ProviderName = IdentityHelper.GetProviderNameFromRequest(Request);
    if (String.IsNullOrEmpty(ProviderName))
    {
        RedirectOnFail();
        return;
    }
    if (!IsPostBack)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
        if (loginInfo == null)
        {
            RedirectOnFail();
            return;
        }
        var user = manager.Find(loginInfo.Login);
        if (user != null)
        {
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else if (User.Identity.IsAuthenticated)
        {
            // Apply Xsrf check when linking
            var verifiedloginInfo = Context.GetOwinContext().Authentication
                .GetExternalLoginInfo(IdentityHelper.XsrfKey, User.Identity.GetUserId());
            if (verifiedloginInfo == null)
            {
                RedirectOnFail();
                return;
            }

            var result = manager.AddLogin(User.Identity.GetUserId<int>(), 
                verifiedloginInfo.Login);
            if (result.Succeeded)
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], 
                    Response);
            }
            else
            {
                AddErrors(result);
                return;
            }
        }
        else
        {
            email.Text = loginInfo.Email;
        }
    }
}