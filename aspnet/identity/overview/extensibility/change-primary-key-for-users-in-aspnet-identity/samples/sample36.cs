public partial class VerifyPhoneNumber : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var phonenumber = Request.QueryString["PhoneNumber"];
        var code = manager.GenerateChangePhoneNumberToken(
            User.Identity.GetUserId<int>(), phonenumber);           
        PhoneNumber.Value = phonenumber;
    }

    protected void Code_Click(object sender, EventArgs e)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid code");
            return;
        }

        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

        var result = manager.ChangePhoneNumber(
            User.Identity.GetUserId<int>(), PhoneNumber.Value, Code.Text);

        if (result.Succeeded)
        {
            var user = manager.FindById(User.Identity.GetUserId<int>());

            if (user != null)
            {
                IdentityHelper.SignIn(manager, user, false);
                Response.Redirect("/Account/Manage?m=AddPhoneNumberSuccess");
            }
        }

        // If we got this far, something failed, redisplay form
        ModelState.AddModelError("", "Failed to verify phone");
    }
}