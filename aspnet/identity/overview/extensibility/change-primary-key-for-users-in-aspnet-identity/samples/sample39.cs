public partial class ManageLogins : System.Web.UI.Page
{
    protected string SuccessMessage
    {
        get;
        private set;
    }
    protected bool CanRemoveExternalLogins
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
        CanRemoveExternalLogins = manager.GetLogins(
            User.Identity.GetUserId<int>()).Count() > 1;

        SuccessMessage = String.Empty;
        successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
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
        var result = manager.RemoveLogin(
            User.Identity.GetUserId<int>(), new UserLoginInfo(loginProvider, providerKey));
        string msg = String.Empty;
        if (result.Succeeded)
        {
            var user = manager.FindById(User.Identity.GetUserId<int>());
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            msg = "?m=RemoveLoginSuccess";
        }
        Response.Redirect("~/Account/ManageLogins" + msg);
    }
}