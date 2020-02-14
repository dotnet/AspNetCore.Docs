using Microsoft.AspNetCore.Mvc;


namespace RoutingSample.Controllers
{
#if NEVER
    #region snippet
    public class MyDemo2Controller : Controller
        {
        [Route("/articles/{page}")]
        public IActionResult ListArticles(int page)
        {
            return Content($"MyDemo2Controller.ListArticles {page}");
        }
    }
    #endregion
#endif
    #region snippet2
    public class MyDemo3Controller : Controller
    {
        [Route("/articles/{id}")]
        public IActionResult ListArticles(int id) =>
            ControllerContext.ToActionResult(id);
    }
    #endregion
}

