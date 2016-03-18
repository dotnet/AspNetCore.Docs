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

        public IActionResult Register2()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register2(RegisterViewModel2 model)
        {
            if (ModelState.IsValid)
            {
                _message = "HttpPost Register success";
                return RedirectToAction("Index");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult Format()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Format(MyNumber model)
        {
            return View(model);
        }
        public IActionResult Index()
        {
            ViewData["Message"] = _message;
            return View();
        }

        public IActionResult RegisterTA()
        {
            return View();
        }

    }
}
