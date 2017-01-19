public async Task<ActionResult> SendCode(string returnUrl)
{
    var userId = await SignInManager.GetVerifiedUserIdAsync();
    if (userId == null)
    {
        return View("Error");
    }
    var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
    var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
    return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl });
}