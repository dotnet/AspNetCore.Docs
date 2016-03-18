using FormsTH.ViewModels;
using Microsoft.AspNet.Mvc;

namespace FormsTH.Controllers
{
    // This controller is used only to demonstrate working with forms.
    public class DemoRegController : Controller
    {
        static string _message;
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _message = "HttpPost Register success";
                return RedirectToAction("Index");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult Index()
        {
            ViewData["Message"] = _message;
            return View();
        }
    }
}
