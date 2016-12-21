//
// POST: /Account/Login
[HttpPost]
[AllowAnonymous]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
{
   if (!ModelState.IsValid)
   {
      return View(model);
   }

   // Require the user to have a confirmed email before they can log on.
  // var user = await UserManager.FindByNameAsync(model.Email);
   var user =  UserManager.Find(model.Email, model.Password);
   if (user != null)
   {
      if (!await UserManager.IsEmailConfirmedAsync(user.Id))
      {
         string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account-Resend");

          // Uncomment to debug locally  
          // ViewBag.Link = callbackUrl;
         ViewBag.errorMessage = "You must have a confirmed email to log on. "
                              + "The confirmation token has been resent to your email account.";
         return View("Error");
      }
   }

   // This doesn't count login failures towards account lockout
   // To enable password failures to trigger account lockout, change to shouldLockout: true
   var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
   switch (result)
   {
      case SignInStatus.Success:
         return RedirectToLocal(returnUrl);
      case SignInStatus.LockedOut:
         return View("Lockout");
      case SignInStatus.RequiresVerification:
         return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
      case SignInStatus.Failure:
      default:
         ModelState.AddModelError("", "Invalid login attempt.");
         return View(model);
   }
}