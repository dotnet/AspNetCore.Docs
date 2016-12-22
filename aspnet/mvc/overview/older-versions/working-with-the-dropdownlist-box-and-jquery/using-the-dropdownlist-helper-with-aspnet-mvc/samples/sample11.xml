[HttpPost]

public ActionResult MultiSelectCountry(FormCollection form) {

    ViewBag.YouSelected = form["Countries"];

    string selectedValues = form["Countries"];

    ViewBag.Countrieslist = GetCountries(selectedValues.Split(','));

    return View();

}