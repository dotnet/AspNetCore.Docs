public async Task<ActionResult> LinkLoginCallback()
{
    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, 
        User.Identity.GetUserId());
    if (loginInfo == null)
    {
        return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
    }
    IdentityResult result = await UserManager.AddLoginAsync(
        User.Identity.GetUserId<int>(), loginInfo.Login);
    if (result.Succeeded)
    {
        return RedirectToAction("Manage");
    }
    return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
}