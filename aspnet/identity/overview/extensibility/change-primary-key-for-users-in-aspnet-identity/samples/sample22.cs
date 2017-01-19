public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
{
    var code = await UserManager.GenerateChangePhoneNumberTokenAsync(
        User.Identity.GetUserId<int>(), phoneNumber);
    // Send an SMS through the SMS provider to verify the phone number
    return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }
    var result = await UserManager.ChangePhoneNumberAsync(
        User.Identity.GetUserId<int>(), model.PhoneNumber, model.Code);
    if (result.Succeeded)
    {
        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
        if (user != null)
        {
            await SignInAsync(user, isPersistent: false);
        }
        return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
    }
    // If we got this far, something failed, redisplay form
    ModelState.AddModelError("", "Failed to verify phone");
    return View(model);
}