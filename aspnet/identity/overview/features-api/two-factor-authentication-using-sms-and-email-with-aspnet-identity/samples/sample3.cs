// GET: /Account/Index
public async Task<ActionResult> Index(ManageMessageId? message)
{
    ViewBag.StatusMessage =
        message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
        : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
        : message == ManageMessageId.SetTwoFactorSuccess ? "Your two factor provider has been set."
        : message == ManageMessageId.Error ? "An error has occurred."
        : message == ManageMessageId.AddPhoneSuccess ? "The phone number was added."
        : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
        : "";

    var model = new IndexViewModel
    {
        HasPassword = HasPassword(),
        PhoneNumber = await UserManager.GetPhoneNumberAsync(User.Identity.GetUserId()),
        TwoFactor = await UserManager.GetTwoFactorEnabledAsync(User.Identity.GetUserId()),
        Logins = await UserManager.GetLoginsAsync(User.Identity.GetUserId()),
        BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(User.Identity.GetUserId())
    };
    return View(model);
}