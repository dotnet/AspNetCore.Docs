public ActionResult Index()
{
    // Create a list of genres
    var genres = new List<string> {"Rock", "Jazz", "Country", "Pop", "Disco"};

    // Create our view model
    var viewModel = new StoreIndexViewModel { 
        NumberOfGenres = genres.Count(),
        Genres = genres
    };

    return this.View(viewModel);
}