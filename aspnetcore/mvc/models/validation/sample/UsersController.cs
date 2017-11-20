using Microsoft.AspNetCore.Mvc;

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

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string email)
        {
            if (!_userRepository.VerifyEmail(email))
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyName(string firstName, string lastName)
        {
            if (!_userRepository.VerifyName(firstName, lastName))
            {
                return Json(data: $"A user named {firstName} {lastName} already exists.");
            }

            return Json(data: true);
        }
    }
}
