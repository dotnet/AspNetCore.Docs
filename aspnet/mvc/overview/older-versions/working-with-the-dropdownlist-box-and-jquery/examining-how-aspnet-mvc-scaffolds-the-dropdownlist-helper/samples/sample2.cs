public ViewResult Index()
{

    var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist)

        .OrderBy(a => a.Price);

    return View(albums.ToList());

}