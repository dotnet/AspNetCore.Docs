[AllowAnonymous]
public ActionResult ExternalLoginCallback(string returnUrl)
{
    AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(
        Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
    if (!result.IsSuccessful)
    {
        return RedirectToAction("ExternalLoginFailure");
    }

    if (result.ExtraData.Keys.Contains("accesstoken"))
    {
        Session["facebooktoken"] = result.ExtraData["accesstoken"];
    }

    if (OAuthWebSecurity.Login(
        result.Provider, 
        result.ProviderUserId, 
        createPersistentCookie: false))
    {
        return RedirectToLocal(returnUrl);
    }

    if (User.Identity.IsAuthenticated)
    {
        // If the current user is logged in add the new account
        OAuthWebSecurity.CreateOrUpdateAccount(
            result.Provider,
            result.ProviderUserId, 
            User.Identity.Name);
        return RedirectToLocal(returnUrl);
    }
    else
    {
        // User is new, ask for their desired membership name
        string loginData = OAuthWebSecurity.SerializeProviderUserId(
            result.Provider, 
            result.ProviderUserId);
        ViewBag.ProviderDisplayName =
            OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
        ViewBag.ReturnUrl = returnUrl;
        return View("ExternalLoginConfirmation", new RegisterExternalLoginModel
        {
            UserName = result.UserName,
            ExternalLoginData = loginData,
            FullName = result.ExtraData["name"],
            Link = result.ExtraData["link"]
        });    
    }
}