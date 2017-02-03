public ActionResult SelectCategoryEnumPost() {

    SetViewBagMovieType(eMovieCategories.Comedy);

    return View();

}

[HttpPost]

public ActionResult SelectCategoryEnumPost(eMovieCategories MovieType) {

    ViewBag.messageString = MovieType.ToString() +

                            " val = " + (int)MovieType;

    return View("Information");

}