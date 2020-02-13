using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting.Controllers
{
    // requires   webBuilder.UseStartup<Startup>();
    #region snippet
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }

        public IActionResult Index()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }
    }
    #endregion
}