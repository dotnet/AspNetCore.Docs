//
// GET: /StoreManager/
public ViewResult Index()
{
	var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);
	return View(albums.ToList());
}