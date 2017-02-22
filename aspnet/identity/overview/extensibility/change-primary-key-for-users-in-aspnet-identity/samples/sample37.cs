public partial class AddPhoneNumber : System.Web.UI.Page
{
    protected void PhoneNumber_Click(object sender, EventArgs e)
    {
        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var code = manager.GenerateChangePhoneNumberToken(
            User.Identity.GetUserId<int>(), PhoneNumber.Text);
        if (manager.SmsService != null)
        {
            var message = new IdentityMessage
            {
                Destination = PhoneNumber.Text,
                Body = "Your security code is " + code
            };

            manager.SmsService.Send(message);
        }

        Response.Redirect("/Account/VerifyPhoneNumber?PhoneNumber=" + HttpUtility.UrlEncode(PhoneNumber.Text));
    }
}