using Microsoft.AspNet.Mvc;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository userRepo;
        public UsersController()
        {
            this.userRepo = new UserRepository();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string email)
        {
            if (!this.userRepo.VerifyEmail())
            {
                return Json(data: $"Email {email} is already in use.");
            }

            return Json(data: true);
        }
    }
}
