public async Task<ActionResult> ManageLogins(ManageMessageId? message)
{
    ViewBag.StatusMessage =
        message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
        : message == ManageMessageId.Error ? "An error has occurred."
        : "";
    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
    if (user == null)
    {
        return View("Error");
    }
    var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId<int>());
    var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
    ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
    return View(new ManageLoginsViewModel
    {
        CurrentLogins = userLogins,
        OtherLogins = otherLogins
    });
}