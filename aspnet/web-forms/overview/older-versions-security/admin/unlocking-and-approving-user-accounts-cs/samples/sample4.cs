protected void NewUserWizard_SendingMail(object sender, MailMessageEventArgs e)
{
     // Get the UserId of the just-added user
     MembershipUser newUser = Membership.GetUser(NewUserWizard.UserName);

     Guid newUserId = (Guid)newUser.ProviderUserKey;

     // Determine the full verification URL (i.e., http://yoursite.com/Verification.aspx?ID=...)
     string urlBase = Request.Url.GetLeftPart(UriPartial.Authority) + 
          Request.ApplicationPath;

     string verifyUrl = "/Verification.aspx?ID=" + newUserId.ToString();
     string fullUrl = urlBase + verifyUrl;

     // Replace <%VerificationUrl%> with the appropriate URL and querystring
     e.Message.Body = e.Message.Body.Replace("<%VerificationUrl%>", fullUrl);
}