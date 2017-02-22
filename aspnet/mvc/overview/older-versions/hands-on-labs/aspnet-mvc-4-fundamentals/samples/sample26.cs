public ActionResult Index()
{
    // Create list of genres
    var genres = new List<string> { "Rock", "Jazz", "Country", "Pop", "Disco" };

    // Create your view model
    var viewModel = new StoreIndexViewModel
    {
        NumberOfGenres = genres.Count,
        Genres = genres
    };

    ViewBag.Starred = new List<string> { "Rock", "Jazz" };

    return this.View(viewModel);
}