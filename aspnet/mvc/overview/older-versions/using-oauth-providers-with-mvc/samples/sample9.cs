return View("ExternalLoginConfirmation", new RegisterExternalLoginModel
{
    UserName = result.UserName,
    ExternalLoginData = loginData,
    FullName = result.ExtraData["name"],
    Link = result.ExtraData["link"]
});