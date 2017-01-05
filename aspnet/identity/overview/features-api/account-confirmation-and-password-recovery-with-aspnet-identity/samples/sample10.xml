public async Task<ActionResult> ConfirmEmail(string userId, string code)
{
    if (userId == null || code == null)
    {
        return View("Error");
    }
    var result = await UserManager.ConfirmEmailAsync(userId, code);
    if (result.Succeeded)
    {
        return View("ConfirmEmail");
    }
    AddErrors(result);
    return View();
}