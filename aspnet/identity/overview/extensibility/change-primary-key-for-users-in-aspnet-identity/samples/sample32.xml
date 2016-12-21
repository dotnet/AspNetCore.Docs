private bool HasPassword(ApplicationUserManager manager)
{
    return manager.HasPassword(User.Identity.GetUserId<int>());
}

protected void Page_Load()
{
    if (!IsPostBack)
    {
        // Determine the sections to render
         var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        if (HasPassword(manager))
        {
            changePasswordHolder.Visible = true;
        }
        else
        {
            setPassword.Visible = true;
            changePasswordHolder.Visible = false;
        }
        CanRemoveExternalLogins = manager.GetLogins(
            User.Identity.GetUserId<int>()).Count() > 1;

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
                : String.Empty;
            successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
        }
    }
}

protected void ChangePassword_Click(object sender, EventArgs e)
{
    if (IsValid)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        IdentityResult result = manager.ChangePassword(
            User.Identity.GetUserId<int>(),
            CurrentPassword.Text, 
            NewPassword.Text);
        if (result.Succeeded)
        {
            var user = manager.FindById(User.Identity.GetUserId<int>());
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
        }
        else
        {
            AddErrors(result);
        }
    }
}

protected void SetPassword_Click(object sender, EventArgs e)
{
    if (IsValid)
    {
        // Create the local login info and link the local account to the user
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        IdentityResult result = manager.AddPassword(User.Identity.GetUserId<int>(), 
            password.Text);
        if (result.Succeeded)
        {
            Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
        }
        else
        {
            AddErrors(result);
        }
    }
}

public IEnumerable<UserLoginInfo> GetLogins()
{
    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
    var accounts = manager.GetLogins(User.Identity.GetUserId<int>());
    CanRemoveExternalLogins = accounts.Count() > 1 || HasPassword(manager);
    return accounts;
}

public void RemoveLogin(string loginProvider, string providerKey)
{
    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
    var result = manager.RemoveLogin(User.Identity.GetUserId<int>(), 
        new UserLoginInfo(loginProvider, providerKey));
    string msg = String.Empty;
    if (result.Succeeded)
    {
        var user = manager.FindById(User.Identity.GetUserId<int>());
        IdentityHelper.SignIn(manager, user, isPersistent: false);
        msg = "?m=RemoveLoginSuccess";
    }
    Response.Redirect("~/Account/Manage" + msg);
}