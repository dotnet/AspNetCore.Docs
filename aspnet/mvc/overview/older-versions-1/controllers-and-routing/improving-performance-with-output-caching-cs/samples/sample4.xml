using System.Web.Mvc;
using System.Web.UI;

namespace MvcApplication1.Controllers
{
    public class UserController : Controller
    {
        [OutputCache(Duration=3600, VaryByParam="none", Location=OutputCacheLocation.Client, NoStore=true)]
        public string GetName()
        {
            return "Hi " + User.Identity.Name;
        }
    }
}