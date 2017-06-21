private async Task<string> SendEmailConfirmationTokenAsync(string userID, string subject)
{
   string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);
   var callbackUrl = Url.Action("ConfirmEmail", "Account",
      new { userId = userID, code = code }, protocol: Request.Url.Scheme);
   await UserManager.SendEmailAsync(userID, subject,
      "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

   return callbackUrl;
}