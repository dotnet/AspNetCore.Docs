public async Task<ActionResult> LinkLoginCallback()
{
    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
    if (loginInfo == null)
    {
        return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
    }
    var result = await UserManager.AddLoginAsync(User.Identity.GetUserId<int>(), 
        loginInfo.Login);
    return result.Succeeded ? RedirectToAction("ManageLogins") : 
        RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
}