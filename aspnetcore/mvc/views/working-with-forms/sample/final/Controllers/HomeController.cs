using FormsTagHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FormsTagHelper.Controllers
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
                var msg = model.Country + " selected";
                return RedirectToAction("IndexSuccess", new { message = msg });
            }

            // If we got this far, something failed; redisplay form.
            return View(model);
        }

        public IActionResult IndexMultiSelect()
        {
            var model = new CountryViewModelIEnumerable();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexMultiSelect(CountryViewModelIEnumerable model)
        {
            if (ModelState.IsValid)
            {
                string strCountriesSelected = "";
                foreach (string s in model.CountryCodes)
                {
                    strCountriesSelected = strCountriesSelected + " " + s;
                }
                return RedirectToAction("IndexSuccess", new { message = strCountriesSelected });
            }

            return View(model);
        }

        public IActionResult IndexGroup()
        {
            var model = new CountryViewModelGroup();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexGroup(CountryViewModelGroup model)
        {
            if (ModelState.IsValid)
            {
                var msg = model.Country + " selected";
                return RedirectToAction("IndexSuccess", new { message = msg });
            }

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
                var msg = model.EnumCountry + " selected";
                return RedirectToAction("IndexSuccess", new { message = msg });
            }

            return View(model);
        }

        public IActionResult IndexEmpty(int id)
        {
            var ViewPage = (id != 0) ? "IndexEmptyTemplate" : "IndexEmpty";

            return View(ViewPage, new CountryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexEmpty(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var msg = !System.String.IsNullOrEmpty(model.Country) ? model.Country
                    : "No selection";
                msg += " Selected";
                return RedirectToAction("IndexSuccess", new { message = msg });
            }

            return View(model);
        }

        public IActionResult IndexOption(int id)
        {
            var model = new CountryViewModel();
            model.Country = "CA";
            return View(model);
        }

        public IActionResult MyModel()
        {
            return View();
        }

        public IActionResult IndexSuccess(string message)
        {
            ViewData["Message"] = message;
            return View();
        }
        #region snippetNone
        public IActionResult IndexNone()
        {
            var model = new CountryViewModel();
            model.Countries.Insert(0, new SelectListItem("<none>", ""));
            return View(model);
        }
        # endregion
    }
}
