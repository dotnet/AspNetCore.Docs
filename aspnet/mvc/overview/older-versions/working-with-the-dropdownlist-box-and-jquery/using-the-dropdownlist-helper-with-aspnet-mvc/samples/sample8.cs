private MultiSelectList GetCountries(string[] selectedValues) {

    List<Country> Countries = new List<Country>()

        {

            new Country() { ID = 1, Name= "United States" },

            new Country() { ID = 2, Name= "Canada" },

            new Country() { ID = 3, Name= "UK" },

            new Country() { ID = 4, Name= "China" },

            new Country() { ID = 5, Name= "Japan" }

        };

    return new MultiSelectList(Countries, "ID", "Name", selectedValues);

}

public ActionResult MultiSelectCountry() {

    ViewBag.Countrieslist = GetCountries(null);

    return View();

}