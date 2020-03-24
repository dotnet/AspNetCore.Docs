#define First
using Microsoft.AspNetCore.Mvc;


namespace RoutingSample.Controllers
{
#if First
    #region snippet
    public class MyDemo2Controller : Controller
        {
        [Route("/articles/{page}")]
        public IActionResult ListArticles(int page)
        {
            return ControllerContext.MyDisplayRouteInfo(page);
        }
    }
    #endregion
#endif

}

