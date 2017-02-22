public enum eMovieCategories { Action, Drama, Comedy, Science_Fiction };

private void SetViewBagMovieType(eMovieCategories selectedMovie) {

    IEnumerable<eMovieCategories> values = 

                      Enum.GetValues(typeof(eMovieCategories))

                      .Cast<eMovieCategories>();

    IEnumerable<SelectListItem> items =

        from value in values

        select new SelectListItem

        {

            Text = value.ToString(),

            Value = value.ToString(),

            Selected = value == selectedMovie,

        };

    ViewBag.MovieType = items;

}

public ActionResult SelectCategoryEnum() {

    SetViewBagMovieType(eMovieCategories.Drama);

    return View("SelectCategory");

}