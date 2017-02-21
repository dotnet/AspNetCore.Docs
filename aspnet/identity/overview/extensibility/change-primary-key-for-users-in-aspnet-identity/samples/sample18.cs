public ActionResult RemoveLogin()
{
    var linkedAccounts = UserManager.GetLogins((User.Identity.GetUserId<int>()));
    ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
    return View(linkedAccounts);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
{
    ManageMessageId? message;
    var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId<int>(), 
        new UserLoginInfo(loginProvider, providerKey));
    if (result.Succeeded)
    {
        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
        if (user != null)
        {
            await SignInAsync(user, isPersistent: false);
        }
        message = ManageMessageId.RemoveLoginSuccess;
    }
    else
    {
        message = ManageMessageId.Error;
    }
    return RedirectToAction("ManageLogins", new { Message = message });
}