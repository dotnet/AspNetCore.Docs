using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    [Route("[controller]/[action]")]
    public class UsersController : Controller
    {       
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string email)
        {
            return Json(data: string.Format("/UsersController/VerifyEmail {0}.", email));
        }
    }
}
