using Microsoft.AspNet.Mvc;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
public class UsersController : Controller
{   
[AcceptVerbs("Get", "Post")]
    public IActionResult VerifyEmail(string email)
    {
        User user = new User();

        if (!user.VerifyEmail()) {           
                return Json(data: string.Format("Email {0} is already in use.", email));
        }

        user.Save();
        return Json(new { success = true });

    }
}
}
