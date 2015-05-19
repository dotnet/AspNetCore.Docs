using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        public ManageController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        public SignInManager<ApplicationUser> SignInManager { get; private set; }

        //
        // GET: /Account/Index
        [HttpGet]
        public async Task<IActionResult> Index(ManageMessageId? message = null)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var user = await GetCurrentUserAsync();
            var model = new IndexViewModel
            {
                HasPassword = await UserManager.HasPasswordAsync(user),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(user),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(user),
                Logins = await UserManager.GetLoginsAsync(user),
                BrowserRemembered = await SignInManager.IsTwoFactorClientRememberedAsync(user)
            };
            return View(model);
        }

        //
        // GET: /Account/RemoveLogin
        [HttpGet]
        public async Task<IActionResult> RemoveLogin()
        {
            var user = await GetCurrentUserAsync();
            var linkedAccounts = await UserManager.GetLoginsAsync(user);
            ViewBag.ShowRemoveButton = await UserManager.HasPasswordAsync(user) || linkedAccounts.Count > 1;
            return View(linkedAccounts);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message = ManageMessageId.Error;
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await UserManager.RemoveLoginAsync(user, loginProvider, providerKey);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    message = ManageMessageId.RemoveLoginSuccess;
                }
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Account/AddPhoneNumber
        public IActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Account/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var user = await GetCurrentUserAsync();
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(user, model.Number);
            await MessageServices.SendSmsAsync(model.Number, "Your security code is: " + code);
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnableTwoFactorAuthentication()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                await UserManager.SetTwoFactorEnabledAsync(user, true);
                await SignInManager.SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableTwoFactorAuthentication()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                await UserManager.SetTwoFactorEnabledAsync(user, false);
                await SignInManager.SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Account/VerifyPhoneNumber
        [HttpGet]
        public async Task<IActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(await GetCurrentUserAsync(), phoneNumber);
            // Send an SMS to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Account/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await UserManager.ChangePhoneNumberAsync(user, model.PhoneNumber, model.Code);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
                }
            }
            // If we got this far, something failed, redisplay the form
            ModelState.AddModelError(string.Empty, "Failed to verify phone number");
            return View(model);
        }

        //
        // GET: /Account/RemovePhoneNumber
        [HttpGet]
        public async Task<IActionResult> RemovePhoneNumber()
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await UserManager.SetPhoneNumberAsync(user, null);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
                }
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        }

        //
        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await UserManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        }

        //
        // GET: /Manage/SetPassword
        [HttpGet]
        public IActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await UserManager.AddPasswordAsync(user, model.NewPassword);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        }

        //GET: /Account/Manage
        [HttpGet]
        public async Task<IActionResult> ManageLogins(ManageMessageId? message = null)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.AddLoginSuccess ? "The external login was added."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(user);
            var otherLogins = SignInManager.GetExternalAuthenticationSchemes().Where(auth => userLogins.All(ul => auth.AuthenticationScheme != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            var redirectUrl = Url.Action("LinkLoginCallback", "Manage");
            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, User.GetUserId());
            return new ChallengeResult(provider, properties);
        }

        //
        // GET: /Manage/LinkLoginCallback
        [HttpGet]
        public async Task<ActionResult> LinkLoginCallback()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var info = await SignInManager.GetExternalLoginInfoAsync(User.GetUserId());
            if (info == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(user, info);
            var message = result.Succeeded ? ManageMessageId.AddLoginSuccess : ManageMessageId.Error;
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private async Task<bool> HasPhoneNumber()
        {
            var user = await UserManager.FindByIdAsync(User.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            AddLoginSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await UserManager.FindByIdAsync(Context.User.GetUserId());
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}
