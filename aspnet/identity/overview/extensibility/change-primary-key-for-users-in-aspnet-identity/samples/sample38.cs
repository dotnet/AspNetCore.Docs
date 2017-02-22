public partial class ManagePassword : System.Web.UI.Page
{
    protected string SuccessMessage
    {
        get;
        private set;
    }

    private bool HasPassword(ApplicationUserManager manager)
    {
        return manager.HasPassword(User.Identity.GetUserId<int>());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

        if (!IsPostBack)
        {
            // Determine the sections to render
            if (HasPassword(manager))
            {
                changePasswordHolder.Visible = true;
            }
            else
            {
                setPassword.Visible = true;
                changePasswordHolder.Visible = false;
            }

            // Render success message
            var message = Request.QueryString["m"];
            if (message != null)
            {
                // Strip the query string from action
                Form.Action = ResolveUrl("~/Account/Manage");
            }
        }
    }

    protected void ChangePassword_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            IdentityResult result = manager.ChangePassword(
                User.Identity.GetUserId<int>(), CurrentPassword.Text, NewPassword.Text);
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
            IdentityResult result = manager.AddPassword(
                User.Identity.GetUserId<int>(), password.Text);
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

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error);
        }
    }
}