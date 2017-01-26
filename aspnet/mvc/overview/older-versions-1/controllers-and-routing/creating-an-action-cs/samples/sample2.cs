using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class WorkController : Controller
    {
        [NonAction]
        public string CompanySecrets()
        {
            return "This information is secret.";
        }
    }
}