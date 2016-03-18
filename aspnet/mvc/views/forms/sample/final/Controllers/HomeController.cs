using Microsoft.AspNet.Mvc;
using FormsTH.ViewModels;

namespace FormsTH
{
    public class HomeController : Controller
    {
        static string _message;

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
                _message = model.Country +  " selected";
                return RedirectToAction("IndexSuccess");
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
                    strCountriesSelected = strCountriesSelected + " " + s;
                _message = strCountriesSelected;

                return RedirectToAction("IndexSuccess");
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
                _message = model.Country + " selected";
                return RedirectToAction("IndexSuccess");
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
                _message = model.EnumCountry + " selected";
                return RedirectToAction("IndexSuccess");
            }

            // If we got this far, something failed, redisplay form.
            return View(model);
        }
        public IActionResult IndexSuccess()
        {
            ViewData["Message"] = _message;
            return View();
        }
    }
}
