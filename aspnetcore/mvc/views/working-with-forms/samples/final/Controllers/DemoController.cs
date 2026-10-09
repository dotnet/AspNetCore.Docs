using FormsTagHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FormsTagHelper.Controllers
{
    // This controller is used only to demonstrate working with forms.

    public class DemoController : Controller
    {       
        public IActionResult Index(string id)
        {
            ViewData["Message"] = id;
            return View();
        }

        public IActionResult RegisterTextArea()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterTextArea(DescriptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = "HttpPost Register success " + model.Description;
                return RedirectToAction("Index", new { id = success });
            }

            return View(model);
        }

        public IActionResult RegisterFormOnly()
        {
            return View();
        }

        public IActionResult RegisterInput()
        {
            return View();
        }

        public IActionResult RegisterAddress()
        {
            return View();
        }

        public IActionResult RegisterValidation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterValidation(ViewModels.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = "HttpPost Register success " + model.Email;
                return RedirectToAction("Index", new { id = success });
            }

            return View(model);
        }

        public IActionResult RegisterLabel()
        {
            return View();
        }
    }
}
