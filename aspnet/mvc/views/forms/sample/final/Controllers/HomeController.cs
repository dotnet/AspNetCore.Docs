using FormsTagHelper.ViewModels;
using Microsoft.AspNet.Mvc;

namespace FormsTH
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new CountryViewModel();
            model.Country = "CA";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                string message = model.Country +  " selected";
                return RedirectToAction("IndexSuccess", new {id=message});
            }

            // If we got this far, something failed, redisplay form.
            return View(model);
        }

        public IActionResult IndexMS()
        {
            var model = new CountryViewModelIEnumerable();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexMS(CountryViewModelIEnumerable model)
        {
            if (ModelState.IsValid)
            {
                string strCountriesSelected="";
                foreach (string s in model.CountryCodes)
                {
                    strCountriesSelected = strCountriesSelected + " " + s;
                }
                return RedirectToAction("IndexSuccess", new { id = strCountriesSelected });
            }

            // If we got this far, something failed, redisplay form.
            return View(model);
        }

        public IActionResult IndexGroup()
        {
            var model = new CountryViewModelGroup();
           // model.Country = "FR";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexGroup(CountryViewModelGroup model)
        {
            if (ModelState.IsValid)
            {
                string message = model.Country + " selected";
                return RedirectToAction("IndexSuccess", new {id=message});
            }

            // If we got this far, something failed, redisplay form.
            return View(model);
        }

        public IActionResult IndexEnum()
        {
            var model = new CountryEnumViewModel();
            model.EnumCountry = CountryEnum.Spain;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexEnum(CountryEnumViewModel model)
        {
            if (ModelState.IsValid)
            {
                string message = model.EnumCountry + " selected";
                return RedirectToAction("IndexSuccess", new {id=message});
            }

            // If we got this far, something failed, redisplay form.
            return View(model);
        }
        public IActionResult IndexSuccess(string ID)
        {
            ViewData["Message"] = ID;
            return View();
        }
    }
}
