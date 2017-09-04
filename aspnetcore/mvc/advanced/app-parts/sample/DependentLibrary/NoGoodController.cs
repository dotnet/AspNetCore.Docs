using Microsoft.AspNetCore.Mvc;

namespace DependentLibrary
{
    /// <summary>
    /// Since the MVC project references this project, this controller 
    /// ordinarily is discovered and available.
    /// </summary>
    public class NoGoodController : Controller
    {
        public IActionResult Index()
        {
            return Ok("We don't want to load this controller.");
        }

    }
}
