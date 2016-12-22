using System.Web.Mvc;
using System.Web.UI;

namespace MvcApplication1.Controllers
{
    public class BadUserController : Controller
    {
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public string GetName()
        {
            return "Hi " + User.Identity.Name;
        }
    }
}