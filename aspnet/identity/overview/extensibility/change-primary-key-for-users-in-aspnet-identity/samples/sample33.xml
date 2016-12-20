public partial class Manage : System.Web.UI.Page
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

    public bool HasPhoneNumber { get; private set; }

    public bool TwoFactorEnabled { get; private set; }

    public bool TwoFactorBrowserRemembered { get; private set; }

    public int LoginsCount { get; set; }

    protected void Page_Load()
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

        HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(
            User.Identity.GetUserId<int>()));

        // Enable this after setting up two-factor authentientication
        //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

        TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId<int>());

        LoginsCount = manager.GetLogins(User.Identity.GetUserId<int>()).Count;

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

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error);
        }
    }

    // Remove phonenumber from user
    protected void RemovePhone_Click(object sender, EventArgs e)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var result = manager.SetPhoneNumber(User.Identity.GetUserId<int>(), null);
        if (!result.Succeeded)
        {
            return;
        }
        var user = manager.FindById(User.Identity.GetUserId<int>());
        if (user != null)
        {
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
        }
    }

    // DisableTwoFactorAuthentication
    protected void TwoFactorDisable_Click(object sender, EventArgs e)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        manager.SetTwoFactorEnabled(User.Identity.GetUserId<int>(), false);

        Response.Redirect("/Account/Manage");
    }

    //EnableTwoFactorAuthentication 
    protected void TwoFactorEnable_Click(object sender, EventArgs e)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        manager.SetTwoFactorEnabled(User.Identity.GetUserId<int>(), true);

        Response.Redirect("/Account/Manage");
    }
}