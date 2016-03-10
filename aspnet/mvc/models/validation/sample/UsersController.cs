using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace MVCMovie.Controllers
{
    [Route("[controller]/[action]")]
    public class UsersController : Controller
    {       
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string email)
        {
            RegEx reg = new Regex("[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}");
            Match match = reg.Match(text);
            if (match.Success)
            {
                return true; 
            }
            return Json(data: string.Format("Invalid email format: {0}", email));            
        }
    }
}
