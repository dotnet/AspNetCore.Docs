using Microsoft.AspNetCore.Mvc;

namespace TagHelpersBuiltIn.Controllers
{
    public class BuiltInTagController : Controller
    {
        public IActionResult Index() => View();

        #region snippet_AnchorTagHelperAction
        public IActionResult Detail(int id)
        {
            var speaker = new Speaker
            {
                SpeakerId = id
            };

            return View(speaker);
        }
        #endregion
    }
}
