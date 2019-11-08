using Microsoft.AspNetCore.Mvc;

namespace AppPartsSample
{
    #region snippet
    [GenericControllerNameConvention]
    public class GenericController<T> : Controller
    {
        public IActionResult Index()
        {
            return Content($"Hello from a generic {typeof(T).Name} controller.");
        }
    }
    #endregion
}
