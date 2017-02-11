public ActionResult Index()
{
    // Get most popular albums
    var albums = GetTopSellingAlbums(5);
 
    return View(albums);
 }