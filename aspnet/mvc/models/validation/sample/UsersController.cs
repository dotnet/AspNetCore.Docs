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
                return Json(data: string.Format("Email {0} is already in use.", email));
            }

            return Json(data: true);
        }
    }
}
