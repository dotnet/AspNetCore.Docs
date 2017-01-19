//
// GET: /Store/Browse?genre=Disco

public ActionResult Browse(string genre)
{
    var genreModel = new Genre()
    {
        Name = genre
    };

    var albums = new List<Album>()
    {
        new Album() { Title = genre + " Album 1" },
        new Album() { Title = genre + " Album 2" }
    };

    var viewModel = new StoreBrowseViewModel()
    {
        Genre = genreModel,
        Albums = albums
    };

    return this.View(viewModel);
}