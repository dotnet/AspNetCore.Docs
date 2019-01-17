using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult CheckEmail()
        {
            return View();
        }

        #region snippet_VerifyEmail
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string email)
        {
            if (!_userRepository.VerifyEmail(email))
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
        }
        #endregion

        #region snippet_VerifyName
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyName(string firstName, string lastName)
        {
            if (!_userRepository.VerifyName(firstName, lastName))
            {
                return Json(data: $"A user named {firstName} {lastName} already exists.");
            }

            return Json(data: true);
        }
        #endregion

        public IActionResult CheckPhone()
        {
            return View();
        }

        #region snippet_VerifyPhone
        [AcceptVerbs("Get", "Post")]
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

        public IActionResult CheckAge()
        {
            return View();
        }

        #region snippet_CheckAge
        [HttpPost]
        public IActionResult CheckAge(
            [BindRequired, FromQuery] int age)
        {
        #endregion
            if (!ModelState.IsValid)
            {
                ViewData["ValidationResult"] = "Validation failed.";
                ViewData["ValidationResultColorStyle"] = "red";

                return View();
            }

            ViewData["ValidationResult"] = "Validation successful.";
            ViewData["ValidationResultColorStyle"] = "green";

            return View();
        }
    }
}
