using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ValidationSample.Services;

namespace ValidationSample.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult CheckEmail() =>
            View();

        #region snippet_VerifyEmail
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {
            if (!_userService.VerifyEmail(email))
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
        }
        #endregion

        public IActionResult CheckName() =>
            View();

        #region snippet_VerifyName
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyName(string firstName, string lastName)
        {
            if (!_userService.VerifyName(firstName, lastName))
            {
                return Json($"A user named {firstName} {lastName} already exists.");
            }

            return Json(true);
        }
        #endregion

        public IActionResult CheckPhone() =>
            View();

        #region snippet_VerifyPhone
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(
            [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")] string phone)
        {
            if (!ModelState.IsValid)
            {
                return Json($"Phone {phone} has an invalid format. Format: ###-###-####");
            }

            return Json(true);
        }
        #endregion

        public IActionResult CheckAge() =>
            View();

        #region snippet_CheckAgeSignature
        [HttpPost]
        public IActionResult CheckAge([BindRequired, FromQuery] int age)
        {
        #endregion
            if (!ModelState.IsValid)
            {
                ViewData["ValidationResult"] = "Validation failed.";
                ViewData["ValidationResultColor"] = "red";
            }
            else
            {
                ViewData["ValidationResult"] = "Validation successful.";
                ViewData["ValidationResultColor"] = "green";
            }

            return View();
        }
    }
}
