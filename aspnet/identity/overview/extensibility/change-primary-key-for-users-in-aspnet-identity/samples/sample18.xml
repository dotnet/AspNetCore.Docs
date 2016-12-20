public async Task<ActionResult> EnableTwoFactorAuthentication()
{
    await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId<int>(), true);
    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
    if (user != null)
    {
        await SignInAsync(user, isPersistent: false);
    }
    return RedirectToAction("Index", "Manage");
}