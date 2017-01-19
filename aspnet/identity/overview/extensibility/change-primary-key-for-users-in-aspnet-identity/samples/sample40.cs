public partial class TwoFactorAuthenticationSignIn : System.Web.UI.Page
{
    private ApplicationSignInManager signinManager;
    private ApplicationUserManager manager;

    public TwoFactorAuthenticationSignIn()
    {
        manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var userId = signinManager.GetVerifiedUserId<ApplicationUser, int>();
        if (userId == default(int))
        {
            Response.Redirect("/Account/Error", true);
        }
        var userFactors = manager.GetValidTwoFactorProviders(userId);
        Providers.DataSource = userFactors.Select(x => x).ToList();
        Providers.DataBind();            
    }

    protected void CodeSubmit_Click(object sender, EventArgs e)
    {
        bool rememberMe = false;
        bool.TryParse(Request.QueryString["RememberMe"], out rememberMe);
            
        var result = signinManager.TwoFactorSignIn<ApplicationUser, int>(SelectedProvider.Value, Code.Text, isPersistent: rememberMe, rememberBrowser: RememberBrowser.Checked);
        switch (result)
        {
            case SignInStatus.Success:
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                break;
            case SignInStatus.LockedOut:
                Response.Redirect("/Account/Lockout");
                break;
            case SignInStatus.Failure:
            default:
                FailureText.Text = "Invalid code";
                ErrorMessage.Visible = true;
                break;
        }
    }

    protected void ProviderSubmit_Click(object sender, EventArgs e)
    {
        if (!signinManager.SendTwoFactorCode(Providers.SelectedValue))
        {
            Response.Redirect("/Account/Error");
        }

        var user = manager.FindById(signinManager.GetVerifiedUserId<ApplicationUser, int>());
        if (user != null)
        {
            var code = manager.GenerateTwoFactorToken(user.Id, Providers.SelectedValue);
        }

        SelectedProvider.Value = Providers.SelectedValue;
        sendcode.Visible = false;
        verifycode.Visible = true;
    }
}